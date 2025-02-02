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
using EnterTheIUT.GestionSaves;

namespace EnterTheIUT.View
{
    /// <summary>
    /// Logique d'interaction pour HallOfFameWindow.xaml
    /// </summary>
    public partial class HallOfFameWindow : Window
    {
        public HallOfFameWindow()
        {
            InitializeComponent();
            AddScores();
        }

        ///<author>MArtin De Lima</author>
        /// <summary>
        /// Ajoute les scores dans la liste
        /// </summary>
        public void AddScores()
        {
            SavesHandler saveHandler = new SavesHandler();
            Dictionary  <string, int> scores = saveHandler.ReadScoresFromFile();
            foreach (KeyValuePair<string, int> score in scores)
            {
                listbox.Items.Add(score.Key + " : " + score.Value);
            }
        }
    }
}
