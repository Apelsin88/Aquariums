using DesignPtAquariums.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesignPtAquariums.Objects
{
    public class DatabaseConnection
    {
        public List<Organism> OrgSpecies = new List<Organism>();
        public List<Aquarium> Aquariums = new List<Aquarium>();

        public DatabaseConnection()
        {
            AquariumBuilder aquariumBuilder = new AquariumBuilder();

            Aquarium builtAquarium1 = aquariumBuilder
                .SetPh(6)
                .SetCarbonateHardness(3)
                .SetGeneralHardness(3)
                .SetTemperatureC(28)
                .SetName("Aquarium1")
                .Build();
            Aquariums.Add(builtAquarium1);

            Aquarium builtAquarium2 = aquariumBuilder
                .SetCarbonateHardness(15)
                .SetGeneralHardness(15)
                .SetPh(8.2f)
                .SetTemperatureC(26)
                .SetName("Aquarium2")
                .SetTotalDissolvedSolidsPpm(300)
                .Build();
            Aquariums.Add(builtAquarium2);

            Aquarium builtAquarium3 = aquariumBuilder
                .SetTotalDissolvedSolidsPpm(220)
                .SetName("Aquarium3")
                .Build();
            Aquariums.Add(builtAquarium3);

            Aquarium builtAquarium4 = aquariumBuilder
                .SetPh(8)
                .SetTotalDissolvedSolidsPpm(260)
                .SetCarbonateHardness(8)
                .SetGeneralHardness(10)
                .SetTemperatureC(18)
                .SetName("Aquarium4")
                .Build();
            Aquariums.Add(builtAquarium4);

            OrganismBuilder organismBuilder = new OrganismBuilder();

            Organism Discus = organismBuilder
                .SetCarbonateHardnessMax(4)
                .SetCarbonateHardnessMin(1)
                .SetGeneralHardnessMax(8)
                .SetGeneralHardnessMin(1)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetPhMax(7)
                .SetPhMin(5.5f)
                .SetTemperatureMinC(26)
                .SetSpecies("Discus")
                .Build();
            OrgSpecies.Add(Discus);

            Organism NeonTetra = organismBuilder
                .SetCarbonateHardnessMax(6)
                .SetCarbonateHardnessMin(1)
                .SetGeneralHardnessMax(10)
                .SetGeneralHardnessMin(1)
                .SetTotalDissolvedSolidsMaxPpm(150)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetPhMax(7)
                .SetPhMin(6)
                .SetTemperatureMaxC(28)
                .SetTemperatureMinC(22)
                .SetSpecies("Neon Tetra")
                .Build();
            OrgSpecies.Add(NeonTetra);

            Organism CorydorasCatfish = organismBuilder
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetGeneralHardnessMax(12)
                .SetGeneralHardnessMin(1)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetPhMax(7.5f)
                .SetPhMin(6)
                .SetTemperatureMaxC(26)
                .SetTemperatureMinC(22)
                .SetSpecies("Corydoras catfish")
                .Build();
            OrgSpecies.Add(CorydorasCatfish);

            Organism BolivianRam = organismBuilder
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetGeneralHardnessMax(12)
                .SetGeneralHardnessMin(1)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetPhMax(7.5f)
                .SetPhMin(6)
                .SetTemperatureMaxC(28)
                .SetTemperatureMinC(24)
                .SetSpecies("Bolivian Ram")
                .Build();
            OrgSpecies.Add(BolivianRam);

            Organism AfricanCichlid = organismBuilder
                .SetCarbonateHardnessMax(20)
                .SetCarbonateHardnessMin(10)
                .SetGeneralHardnessMax(30)
                .SetGeneralHardnessMin(10)
                .SetTotalDissolvedSolidsMaxPpm(500)
                .SetTotalDissolvedSolidsMinPpm(200)
                .SetPhMax(9)
                .SetPhMin(7.5f)
                .SetTemperatureMaxC(28)
                .SetTemperatureMinC(24)
                .SetSpecies("African Cichlid")
                .Build();
            OrgSpecies.Add(AfricanCichlid);

            Organism AfricanDwarfFrog = organismBuilder
                .SetPhMax(7.5f)
                .SetPhMin(6.5f)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetGeneralHardnessMax(10)
                .SetGeneralHardnessMin(2)
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(26)
                .SetTemperatureMinC(23)
                .SetSpecies("African Dwarf Frog")
                .Build();
            OrgSpecies.Add(AfricanDwarfFrog);

            Organism SynodontisCatfish = organismBuilder
                .SetPhMax(8)
                .SetPhMin(6)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetGeneralHardnessMax(15)
                .SetGeneralHardnessMin(1)
                .SetCarbonateHardnessMax(10)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(26)
                .SetTemperatureMinC(24)
                .SetSpecies("Synodontis Catfish")
                .Build();
            OrgSpecies.Add(SynodontisCatfish);

            Organism Angelfish = organismBuilder
                .SetPhMax(7.5f)
                .SetPhMin(6.5f)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetGeneralHardnessMax(10)
                .SetGeneralHardnessMin(3)
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(28)
                .SetTemperatureMinC(24)
                .SetSpecies("Angelfish")
                .Build();
            OrgSpecies.Add(Angelfish);

            Organism BettaFish = organismBuilder
                .SetPhMax(7.5f)
                .SetPhMin(6)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetGeneralHardnessMax(15)
                .SetGeneralHardnessMin(1)
                .SetCarbonateHardnessMax(10)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(28)
                .SetTemperatureMinC(24)
                .SetSpecies("Betta Fish")
                .Build();
            OrgSpecies.Add(BettaFish);

            Organism EmberTetra = organismBuilder
                .SetPhMax(7)
                .SetPhMin(6)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetGeneralHardnessMax(10)
                .SetGeneralHardnessMin(1)
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(27)
                .SetTemperatureMinC(23)
                .SetSpecies("Ember Tetra")
                .Build();
            OrgSpecies.Add(EmberTetra);

            Organism GhostShrimp = organismBuilder
                .SetPhMax(7.5f)
                .SetPhMin(6.5f)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetGeneralHardnessMax(10)
                .SetGeneralHardnessMin(3)
                .SetCarbonateHardnessMax(8)
                .SetCarbonateHardnessMin(1)
                .SetTemperatureMaxC(26)
                .SetTemperatureMinC(22)
                .SetSpecies("Ghost Shrimp")
                .SetGroup(Group.Shrimp)
                .Build();
            OrgSpecies.Add(GhostShrimp);

            Organism Goldfish = organismBuilder
                .SetPhMax(8)
                .SetPhMin(6.5f)
                .SetTotalDissolvedSolidsMaxPpm(500)
                .SetTotalDissolvedSolidsMinPpm(100)
                .SetGeneralHardnessMax(12)
                .SetGeneralHardnessMin(8)
                .SetCarbonateHardnessMax(10)
                .SetCarbonateHardnessMin(6)
                .SetTemperatureMaxC(22)
                .SetTemperatureMinC(18)
                .SetSpecies("Goldfish")
                .SetGroup(Group.Fish)
                .Build();
            OrgSpecies.Add(Goldfish);

            Organism WhiteCloudMountainMinnow = organismBuilder
                .SetPhMax(8)
                .SetPhMin(6)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetGeneralHardnessMax(12)
                .SetGeneralHardnessMin(4)
                .SetCarbonateHardnessMax(10)
                .SetCarbonateHardnessMin(3)
                .SetTemperatureMaxC(22)
                .SetTemperatureMinC(18)
                .SetSpecies("White Cloud Mountain Minnow")
                .SetGroup(Group.Fish)
                .Build();
            OrgSpecies.Add(WhiteCloudMountainMinnow);

            Organism WeatherLoach = organismBuilder
                .SetPhMax(8)
                .SetPhMin(6)
                .SetTotalDissolvedSolidsMaxPpm(300)
                .SetTotalDissolvedSolidsMinPpm(50)
                .SetGeneralHardnessMax(12)
                .SetGeneralHardnessMin(4)
                .SetCarbonateHardnessMax(10)
                .SetCarbonateHardnessMin(3)
                .SetTemperatureMaxC(22)
                .SetTemperatureMinC(18)
                .SetSpecies("Weather Loach")
                .SetGroup(Group.Fish)
                .Build();
            OrgSpecies.Add(WeatherLoach);
        }

        public Organism GetOrganism(string Species)
        {
            foreach (var org in OrgSpecies)
            {
                if (org.Species == Species)
                {
                    return org;
                }
            }
            return null;
        }

        public List<OrganismProxy> GetProxys()
        {
            List<OrganismProxy> organismProxies = new List<OrganismProxy>();
            foreach (var org in OrgSpecies)
            {
                organismProxies.Add(new OrganismProxy(this, org.Species));
            }
            return organismProxies;
        }
    }
}
