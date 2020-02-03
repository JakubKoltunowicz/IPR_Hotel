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

namespace Hotel
{
    /// <summary>
    /// Logika interakcji dla klasy OknoInterkom.xaml
    /// </summary>
    public partial class OknoInterkom : Window
    {
        Interkom interkom = new Interkom();
        public OknoInterkom()
        {
            InitializeComponent();
        }

        private void Okno_glowne_Click(object sender, RoutedEventArgs e)
        {
            OknoGlowne okno_glowne = new OknoGlowne();
            okno_glowne.Show();
            this.Close();
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

        private void Wyslij_wiadomosc_Click(object sender, RoutedEventArgs e)
        {
            interkom.WyslijWiadomosc(Wiadomosc.Text);
            Wiadomosc.Text = String.Empty;
            MessageBox.Show("Wiadomość została wysłana.");
        }

        private void Zadzwon_do_mieszkania_Click(object sender, RoutedEventArgs e)
        {
            interkom.Zadzwon();
            MessageBox.Show("Dzwonię.");
        }

        private void Lista_mieszkancow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dane = (sender as ComboBox).SelectedItem as string;
            string[] id = dane.Split('.');
            int result = Int32.Parse(id[0]);
            interkom.UstawMieszkanca(result);
            Imie_Nazwisko.Content = id[1];
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data = interkom.ZaladujlListe();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
    }
}
