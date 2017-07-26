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
            var superBlocks = new List<SuperBlock>
            {
                new SuperBlock()
                {
                    Name = "Grand Coalition"
                },
                new SuperBlock()
                {
                    Name = "Imperial Bond"
                },
                new SuperBlock()
                {
                    Name = "Free Nations"
                }
            };
            foreach (var superBlock in superBlocks)
            {
                context.SuperBlocks.AddOrUpdate(s => s.Name, superBlock);
            }
            context.SaveChanges();

            var factions = new List<Faction>
            {
                new Faction
                {
                    Name = "Covenant of Antarctica",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Free Nations"),
                    Acronym = "CoA",
                    MajorFaction = true
                },
                new Faction
                {
                    Name = "Empire of the Blazing Sun",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Imperial Bond"),
                    Acronym = "EotBS",
                    MajorFaction = true
                },
                new Faction
                {
                    Name = "Federated States of America",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Grand Coalition"),
                    Acronym = "FSA",
                    MajorFaction = true
                },
                new Faction
                {
                    Name = "Kingdom of Britannia",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Grand Coalition"),
                    Acronym = "KoB",
                    MajorFaction = true
                },
                new Faction
                {
                    Name = "Prussian Empire",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Imperial Bond"),
                    Acronym = "PE",
                    MajorFaction = true
                },

                new Faction
                {
                    Name = "Republique of France",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Imperial Bond"),
                    Acronym = "RoF",
                    MajorFaction = true
                },
                new Faction
                {
                    Name = "Russian Coalition",
                    SuperBlock = context.SuperBlocks.FirstOrDefault(s => s.Name == "Grand Coalition"),
                    Acronym = "RC",
                    MajorFaction = true
                }
            };
            foreach (var faction in factions)
            {
                context.Factions.AddOrUpdate(f => f.Name, faction);
            }
            context.SaveChanges();

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
                    Name = "Kepler",
                    BasePoints = 95,
                    CurrentPoints = 95,
                    Size = "M",
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
                            },
                            IsAttachment = false
                        },
                        new SquadronEntry
                        {
                            Maximum = 1,
                            Minimum = 0,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Kepler")
                            },
                            IsAttachment = true
                        },
                        new SquadronEntry
                        {
                            Maximum = 3,
                            Minimum = 0,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Galen")
                            },
                            IsAttachment = true
                        }
                    },
                    Name = "Aristotle",
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Covenant of Antarctica")
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
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Covenant of Antarctica")
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 3,
                            Minimum = 1,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Zeno")
                            }
                        }
                    },
                    Name = "Zeno Squadron",
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Covenant of Antarctica")
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 5,
                            Minimum = 2,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Thales")
                            }
                        }
                    },
                    Name = "Thales",
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Covenant of Antarctica")
                },
                new Squadron
                {
                    Entries = new List<SquadronEntry>
                    {
                        new SquadronEntry
                        {
                            Maximum = 3,
                            Minimum = 2,
                            Ships = new List<Ship>
                            {
                                context.Ships.FirstOrDefault(s => s.Name == "Plutarch")
                            }
                        }
                    },
                    Name = "Plutarch",
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Covenant of Antarctica")
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
                    FactionID = context.Factions.FirstOrDefault(f => f.Name == "Kingdom of Britannia")
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
