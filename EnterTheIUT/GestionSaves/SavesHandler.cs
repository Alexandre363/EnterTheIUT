using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using IUTGame;
using System.Windows.Media;
using Newtonsoft.Json;
using EnterTheIUT.Metier.Personnages;
using EnterTheIUT.Metier.Carte.Salles;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows;

namespace EnterTheIUT.GestionSaves
{
    /// <author>Martin De Lima</author>
    /// <summary>
    /// Gère les sauvegardes de maps et de scores
    /// </summary>
    public class SavesHandler
    {
        private string savesPath;
        private string mapsPath;
        private string scoresPath;
        private string currentSaveName;

        public string MapsPath
        {
            get { return mapsPath; }
            set { mapsPath = value; }
        }

        public string SavesPath
        {
            get { return savesPath; }
            set { savesPath = value; }
        }

        public string CurrentSaveName
        {
            get { return currentSaveName; }
            set { currentSaveName = value; }
        }

        public SavesHandler() 
        {
            this.currentSaveName = "No Save";
            this.savesPath = Path.Combine(Environment.CurrentDirectory,@"GestionSaves\Saves");
            this.mapsPath = Path.Combine(Environment.CurrentDirectory, @"GestionSaves\Maps");
            this.scoresPath = Path.Combine(Environment.CurrentDirectory, @"GestionSaves\Scores\Scores.txt");
        }

        ///<author>Martin De Lima</author>
        /// <summary>
        /// Lit une matrice dans un fichier texte
        /// </summary>
        public int[,] ReadMatrixFromFile(string fileName)
        {
            string filePath = fileName;
            string[] lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int columnCount = lines[0].Split(' ').Length;
            int[,] matrix = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(' ');

                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }
            return matrix;
        }

        ///<author>Martin De Lima</author>
        /// <summary>
        /// renvoie le dictionnaire nom:score sauvegardé dans le fichier
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Dictionary<string, int> ReadScoresFromFile()
        {
            string filePath = this.scoresPath;
            Dictionary<string, int> scores = new Dictionary<string, int>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string playerName = parts[0].Trim();
                        int score;
                        if (int.TryParse(parts[1].Trim(), out score))
                        {
                            scores[playerName] = score;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la lecture du fichier : " + ex.Message);
            }
            return scores;
        }

        ///<author>Martin De Lima</author>
        /// <summary>
        /// Ajoute un score au fichier
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void AppendScore(string name, int score)
        {
            string filePath = this.scoresPath;
            try
            {
                Dictionary<string, int> scores = ReadScoresFromFile();
                scores[name] = score;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (KeyValuePair<string, int> entry in scores)
                    {
                        string scoreEntry = entry.Key + ":" + entry.Value;
                        writer.WriteLine(scoreEntry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'ajout du score : " + ex.Message);
            }
        }
    }
}
