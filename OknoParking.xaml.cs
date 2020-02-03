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
    }
}
