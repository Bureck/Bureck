using System.Data.SqlClient;

namespace Bureck___The_Game
{
    public partial class MainWindow
    {
        class equip
        {
            protected string nazwa;
            protected bool exist;
            protected bool used;
            protected int cena;
            protected int itemtype;
            protected int bonustype;
            protected int bonus;
            protected int id;

            public equip()
            {
                exist = false;
                nazwa = "brak";
                used = false;
            }

            public int ID
            {
                get { return id; }
            }

            public int Bon
            {
                get { return bonus; }
            }

            public int Typ
            {
                get { return bonustype; }
            }

            public bool Exist
            {
                get { return exist; }
            }

            public int Type
            {
                get { return itemtype; }
            }

            public bool Used
            {
                get { return used; }
                set { used = value; }
            }

            public bool sell()
            {
                bool wynik = true;
                if (used == false)
                {
                    exist = false;
                    nazwa = "brak";
                }
                else
                    wynik = false;
                return wynik;
            }

            public int Cena
            {
                set { cena = value; }
                get { return cena; }
            }

            public void newitem(details details)
            {
                this.nazwa = details.nazwa;
                this.cena = details.cena;
                this.itemtype = details.itemtype;
                this.bonustype = details.bonustype;
                this.bonus = details.bonus;
                this.id = details.id;
                this.exist = true;
            }

            public string check()
            {
                string opis;
                opis = "Nazwa: ";
                opis += nazwa.ToString();

                return opis;
            }
            public string check2()
            {
                string opis;
                opis = "bonus: +";
                opis += bonus.ToString();
                switch (bonustype)
                {
                    case 1:
                        opis += " siły";
                        break;
                    case 2:
                        opis += " zręczności";
                        break;
                    case 3:
                        opis += " inteligencji";
                        break;
                    case 4:
                        opis += " HP";
                        break;
                    case 5:
                        opis += " pancerza";
                        break;
                    case 6:
                        opis += " ataku";
                        break;
                }

                return opis;
            }
            public string check3()
            {
                string opis;
                opis = "Cena: ";
                opis += cena.ToString();

                return opis;
            }
            public string check4()
            {
                string opis = "";
                switch (itemtype)
                {
                    case 0:
                        opis = "broń";
                        break;
                    case 1:
                        opis = "zbroja";
                        break;
                    case 2:
                        opis = "buty";
                        break;
                }
                return opis;
            }

            public class details
            {
                public string nazwa;
                public int cena;
                public int itemtype;
                public int bonustype;
                public int bonus;
                public int id;

                public details(string nazwa, int cena, int itemtype, int bonustype, int bonus, int id)
                {
                    this.nazwa = nazwa;
                    this.cena = cena;
                    this.itemtype = itemtype;
                    this.bonustype = bonustype;
                    this.bonus = bonus;
                    this.id = id;
                }
            }
        }


    }

}
