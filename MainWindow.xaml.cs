using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Film
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
        public double Ertekeles { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Film> lista = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            lista.Add(new Film { Cim = "Csillagok háborúja", Mufaj = "sci-fi", Hossz = 121, Ertekeles = 8.6 });
            lista.Add(new Film { Cim = "Titanic", Mufaj = "dráma", Hossz = 195, Ertekeles = 7.8 });
            lista.Add(new Film { Cim = "A Gyűrűk Ura", Mufaj = "fantasy", Hossz = 201, Ertekeles = 8.8 });
            lista.Add(new Film { Cim = "Mátrix", Mufaj = "sci-fi", Hossz = 136, Ertekeles = 8.7 });
            lista.Add(new Film { Cim = "Shrek", Mufaj = "animáció", Hossz = 90, Ertekeles = 7.9 });

            dgFilmek.ItemsSource = null;
            dgFilmek.ItemsSource = lista;
        }

        private void btnDarab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Filmek száma: " + lista.Count);
        }

        private void btnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be a filmeket!");
                return;
            }

            Film legjobb = lista[0];
            foreach (Film f in lista)
            {
                if (f.Hossz > legjobb.Hossz)
                {
                    legjobb = f;
                }
            }
            MessageBox.Show("Leghosszabb film: " + legjobb.Cim + " (" + legjobb.Hossz + " perc)");
        }

        private void btnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be a filmeket!");
                return;
            }

            double osszeg = 0;
            foreach (Film f in lista)
            {
                osszeg += f.Ertekeles;
            }
            double atlag = osszeg / lista.Count;
            MessageBox.Show("Átlag értékelés: " + atlag.ToString("0.00"));
        }

        private void btnSciFi_Click(object sender, RoutedEventArgs e)
        {
            List<Film> scifik = new List<Film>();
            foreach (Film f in lista)
            {
                if (f.Mufaj == "sci-fi")
                {
                    scifik.Add(f);
                }
            }

            dgFilmek.ItemsSource = null;
            dgFilmek.ItemsSource = scifik;
        }

        private void btnCimek_Click(object sender, RoutedEventArgs e)
        {
            string cimek = "";
            foreach (Film f in lista)
            {
                cimek += f.Cim + "\n";
            }
            MessageBox.Show(cimek, "Címek");
        }

        private void btnRendezes_Click(object sender, RoutedEventArgs e)
        {
            lista.Sort((a, b) => a.Cim.CompareTo(b.Cim));

            dgFilmek.ItemsSource = null;
            dgFilmek.ItemsSource = lista;
        }

        private void dgFilmek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Film kivalasztott = dgFilmek.SelectedItem as Film;
            if (kivalasztott != null)
            {
                MessageBox.Show("Kiválasztott film: " + kivalasztott.Cim + "\nÉrtékelés: " + kivalasztott.Ertekeles);
            }
        }
    }
}