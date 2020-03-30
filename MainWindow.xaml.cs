using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bureck___The_Game
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //===============================================================================KLASA MIEJSCE=========================================================================
        class places
        {
            protected bool available;

            public bool Available
            {
                get { return available; }
                set { available = value; }
            }

            public places()
            {
                available = false;
            }
        }
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
                        option = 0;
                        break;
                    case 1:
                        name = "Frycu";
                        option = 0;
                        break;
                    case 2:
                        name = "Wojtenfall";
                        option = 0;
                        break;
                }
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

            public void enemy(int x)
            {
                switch (x)
                {
                    case 0:
                        name = "manekin treningowy";
                        str = 0;
                        mbl = 0;
                        wis = 0;
                        hp = 50;
                        armor = 0;
                        xp = 10;
                        break;
                    case 1:
                        name = "bandyta";
                        str = 2;
                        mbl = 1;
                        wis = 0;
                        hp = 60;
                        armor = 2;
                        xp = 5;
                        break;
                }
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

        }
        //important szit======================================================================================================================================================================

        SqlConnection connection;

        hero bohater = new hero();
        hero oponent = new hero();

        info stan = new info();

        int gold = 0;
        int but1;
        int but2;
        int kryt;
        int maxhp = 50;
        int pu = 0;
        int xpneed;
        int lvl = 0;
        int who;
        int attackbonus=0;
        string komunikat = "start";
        Osoba Bureck = new Osoba(0);
        Osoba Frycu = new Osoba(1);
        Osoba Wojten = new Osoba(2);

        Random rnd = new Random();

        places farmaCheck = new places();
        places ridoCheck = new places();
        places goraCheck = new places();

        equip shopitem = new equip();
        equip item1 = new equip();
        equip item2 = new equip();
        equip item3 = new equip();
        equip item4 = new equip();
        equip item5 = new equip();
        equip item6 = new equip();
        equip item7 = new equip();
        equip item8 = new equip();
        equip item9 = new equip();

        bool slot0 = false;
        bool slot1 = false;
        bool slot2 = false;
        //end of important szit

        public MainWindow()
        {
            InitializeComponent();

            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            connection.Open();

            strbox.Text = bohater.Str.ToString();
            mblbox.Text = bohater.Mbl.ToString();
            intbox.Text = bohater.Wis.ToString();
            hpbox.Text = bohater.Hp.ToString();
            armbox.Text = bohater.Armor.ToString();
            zloto.Text = gold.ToString();
            wyswietlacz.Visibility = Visibility.Visible;
            rozmowa1.Visibility = Visibility.Visible;
            wyswietlacz.Text = "Nadszedł kolejny dzień pracy na farmie. Pomimo tego, że jej właściciel całkiem nieźle Ci za tą pracę płaci, to czujesz, że nie chcesz robić tego do końca życia. Ten dzień, jak każdy inny zaczynasz od ćwiczeń walki.";
            rozmowa1.Text = "Kontynuuj";
            but1 = 0;
            farmaCheck.Available = true;

           
        }

        //============================================================================DODAWANIE PUNKTÓW DO STATYSTYK===================================================================
        private void Addstr(object sender, MouseButtonEventArgs e)
        {
            bohater.lvlup(1);
            strbox.Text = bohater.Str.ToString();
            pu -= 1;
            if (pu <= 0)
            {
                strplus.Visibility = Visibility.Collapsed;
                mblplus.Visibility = Visibility.Collapsed;
                intplus.Visibility = Visibility.Collapsed;
            }

        }

        private void Addmbl(object sender, MouseButtonEventArgs e)
        {
            bohater.lvlup(2);
            mblbox.Text = bohater.Mbl.ToString();
            pu -= 1;
            if (pu <= 0)
            {
                strplus.Visibility = Visibility.Collapsed;
                mblplus.Visibility = Visibility.Collapsed;
                intplus.Visibility = Visibility.Collapsed;
            }
        }

        private void Addint(object sender, MouseButtonEventArgs e)
        {
            bohater.lvlup(3);
            intbox.Text = bohater.Wis.ToString();
            pu -= 1;
            if (pu <= 0)
            {
                strplus.Visibility = Visibility.Collapsed;
                mblplus.Visibility = Visibility.Collapsed;
                intplus.Visibility = Visibility.Collapsed;
            }
        }
        //===============================================================================BUTTONY WALKI=====================================================================
        private void fight1(object sender, MouseButtonEventArgs e)
        {
            int trafienie = bohater.Mbl + oponent.Mbl + 5;
            int test;
            test = rnd.Next(1, trafienie);
            if (test >= oponent.Mbl)
            {
                int atack;
                kryt = rnd.Next(1, 50);
                if (kryt <= bohater.Str)
                {
                    atack = 2 * bohater.Str;
                    komunikat = "Obrażenia krytyczne! ";
                }
                else
                {
                    atack = bohater.Str;
                    komunikat = "";
                }
                atack *= 5;
                atack += attackbonus;
                atack -= oponent.Str;
                atack -= oponent.Armor;
                komunikat += "Zadałeś przeciwnikowi ";
                komunikat += atack;
                komunikat += " obrażeń!";
                oponent.Hp -= atack;
            }
            else
                komunikat = "Twój atak nie trafił!";
            checkStateFight();
        }

        private void fight2(object sender, MouseButtonEventArgs e)
        {
            magic.Visibility = Visibility.Visible;
            closemagic.Visibility = Visibility.Visible;
            wyswietlacz.Visibility = Visibility.Collapsed;
            walka1.Visibility = Visibility.Collapsed;
            walka2.Visibility = Visibility.Collapsed;
        }

        private void fight3(object sender, MouseButtonEventArgs e)
        {

        }
        //==================================================================================BUTTONY ROZMOWY========================================================================================
        private void talk1(object sender, MouseButtonEventArgs e)
        {
            checkStateTalk(but1);
        }

        private void talk2(object sender, MouseButtonEventArgs e)
        {
            checkStateTalk(but2);
        }

        private void talk3(object sender, MouseButtonEventArgs e)
        {
            if (stan.Czynnosc != 2)
                talkend();
            else
                checkStateTalk(7);
        }

        private void zamknijmagie(object sender, MouseButtonEventArgs e)
        {
            magic.Visibility = Visibility.Collapsed;
            closemagic.Visibility = Visibility.Collapsed;
            wyswietlacz.Visibility = Visibility.Visible;
            walka1.Visibility = Visibility.Visible;
            walka2.Visibility = Visibility.Visible;
        }
        //================================================================================CHECK STATE TALK=======================================================================================
        void checkStateTalk(int optID)
        {
            switch (optID)
            {
                case 0:
                    //ROZPOCZECIE GRY
                    who = 0;
                    wyswietlacz.Text = "Stajesz przed potężnym manekinem treningowym. Nie zada Ci obrażeń, więc jest szansa, że uda Ci się go pokonać.";
                    fightstart();
                    break;
                case 1:
                    //ZWYCIĘSTWO W WALCE
                    bohater.Xp += oponent.Xp;
                    if (bohater.Xp >= 0)
                    {
                        pu += 2;
                        lvl += 1;
                        bohater.Xp -= lvl * 30;
                        bohater.Hp += lvl * 15;
                        hpbox.Text = bohater.Hp.ToString();
                        maxhp = bohater.Hp;
                        strplus.Visibility = Visibility.Visible;
                        mblplus.Visibility = Visibility.Visible;
                        intplus.Visibility = Visibility.Visible;
                        wyswietlacz.Text = "Uzyskałeś nowy poziom doświadczenia!";
                    }
                    else
                    {
                        xpneed = 0;
                        xpneed -= bohater.Xp;
                        komunikat = "Do następnego poziomu pozostało ";
                        komunikat += xpneed;
                        komunikat += " punktów doświadczenia";
                        wyswietlacz.Text = komunikat;
                    }
                    but1 = 3;
                    break;
                case 2:
                    //PRZEGRANA W WALCE
                    wyswietlacz.Text = "Wracasz na farmę, by wyleczyć rany.";
                    stan.Miejsce = 0;
                    but1 = 3;
                    break;
                case 3:
                    //Powrót z walki lub rozmowy do normalnej rozgrywki
                    checkstateplace();
                    break;
                case 4:
                    //Początek wątku Burecka
                    wyswietlacz.Text = "W takim razie idź sobie wreszcie kupić jakiś miecz. Masz tu 30 sztuk złota, powinno wystarczyć. W mieście Rido, niedaleko stąd mam znajomego kowala. Poznasz go po tym, że jest jeszcze bardziej łysy niż ja sam. Zaznaczyłem Ci to miasto na mapie. Jak już kupisz ten miecz to wróć do mnie.";
                    gold += 30;
                    zloto.Text = gold.ToString();
                    rozmowa1.Visibility = Visibility.Collapsed;
                    Bureck.Option = 1;
                    ridoCheck.Available = true;
                    break;
                case 5:
                    //wstępny wątek Fryca
                    Frycu.Option += 1;
                    Frycutalk();
                    break;
                case 6:
                    //HANDEL z Frycem
                    shop1.Visibility = Visibility.Visible;
                    shop2.Visibility = Visibility.Visible;
                    shop3.Visibility = Visibility.Visible;
                    wyswietlacz.Visibility = Visibility.Collapsed;
                    rozmowa1.Visibility = Visibility.Collapsed;
                    rozmowa3.Text = "cofnij";
                    stan.Czynnosc = 2;
                    break;
                case 7:
                    //koniec handlu z Frycem
                    shop1.Visibility = Visibility.Collapsed;
                    shop2.Visibility = Visibility.Collapsed;
                    shop3.Visibility = Visibility.Collapsed;
                    wyswietlacz.Visibility = Visibility.Visible;
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa3.Text = "Żegnam";
                    stan.Czynnosc = 0;
                    break;
                case 8:
                    //dalszy wątek Burecka
                    Bureck.Option += 1;
                    Burecktalk();
                    break;
                case 9:
                    //WątekFall błąd
                    if (Wojten.Option == 3)
                        Wojten.Option = 0;
                    else
                        Wojten.Option += 1;
                    Wojtentalk();
                    break;
                case 10:
                    //WątekFall sukces
                    Wojten.Option = 4;
                    Wojtentalk();
                    break;
                case 11:
                    //WątekFall część dalsza
                    Wojten.Option += 1;
                    Wojtentalk();
                    break;
            }
        }
        //==================================================================================CHECK STATE FIGHT=========================================================================================
        void checkStateFight()
        {
            int atack;
            enemyhp.Text = oponent.Hp.ToString();
            if (oponent.Hp > 0)
            {
                int trafienie = bohater.Mbl + oponent.Mbl + 5;
                int test;
                test = rnd.Next(1, trafienie);
                if (test >= bohater.Mbl)
                {
                    kryt = rnd.Next(1, 50);
                    if (kryt <= oponent.Str)
                    {
                        atack = 2 * oponent.Str;
                        komunikat += " Przeciwnik zadaje obrażenia krytyczne o wartości ";
                    }
                    else
                    {
                        atack = oponent.Str;
                        komunikat += " Przeciwnik zadaje obrażenia o wartości ";
                    }
                    atack *= 5;
                    if (atack > 0)
                    {
                        atack -= bohater.Str;
                        atack -= bohater.Armor;
                    }
                    komunikat += atack.ToString();
                    bohater.Hp -= atack;
                    if (bohater.Hp <= 0)
                    {
                        komunikat += " Padasz na ziemie nieprzytomny.";
                        wyswietlacz.Text = komunikat;
                        but1 = 2;
                        fightend();
                    }
                    else
                        wyswietlacz.Text = komunikat;
                }
                else
                {
                    komunikat += " Atak przeciwnika nie trafił!";
                    wyswietlacz.Text = komunikat;
                }
            }
            else
            {
                komunikat += " Przeciwnik pada na ziemie nieprzytomny.";
                wyswietlacz.Text = komunikat;
                but1 = 1;
                fightend();
            }
            hpbox.Text = bohater.Hp.ToString();
        }
        //====================================================================================CHECK STATE PLACE==================================================================================
        void checkstateplace()
        {
            wyswietlacz.Visibility = Visibility.Collapsed;
            rozmowa1.Visibility = Visibility.Collapsed;
            rozmowa2.Visibility = Visibility.Collapsed;
            rozmowa3.Visibility = Visibility.Collapsed;
            mapicon.Visibility = Visibility.Visible;
            switch (stan.Miejsce)
            {
                case 0:
                    farma.Visibility = Visibility.Visible;
                    bureckbutton.Visibility = Visibility.Visible;
                    break;
                case 1:
                    rido.Visibility = Visibility.Visible;
                    Frycubutton.Visibility = Visibility.Visible;
                    ridoFarm.Visibility = Visibility.Visible;
                    break;
                case 2:
                    gora.Visibility = Visibility.Visible;
                    wojten_icon.Visibility = Visibility.Visible;
                    gorafarm.Visibility = Visibility.Visible;
                    break;
            }
        }
        //==================================================================================FIGHT START I END===================================================================================
        void fightstart()
        {
            oponent.enemy(who);
            mapicon.Visibility = Visibility.Collapsed;
            rozmowa1.Visibility = Visibility.Collapsed;
            rozmowa2.Visibility = Visibility.Collapsed;
            rozmowa3.Visibility = Visibility.Collapsed;
            wyswietlacz.Visibility = Visibility.Visible;
            walka1.Visibility = Visibility.Visible;
            walka2.Visibility = Visibility.Visible;
            walka1.Text = "Atak zwykły";
            walka2.Text = "Atak specjalny";
            enemyhp.Visibility = Visibility.Visible;
            enemyhp.Text = oponent.Hp.ToString();
            talkenemyname.Visibility = Visibility.Visible;
            talkenemyname.Text = oponent.Name;
            switch (who)
            {
                case 0:
                    dummy.Visibility = Visibility.Visible;
                    break;
                case 1:
                    wyswietlacz.Text = "W ciemnym zaułku spotykasz agresywnego mężczyznę mongolskiego pochodzenia.";
                    rido.Visibility = Visibility.Collapsed;
                    Frycubutton.Visibility = Visibility.Collapsed;
                    ridoFarm.Visibility = Visibility.Collapsed;
                    bandyta.Visibility = Visibility.Visible;
                    break;
            }
            stan.Czynnosc = 1;
        }

        void fightend()
        {
            switch (who)
            {
                case 0:
                    dummy.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    bandyta.Visibility = Visibility.Collapsed;
                    if (Frycu.Option == 4)
                        Frycu.Option += 1;
                    break;
            }
            rozmowa1.Visibility = Visibility.Visible;
            walka1.Visibility = Visibility.Collapsed;
            walka2.Visibility = Visibility.Collapsed;
            talkenemyname.Visibility = Visibility.Collapsed;
            enemyhp.Visibility = Visibility.Collapsed;
            rozmowa1.Text = "Kontynuuj";
            bohater.Hp = maxhp;
        }
        //============================================================================================TALK START I END================================================================================
        void talkstart()
        {
            wyswietlacz.Visibility = Visibility.Visible;
            rozmowa3.Visibility = Visibility.Visible;
            mapicon.Visibility = Visibility.Collapsed;
            talkenemyname.Visibility = Visibility.Visible;
            switch (who)
            {
                case 0:
                    Bureckface.Visibility = Visibility.Visible;
                    talkenemyname.Text = Bureck.Name;
                    farma.Visibility = Visibility.Collapsed;
                    bureckbutton.Visibility = Visibility.Collapsed;
                    if (Bureck.Option == 0)
                        wyswietlacz.Text = "Okładanie tego manekina pięściami jeszcze Ci się nie znudziło?";
                    else
                        wyswietlacz.Text = "Słucham Cie chłopcze";
                    break;
                case 1:
                    ridoFarm.Visibility = Visibility.Collapsed;
                    FrycuFace.Visibility = Visibility.Visible;
                    talkenemyname.Text = Frycu.Name;
                    rido.Visibility = Visibility.Collapsed;
                    Frycubutton.Visibility = Visibility.Collapsed;
                    wyswietlacz.Text = "Witam.";
                    break;
                case 2:
                    gorafarm.Visibility = Visibility.Collapsed;
                    wojtenface.Visibility = Visibility.Visible;
                    talkenemyname.Text = Wojten.Name;
                    gora.Visibility = Visibility.Collapsed;
                    wojten_icon.Visibility = Visibility.Collapsed;
                    wyswietlacz.Text = "...";
                    break;
            }
        }

        void talkend()
        {
            switch (who)
            {
                case 0:
                    Bureckface.Visibility = Visibility.Collapsed;
                    talkenemyname.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    FrycuFace.Visibility = Visibility.Collapsed;
                    talkenemyname.Visibility = Visibility.Collapsed;
                    if (Frycu.Option < 4)
                        Frycu.Option = 0;
                    break;
                case 2:
                    wojtenface.Visibility = Visibility.Collapsed;
                    talkenemyname.Visibility = Visibility.Collapsed;
                    break;
            }
            checkstateplace();
        }
        //===================================================================================OPEN MAP========================================================================================
        private void openmap(object sender, MouseButtonEventArgs e)
        {
            if (mapsko.Visibility == Visibility.Visible)
            {
                mapsko.Visibility = Visibility.Collapsed;
                mapafarma.Visibility = Visibility.Collapsed;
                maparido.Visibility = Visibility.Collapsed;
                mapagora.Visibility = Visibility.Collapsed;
            }
            else
            {
                mapsko.Visibility = Visibility.Visible;
                if (farmaCheck.Available == true)
                    mapafarma.Visibility = Visibility.Visible;
                if (ridoCheck.Available == true)
                    maparido.Visibility = Visibility.Visible;
                if (goraCheck.Available == true)
                    mapagora.Visibility = Visibility.Visible;
                    
            }
        }
        //===================================================================================TALK TO BURECK=================================================================================
        private void talkToBureck(object sender, MouseButtonEventArgs e)
        {
            who = 0;
            talkstart();
            Burecktalk();
        }

        void Burecktalk()
        {
            switch (Bureck.Option)
            {
                case 0:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "Otóż nie";
                    but1 = 4;
                    break;
                case 1:
                    break;
                case 2:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "Wróciłem z Rido";
                    but1 = 8;
                    break;
                case 3:
                    wyswietlacz.Text = "W takim razie nadszedł czas, byś zaczął podążać własną ścieżką. Nie martw się, będziesz wiedział gdzie się udać.";
                    rozmowa1.Text = "Tak też uczynie";
                    but1 = 8;
                    break;
                case 4:
                    wyswietlacz.Text = "...";
                    rozmowa1.Visibility = Visibility.Collapsed;
                    goraCheck.Available = true;
                    break;
            }
        }
        //===================================================================================TALK TO FRYCU====================================================================================
        private void talkToFrycu(object sender, MouseButtonEventArgs e)
        {
            who = 1;
            talkstart();
            Frycutalk();
        }

        void Frycutalk()
        {
            switch (Frycu.Option)
            {
                case 0:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "Łał, Twoja łysina jest niepodważalnie zjawiskowa!";
                    but1 = 5;
                    break;
                case 1:
                    wyswietlacz.Text = "Jestem tego świadomy, słyszę to regularnie. W jakim celu tu przybywasz?";
                    rozmowa1.Text = "Chce kupić miecz, za 30 złotych monet";
                    break;
                case 2:
                    wyswietlacz.Text = "Łaknę Ci pomóc, niemniej jednak koszt wykutego przez moją osobę ostrza wynosi 50 sztuk złota.";
                    rozmowa1.Text = "Kiedy ja mam tylko 30";
                    break;
                case 3:
                    wyswietlacz.Text = "Mam więc inną propozycje. Za moją pracownią znajduje się ciemny zaułek. W takich miejscach zawsze można natrafić na niebezpieczeństwo. Dowiedz się co tam jest i się tego pozbądź a obniżę cenę miecza do 30.";
                    rozmowa1.Visibility = Visibility.Collapsed;
                    Frycu.Option += 1;
                    break;
                case 4:
                    break;
                case 5:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "Pozbyłem się bandyty zza Twojej kuźni";
                    but1 = 5;
                    break;
                case 6:
                    wyswietlacz.Text = "Wielce mnie to raduje. Możesz ponowić wędrówkę w to miejsce w celu rozbudowy Twych sprawności. W innych obszarach też można napotkać takie ciemne zaułki. Ja tymczasem dotrzymam obietnicy sprzedania Ci broni po kosztach";
                    rozmowa1.Text = "HANDEL";
                    Frycu.Option += 1;
                    Bureck.Option = 2;
                    but1 = 6;
                    break;
                case 7:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "HANDEL";
                    but1 = 6;
                    break;
                case 8:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa1.Text = "HANDEL";
                    but1 = 6;
                    break;

            }
        }
        //======================================================================================TALK TO WOJTEN===============================================================================

        private void talkToWojten(object sender, MouseButtonEventArgs e)
        {
            who = 2;
            talkstart();
            Wojtentalk();
        }

        void Wojtentalk()
        {
            switch (Wojten.Option)
            {
                case 0:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa2.Visibility = Visibility.Visible;
                    but1 = 9;
                    but2 = 10;
                    rozmowa1.Text = "Dzień dobry";
                    rozmowa2.Text = "...";
                    break;
                case 1:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa2.Visibility = Visibility.Visible;
                    but1 = 9;
                    but2 = 10;
                    rozmowa1.Text = "Haaaalooooo";
                    rozmowa2.Text = "...";
                    break;
                case 2:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa2.Visibility = Visibility.Visible;
                    but1 = 9;
                    but2 = 10;
                    rozmowa1.Text = "Słyszysz mnie?";
                    rozmowa2.Text = "...";
                    break;
                case 3:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa2.Visibility = Visibility.Visible;
                    but1 = 9;
                    but2 = 10;
                    rozmowa1.Text = "Co tu się dzieje?";
                    rozmowa2.Text = "...";
                    break;
                case 4:
                    rozmowa1.Visibility = Visibility.Visible;
                    rozmowa2.Visibility = Visibility.Collapsed;
                    wyswietlacz.Text = "Ukradli mi drzewo";
                    but1 = 11;
                    rozmowa1.Text = "Przykro mi z powodu Twojej straty";
                    break;
            }
        }

        //=======================================================================================GO TO=======================================================================================
        private void goToFarma(object sender, MouseButtonEventArgs e)
        {
            mapsko.Visibility = Visibility.Collapsed;
            mapafarma.Visibility = Visibility.Collapsed;
            maparido.Visibility = Visibility.Collapsed;
            mapagora.Visibility = Visibility.Collapsed;
            switch (stan.Miejsce)
            {
                case 0:
                    break;
                case 1:
                    rido.Visibility = Visibility.Collapsed;
                    Frycubutton.Visibility = Visibility.Collapsed;
                    ridoFarm.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    gora.Visibility = Visibility.Collapsed;
                    wojten_icon.Visibility = Visibility.Collapsed;
                    gorafarm.Visibility = Visibility.Collapsed;
                    break;
            }
            stan.Miejsce = 0;
            checkstateplace();
        }

        private void goToRido(object sender, MouseButtonEventArgs e)
        {
            mapsko.Visibility = Visibility.Collapsed;
            mapafarma.Visibility = Visibility.Collapsed;
            maparido.Visibility = Visibility.Collapsed;
            mapagora.Visibility = Visibility.Collapsed;
            switch (stan.Miejsce)
            {
                case 0:
                    farma.Visibility = Visibility.Collapsed;
                    bureckbutton.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    break;
                case 2:
                    gora.Visibility = Visibility.Collapsed;
                    wojten_icon.Visibility = Visibility.Collapsed;
                    gorafarm.Visibility = Visibility.Collapsed;
                    break;
            }
            stan.Miejsce = 1;
            checkstateplace();
        }

        private void goToGora(object sender, MouseButtonEventArgs e)
        {
            mapsko.Visibility = Visibility.Collapsed;
            mapafarma.Visibility = Visibility.Collapsed;
            maparido.Visibility = Visibility.Collapsed;
            mapagora.Visibility = Visibility.Collapsed;
            switch (stan.Miejsce)
            {
                case 0:
                    farma.Visibility = Visibility.Collapsed;
                    bureckbutton.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    rido.Visibility = Visibility.Collapsed;
                    Frycubutton.Visibility = Visibility.Collapsed;
                    ridoFarm.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    break;

            }
            stan.Miejsce = 2;
            checkstateplace();
        }
        //===================================================================================EXP FARMY=======================================================================================
        private void ridofarm(object sender, MouseButtonEventArgs e)
        {
            who = 1;
            ridoFarm.Visibility = Visibility.Collapsed;
            fightstart();
        }
        //===================================================================================CHECK I STOP ITEMS==============================================================================
        private void checkshop1(object sender, MouseEventArgs e)
        {
            checkitem();
            shopitem.newitem(0);
            if (Frycu.Option == 7)
                shopitem.Cena = 30;
            itemstats.Text = shopitem.check();
            itemstats2.Text = shopitem.check2();
            itemstats3.Text = shopitem.check3();
            itemstats4.Text = shopitem.check4();
        }

        private void checkshop2(object sender, MouseEventArgs e)
        {
            checkitem();
            shopitem.newitem(1);
            itemstats.Text = shopitem.check();
            itemstats2.Text = shopitem.check2();
            itemstats3.Text = shopitem.check3();
            itemstats4.Text = shopitem.check4();
        }

        private void checkshop3(object sender, MouseEventArgs e)
        {
            checkitem();
            shopitem.newitem(2);
            itemstats.Text = shopitem.check();
            itemstats2.Text = shopitem.check2();
            itemstats3.Text = shopitem.check3();
            itemstats4.Text = shopitem.check4();
        }

        private void stopshop(object sender, MouseEventArgs e)
        {
            stopcheckitem();
        }

        private void itcheck1(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item1.check();
            itemstats2.Text = item1.check2();
            itemstats3.Text = item1.check3();
            itemstats4.Text = item1.check4();
        }
        private void itcheck2(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item2.check();
            itemstats2.Text = item2.check2();
            itemstats3.Text = item2.check3();
            itemstats4.Text = item2.check4();
        }
        private void itcheck3(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item3.check();
            itemstats2.Text = item3.check2();
            itemstats3.Text = item3.check3();
            itemstats4.Text = item3.check4();
        }
        private void itcheck4(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item4.check();
            itemstats2.Text = item4.check2();
            itemstats3.Text = item4.check3();
            itemstats4.Text = item4.check4();
        }
        private void itcheck5(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item5.check();
            itemstats2.Text = item5.check2();
            itemstats3.Text = item5.check3();
            itemstats4.Text = item5.check4();
        }
        private void itcheck6(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item6.check();
            itemstats2.Text = item6.check2();
            itemstats3.Text = item6.check3();
            itemstats4.Text = item6.check4();
        }
        private void itcheck7(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item7.check();
            itemstats2.Text = item7.check2();
            itemstats3.Text = item7.check3();
            itemstats4.Text = item7.check4();
        }
        private void itcheck8(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item8.check();
            itemstats2.Text = item8.check2();
            itemstats3.Text = item8.check3();
            itemstats4.Text = item8.check4();
        }
        private void itcheck9(object sender, MouseEventArgs e)
        {
            checkitem();
            itemstats.Text = item9.check();
            itemstats2.Text = item9.check2();
            itemstats3.Text = item9.check3();
            itemstats4.Text = item9.check4();
        }


        void checkitem()
        {
            itemstats.Visibility = Visibility.Visible;
            itemstats2.Visibility = Visibility.Visible;
            itemstats3.Visibility = Visibility.Visible;
            itemstats4.Visibility = Visibility.Visible;
            stats.Visibility = Visibility.Collapsed;
            strbox.Visibility = Visibility.Collapsed;
            mblbox.Visibility = Visibility.Collapsed;
            intbox.Visibility = Visibility.Collapsed;
            hpbox.Visibility = Visibility.Collapsed;
            armbox.Visibility = Visibility.Collapsed;
        }

        void stopcheckitem()
        {
            itemstats.Visibility = Visibility.Collapsed;
            itemstats2.Visibility = Visibility.Collapsed;
            itemstats3.Visibility = Visibility.Collapsed;
            itemstats4.Visibility = Visibility.Collapsed;
            stats.Visibility = Visibility.Visible;
            strbox.Visibility = Visibility.Visible;
            mblbox.Visibility = Visibility.Visible;
            intbox.Visibility = Visibility.Visible;
            hpbox.Visibility = Visibility.Visible;
            armbox.Visibility = Visibility.Visible;
        }
        //=========================================================================================BUY ITEM====================================================================
        private void buy1(object sender, MouseButtonEventArgs e)
        {
            bool check;
            if (shopitem.Cena <= gold)
            {
                check = itemslot(0);
                if (check == false)
                {
                    wyswietlacz.Visibility = Visibility.Visible;
                    wyswietlacz.Text = "Brak miejsca w ekwipunku";
                }
                else
                {
                    if (Frycu.Option == 7)
                        Frycu.Option += 1;
                    gold -= shopitem.Cena;
                }
            }
            else
            {
                wyswietlacz.Visibility = Visibility.Visible;
                wyswietlacz.Text = "Masz za mało złota";
            }
            zloto.Text = gold.ToString();
        }

        private void buy2(object sender, MouseButtonEventArgs e)
        {
            bool check;
            if (shopitem.Cena <= gold)
            {
                check = itemslot(1);
                if (check == false)
                {
                    wyswietlacz.Visibility = Visibility.Visible;
                    wyswietlacz.Text = "Brak miejsca w ekwipunku";
                }
                else
                    gold -= shopitem.Cena;
            }
            else
            {
                wyswietlacz.Visibility = Visibility.Visible;
                wyswietlacz.Text = "Masz za mało złota";
            }
            zloto.Text = gold.ToString();
        }

        private void buy3(object sender, MouseButtonEventArgs e)
        {
            bool check;
            if (shopitem.Cena <= gold)
            {
                check = itemslot(2);
                if (check == false)
                {
                    wyswietlacz.Visibility = Visibility.Visible;
                    wyswietlacz.Text = "Brak miejsca w ekwipunku";
                }
                else
                    gold -= shopitem.Cena;
            }
            else
            {
                wyswietlacz.Visibility = Visibility.Visible;
                wyswietlacz.Text = "Masz za mało złota";
            }
            zloto.Text = gold.ToString();
        }


        //=========================================================================================ITEM SLOT CHECK=============================================================
        bool itemslot(int x)
        {
             SqlCommand command = new SqlCommand("select nazwa, cena, itemtype, bonutype, bonus, id from Przedmioty where id = " + x, connection);
             SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            equip.details equipDetails = new equip.details(reader.GetValue(0));

            if (item1.Exist == false)
            {
                item1.newitem(x);
                itemicon(x, 1);
                it1.Visibility = Visibility.Visible;
                return true;
            }

                if (item2.Exist == false)
                {
                    item2.newitem(x);
                    itemicon(x, 2);
                    it2.Visibility = Visibility.Visible;
                return true;
            }

                    if (item3.Exist == false)
                    {
                        item3.newitem(x);
                        itemicon(x, 3);
                        it3.Visibility = Visibility.Visible;

                return true;
            }
                        if (item4.Exist == false)
                        {
                            item4.newitem(x);
                            itemicon(x, 4);
                            it4.Visibility = Visibility.Visible;
                return true;
            }
                            if (item5.Exist == false)
                            {
                                item5.newitem(x);
                                itemicon(x, 5);
                                it5.Visibility = Visibility.Visible;
                    return true;
                }
                                if (item6.Exist == false)
                                {
                                    item6.newitem(x);
                                    itemicon(x, 6);
                                    it6.Visibility = Visibility.Visible;
                        return true;
                    }
                                    if (item7.Exist == false)
                                    {
                                        item7.newitem(x);
                                        itemicon(x, 7);
                                        it7.Visibility = Visibility.Visible;
                            return true;
                        }
                                        if (item8.Exist == false)
                                        {
                                            item8.newitem(x);
                                            itemicon(x, 8);
                                            it8.Visibility = Visibility.Visible; return true;
                            }
                                            if (item9.Exist == false)
                                            {
                                                item9.newitem(x);
                                                itemicon(x, 9);
                                                it9.Visibility = Visibility.Visible;
                                    return true;
                                }
            return false;
        }
        //================================================================================ITEM ICON===========================================================================================
        void itemicon(int x, int eqplace)
        {
            switch (x)
            {
                case 0:
                    itemtemple.Source = shop1.Source;
                    break;
                case 1:
                    itemtemple.Source = shop2.Source;
                    break;
                case 2:
                    itemtemple.Source = shop3.Source;
                    break;
            }
            switch (eqplace)
            {
                case 1:
                    it1.Source = itemtemple.Source;
                    break;
                case 2:
                    it2.Source = itemtemple.Source;
                    break;
                case 3:
                    it3.Source = itemtemple.Source;
                    break;
                case 4:
                    it4.Source = itemtemple.Source;
                    break;
                case 5:
                    it5.Source = itemtemple.Source;
                    break;
                case 6:
                    it6.Source = itemtemple.Source;
                    break;
                case 7:
                    it7.Source = itemtemple.Source;
                    break;
                case 8:
                    it8.Source = itemtemple.Source;
                    break;
                case 9:
                    it9.Source = itemtemple.Source;
                    break;
            }
        }

        void itemicon2(int x, int eqplace)
        {
            switch (x)
            {
                case 0:
                    itemtemple.Source = use0.Source;
                    break;
                case 1:
                    itemtemple.Source = use1.Source;
                    break;
                case 2:
                    itemtemple.Source = use2.Source;
                    break;
            }
            switch (eqplace)
            {
                case 1:
                    it1.Source = itemtemple.Source;
                    break;
                case 2:
                    it2.Source = itemtemple.Source;
                    break;
                case 3:
                    it3.Source = itemtemple.Source;
                    break;
                case 4:
                    it4.Source = itemtemple.Source;
                    break;
                case 5:
                    it5.Source = itemtemple.Source;
                    break;
                case 6:
                    it6.Source = itemtemple.Source;
                    break;
                case 7:
                    it7.Source = itemtemple.Source;
                    break;
                case 8:
                    it8.Source = itemtemple.Source;
                    break;
                case 9:
                    it9.Source = itemtemple.Source;
                    break;
            }
        }
        //===========================================================================================EQUIP OR SELL====================================================================================
        private void equiporsell1(object sender, MouseButtonEventArgs e)
        {
            equiporsell(1);
        }
        private void equiporsell2(object sender, MouseButtonEventArgs e)
        {
            equiporsell(2);
        }
        private void equiporsell3(object sender, MouseButtonEventArgs e)
        {
            equiporsell(3);
        }
        private void equiporsell4(object sender, MouseButtonEventArgs e)
        {
            equiporsell(4);
        }
        private void equiporsell5(object sender, MouseButtonEventArgs e)
        {
            equiporsell(5);
        }
        private void equiporsell6(object sender, MouseButtonEventArgs e)
        {
            equiporsell(6);
        }
        private void equiporsell7(object sender, MouseButtonEventArgs e)
        {
            equiporsell(7);
        }
        private void equiporsell8(object sender, MouseButtonEventArgs e)
        {
            equiporsell(8);
        }
        private void equiporsell9(object sender, MouseButtonEventArgs e)
        {
            equiporsell(9);
        }
        void equiporsell(int x)
        {
            bool wynik;
            switch (x)
            {
                case 1:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item1.sell();
                        if (wynik == true)
                        {
                            it1.Visibility = Visibility.Collapsed;
                            gold += item1.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item1.Used == true)
                        {
                            item1.Used = false;
                            itemicon(item1.ID, 1);
                            typecheck2(item1.Type);
                            typecheck4(item1.Bon, item1.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item1.Type);
                            if (wynik == true)
                            {
                                item1.Used = true;
                                itemicon2(item1.ID, 1);
                                typecheck3(item1.Bon, item1.Typ);
                            }
                        }
                    }
                    break;
                case 2:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item2.sell();
                        if (wynik == true)
                        {
                            it2.Visibility = Visibility.Collapsed;
                            gold += item2.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item2.Used == true)
                        {
                            item2.Used = false;
                            itemicon(item2.ID, 2);
                            typecheck2(item2.Type);
                            typecheck4(item2.Bon, item2.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item2.Type);
                            if (wynik == true)
                            {
                                item2.Used = true;
                                itemicon2(item2.ID, 2);
                                typecheck3(item2.Bon, item2.Typ);
                            }
                        }
                    }
                    break;
                case 3:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item3.sell();
                        if (wynik == true)
                        {
                            it3.Visibility = Visibility.Collapsed;
                            gold += item3.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item3.Used == true)
                        {
                            item3.Used = false;
                            itemicon(item3.ID, 3);
                            typecheck2(item3.Type);
                            typecheck4(item3.Bon, item3.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item3.Type);
                            if (wynik == true)
                            {
                                item3.Used = true;
                                itemicon2(item3.ID, 3);
                                typecheck3(item3.Bon, item3.Typ);
                            }
                        }
                    }
                    break;
                case 4:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item4.sell();
                        if (wynik == true)
                        {
                            it4.Visibility = Visibility.Collapsed;
                            gold += item4.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item4.Used == true)
                        {
                            item4.Used = false;
                            itemicon(item4.ID, 4);
                            typecheck2(item4.Type);
                            typecheck4(item4.Bon, item4.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item4.Type);
                            if (wynik == true)
                            {
                                item4.Used = true;
                                itemicon2(item4.ID, 4);
                                typecheck3(item4.Bon, item4.Typ);
                            }
                        }
                    }
                    break;
                case 5:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item5.sell();
                        if (wynik == true)
                        {
                            it5.Visibility = Visibility.Collapsed;
                            gold += item5.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item5.Used == true)
                        {
                            item5.Used = false;
                            itemicon(item5.ID, 5);
                            typecheck2(item5.Type);
                            typecheck4(item5.Bon, item5.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item5.Type);
                            if (wynik == true)
                            {
                                item5.Used = true;
                                itemicon2(item5.ID, 5);
                                typecheck3(item5.Bon, item5.Typ);
                            }
                        }
                    }
                    break;
                case 6:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item6.sell();
                        if (wynik == true)
                        {
                            it6.Visibility = Visibility.Collapsed;
                            gold += item6.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item6.Used == true)
                        {
                            item6.Used = false;
                            itemicon(item6.ID, 6);
                            typecheck2(item6.Type);
                            typecheck4(item6.Bon, item6.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item6.Type);
                            if (wynik == true)
                            {
                                item6.Used = true;
                                itemicon2(item6.ID, 6);
                                typecheck3(item6.Bon, item6.Typ);
                            }
                        }
                    }
                    break;
                case 7:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item7.sell();
                        if (wynik == true)
                        {
                            it7.Visibility = Visibility.Collapsed;
                            gold += item7.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item7.Used == true)
                        {
                            item7.Used = false;
                            itemicon(item7.ID, 7);
                            typecheck2(item7.Type);
                            typecheck4(item7.Bon, item7.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item7.Type);
                            if (wynik == true)
                            {
                                item7.Used = true;
                                itemicon2(item7.ID, 7);
                                typecheck3(item7.Bon, item7.Typ);
                            }
                        }
                    }
                    break;
                case 8:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item8.sell();
                        if (wynik == true)
                        {
                            it8.Visibility = Visibility.Collapsed;
                            gold += item8.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item8.Used == true)
                        {
                            item8.Used = false;
                            itemicon(item8.ID, 8);
                            typecheck2(item8.Type);
                            typecheck4(item8.Bon, item8.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item8.Type);
                            if (wynik == true)
                            {
                                item8.Used = true;
                                itemicon2(item8.ID, 8);
                                typecheck3(item8.Bon, item8.Typ);
                            }
                        }
                    }
                    break;
                case 9:
                    if (stan.Czynnosc == 2)
                    {
                        wynik = item9.sell();
                        if (wynik == true)
                        {
                            it9.Visibility = Visibility.Collapsed;
                            gold += item9.Cena;
                        }
                        else
                        {
                            wyswietlacz.Visibility = Visibility.Visible;
                            wyswietlacz.Text = "Nie można sprzedać używanego przedmiotu!";
                        }
                    }
                    else
                    {
                        if (item9.Used == true)
                        {
                            item9.Used = false;
                            itemicon(item9.ID, 9);
                            typecheck2(item9.Type);
                            typecheck4(item9.Bon, item9.Typ);
                        }
                        else
                        {
                            wynik = typecheck(item9.Type);
                            if (wynik == true)
                            {
                                item9.Used = true;
                                itemicon2(item9.ID, 9);
                                typecheck3(item9.Bon, item9.Typ);
                            }
                        }
                    }
                    break;
            }
            zloto.Text = gold.ToString();
        }

        bool typecheck(int x)
        {
            bool wynik=true;
            switch (x)
            {
                case 0:
                    if (slot0 == true)
                        wynik = false;
                    else
                        slot0 = true;
                    break;
                case 1:
                    if (slot1 == true)
                        wynik = false;
                    else
                        slot1 = true;
                    break;
                case 2:
                    if (slot2 == true)
                        wynik = false;
                    else
                        slot2 = true;
                    break;
            }
            return wynik;
        }

        void typecheck2(int x)
        {
            switch (x)
            {
                case 0:
                    slot0 = false;
                    break;
                case 1:
                    slot1 = false;
                    break;
                case 2:
                    slot2 = false;
                    break;
            }
        }

        void typecheck3(int bonus, int typ)
        {
            switch (typ)
            {
                case 1:
                    bohater.Str += bonus;
                    strbox.Text = bohater.Str.ToString();
                    break;
                case 2:
                    bohater.Mbl += bonus;
                    mblbox.Text = bohater.Mbl.ToString();
                    break;
                case 3:
                    bohater.Wis += bonus;
                    intbox.Text = bohater.Wis.ToString();
                    break;
                case 4:
                    bohater.Hp += bonus;
                    hpbox.Text = bohater.Hp.ToString();
                    break;
                case 5:
                    bohater.Armor += bonus;
                    armbox.Text = bohater.Armor.ToString();
                    break;
                case 6:
                    attackbonus += bonus;
                    break;
            }
        }
        void typecheck4(int bonus, int typ)
        {
            switch (typ)
            {
                case 1:
                    bohater.Str -= bonus;
                    strbox.Text = bohater.Str.ToString();
                    break;
                case 2:
                    bohater.Mbl -= bonus;
                    mblbox.Text = bohater.Mbl.ToString();
                    break;
                case 3:
                    bohater.Wis -= bonus;
                    intbox.Text = bohater.Wis.ToString();
                    break;
                case 4:
                    bohater.Hp -= bonus;
                    hpbox.Text = bohater.Hp.ToString();
                    break;
                case 5:
                    bohater.Armor -= bonus;
                    armbox.Text = bohater.Armor.ToString();
                    break;
                case 6:
                    attackbonus -= bonus;
                    break;
            }
        }

        
    }
}
