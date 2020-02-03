using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Interkom
    {
        private int wybranyMieszkaniec;

        public void UstawMieszkanca(int id)
        {
            wybranyMieszkaniec = id;
        }

        public void WyslijWiadomosc(string wiadomosc)
        {

        }

        public void Zadzwon()
        {

        }

        public List<string> ZaladujlListe()
        {
            List<string> data = new List<string>();
            int number = DBCommand.ID();
            int id;
            string dane, imie, nazwisko;
            for (int i = 1; i <= number; i++)
            {
                imie = DBCommand.Imie(i);
                nazwisko = DBCommand.Nazwisko(i);
                id = DBCommand.ID_po_imieniu(imie);
                dane = id + ". " + imie + " " + nazwisko;
                data.Add(dane);
            }
            return data;
        }
    }
}
