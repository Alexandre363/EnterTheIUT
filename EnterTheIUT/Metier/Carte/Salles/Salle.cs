using EnterTheIUT.Metier.Personnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Carte.Salles
{
    /// <summary>
    /// Constitue la carte
    /// </summary>
    public class Salle
    {
        /// <summary>
        /// liste des murs de la salle
        /// </summary>
        private List<Mur> murs ;
        public List<Mur> Murs { get { return murs; } set { murs = value; } }

        /// <summary>
        /// liste des portes de la salle
        /// </summary>
        private List<Porte?> portes;
        public List<Porte?> Portes { get { return portes; } set { portes = value; } }

        /// <summary>
        /// liste des ennemies contenue dans la salle
        /// </summary>
        private List<Ennemi> ennemis;
        public List<Ennemi> Ennemis { get { return ennemis; } set { ennemis = value; } }

        /// <summary>
        /// La positioin de la salle dans la carte
        /// </summary>
        private (int x, int y) position;
        public (int x, int y) Position { get { return position; } set { position = value; } }

        /// <summary>
        /// Pour la création de la carte ce système de création de salle est obligatoire, il permet de définir des salles à diférente positoion sur la carte
        /// </summary>
        /// <param name="murHaut">Le mur en haut de l'écran</param>
        /// <param name="murBas">Le mur en basa de l'écran</param>
        /// <param name="murDroit">le mur à droite de l'écran</param>
        /// <param name="murGauche">Le mur à gauche de l'écran</param>
        /// <param name="porteHaute">la porte en haut de l'écran</param>
        /// <param name="porteBas">la porte en bas de l'écran</param>
        /// <param name="porteGauche">la porte à gauche de l'écran</param>
        /// <param name="porteDroite">la porte à droite de l'écran</param>
        /// <param name="ennemis">la liste des ennemis a faire apparaitre dans la salle</param>
        /// <param name="position">la position de la salle sur la carte</param>
        /// <author>GUYENET Julien</author>
        public Salle(Mur murHaut, Mur murBas, Mur murDroit, Mur murGauche, Porte? porteHaute, Porte? porteBas, Porte? porteGauche, Porte? porteDroite, List<Ennemi> ennemis, (int x,int y) position)
        {
            Murs = new List<Mur>();
            Portes = new List<Porte?>();
            Ennemis = new List<Ennemi>();
            this.Murs.Add(murHaut);
            this.Murs.Add(murBas);
            this.Murs.Add(murDroit);
            this.Murs.Add(murGauche);
            this.Portes.Add(porteHaute);
            this.Portes.Add(porteBas);
            this.Portes.Add(porteGauche);
            this.Portes.Add(porteDroite);
            this.ennemis = ennemis;
            this.position = position;
        }
    }
}
