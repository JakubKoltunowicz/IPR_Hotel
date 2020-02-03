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
using System.IO;

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class OknoGlowne : Window
    {
        public OknoGlowne()
        {   
            InitializeComponent();
            Random rnd = new Random();
            string path1, path2, path;
            int liczba_mieszkancow, liczba;
            ZarzadMieszkancami zarzad_mieszkancami = new ZarzadMieszkancami();

            path1 = Directory.GetCurrentDirectory();
            liczba_mieszkancow = DBCommand.ID();
            liczba = rnd.Next(1, liczba_mieszkancow + 1);
            zarzad_mieszkancami.StworzMieszkanca(liczba);
            Imie_nazwisko.Content = zarzad_mieszkancami.WyswietlNazwe();
            Pozostale_informacje.Content = zarzad_mieszkancami.WyswietlOpis();
            path2 = zarzad_mieszkancami.WyswietlZdjecie();
            path = path1 + path2;

            if (System.IO.File.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                {
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.StreamSource = stream;
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    this.Image.Source = bmp;
                }
            }
            else
            {
                Image.Source = null;
            }
        }

        private void Ustawienia_mieszkancow_Click(object sender, RoutedEventArgs e)
        {
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }

        private void Parking_Click(object sender, RoutedEventArgs e)
        {
            OknoParking okno_parking = new OknoParking();
            okno_parking.Show();
            this.Close();
        }

        private void Interkorm_Click(object sender, RoutedEventArgs e)
        {
            OknoInterkom okno_interkom = new OknoInterkom();
            okno_interkom.Show();
            this.Close();
        }

        private void Otworz_bramke_parkingowa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Brama parkingowa została otworzona.");
        }

        private void Otworz_drzwi_wind_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Drzwi windy zostały otworzone.");
        }

        private void Otworz_drzwi_wejsciowe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Drzwi wejściowe zostały otworzone.");
        }
    }
}