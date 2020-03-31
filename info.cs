namespace Bureck___The_Game
{
    public partial class MainWindow
    {
        //===============================================================================KLASA INFO=============================================================================
        class info
        {
            protected int miejsce;
            protected int czynnosc;

            public int Miejsce
            {
                get { return miejsce; }
                set { miejsce = value; }
            }
            public int Czynnosc
            {
                get { return czynnosc; }
                set { czynnosc = value; }
            }

            public info()
            {
                miejsce = 0;
                czynnosc = 0;
            }
        }

        
    }
}
