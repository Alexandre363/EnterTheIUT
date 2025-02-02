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
using System.Windows.Shapes;

namespace EnterTheIUT.View
{
    /// <summary>
    /// Logique d'interaction pour AskingNameWindow.xaml
    /// </summary>
    public partial class AskingNameWindow : Window
    {
        private string ?returnedName;

        public event EventHandler NameSet;

        public string ?ReturnedName
        {
            get { return returnedName; }
            set { returnedName = value; }
        }
        public AskingNameWindow()
        {
            InitializeComponent();
        }

        ///<author>Martin De Lima</author>
        /// <summary>
        /// Confirme le nom entré, si il n'y a pas de nom, le nom sera Anonymous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (this.textbox.Text != "")
            {
                this.returnedName = this.textbox.Text;
                NameSet?.Invoke(this, new EventArgs());
                this.Close();
            }
            else
            {
                this.returnedName = "Anonymous";
            }
        }
    }
}
