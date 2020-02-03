using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Mieszkaniec
    {
        private int id;
        private string imie;
        private string nazwisko;
        private string opis;
        private string zdjecie;

        public void Wczytaj(int id)
        {
            this.id = id;
            imie = DBCommand.Imie(id);
            nazwisko = DBCommand.Nazwisko(id);
            opis = DBCommand.Informacje(id);
            zdjecie = DBCommand.Sciezka(id);
        }

        public int ID()
        {
            return id;
        }
        public string SetNazwa()
        {
            return imie + " " + nazwisko;
        }

        public string SetOpis()
        {
            return opis;
        }

        public string SetZdjecie()
        {
            return zdjecie;
        }
    }
}
