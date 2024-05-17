using DesignPtAquariums.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPtAquariums.Patterns
{
    internal class AquariumBuilder
    {
        public string Name { get; set; } = "Aquarium";
        public float VolumeLitre { get; set; } = 50;
        public float TemperatureC { get; set; } = 25;
        public float Ph { get; set; } = 7;
        public float TotalDissolvedSolidsPpm { get; set; } = 135;
        public float GeneralHardness { get; set; } = 7;
        public float CarbonateHardness { get; set; } = 6;
        public List<Organism> Organisms { get; set; } = new List<Organism>();

        public AquariumBuilder SetName(string name)
        {
            Name = name;
            return this;
        }
        public AquariumBuilder SetVolumeLitre(float volumeLitre)
        {
            VolumeLitre = volumeLitre;
            return this;
        }
        public AquariumBuilder SetTemperatureC(float temperatureC)
        {
            TemperatureC = temperatureC;
            return this;
        }
        public AquariumBuilder SetPh(float ph)
        {
            Ph = ph;
            return this;
        }
        public AquariumBuilder SetTotalDissolvedSolidsPpm(float totalDissolvedSolidsPpm)
        {
            TotalDissolvedSolidsPpm = totalDissolvedSolidsPpm;
            return this;
        }
        public AquariumBuilder SetGeneralHardness(float generalHardness)
        {
            GeneralHardness = generalHardness;
            return this;
        }
        public AquariumBuilder SetCarbonateHardness(float carbonateHardness)
        {
            CarbonateHardness = carbonateHardness;
            return this;
        }
        public AquariumBuilder SetOrganisms(List<Organism> organisms)
        {
            Organisms = organisms;
            return this;
        }

        public Aquarium Build()
        {
            return new Aquarium(Name, VolumeLitre, TemperatureC, Ph, TotalDissolvedSolidsPpm, GeneralHardness, CarbonateHardness, Organisms);
        }

    }
}
