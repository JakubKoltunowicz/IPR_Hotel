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
    /// Logika interakcji dla klasy OknoUstawianieZdjecia.xaml
    /// </summary>
    public partial class OknoUstawianieZdjecia : Window
    {
        private int wybranyMieszkaniec;

        ZarzadMieszkancami zarzadzanie = new ZarzadMieszkancami();
        public OknoUstawianieZdjecia(int wybranyMieszkaniec)
        {
            InitializeComponent();
            this.wybranyMieszkaniec = wybranyMieszkaniec;
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }

        private void Ustaw_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            string sciezka_zdjecia = Sciezka_zdjecia.Text;
            zarzadzanie.ZmienZdjecie(wybranyMieszkaniec, sciezka_zdjecia);
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }

        private void Usun_zdjecie_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanie.UsunZdjecie(wybranyMieszkaniec);
            OknoMieszkancy okno_mieszkancy = new OknoMieszkancy();
            okno_mieszkancy.Show();
            this.Close();
        }
    }
}
