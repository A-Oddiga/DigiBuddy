using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
using WpfAnimatedGif;

namespace DesktopBuddy
{
    /// <summary>
    /// The purpose of this program is for you as the user 
    /// to have your own personal assistant when your pc starts. This program will 
    /// allow you to select your own creature that has its own commands for you to select from.
    /// </summary>
  
    public partial class MainWindow : Window
    {
        public int amount = 0;
        public string backgroundAnswer = "";
        public double maxExpinit = 99;
        public int level = 0;
        public int foodNum = 0;
        Creature creature = new Creature();
        ScaleTransform flipTrans = new ScaleTransform();
        BitmapImage egg = new BitmapImage();
        BitmapImage coin = new BitmapImage();
        BitmapImage actualCoin = new BitmapImage();
        BitmapImage creature_created = new BitmapImage();
        Select selectSound = new Select();
        Event eventSound = new Event();
        SoundPlayer select = new SoundPlayer();
        SoundPlayer event_occured = new SoundPlayer();
        Random randoEgg = new Random();
        SoundPlayer lullaby = new SoundPlayer("C:\\Users\\Adel Lombardi\\Music\\Emotional-piano-song.wav");
        
        public double MaxEXP
        {
            get { return maxExpinit; }
            set { maxExpinit = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            //Food info
            foodNum = 0;
            Eat.Text += foodNum;
            //Level info     
            level = 0;
            Lvl_Label.Content = "LVL: 0";     
            //Set animation
            egg.BeginInit();
            egg.UriSource = new Uri("C:\\Users\\Adel Lombardi\\Documents\\DesktopBuddy\\Creatures\\OriginalEgg.gif");
            egg.EndInit();
            ImageBehavior.SetAnimatedSource(Egg, egg);
            coin.BeginInit();
            coin.UriSource = new Uri(@"C:\Users\Adel Lombardi\Documents\DesktopBuddy\Picture-Labels\Coin.gif");
            coin.EndInit();
            ImageBehavior.SetAnimatedSource(CoinLabel, coin);
            actualCoin.BeginInit();
            actualCoin.UriSource = new Uri(@"C:\Users\Adel Lombardi\Documents\DesktopBuddy\Picture-Labels\Coin.gif");
            actualCoin.EndInit();
            ImageBehavior.SetAnimatedSource(Coin, actualCoin);
            //Set sounds
            select = selectSound.Noise;
            event_occured = eventSound.Noise;
     
            //ToolTips
            Skill1.ToolTip = "Choose from the following:  \n*gray  \n*yellow \n *green \n *white \n*black";
        }
        #region Customize-Background
        private void BackgroundMenu_Click(object sender, RoutedEventArgs e)
        {
           
            textBox.IsEnabled = true;
            textBox.Text = string.Empty;
            textBox.Visibility = Visibility.Visible;         
        }
       
        public void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            backgroundAnswer = textBox.Text.ToLower();
            if (Key.Enter == e.Key)
            {
                
                switch (backgroundAnswer)
                {
                    case "black":
                        {
                            select.Play();
                            EXP_Bar.Value += 10;
                            textBox.Visibility = Visibility.Hidden;
                            MainsWindow1.Background = Brushes.Black;
                            break;
                        }
                    case "green":
                        {
                            select.Play();
                            EXP_Bar.Value += 10;
                            textBox.Visibility = Visibility.Hidden;
                            MainsWindow1.Background = Brushes.ForestGreen;
                            break;
                        }
                    case "yellow":
                        {
                            select.Play();
                            EXP_Bar.Value += 10;
                            textBox.Visibility = Visibility.Hidden;
                            MainsWindow1.Background = Brushes.LightYellow;
                            break;
                        }
                    case "white":
                        {
                            select.Play();
                            EXP_Bar.Value += 10;
                            textBox.Visibility = Visibility.Hidden;
                            MainsWindow1.Background = Brushes.LightBlue;
                            break;
                        }
                    case "gray":
                        {
                            select.Play();
                            EXP_Bar.Value += 10;
                            textBox.Visibility = Visibility.Hidden;
                            MainsWindow1.Background = Brushes.DarkSlateGray;
                            break;
                        }
                    default:
                        {
                            textBox.Visibility = Visibility.Hidden;
                            MessageBox.Show("You have entered an invalid color from what is available");
                            break;
                        }
                }
                textBox.IsEnabled = false;
            }
        }
        #endregion
        #region Exp
        private void EXP_Bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            if (EXP_Bar.Value >= MaxEXP)
            {
                SoundPlayer levelSound = new SoundPlayer(@"C:\Users\Adel Lombardi\Documents\DesktopBuddy\Selection Sounds\Level_up.wav");
                level += 1;
                Lvl_Label.Content = "LVL: " + level.ToString();
                EXP_Bar.Value = 0;
                MaxEXP += 100;
                EXP_Bar.Maximum = MaxEXP;
                levelSound.Play();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(Hunger.Value >=10)
            {               
                Hunger.Value -= 10;
                EXP_Bar.Value += 9;                           
            }
            else if(Hunger.Value < 10)
            {

            }
        }
        #endregion
        #region Hatching + Declaring initial Digibuddy
        private void Link_MouseDown(object sender, MouseButtonEventArgs e)
        {
            event_occured.Play();
            Egg.Visibility = Visibility.Hidden;
            int result = randoEgg.Next(0, 2);
            switch (result)
            {
                case 0:
                    {
                        Veemon veemon = new Veemon();
                        creature = veemon;
                        break;
                    }
                case 1:
                    {
                        Gabumon gabumon = new Gabumon();
                        creature = gabumon;
                        break;
                    }
            }
            
            creature.IsHatched = true;
            if (creature.IsHatched == true)
            {
                Fight.Visibility = Visibility.Visible;
            }
            Thread.Sleep(500);
            creature_created.BeginInit();
            creature_created.UriSource = creature.CreatureUri;
            creature_created.EndInit();
            if (creature.CreatureUri.ToString().Contains("Gabumon"))
            {
                Creature.Margin = new Thickness(90, 80, 0, 210);
            }
            else
            {
                Creature.Margin = new Thickness(90, 90, 0, 210);
            }
           
            ImageBehavior.SetAnimatedSource(Creature, creature_created);
            Alerts.Text = creature.Intro;                        
        }
        #endregion
        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {

            if (Creature.Margin == new Thickness(110, 90, 0, 210))
            {
                flipTrans.ScaleX = 1;
                Creature.RenderTransform = flipTrans;
            }
        }

        private void Left_side_MouseEnter(object sender, MouseEventArgs e)
        {
          
            if (Creature.Margin == new Thickness(110, 90, 0, 210))
            {
                flipTrans.ScaleX = -1;
                Creature.RenderTransform = flipTrans;
            }
        }


        private void Right_side_Initialized(object sender, EventArgs e)
        {
           
            BitmapImage food = new BitmapImage();
            food.BaseUri = new Uri("C:\\Users\\Adel Lombardi\\Documents\\DesktopBuddy\\Picture-Labels\\Chicken-leg.png");
            
        }

        private void MainsWindow1_Initialized(object sender, EventArgs e)
        {
          
        }

        private void food1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Hunger.Value < 100)
            {
                Hunger.Value += 10;
            }        
            if(foodNum > 0)
            {
                foodNum -= 1;
            }
            Eat.Text = ": " + foodNum.ToString();
        }

        private void food2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hunger.Value += 5;
        }

        private void Hunger_LayoutUpdated(object sender, EventArgs e)
        {
 
        }

        private void Hunger_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Battle_LayoutUpdated(object sender, EventArgs e)
        {
           
        }

        private void food1_LayoutUpdated(object sender, EventArgs e)
        {
            if (Hunger.Value <= 10)
            {
               
            }

        }

        private void MainsWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.Escape))
            {
                textBox.Visibility = Visibility.Hidden;           
            }
        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer itemSelect = new SoundPlayer(@"C:\Users\Adel Lombardi\Documents\DesktopBuddy\Selection Sounds\Menu_Select.wav");
            itemSelect.Play();
        }

        private void Customize_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            SoundPlayer menuSelect = new SoundPlayer(@"C:\Users\Adel Lombardi\Documents\DesktopBuddy\Selection Sounds\Menu_Select.wav");
            menuSelect.Play();
        }
        private void Coin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {                     

        }

        private void Coin_LayoutUpdated(object sender, EventArgs e)
        {
            if (creature.IsHatched)
            {
                Coin.Visibility = Visibility.Visible;
            }                            
        }

        private void Coin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Random randoMoney = new Random();
            Random rando = new Random();
            Coin.Margin = new Thickness(rando.Next(-60, 180), rando.Next(-300, 60), 0, 0);
            Coin.Visibility = Visibility.Hidden;
            creature.CurrentMoney += amount;
            amount += randoMoney.Next(1,5);
            money.Text = amount.ToString();
        }

        private void Buy_Food_Click(object sender, RoutedEventArgs e)
        {
            if(amount >= 10)
            {
                foodNum += 1;
                Eat.Text = ": " + foodNum.ToString();
                amount -= 10;
                money.Text = amount.ToString();
            }
        }
    }
}
