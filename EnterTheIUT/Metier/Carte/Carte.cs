using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterTheIUT.Metier.Armes;
using EnterTheIUT.Metier.Carte.Salles;
using EnterTheIUT.Metier.Personnages;
using IUTGame;

namespace EnterTheIUT.Metier.Carte
{
    /// <summary>
    /// Carte contenant les différentes salles du jeu
    /// </summary>
    /// <author>GUYENET Julien</author>
    public class Carte
    {
        /// <summary>
        /// Listes des salles de la cartes dans lesquelles le joueur pourra se déplacer
        /// </summary>
        /// <author>GUYENET Julien</author>
        private Salle[][] salles;
        public Salle[][] Salles { get { return salles; } set { salles = value; } }

        /// <summary>
        /// Constructeur de la carte
        /// </summary>
        /// <param name="game">le jeu dans lequel la carte doit etre crée</param>
        /// <author>GUYENET Julien</author>
        public Carte(Game game)
        {
            List<Ennemi> ennemis = new List<Ennemi>();
            //ennemis.Add(new Ennemi(0, 5, 2, 2, 1, 500, 500,new Sceptre(500,500,game),game,"ennemi/1.png" ));
            for(int i=0; i<4; i++)
            {
                for(int j = 0; j <4; j++)
                {
                    CreationSalle(game,(i,j),ennemis);
                }
            }
        }

        /// <summary>
        /// Cette fonction permet de génére un salle, normalement le game.AddItem n'est pas executer dans cette fonction mais dans une fonction changerSalle et lors de l'initialisation des Item dans le jeu, malheureusement cela ne fonctionne pas
        /// </summary>
        /// <param name="game">le jeu dans lequel la salle doit etre crée</param>
        /// <param name="position">la position sur la carte de la salle</param>
        /// <param name="ennemis">les différents ennemies de la salle</param>
        /// <author>GUYENET Julien</author>
        public void CreationSalle(Game game, (int, int) position, List<Ennemi?> ennemis)
        {
            Mur murHaut = new(0, 0, game, "salles/murHorizontalHaut.png");
            Mur murBas = new(0, game.Screen.Height - 70, game, "salles/murHorizontalBas.png");
            Mur murGauche = new(0, 41, game, "salles/murVerticalGauche.png");
            Mur murDroit = new(game.Screen.Width - 78, 41, game, "salles/murVerticalDroit.png");
            Porte porteHaut = new(game.Screen.Width / 2, 0, game, "salles/porteFermeeHaut.png", "haut");
            Porte porteBas = new(game.Screen.Width / 2, game.Screen.Height - 70, game, "salles/porteFermeeBas.png", "bas");
            Porte porteGauche = new(0, 410, game, "salles/porteFermeeGauche.png", "gauche");
            Porte porteDroite = new(game.Screen.Width - 79, 410, game, "salles/porteFermeeDroite.png", "droite");
            Salle salle = new(murHaut, murBas, murGauche, murDroit, porteHaut, porteBas, porteGauche, porteDroite, ennemis, position);
            game.AddItem(murHaut);
            game.AddItem(murBas);
            game.AddItem(murGauche);
            game.AddItem(murDroit);
            game.AddItem(porteHaut);
            game.AddItem(porteBas);
            game.AddItem(porteGauche);
            game.AddItem(porteDroite);
            if (ennemis.Count != 0)
            foreach (Ennemi ennemi in ennemis) game.AddItem(ennemi);
        }
    }
}
