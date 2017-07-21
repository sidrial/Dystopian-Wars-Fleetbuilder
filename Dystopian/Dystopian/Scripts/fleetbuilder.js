var FleetViewModel = (function () {
    function FleetViewModel() {
        var _this = this;
        this.SelectedFaction = ko.observable("");
        this.SelectedCore = ko.observable("");
        this.SelectedRules = ko.observable("");
        //TODO: Refactor zodat we Squadrons gebruiken ipv Ships.
        this.AvailableModels = ko.observableArray();
        this.FleetList = ko.observableArray();
        this.TotalPoints = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.FleetList(), function (squadron) {
                if (squadron != null) {
                    total += squadron.CurrentPoints();
                }
            });
            return total;
        }, this);
        this.CurrentShip = ko.observable({});
        this.CappedPoints = ko.observable(1000);
        this.PercentageLarge = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.FleetList(), function (squadron) {
                if (squadron != null && squadron.Size() == "L") {
                    total += squadron.CurrentPoints();
                }
            });
            return ((total / this.CappedPoints() * 100).toFixed(0));
        }, this);
        this.PercentageMedium = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.FleetList(), function (squadron) {
                if (squadron != null && squadron.Size() == "M") {
                    total += squadron.CurrentPoints();
                }
            });
            return ((total / this.CappedPoints() * 100).toFixed(0));
        }, this);
        this.PercentageSmall = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.FleetList(), function (squadron) {
                if (squadron != null && squadron.Size() == "S") {
                    total += squadron.CurrentPoints();
                }
            });
            return ((total / this.CappedPoints() * 100).toFixed(0));
        }, this);
        this.GetFactionModels = function () {
            var url = $("body").data("root") + "Home/GetFactionModels?faction=" + _this.SelectedFaction();
            var getRequest = $.ajax({
                cache: false,
                url: url
            });
            getRequest.done(function (data) {
                _this.AvailableModels(data);
            });
        };
        this.addToSelectedItems = function (item) {
            var ship = new Squadron(item);
            _this.FleetList.push(ship);
            _this.FleetList.sort(function (left, right) { return left.Size() == right.Size() ? 0 : (left.Size() < right.Size() ? -1 : 1); });
        };
        this.increaseSquadronSize = function (squadron) {
            if (squadron.SquadronSize() + 1 <= squadron.MaxSquadronSize()) {
                squadron.Ships()[squadron.SquadronSize()].Active(true);
            }
        };
        this.decreaseSquadronSize = function (squadron) {
            if (squadron.SquadronSize() - 1 >= squadron.MinSquadronSize()) {
                squadron.Ships()[squadron.SquadronSize() - 1].Active(false);
            }
        };
        this.removeFromSelectedItems = function (item) {
            _this.FleetList.remove(item);
        };
        this.showOptions = function (item) {
            _this.CurrentShip(item);
            $('#shipOptionsModal').modal('show');
        };
        this.SelectedFaction.subscribe(function (newFaction) {
            _this.GetFactionModels();
        });
    }
    return FleetViewModel;
}());
$(document).ready(function () {
    var observe = ko.observable(new FleetViewModel());
    ko.applyBindings(observe);
    $("#faction").select2({
        templateResult: formatFaction,
        templateSelection: formatFaction
    });
    $("#core").select2({
        templateResult: formatCore,
        templateSelection: formatCore
    });
    $("#rules").select2({});
    function formatFaction(faction) {
        if (!faction.id) {
            return faction.text;
        }
        var $faction = $('<span><img src="Content/Flags/' + faction.element.value.toLowerCase() + '.jpg" class="img-flag" /> ' + faction.text + '</span>');
        return $faction;
    }
    ;
    function formatCore(core) {
        if (!core.id) {
            return core.text;
        }
        var $core = $('<span><img src="Content/Core/' + core.element.value.toLowerCase() + '.png" class="img-core" /> ' + core.text + '</span>');
        return $core;
    }
    ;
    return observe;
});
var Squadron = (function () {
    function Squadron(ship) {
        this.MinSquadronSize = ko.observable();
        this.MaxSquadronSize = ko.observable();
        this.Ships = ko.observableArray();
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
                this.Ships.push(addShip);
            }
            ;
        }
        this.CurrentPoints = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.Ships(), function (ship) {
                if (ship != null && ship.Active()) {
                    total += ship.CurrentPoints();
                }
            });
            return total;
        }, this);
        this.SquadronSize = ko.computed(function () {
            var total = 0;
            ko.utils.arrayForEach(this.Ships(), function (ship) {
                if (ship != null && ship.Active()) {
                    total = total + 1;
                }
            });
            return total;
        }, this);
        this.Url = ko.computed(function () {
            var url = "/Content/Models/" + this.Name().toLowerCase() + ".png";
            return (url);
        }, this);
    }
    return Squadron;
}());
var Ship = (function () {
    function Ship(ship) {
        this.Options = ko.observableArray();
        this.Name = ko.observable(ship.Name);
        this.BasePoints = ko.observable(ship.BasePoints);
        this.Size = ko.observable(ship.Size);
        this.Active = ko.observable(ship.Active);
        if (ship.Options != null) {
            for (var i = 0; i < ship.Options.length; i++) {
                var shipOptions = new MAROption(ship.Options[i]);
                this.Options.push(shipOptions);
            }
            ;
        }
        this.CurrentPoints = ko.computed(function () {
            var total = this.BasePoints();
            ko.utils.arrayForEach(this.Options(), function (option) {
                if (option != null && option.Active()) {
                    total += option.Points();
                }
            });
            return total;
        }, this);
    }
    return Ship;
}());
var MAROption = (function () {
    function MAROption(option) {
        this.Active = ko.observable(false);
        this.Name = ko.observable(option.Name);
        this.Value = ko.observable(option.Value);
        this.Points = ko.observable(option.Points);
        this.OptionGroup = ko.observable(option.OptionGroup);
    }
    return MAROption;
}());
ko.bindingHandlers.bsChecked = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = valueAccessor();
        var newValueAccessor = function () {
            return {
                change: function () {
                    value(element.value);
                }
            };
        };
        ko.bindingHandlers.event.init(element, newValueAccessor, allBindingsAccessor, viewModel, bindingContext);
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        if ($(element).val() == ko.unwrap(valueAccessor())) {
            setTimeout(function () {
                $(element).closest('.btn').button('toggle');
            }, 1);
        }
    }
};
//# sourceMappingURL=fleetbuilder.js.map