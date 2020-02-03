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
using System.Windows.Shapes;
using System.IO;

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy OknoMieszkancy.xaml
    /// </summary>
    public partial class OknoMieszkancy : Window
    {
        private int wybranyMieszkaniec;

        ZarzadMieszkancami zarzadzanie = new ZarzadMieszkancami();
        public OknoMieszkancy()
        {
            InitializeComponent();
        }

        private void Okno_glowne_Click(object sender, RoutedEventArgs e)
        {
            OknoGlowne okno_glowne = new OknoGlowne();
            okno_glowne.Show();
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

        private void Edytuj_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            OknoUstawianieZdjecia okno_ustawianie_zdjecia = new OknoUstawianieZdjecia(wybranyMieszkaniec);
            okno_ustawianie_zdjecia.Show();
            this.Close();
        }

        private void Zapisz_zmiany_Click(object sender, RoutedEventArgs e)
        {
            string zmiany = Pozostale_informacje.Text;
            zarzadzanie.ZmienOpis(zmiany);
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }

        private void Odrzuc_zmiany_Click(object sender, RoutedEventArgs e)
        {
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }

        private void Lista_mieszkancow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path1, path2, path;
            path1 = Directory.GetCurrentDirectory();
            string dane = (sender as ComboBox).SelectedItem as string;
            string[] id = dane.Split('.');
            wybranyMieszkaniec = Int32.Parse(id[0]);
            zarzadzanie.StworzMieszkanca(wybranyMieszkaniec);
            Imie_Nazwisko.Text = zarzadzanie.WyswietlNazwe();
            Pozostale_informacje.Text = zarzadzanie.WyswietlOpis();

            path2 = zarzadzanie.WyswietlZdjecie();
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

        private void Pozostale_informacje_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Pozostale_informacje.IsReadOnly = false;
            }
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data = zarzadzanie.ZaladujlListe();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            //comboBox.SelectedIndex = 0;
        }
    }
}
