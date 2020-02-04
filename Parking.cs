using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Parking
    {
        MiejsceParkingowe miejsce_parkingowe = new MiejsceParkingowe();
        private List<string> wolne_miejsca = new List<string>();
        private int liczba_miejsc, liczba_rezerwacji, dostepnosc;
        private string poczatek_bazy, koniec_bazy;
        private int miejsce_parkingowe_bazy;
        private DateTime poczatek_parse, koniec_parse, poczatek_bazy_parse, koniec_bazy_parse;

        public List<string> PokazWolne(string poczatek, string koniec)
        {
            poczatek_parse = DateTime.Parse(poczatek);
            koniec_parse = DateTime.Parse(koniec);
            liczba_miejsc =  DBCommand.ID_miejsca();
            liczba_rezerwacji = DBCommand.ID_rezerwacji();
            for(int i=1; i<=liczba_miejsc; i++)
            {
                dostepnosc = 1;

                for(int j=1; j<=liczba_rezerwacji; j++)
                {
                    miejsce_parkingowe_bazy = DBCommand.ID_miejsca_parkingowego(j);
                    poczatek_bazy = DBCommand.Poczatek(j);
                    poczatek_bazy_parse = DateTime.Parse(poczatek_bazy);
                    koniec_bazy = DBCommand.Koniec(j);
                    koniec_bazy_parse = DateTime.Parse(koniec_bazy);
                    if (i==miejsce_parkingowe_bazy)
                    {
                        if (((poczatek_parse>=poczatek_bazy_parse)&&(poczatek_parse<=koniec_bazy_parse))||((koniec_parse>=poczatek_bazy_parse)&&(koniec_parse<=koniec_bazy_parse))||((poczatek_parse<=poczatek_bazy_parse)&&(koniec_parse>=koniec_bazy_parse)))
                        {
                            dostepnosc = 0;
                        }
                    }
                }
                if(dostepnosc == 1)
                {
                    wolne_miejsca.Add("" + i + "");
                }
            }
            
            return wolne_miejsca;
        }

        public void DodajRezerwacje(string poczatek_rezerwacji, string koniec_rezerwacji, int ID_miejsca, string rezerwujacy)
        {
            DBCommand.Dodawanie_rezerwacji(poczatek_rezerwacji, koniec_rezerwacji, ID_miejsca, rezerwujacy);
        }
    }
}
