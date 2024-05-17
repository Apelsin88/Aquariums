using DesignPtAquariums.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DesignPtAquariums.Patterns
{
    public class OrganismProxy
    {
        private Organism Organism = null;
        private DatabaseConnection Db = new DatabaseConnection();
        public string Species { get; set; }

        public OrganismProxy(DatabaseConnection db, string species)
        {
            Db = db;
            Species = species;

        }

        public string Name
        {
            get
            {
                Load();
                return Organism.Name;
            }
            set
            {
                Load();
                Organism.Name = value;
            }
        }
        public Group Group
        {
            get
            {
                Load();
                return Organism.Group;
            }
            set
            {
                Load();
                Organism.Group = value;
            }
        }
        public float TemperatureMinC
        {
            get
            {
                Load();
                return Organism.TemperatureMinC;
            }
            set
            {
                Load();
                Organism.TemperatureMinC = value;
            }
        }
        public float TemperatureMaxC
        {
            get
            {
                Load();
                return Organism.TemperatureMaxC;
            }
            set
            {
                Load();
                Organism.TemperatureMaxC = value;
            }
        }
        public float PhMin
        {
            get
            {
                Load();
                return Organism.PhMin;
            }
            set
            {
                Load();
                Organism.PhMin = value;
            }
        }
        public float PhMax
        {
            get
            {
                Load();
                return Organism.PhMax;
            }
            set
            {
                Load();
                Organism.PhMax = value;
            }
        }
        public float TotalDissolvedSolidsMinPpm
        {
            get
            {
                Load();
                return Organism.TotalDissolvedSolidsMinPpm;
            }
            set
            {
                Load();
                Organism.TotalDissolvedSolidsMinPpm = value;
            }
        }
        public float TotalDissolvedSolidsMaxPpm
        {
            get
            {
                Load();
                return Organism.TotalDissolvedSolidsMaxPpm;
            }
            set
            {
                Load();
                Organism.TotalDissolvedSolidsMaxPpm = value;
            }
        }
        public float GeneralHardnessMin
        {
            get
            {
                Load();
                return Organism.GeneralHardnessMin;
            }
            set
            {
                Load();
                Organism.GeneralHardnessMin = value;
            }
        }
        public float GeneralHardnessMax
        {
            get
            {
                Load();
                return Organism.GeneralHardnessMax;
            }
            set
            {
                Load();
                Organism.GeneralHardnessMax = value;
            }
        }
        public float CarbonateHardnessMin
        {
            get
            {
                Load();
                return Organism.CarbonateHardnessMin;
            }
            set
            {
                Load();
                Organism.CarbonateHardnessMin = value;
            }
        }
        public float CarbonateHardnessMax
        {
            get
            {
                Load();
                return Organism.CarbonateHardnessMax;
            }
            set
            {
                Load();
                Organism.CarbonateHardnessMax = value;
            }
        }

        public string Aquarium1
        {
            get
            {
                Load();
                return Organism.Aquarium1;
            }
            set
            {
                Load();
                Organism.Aquarium1 = value;
            }
        }
        public string Aquarium2
        {
            get
            {
                Load();
                return Organism.Aquarium2;
            }
            set
            {
                Load();
                Organism.Aquarium2 = value;
            }
        }
        public string Aquarium3
        {
            get
            {
                Load();
                return Organism.Aquarium3;
            }
            set
            {
                Load();
                Organism.Aquarium3 = value;
            }
        }
        public string Aquarium4
        {
            get
            {
                Load();
                return Organism.Aquarium4;
            }
            set
            {
                Load();
                Organism.Aquarium4 = value;
            }
        }

        public List<Organism> Eats
        {
            get
            {
                Load();
                return Organism.Eats;
            }
            set
            {
                Load();
                Organism.Eats = value;
            }
        }


        public void Load()
        {
            if (Organism == null)
            {
                Console.WriteLine("Loading " + Species + "!");
                Organism = Db.GetOrganism(Species);
            }
        }
    }
}
