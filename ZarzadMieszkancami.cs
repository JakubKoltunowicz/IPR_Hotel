using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hotel
{
    class ZarzadMieszkancami
    {

        Mieszkaniec mieszkaniec = new Mieszkaniec();
        public void StworzMieszkanca(int id)
        {
            mieszkaniec.Wczytaj(id);
        }

        public string WyswietlNazwe()
        {
            string nazwa = mieszkaniec.SetNazwa();
            return nazwa;
        }
        public string WyswietlOpis()
        {
            string opis = mieszkaniec.SetOpis();
            return opis;
        }

        public string WyswietlZdjecie()
        {
            string zdjecie = mieszkaniec.SetZdjecie();
            return zdjecie;
        }

        public void ZmienOpis(string zmiany)
        {
            int id = mieszkaniec.ID();
            DBCommand.Aktualizacja_danych(zmiany, id);
        }
        
        public void ZmienZdjecie(int id, string zrodl_zdjecia)
        {
            string sciezka = DBCommand.Sciezka(id);
            string path = Directory.GetCurrentDirectory() + "\\" + id + ".png";
            if (sciezka == "\\")
            {
                string path1 = id + ".png";
                if (System.IO.File.Exists(zrodl_zdjecia))
                {
                    try
                    {
                        System.IO.File.Copy(zrodl_zdjecia, path, true);
                    }
                    catch (System.IO.IOException w)
                    {
                        Console.WriteLine(w.Message);
                        return;
                    }
                    DBCommand.Aktualizacja(path1, id);
                }
            }
        }

        public void UsunZdjecie(int id)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + id + ".png";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException w)
                {
                    Console.WriteLine(w.Message);
                    return;
                }
                DBCommand.Delete_picture(id);
            }
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
