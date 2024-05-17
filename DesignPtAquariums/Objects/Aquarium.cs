using DesignPtAquariums.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPtAquariums.Objects
{
    public class Aquarium
    {
        public string Name { get; set; }
        public float VolumeLitre { get; set; }
        public float TemperatureC { get; set; }
        public float Ph { get; set; }
        public float TotalDissolvedSolidsPpm { get; set; }
        public float GeneralHardness { get; set; }
        public float CarbonateHardness { get; set; }
        public List<Organism> Organisms { get; set; }
        public List<IObserver> observers = new List<IObserver>();

        public Aquarium(string name, float volumeLitre, float temperatureC, float ph, float totalDissolvedSolidsPpm, float generalHardness, float carbonateHardness, List<Organism> organisms)
        {
            Name = name;
            VolumeLitre = volumeLitre;
            TemperatureC = temperatureC;
            Ph = ph;
            TotalDissolvedSolidsPpm = totalDissolvedSolidsPpm;
            GeneralHardness = generalHardness;
            CarbonateHardness = carbonateHardness;
            this.Organisms = organisms;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void PostContent()
        {
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            Aquarium aquarium = this;
            foreach (var observer in observers)
            {
                observer.Notify(aquarium);
            }
        }
    }
}
