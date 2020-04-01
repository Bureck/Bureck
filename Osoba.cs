using System;

namespace Bureck___The_Game
{
    public partial class MainWindow
    {
        //================================================================================KLASA OSOBA=================================================================================
        class Osoba
        {
            protected string name;
            protected int OsId;
            protected int option;

            public Osoba(int x)
            {
                OsId = x;
                switch (x)
                {
                    case 0:
                        name = "Bureck";
                        break;
                    case 1:
                        name = "Frycu";
                        break;
                    case 2:
                        name = "Wojtenfall";
                        break;
                    case 3:
                        name = "Złodziej drzew";
                        break;
                }
                option = 0;
            }

            public String Name
            {
                get { return name; }
            }

            public int Option
            {
                get { return option; }
                set { option = value; }
            }
        }

        
    }
}
