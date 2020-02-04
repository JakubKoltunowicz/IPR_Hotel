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
    /// Logika interakcji dla klasy OknoParking.xaml
    /// </summary>
    public partial class OknoParking : Window
    {
        private Parking parking = new Parking();
        private List<string> lista_miejsc = new List<string>();
        private int ID_miejsca;
        private string poczatek_rezerwacji;
        private string koniec_rezerwacji;
        private string rezerwujacy;

        public OknoParking()
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

        private void Interkorm_Click(object sender, RoutedEventArgs e)
        {
            OknoInterkom okno_interkom = new OknoInterkom();
            okno_interkom.Show();
            this.Close();
        }
        private void Lista_miejsc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dane = (sender as ListBox).SelectedItem as string;
            ID_miejsca = Int32.Parse(dane);
        }
        
        private void Dodawanie_rezerwacji_Click(object sender, RoutedEventArgs e)
        {
            poczatek_rezerwacji = textBox_poczatek.Text;
            koniec_rezerwacji = textBox_koniec.Text;
            rezerwujacy = Rezerwujacy.Text;
            parking.DodajRezerwacje(poczatek_rezerwacji, koniec_rezerwacji, ID_miejsca, rezerwujacy);
        }
        
        private void Wolne_Click(object sender, RoutedEventArgs e)
        {
            poczatek_rezerwacji = textBox_poczatek.Text;
            koniec_rezerwacji = textBox_koniec.Text;
            lista_miejsc = parking.PokazWolne(poczatek_rezerwacji, koniec_rezerwacji);
            listBox.ItemsSource = lista_miejsc;
        }

        private void Nowe_Click(object sender, RoutedEventArgs e)
        {
            OknoParking okno_parking = new OknoParking();
            okno_parking.Show();
            this.Close();
        }
    }
}
