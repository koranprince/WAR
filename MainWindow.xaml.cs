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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace War
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

      
        public MainWindow()
        {
            InitializeComponent();
        }
        static List<int> cpudeck = CardDeck();
        static List<int> Playerdeck = CardDeck();
        List<int> coms = new List<int>();
        List<int> plays = new List<int>();
        static Random rand = new Random();


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ko.Content = "CPU DECK:" + cpudeck.Count.ToString();
            ra.Content = "Player One DECK:" + Playerdeck.Count.ToString() + Environment.NewLine;

            CardGame();

            
           

        }


        public void CardGame()
        {

            


            if (cpudeck.Count == 0 )
            {
                ko.Content = "Sorry";
                ra.Content = "You won";
                

            }
            else if(Playerdeck.Count == 0)
            {
                ko.Content = "You Won";
                ra.Content = "Sorry";

            }

            else
            {

                int CPU = rand.Next(cpudeck.Count);
                
                int Pone = rand.Next(Playerdeck.Count);
                CardGames(Pone,CPU);

            }

            
        }

        


        public  void CardGames(int Pone, int Cpu)
        {

            int playerone = Playerdeck.ElementAt(Pone);
            int computer = cpudeck.ElementAt(Cpu);

          if (playerone == computer)
            {
                Playerone.Text = Playerdeck.ElementAt(Pone).ToString();
                CPU.Text = cpudeck.ElementAt(Cpu).ToString();
                war();
                
            }

            else if (playerone > computer)
            {
                Playerone.Text = Playerdeck.ElementAt(Pone).ToString(); 
                CPU.Text = cpudeck.ElementAt(Cpu).ToString();

                cpudeck.RemoveAt(Cpu);
                Playerdeck.Add(computer);
                



            }
            else
            {
                Playerone.Text = Playerdeck.ElementAt(Pone).ToString();
                CPU.Text = cpudeck.ElementAt(Cpu).ToString();

                Playerdeck.RemoveAt(Pone);
                cpudeck.Add(playerone);

            }


        }

        public static int Change()
        {

            return cpudeck.Count ;

        }

        public async void war()
        {
            if (cpudeck.Count <= 4)
            {
                ko.Foreground = Brushes.Red;
                ko.Content = "CPU:Sorry Not Enough Cards";
                ra.Content = "Playerone: You won";
                butt.Visibility = System.Windows.Visibility.Hidden;



            }
            else if (Playerdeck.Count <= 4)
            {
                ra.Foreground = Brushes.Red;
                ko.Content = "CPU: You Won";
                ra.Content = "Playerone: Sorry Not Enough Cards";

            }
            else
            {

                butt.Visibility = System.Windows.Visibility.Hidden;
                int win = 0;
                string[] IWAR = { "W", "A", "R", };

                foreach (string let in IWAR)
                {
                    idwar.Text += await Task.Run(() => let + Environment.NewLine);
                    await Task.Delay(2000);
                    win++;
                    int WCPU = rand.Next(cpudeck.Count);
                    int WWCPU = cpudeck.ElementAt(WCPU);
                    int WPone = rand.Next(Playerdeck.Count);
                    int WWPone = Playerdeck.ElementAt(WPone);

                    await Task.Delay(2000);
                    await Task.Run(() => warconfig(WWCPU, WWPone, win));
                    

                }
                await Task.Run(() => idwar.Dispatcher.Invoke(() => { idwar.Text = ""; }));
                butt.Visibility = System.Windows.Visibility.Visible;


                // CardGames(WPone, WCPU);

            }
        }

        private void warconfig(int com, int play, int win)
        {

            coms.Add(com);
            plays.Add(play);

            if (win == 3)
            {
                if (com == play)
                {
                    war();
                }
                else if (com > play)
                {
                    foreach (int numb in plays)
                    {
                        cpudeck.Add(numb);
                        if (Playerdeck.Contains(numb))
                        {
                            Playerdeck.Remove(numb);
                        }
                        else
                        {
                            while (!Playerdeck.Contains(numb))
                            {
                                int WPone = rand.Next(Playerdeck.Count);
                                int WWPone = Playerdeck.ElementAt(WPone);
                                bool returns = pvalidate(WWPone);

                                if (returns == true)
                                {
                                    break;

                                }
                            }


                        }
                    }


                }
                else
                {
                    foreach (int numb in coms)
                    {

                        Playerdeck.Add(numb);
                        if (cpudeck.Contains(numb))
                        {
                            cpudeck.Remove(numb);
                        }
                        else
                        {
                            while (!cpudeck.Contains(numb))
                            {
                                int WCPU = rand.Next(cpudeck.Count);
                                int WWCPU = cpudeck.ElementAt(WCPU);
                                bool returns = cvalidate(WWCPU);

                                if (returns == true)
                                {
                                    break;

                                }
                            }
                            cpudeck.Remove(numb);

                        }


                    }
                    coms.Clear();
                    plays.Clear();

                    Playerone.Dispatcher.Invoke(() => { Playerone.Text = play.ToString(); });
                    CPU.Dispatcher.Invoke(() => { CPU.Text = com.ToString(); });
                }



            }
        }
        private bool pvalidate(int numb)
        {
           
            if (Playerdeck.Contains(numb))
            {
               Playerdeck.Remove(numb);
               bool numbs = true;
               return numbs;
            }
            else
            {
                bool numbs = false;

                return numbs;

            }

        }

            bool cvalidate(int numb)
            {

                if (cpudeck.Contains(numb))
                {
                    cpudeck.Remove(numb);
                    bool numbs = true;
                    return numbs;
                }
                else
                {
                    bool numbs = false;

                    return numbs;

                }

            }





            public static List<int> CardDeck()
        {
            List<int> CardDeck = new List<int>();
            CardDeck.Add(1);
            CardDeck.Add(2);
            CardDeck.Add(3);
            CardDeck.Add(4);
            CardDeck.Add(5);
            CardDeck.Add(6);
            CardDeck.Add(7);
            CardDeck.Add(8);
            CardDeck.Add(9);
            CardDeck.Add(10);
            CardDeck.Add(11);
            CardDeck.Add(12);
            CardDeck.Add(13);
            CardDeck.Add(14);
            CardDeck.Add(15);
            CardDeck.Add(16);
            CardDeck.Add(17);
            CardDeck.Add(18);
            CardDeck.Add(19);
            CardDeck.Add(20);
            CardDeck.Add(21);
            CardDeck.Add(22);
            CardDeck.Add(23);
            CardDeck.Add(24);
            CardDeck.Add(25);
            CardDeck.Add(26);


            return CardDeck;

        }
       
        private void test_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void test_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
