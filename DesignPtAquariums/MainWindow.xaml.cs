using DesignPtAquariums.Objects;
using DesignPtAquariums.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace DesignPtAquariums
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DatabaseConnection Db = new DatabaseConnection();
        List<OrganismProxy> organismProxies = new List<OrganismProxy>();

        public MainWindow()
        {
            InitializeComponent();

            organismProxies = Db.GetProxys();

            Aquarium1TemperatureValueTextbox.Text = Db.Aquariums[0].TemperatureC.ToString();
            Aquarium1PHValueTextbox.Text = Db.Aquariums[0].Ph.ToString();
            Aquarium1TDSValueTextbox.Text = Db.Aquariums[0].TotalDissolvedSolidsPpm.ToString();
            Aquarium1GHValueTextbox.Text = Db.Aquariums[0].GeneralHardness.ToString();
            Aquarium1CHValueTextbox.Text = Db.Aquariums[0].CarbonateHardness.ToString();

            Aquarium2TemperatureValueTextbox.Text = Db.Aquariums[1].TemperatureC.ToString();
            Aquarium2PHValueTextbox.Text = Db.Aquariums[1].Ph.ToString();
            Aquarium2TDSValueTextbox.Text = Db.Aquariums[1].TotalDissolvedSolidsPpm.ToString();
            Aquarium2GHValueTextbox.Text = Db.Aquariums[1].GeneralHardness.ToString();
            Aquarium2CHValueTextbox.Text = Db.Aquariums[1].CarbonateHardness.ToString();

            Aquarium3TemperatureValueTextbox.Text = Db.Aquariums[2].TemperatureC.ToString();
            Aquarium3PHValueTextbox.Text = Db.Aquariums[2].Ph.ToString();
            Aquarium3TDSValueTextbox.Text = Db.Aquariums[2].TotalDissolvedSolidsPpm.ToString();
            Aquarium3GHValueTextbox.Text = Db.Aquariums[2].GeneralHardness.ToString();
            Aquarium3CHValueTextbox.Text = Db.Aquariums[2].CarbonateHardness.ToString();

            Aquarium4TemperatureValueTextbox.Text = Db.Aquariums[3].TemperatureC.ToString();
            Aquarium4PHValueTextbox.Text = Db.Aquariums[3].Ph.ToString();
            Aquarium4TDSValueTextbox.Text = Db.Aquariums[3].TotalDissolvedSolidsPpm.ToString();
            Aquarium4GHValueTextbox.Text = Db.Aquariums[3].GeneralHardness.ToString();
            Aquarium4CHValueTextbox.Text = Db.Aquariums[3].CarbonateHardness.ToString();

            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
            foreach (Organism a in Db.OrgSpecies)
            { 
                Db.Aquariums[0].AddObserver(a);
                Db.Aquariums[1].AddObserver(a);
                Db.Aquariums[2].AddObserver(a);
                Db.Aquariums[3].AddObserver(a);
            }


        }

        void AddToAquarium(Aquarium aquarium, Organism organism, ListBox box)
        {
            bool temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
            bool ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
            bool tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
            bool gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
            bool kh = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);

            if (temperature == true && ph == true && tds == true && gh == true && kh == true)
            {
                OrganismBuilder organismBuilder = new OrganismBuilder();
                Organism newOrg = organismBuilder
                    .SetSpecies(organism.Species)
                    .SetCarbonateHardnessMax(organism.CarbonateHardnessMax)
                    .SetCarbonateHardnessMin(organism.CarbonateHardnessMin)
                    .SetGeneralHardnessMax(organism.GeneralHardnessMax)
                    .SetGeneralHardnessMin(organism.GeneralHardnessMin)
                    .SetTotalDissolvedSolidsMaxPpm(organism.TotalDissolvedSolidsMaxPpm)
                    .SetTotalDissolvedSolidsMinPpm(organism.TotalDissolvedSolidsMinPpm)
                    .SetPhMax(organism.PhMax)
                    .SetPhMin(organism.PhMin)
                    .SetTemperatureMaxC(organism.TemperatureMaxC)
                    .SetTemperatureMinC(organism.TemperatureMinC)
                    .Build();
                aquarium.Organisms.Add(newOrg);
                box.Items.Add(newOrg.Name + " the " + newOrg.Species);
            }
            else
            {
                MessageBox.Show($"{aquarium.Name} is not suiteble for {organism.Species} \n\n{organism.Name} the {organism.Species}     {aquarium.Name} parameters\nTemperature Max: {organism.TemperatureMaxC}.                        {aquarium.TemperatureC}\nTemperature Min: {organism.TemperatureMinC}.\nPH Max: {organism.PhMax}.                                           {aquarium.Ph}\nPH Min: {organism.PhMin}. \nTDS Max: {organism.TotalDissolvedSolidsMaxPpm}.                                     {aquarium.TotalDissolvedSolidsPpm}\nTDS Min: {organism.TotalDissolvedSolidsMinPpm}. \nGH Max: {organism.GeneralHardnessMax}.                                        {aquarium.GeneralHardness}\nGH Min: {organism.GeneralHardnessMin}. \nKH Max: {organism.CarbonateHardnessMax}.                                        {aquarium.CarbonateHardness}\nKH Min: {organism.CarbonateHardnessMin}.");
            }
        }

        private void Aquarium1Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            if (OraganismProxysListbox.SelectedItem != null)
            {
                int OrgIndex = OraganismProxysListbox.SelectedIndex;
                OrganismProxy orgProxy = organismProxies[OrgIndex];
                Organism org = Db.GetOrganism(orgProxy.Species);
                AddToAquarium(aquarium, org, box);
            }
            else
            {
                MessageBox.Show("Choose an organism to add :)");
            }
        }

        private void Aquarium2Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];

            if (OraganismProxysListbox.SelectedItem != null)
            {
                int OrgIndex = OraganismProxysListbox.SelectedIndex;
                OrganismProxy orgProxy = organismProxies[OrgIndex];
                Organism org = Db.GetOrganism(orgProxy.Species);
                AddToAquarium(aquarium, org, box);
            }
            else
            {
                MessageBox.Show("Choose an organism to add :)");
            }

        }

        private void Aquarium3Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];

            if (OraganismProxysListbox.SelectedItem != null)
            {
                int OrgIndex = OraganismProxysListbox.SelectedIndex;
                OrganismProxy orgProxy = organismProxies[OrgIndex];
                Organism org = Db.GetOrganism(orgProxy.Species);
                AddToAquarium(aquarium, org, box);
            }
            else
            {
                MessageBox.Show("Choose an organism to add :)");
            }

        }

        private void Aquarium4Button_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];

            if (OraganismProxysListbox.SelectedItem != null)
            {
                int OrgIndex = OraganismProxysListbox.SelectedIndex;
                OrganismProxy orgProxy = organismProxies[OrgIndex];
                Organism org = Db.GetOrganism(orgProxy.Species);
                AddToAquarium(aquarium, org, box);
            }
            else
            {
                MessageBox.Show("Choose an organism to add :)");
            }

        }

        private void OraganismProxysListbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (OraganismProxysListbox.SelectedItem != null)
            {
                int OrgIndex = OraganismProxysListbox.SelectedIndex;
                OrganismProxy orgProxy = organismProxies[OrgIndex];
                MessageBox.Show($"{orgProxy.Name} the {orgProxy.Species}\nTemperature Max: {orgProxy.TemperatureMaxC}.\nTemperature Min: {orgProxy.TemperatureMinC}.\nPH Max: {orgProxy.PhMax}. \nPH Min: {orgProxy.PhMin}. \nTDS Max: {orgProxy.TotalDissolvedSolidsMaxPpm}. \nTDS Min: {orgProxy.TotalDissolvedSolidsMinPpm}. \nGH Max: {orgProxy.GeneralHardnessMax}. \nGH Min: {orgProxy.GeneralHardnessMin}. \nKH Max: {orgProxy.CarbonateHardnessMax}. \nKH Min: {orgProxy.CarbonateHardnessMin}. \n\nA1 = {orgProxy.Aquarium1}  A2 = {orgProxy.Aquarium2}  A3 = {orgProxy.Aquarium3}  A4 = {orgProxy.Aquarium4}.");
            }
            else
            {
                MessageBox.Show("Choose an organism to add :)");
            }
        }
        
        private void Aquarium1TemperatureMinusButton_Click(object sender, RoutedEventArgs e)
        {
            
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.TemperatureC--;
            Aquarium1TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++ )
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms) 
            { 
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();

        }

        

        private void Aquarium1TemperaturePlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.TemperatureC++;
            Aquarium1TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium1PHMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.Ph--;
            Aquarium1PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1PHPlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.Ph++;
            Aquarium1PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1TDSMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.TotalDissolvedSolidsPpm--;
            Aquarium1TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1TDSPlusButton_Click(Object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.TotalDissolvedSolidsPpm++;
            Aquarium1TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1GHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.GeneralHardness--;
            Aquarium1GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1GHPlusButton_Click(Object sender, EventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.GeneralHardness++;
            Aquarium1GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1KHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.CarbonateHardness--;
            Aquarium1CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium1KHPlusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium1Listbox;
            Aquarium aquarium = Db.Aquariums[0];
            aquarium.CarbonateHardness++;
            Aquarium1CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium2TemperatureMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.TemperatureC--;
            Aquarium2TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium2TemperaturePlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.TemperatureC++;
            Aquarium2TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium2PHMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.Ph--;
            Aquarium2PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2PHPlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.Ph++;
            Aquarium2PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2TDSMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.TotalDissolvedSolidsPpm--;
            Aquarium2TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2TDSPlusButton_Click(Object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.TotalDissolvedSolidsPpm++;
            Aquarium2TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2GHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.GeneralHardness--;
            Aquarium2GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2GHPlusButton_Click(Object sender, EventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.GeneralHardness++;
            Aquarium2GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2KHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.CarbonateHardness--;
            Aquarium2CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium2KHPlusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium2Listbox;
            Aquarium aquarium = Db.Aquariums[1];
            aquarium.CarbonateHardness++;
            Aquarium2CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium3TemperatureMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.TemperatureC--;
            Aquarium3TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium3TemperaturePlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.TemperatureC++;
            Aquarium3TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium3PHMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.Ph--;
            Aquarium3PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3PHPlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.Ph++;
            Aquarium3PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3TDSMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.TotalDissolvedSolidsPpm--;
            Aquarium3TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3TDSPlusButton_Click(Object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.TotalDissolvedSolidsPpm++;
            Aquarium3TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3GHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.GeneralHardness--;
            Aquarium3GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3GHPlusButton_Click(Object sender, EventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.GeneralHardness++;
            Aquarium3GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3KHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.CarbonateHardness--;
            Aquarium3CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium3KHPlusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium3Listbox;
            Aquarium aquarium = Db.Aquariums[2];
            aquarium.CarbonateHardness++;
            Aquarium3CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }


        private void Aquarium4TemperatureMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.TemperatureC--;
            Aquarium4TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium4TemperaturePlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.TemperatureC++;
            Aquarium4TemperatureValueTextbox.Text = aquarium.TemperatureC.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool temperature = true;
                Organism organism = aquarium.Organisms[orgIndex];
                temperature = organism.CInRange(organism.TemperatureMinC, organism.TemperatureMaxC, aquarium);
                if (temperature == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void Aquarium4PHMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.Ph--;
            Aquarium4PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4PHPlusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.Ph++;
            Aquarium4PHValueTextbox.Text = aquarium.Ph.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ph = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ph = organism.PhInRange(organism.PhMin, organism.PhMax, aquarium);
                if (ph == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4TDSMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.TotalDissolvedSolidsPpm--;
            Aquarium4TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4TDSPlusButton_Click(Object sender, RoutedEventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.TotalDissolvedSolidsPpm++;
            Aquarium4TDSValueTextbox.Text = aquarium.TotalDissolvedSolidsPpm.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool tds = true;
                Organism organism = aquarium.Organisms[orgIndex];
                tds = organism.TdsInRange(organism.TotalDissolvedSolidsMinPpm, organism.TotalDissolvedSolidsMaxPpm, aquarium);
                if (tds == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4GHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.GeneralHardness--;
            Aquarium4GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4GHPlusButton_Click(Object sender, EventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.GeneralHardness++;
            Aquarium4GHValueTextbox.Text = aquarium.GeneralHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool gh = true;
                Organism organism = aquarium.Organisms[orgIndex];
                gh = organism.GhInRange(organism.GeneralHardnessMin, organism.GeneralHardnessMax, aquarium);
                if (gh == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4KHMinusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.CarbonateHardness--;
            Aquarium4CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }
        private void Aquarium4KHPlusButton_Click(object sender, EventArgs e)
        {
            ListBox box = Aquarium4Listbox;
            Aquarium aquarium = Db.Aquariums[3];
            aquarium.CarbonateHardness++;
            Aquarium4CHValueTextbox.Text = aquarium.CarbonateHardness.ToString();

            for (int orgIndex = 0; orgIndex <= aquarium.Organisms.Count() - 1; orgIndex++)
            {
                bool ch = true;
                Organism organism = aquarium.Organisms[orgIndex];
                ch = organism.KhInRange(organism.CarbonateHardnessMin, organism.CarbonateHardnessMax, aquarium);
                if (ch == false)
                {
                    aquarium.Organisms.Remove(organism);
                    orgIndex--;
                }
            }
            box.Items.Clear();
            foreach (Organism leftOrganism in aquarium.Organisms)
            {
                box.Items.Add(leftOrganism.Name + " the " + leftOrganism.Species);
            }
            aquarium.NotifyObservers();
        }

        private void QuickSort(List<OrganismProxy> list, int low, int high, Func<OrganismProxy, float> keySelector)
        {
            if (low < high)
            {
                int pi = Partition(list, low, high, keySelector);
                QuickSort(list, low, pi - 1, keySelector);
                QuickSort(list, pi + 1, high, keySelector);
            }
        }

        private int Partition(List<OrganismProxy> list, int low, int high, Func<OrganismProxy, float> keySelector)
        {
            float pivot = keySelector(list[high]);
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (keySelector(list[j]) <= pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, high);
            return i + 1;
        }

        private void Swap(List<OrganismProxy> list, int i, int j)
        {
            OrganismProxy temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private void TemperatureComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            QuickSort(organismProxies, 0, organismProxies.Count - 1, o => o.TemperatureMaxC);

            OraganismProxysListbox.Items.Clear();
            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
        }

        private void PhComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            QuickSort(organismProxies, 0, organismProxies.Count - 1, o => o.PhMax);

            OraganismProxysListbox.Items.Clear();
            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
        }

        private void TdsComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            QuickSort(organismProxies, 0, organismProxies.Count - 1, o => o.TotalDissolvedSolidsMaxPpm);

            OraganismProxysListbox.Items.Clear();
            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
        }

        private void GhComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            QuickSort(organismProxies, 0, organismProxies.Count - 1, o => o.GeneralHardnessMax);

            OraganismProxysListbox.Items.Clear();
            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
        }

        private void KhComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            QuickSort(organismProxies, 0, organismProxies.Count - 1, o => o.CarbonateHardnessMax);

            OraganismProxysListbox.Items.Clear();
            foreach (OrganismProxy a in organismProxies)
            {
                OraganismProxysListbox.Items.Add(a.Species);
            }
        }
    }
    
}
