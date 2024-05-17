using DesignPtAquariums.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPtAquariums.Patterns
{
    public class OrganismBuilder
    {
        public string Name { get; set; } = "Bob";
        public string Species { get; set; } = "Karp";
        public Group Group { get; set; } = Group.Fish;
        public float TemperatureMinC { get; set; } = 4;
        public float TemperatureMaxC { get; set; } = 30;
        public float PhMin { get; set; } = 6.1f;
        public float PhMax { get; set; } = 7.4f;
        public float TotalDissolvedSolidsMinPpm { get; set; } = 71.4f;
        public float TotalDissolvedSolidsMaxPpm { get; set; } = 328.6f;
        public float GeneralHardnessMin { get; set; } = 2.8f;
        public float GeneralHardnessMax { get; set; } = 13.7f;
        public float CarbonateHardnessMin { get; set; } = 2.6f;
        public float CarbonateHardnessMax { get; set; } = 8.2f;

        public string Aquarium1 { get; set; } = "?";
        public string Aquarium2 { get; set; } = "?";
        public string Aquarium3 { get; set; } = "?";
        public string Aquarium4 { get; set; } = "?";

        public List<Organism> Eats { get; set; } = new List<Organism>();

        public OrganismBuilder SetName(string name)
        {
            Name = name;
            return this;
        }
        public OrganismBuilder SetSpecies(string species)
        {
            Species = species;
            return this;
        }
        public OrganismBuilder SetGroup(Group group)
        {
            Group = group;
            return this;
        }
        public OrganismBuilder SetTemperatureMinC(float temperatureMinC)
        {
            TemperatureMinC = temperatureMinC;
            return this;
        }
        public OrganismBuilder SetTemperatureMaxC(float temperatureMaxC)
        {
            TemperatureMaxC = temperatureMaxC;
            return this;
        }
        public OrganismBuilder SetPhMin(float phMin)
        {
            PhMin = phMin;
            return this;
        }
        public OrganismBuilder SetPhMax(float phMax)
        {
            PhMax = phMax;
            return this;
        }
        public OrganismBuilder SetTotalDissolvedSolidsMinPpm(float totalDissolvedSolidsMinPpm)
        {
            TotalDissolvedSolidsMinPpm = totalDissolvedSolidsMinPpm;
            return this;
        }
        public OrganismBuilder SetTotalDissolvedSolidsMaxPpm(float totalDissolvedSoolidsMaxPpm)
        {
            TotalDissolvedSolidsMaxPpm = totalDissolvedSoolidsMaxPpm;
            return this;
        }
        public OrganismBuilder SetGeneralHardnessMin(float generalHardnessMin)
        {
            GeneralHardnessMin = generalHardnessMin;
            return this;
        }
        public OrganismBuilder SetGeneralHardnessMax(float generalHardnessMax)
        {
            GeneralHardnessMax = generalHardnessMax;
            return this;
        }
        public OrganismBuilder SetCarbonateHardnessMin(float carbonateHardnessMin)
        {
            CarbonateHardnessMin = carbonateHardnessMin;
            return this;
        }
        public OrganismBuilder SetCarbonateHardnessMax( float carbonateHardnessMax)
        {
            CarbonateHardnessMax = carbonateHardnessMax;
            return this;
        }
        public OrganismBuilder SetEats(List<Organism> eats)
        {
            Eats = eats;
            return this;
        }

        public OrganismBuilder SetAquarium1(string aquarium1)
        {
            Aquarium1 = aquarium1;
            return this;
        }
        public OrganismBuilder SetAquarium2(string aquarium2)
        {
            Aquarium2 = aquarium2;
            return this;
        }
        public OrganismBuilder SetAquarium3(string aquarium3)
        {
            Aquarium3 = aquarium3;
            return this;
        }
        public OrganismBuilder SetAquarium4(string aquarium4)
        {
            Aquarium4 = aquarium4;
            return this;
        }


        public Organism Build()
        {
            return new Organism(Name, Species, Group, TemperatureMinC, TemperatureMaxC, PhMin, PhMax, TotalDissolvedSolidsMinPpm, TotalDissolvedSolidsMaxPpm, GeneralHardnessMin, GeneralHardnessMax, CarbonateHardnessMin, CarbonateHardnessMax, Aquarium1, Aquarium2, Aquarium3, Aquarium4, Eats);
        }
    }
}
