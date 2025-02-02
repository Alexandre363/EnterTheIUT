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
using EnterTheIUT.View;
using System.IO;
using System.Globalization;
using IUTGame.WPF;
using System.Threading;

namespace EnterTheIUT.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Jeu jeu;
        private bool nameSet = false;
 
        public MainWindow()
        {
            InitializeComponent();
            jeu = new Jeu(new WPFScreen(this.canva));
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        /// <author>Julien Guyenet et Martin De Lima</author>
        /// <summary>
        /// Ouvre le menu quand on appuie sur echap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Julien Guyenet</author>
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (this.MenuBar.Visibility == Visibility.Visible)
                {
                    MenuBar.Visibility = Visibility.Collapsed;
                    this.canva.Width = 1920;
                    this.canva.Height = 1080;
                    jeu.Resume(); 
                }
                else
                {
                    this.canva.Width = 1400;
                    this.canva.Height = 1080;
                    MenuBar.Visibility = Visibility.Visible;
                    jeu.Pause();
                }
            }
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Lance le jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemPlay_Click(object sender, RoutedEventArgs e)
        {
            if (!nameSet)
            {
                AskingNameWindow askName = new AskingNameWindow();
                askName.NameSet += askName_NameSet;
                askName.Show();
            }
            this.MenuBar.Visibility = Visibility.Collapsed;
        }

        ///<author>Martin De Lima</author>
        /// <summary>
        /// Met le nom du joueur dans le jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void askName_NameSet(object sender, EventArgs e)
        {
            nameSet = true;
            jeu.PlayerName = ((AskingNameWindow)sender).ReturnedName;
            jeu.Run();
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Ouvre la fenêtre du hall of fame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemHof_Click(object sender, RoutedEventArgs e)
        {
            Window hof = new HallOfFameWindow();
            hof.Show();
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Met l'application en plein écran, ne fait rien si l'application est déjà en plein écran
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemFullscreen_Click(object sender, RoutedEventArgs e)
        {
             this.WindowStyle = WindowStyle.None;
             this.WindowState = WindowState.Maximized;
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Met l'application en mode fenêtré, ne fait rien si l'application est déjà en mode fenêtré
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemWindowed_Click(object sender, RoutedEventArgs e)
        {
             this.WindowStyle = WindowStyle.SingleBorderWindow;
             this.WindowState = WindowState.Maximized;
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Change la langue de l'application en anglais et rafraichit la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemEnglish_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("en");
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Change la langue de l'application en français et rafraichit la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemFrench_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("fr");
        }

        /// <author>Martin De Lima</author>
        /// <summary>
        /// Change la langue de l'application
        /// </summary>
        /// <param name="language">un string representant la langue vers laquelle changer</param>
        private void ChangeLanguage(string language)
        {
             System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
             MainWindow window = new MainWindow();
             window.WindowStyle = this.WindowStyle;
             window.WindowState = this.WindowState;
             window.Show();
             this.Close();
        }
    }
}
