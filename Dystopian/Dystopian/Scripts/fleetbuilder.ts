class FleetViewModel {
    SelectedFaction = ko.observable<string>("");
    AvailableModels = ko.observableArray<Ship>();
    FleetList = ko.observableArray<Squadron>();
    TotalPoints = ko.computed(function () {       
        var total = 0;
        ko.utils.arrayForEach(this.FleetList(), function (squadron: Squadron) {
            if (squadron != null)
            {
                total += squadron.CurrentPoints();
            }           
        });
        return total;
    }, this);

    CurrentShip = ko.observable<any>({});

    CappedPoints = ko.observable<number>(1000);

    PercentageLarge = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(this.FleetList(), function (squadron: Squadron) {
            if (squadron != null && squadron.Size() == "L") {
                total += squadron.CurrentPoints();
            }
        });
        return ((total / this.CappedPoints()*100).toFixed(0));
    }, this);

    PercentageMedium = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(this.FleetList(), function (squadron: Squadron) {
            if (squadron != null && squadron.Size() == "M") {
                total += squadron.CurrentPoints();
            }
        });
        return ((total / this.CappedPoints() * 100).toFixed(0));
    }, this);

    PercentageSmall = ko.computed(function () {
        var total = 0;
        ko.utils.arrayForEach(this.FleetList(), function (squadron: Squadron) {
            if (squadron != null && squadron.Size() == "S") {
                total += squadron.CurrentPoints();
            }
        });
        return ((total / this.CappedPoints() * 100).toFixed(0));
    }, this);

    GetFactionModels = () => {      
        var url = `${$("body").data("root")}Home/GetFactionModels?faction=${this.SelectedFaction()}`;
        var getRequest = $.ajax({
            cache: false,
            url: url
        });

        getRequest.done((data: any) => {
            this.AvailableModels(data);
        });      
    }

    addToSelectedItems = (item: Ship) => {
        var ship = new Squadron(item);
        this.FleetList.push(ship);
        this.FleetList.sort(function (left, right) { return left.Size() == right.Size() ? 0 : (left.Size() < right.Size() ? -1 : 1) })
       
    };

    increaseSquadronSize = (squadron: Squadron) => {
        if (squadron.SquadronSize() + 1 <= squadron.MaxSquadronSize())
        {
            squadron.Ships()[squadron.SquadronSize()].Active(true);
        }
    };
    
    decreaseSquadronSize = (squadron: Squadron) => {
        if (squadron.SquadronSize() - 1 >= squadron.MinSquadronSize()) {
            squadron.Ships()[squadron.SquadronSize() - 1].Active(false);
        }
    };

    removeFromSelectedItems = (item: any) => {
        this.FleetList.remove(item);
    };

    showOptions = (item: Ship) =>
    {
        this.CurrentShip(item);
        $('#shipOptionsModal').modal('show');
    };

    constructor() {
        this.SelectedFaction.subscribe(newFaction => {
          this.GetFactionModels()
        });
    }

}

$(document).ready(() => {
    $(".select2").select2({
        allowClear: true
    });
    var observe = ko.observable(new FleetViewModel());
    ko.applyBindings(observe);  

    $(".select2").select2({
        allowClear: true
    });

    return observe;
});

class Squadron {
    Name: KnockoutObservable<string>;
    CurrentPoints: KnockoutComputed<number>;
    SquadronSize: KnockoutComputed<number>;
    MinSquadronSize = ko.observable<number>();
    MaxSquadronSize = ko.observable<number>();
    Ships = ko.observableArray<Ship>();
    Size: KnockoutObservable<string>;
    Url: KnockoutComputed<string>;

    constructor(ship: any) {
        if (ship != undefined) {
            this.Size = ko.observable(ship.Size);
            this.Name = ko.observable(ship.Name);
            this.MinSquadronSize = ko.observable(ship.MinSquadronSize);
            this.MaxSquadronSize = ko.observable(ship.MaxSquadronSize);
           
            for (var i = 0; i < this.MaxSquadronSize(); i++) {
                var addShip = new Ship(ship);

                if (i < this.MinSquadronSize()) {
                    addShip.Active(true);                 
                }
                this.Ships.push(addShip)

            
            };
        }

        this.CurrentPoints = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.Ships(), function (ship: any) {
                if (ship != null && ship.Active()) {
                    total += ship.CurrentPoints();
                }
            });
            return total;
        }, this);

        this.SquadronSize = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.Ships(), function (ship: any) {
                if (ship != null && ship.Active()) {
                  
                    total = total + 1;
                }
            });
            return total;
        }, this);
     
        this.Url = ko.computed(function () {
            var url = "/Content/Models/" + this.Name().toLowerCase() + ".png"
            return (url);
        }, this);
    }
}
class Ship {
    Id: KnockoutObservable<number>;
    Name: KnockoutObservable<string>;
    BasePoints: KnockoutObservable<number>;
    CurrentPoints: KnockoutComputed<number>;
    Size: KnockoutObservable<string>;
    Active: KnockoutObservable<boolean>;
    Options = ko.observableArray<MAROption>();

    constructor(ship: any)
    {
        this.Name = ko.observable(ship.Name);
        this.BasePoints = ko.observable(ship.BasePoints);
        this.Size = ko.observable(ship.Size);
        this.Active = ko.observable(ship.Active);

        if (ship.Options != null) {
            for (var i = 0; i < ship.Options.length; i++) {
                var shipOptions = new MAROption(ship.Options[i]);
                this.Options.push(shipOptions);
            };
        }

        this.CurrentPoints = ko.computed(function () {
           
            var total = this.BasePoints();
            ko.utils.arrayForEach(this.Options(), function (option: MAROption) {
                if (option != null && option.Active()) {
                   
                    total += option.Points();
                }
            });
            return total;
        }, this);
}

}
class MAROption {
    Name: KnockoutObservable<string>;
    Value: KnockoutObservable<string>;
    Points: KnockoutObservable<number>;
    OptionGroup: KnockoutObservable<number>;
    Active = ko.observable<boolean>(false);

    constructor(option: any) {
        this.Name = ko.observable(option.Name);
        this.Value = ko.observable(option.Value);
        this.Points = ko.observable(option.Points);
        this.OptionGroup = ko.observable(option.OptionGroup);
    }
}