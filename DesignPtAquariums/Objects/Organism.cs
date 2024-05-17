using DesignPtAquariums.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPtAquariums.Objects
{
    public enum Group { Fish, Shrimp, Mollusk}

    public class Organism : IObserver
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public Group Group { get; set; }
        public float TemperatureMinC { get; set; }
        public float TemperatureMaxC { get; set; }
        public float PhMin { get; set; }
        public float PhMax { get; set; }
        public float TotalDissolvedSolidsMinPpm { get; set; }
        public float TotalDissolvedSolidsMaxPpm { get; set; }
        public float GeneralHardnessMin { get; set; }
        public float GeneralHardnessMax { get; set; }
        public float CarbonateHardnessMin { get; set; }
        public float CarbonateHardnessMax { get; set; }

        public string Aquarium1 { get; set; }
        public string Aquarium2 { get; set; }
        public string Aquarium3 { get; set; }
        public string Aquarium4 { get; set; }

        public List<Organism> Eats { get; set; }

        public Organism(string name, string species, Group group, float temperatureMinC, float temperatureMaxC, float phMin, float phMax, float totalDissolvedSolidsMinPpm, float totalDissolvedSolidsMaxPpm, float generalHardnessMin, float generalHardnessMax, float carbonateHardnessMin, float carbonateHardnessMax, string aquarium1, string aquarium2, string aquarium3, string aquarium4, List<Organism> eats)
        {
            Name = name;
            Species = species;
            Group = group;
            TemperatureMinC = temperatureMinC;
            TemperatureMaxC = temperatureMaxC;
            PhMin = phMin;
            PhMax = phMax;
            TotalDissolvedSolidsMinPpm = totalDissolvedSolidsMinPpm;
            TotalDissolvedSolidsMaxPpm = totalDissolvedSolidsMaxPpm;
            GeneralHardnessMin = generalHardnessMin;
            GeneralHardnessMax = generalHardnessMax;
            CarbonateHardnessMin = carbonateHardnessMin;
            CarbonateHardnessMax = carbonateHardnessMax;

            Aquarium1 = aquarium1;
            Aquarium2 = aquarium2;
            Aquarium3 = aquarium3;
            Aquarium4 = aquarium4;

            Eats = eats;
        }

        public void Notify(Aquarium aquarium)
        {

            bool temperature = CInRange(TemperatureMinC, TemperatureMaxC, aquarium);
            bool ph = PhInRange(PhMin, PhMax, aquarium);
            bool tds = TdsInRange(TotalDissolvedSolidsMinPpm, TotalDissolvedSolidsMaxPpm, aquarium);
            bool gh = GhInRange(GeneralHardnessMin, GeneralHardnessMax, aquarium);
            bool kh = KhInRange(CarbonateHardnessMin, CarbonateHardnessMax, aquarium);

            if (temperature == true && ph == true && tds == true && gh == true && kh == true)
            {
                
                if (aquarium.Name == "Aquarium1")
                {
                    Aquarium1 = "Yes";
                }
                if (aquarium.Name == "Aquarium2")
                {
                    Aquarium2 = "Yes";
                }
                if (aquarium.Name == "Aquarium3")
                {
                    Aquarium3 = "Yes";
                }
                if (aquarium.Name == "Aquarium4")
                {
                    Aquarium4 = "Yes";
                }
            }
            else
            {
                if (aquarium.Name == "Aquarium1")
                {
                    Aquarium1 = "Nope";
                }
                if (aquarium.Name == "Aquarium2")
                {
                    Aquarium2 = "Nope";
                }
                if (aquarium.Name == "Aquarium3")
                {
                    Aquarium3 = "Nope";

                }
                if (aquarium.Name == "Aquarium4")
                {
                    Aquarium4 = "Nope";
                }
            }

        }
        public bool CInRange(float min, float max, Aquarium aquarium)
        {
            if (aquarium.TemperatureC < min || aquarium.TemperatureC > max)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool PhInRange(float min, float max, Aquarium aquarium)
        {
            if (aquarium.Ph < min || aquarium.Ph > max)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool TdsInRange(float min, float max, Aquarium aquarium)
        {
            if (aquarium.TotalDissolvedSolidsPpm < min || aquarium.TotalDissolvedSolidsPpm > max)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool GhInRange(float min, float max, Aquarium aquarium)
        {
            if (aquarium.GeneralHardness < min || aquarium.GeneralHardness > max)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool KhInRange(float min, float max, Aquarium aquarium)
        {
            if (aquarium.CarbonateHardness < min || aquarium.CarbonateHardness > max)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
