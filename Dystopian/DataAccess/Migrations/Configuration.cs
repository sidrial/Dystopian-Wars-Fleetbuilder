using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.DystopianRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.DystopianRepository context)
        {
            var ships = new List<Ship>
            {
                new Ship
                {
                    Name = "Aristotle",
                    BasePoints = 185,
                    CurrentPoints = 185,
                    Size = "L",
                    Options = new List<Option>()
                    {
                        new Option
                        {
                            Name = "Target Painter Generator",
                            Value = "(Primary Weaponry, 12”)",
                            Points = 5,
                            OptionGroup = 1
                        },
                        new Option
                        {
                            Name = "Disruption Generator",
                            Value = "(8”)",
                            Points = 5,
                            OptionGroup = 1
                        }
                    }
                },
                new Ship
                {
                    Name = "Zeno",
                    BasePoints = 100,
                    CurrentPoints = 100,
                    Size = "M",
                    Options = new List<Option>()
                },
                new Ship
                {
                    Name = "Thales",
                    BasePoints = 20,
                    CurrentPoints = 20,
                    Size = "S",
                    Options = new List<Option>()
                },
                new Ship
                {
                    Name = "Pericles",
                    BasePoints = 170,
                    CurrentPoints = 170,
                    Size = "L",
                    Options = new List<Option>()
                    {
                        new Option
                        {
                            Name = "Energy Weapons",
                            Value = "",
                            Points = 15,

                        }
                    }
                },
                new Ship
                {
                    Name = "Plutarch",
                    BasePoints = 45,
                    CurrentPoints = 45,
                    Size = "S",
                    Options = new List<Option>()
                },
                new Ship
                {
                    Name = "Avenger",
                    BasePoints = 200,
                    CurrentPoints = 200,
                    Size = "L",
                    Options = new List<Option>()
                }
            };
            foreach (var ship in ships)
            {
                context.Ships.AddOrUpdate(s => s.Name, ship);
            }
            context.SaveChanges();

            var squadrons = new List<Squadron>
            {
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 1,
                            Minimum = 1,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Aristotle")
                            }
                        }
                    },
                    Name = "Aristotle",
                    FactionID = Faction.COA
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 1,
                            Minimum = 1,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Pericles")
                            }
                        }
                    },
                    Name = "Pericles",
                    FactionID = Faction.COA
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 1,
                            Minimum = 3,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Zeno")
                            }
                        }
                    },
                    Name = "Zeno Squadron",
                    FactionID = Faction.COA
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 2,
                            Minimum = 5,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Thales")
                            }
                        }
                    },
                    Name = "Thales",
                    FactionID = Faction.COA
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 2,
                            Minimum = 3,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Plutarch")
                            }
                        }
                    },
                    Name = "Plutarch",
                    FactionID = Faction.COA
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 1,
                            Minimum = 1,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Avenger")
                            }
                        }
                    },
                    Name = "Avenger",
                    FactionID = Faction.KOB
                }
            };
            foreach (var squadron in squadrons)
            {
                context.Squadrons.AddOrUpdate(s => s.Name, squadron);
            }
            context.SaveChanges();
        }
    }
}
