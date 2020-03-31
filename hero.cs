namespace Bureck___The_Game
{
    public partial class MainWindow
    {
        //======================================================================================KLASA HERO=================================================================================
        class hero
        {
            protected string name;
            protected int str;
            protected int mbl;
            protected int wis;
            protected int hp;
            protected int armor;
            protected int xp;

            public hero()
            {
                name = "Ty";
                str = 1;
                mbl = 1;
                wis = 1;
                hp = 50;
                armor = 0;
                xp = -10;
            }

            public int Xp
            {
                get { return xp; }
                set { xp = value; }
            }

            public int Hp
            {
                get { return hp; }
                set { hp = value; }
            }

            public int Str
            {
                get { return str; }
                set { str = value; }
            }

            public int Mbl
            {
                get { return mbl; }
                set { mbl = value; }
            }

            public int Wis
            {
                get { return wis; }
                set { wis = value; }
            }

            public int Armor
            {
                get { return armor; }
                set { armor = value; }
            }

            public string Name
            {
                get { return name; }
            }

            public void enemy(details details)
            {
                this.name = details.name;
                this.str = details.str;
                this.mbl = details.mbl;
                this.wis = details.wis;
                this.hp = details.hp;
                this.armor = details.armor;
                this.xp = details.xp;  
            }

            public void lvlup(int x)
            {
                switch (x)
                {
                    case 1:
                        str += 1;
                        break;
                    case 2:
                        mbl += 1;
                        break;
                    case 3:
                        wis += 1;
                        break;
                    case 4:
                        hp += 1;
                        break;
                }
            }
            public int retstat(int x)
            {
                int y;
                switch (x)
                {
                    case 1:
                        y = str;
                        break;
                    case 2:
                        y = mbl;
                        break;
                    case 3:
                        y = wis;
                        break;
                    case 4:
                        y = hp;
                        break;
                    case 5:
                        y = armor;
                        break;
                    default:
                        y = 0;
                        break;
                }
                return y;
            }

            public class details
            {
                public string name;
                public int str;
                public int mbl;
                public int wis;
                public int hp;
                public int armor;
                public int xp;

                public details(string name, int str, int mbl, int wis, int hp, int armor, int xp)
                {
                this.name = name;
                this.str = str;
                this.mbl = mbl;
                this.wis = wis;
                this.hp = hp;
                this.armor = armor;
                this.xp = xp;  
                }
            }
        }

        
    }
}
