using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IUTGame;
using EnterTheIUT.Metier.Armes;
using System.Numerics;

namespace EnterTheIUT.Metier.Personnages
{
    ///<author>Martin De Lima</author>
    /// <summary>
    /// Classe personnage, dont hérite le joueur et les ennemis
    /// </summary>
    public class Personnage : GameItem, IAnimable, IKeyboardInteract
    {
        private float pointsDeVie;
        private float defense;
        private float pointsAttaque;
        private float vitesse = 1;
        private double xPos;
        private double yPos;
        private bool estVivant;
        private Arme arme;

        public override string TypeName => "Personnage";

        /// <summary>
        /// Création de la classe personnage
        /// </summary>
        /// <param name="hp">définis les hp</param>
        /// <param name="def">définis la defense</param>
        /// <param name="atk">définis l'attaque</param>
        /// <param name="spd">définis la vitesse</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="arme">définis l'arme</param>
        /// <param name="g"></param>
        /// <param name="spriteName"></param>
        public Personnage(float hp, float def, float atk, float spd, double x, double y, Arme? arme, Game g, string spriteName = null) : base(x,y,g,spriteName,1)
        {
            this.pointsDeVie = hp;
            this.defense = def;
            this.pointsAttaque = atk;
            this.vitesse = spd;
            this.xPos = x;
            this.yPos = y;
            this.estVivant = true;
            this.arme = arme;
            if (arme != null)
            {
                this.vitesse *= arme.Poids;
            }
        }

        /// <summary>
        /// permet de savoir si le personnage est vivant
        /// </summary>
        /// <author>Martin DeLima</author>
        public bool EstVivant
        {
            get { return estVivant; }
        }


        /// <summary>
        /// permet de récuperer et mettre à jour les hp
        /// </summary>
        /// <author>Martin DeLima</author>
        public float PointsDeVie
        {
            get { return pointsDeVie; }
            set { pointsDeVie = value; }
        }

        /// <summary>
        /// permet de récuperer et mettre à jour la defense
        /// </summary>
        /// <author>Martin DeLima</author>
        public float Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        /// <summary>
        /// permet de récuperer l'attaque
        /// </summary>
        /// <author>Martin DeLima</author>
        public float PointsAttaque
        {
            get { return pointsAttaque; }
        }

        /// <summary>
        /// permet de récuperer et mettre à jour la vitesse
        /// </summary>
        /// <author>Martin DeLima</author>
        public float Vitesse
        {
            get { return vitesse; }
            set { vitesse = value; }
        }

        /// <summary>
        /// permet de récuperer et mettre à jour les coordonnées
        /// </summary>
        /// <author>Martin DeLima</author>
        public double XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        /// <summary>
        /// permet de récuperer et mettre à jour les coordonnées
        /// </summary>
        /// <author>Martin DeLima</author>
        public double YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        /// <summary>
        /// permet de récuperer et mettre à jour l'arme
        /// </summary>
        /// <author>Martin DeLima</author>
        public Arme Arme
        {
            get { return arme; }
        }

        

        public void Animate(TimeSpan ts) 
        {
            
        }

        /// <summary>
        /// permet de mettre a jour l'attribut estVivant
        /// </summary>
        /// <author>Martin DeLima</author>
        public void Mourir()
        {
            this.estVivant = false;
        }

        /// <summary>
        /// permet d'enlever des points de vie
        /// </summary>
        /// <author>Martin DeLima</author>
        public void PrendreDegats(float degats)
        {
            this.pointsDeVie -= degats/(this.defense*0.5f);
        }

        
        public override string ToString()
        {
            return "Points de vie : " + this.pointsDeVie + "\n" +
                "Defense : " + this.defense + "\n" +
                "Points d'attaque : " + this.pointsAttaque + "\n" +
                "Vitesse : " + this.vitesse + "\n" +
                "Position : (" + this.xPos + "," + this.yPos + ")\n" +
                "Est vivant : " + this.estVivant + "\n" +
                "Arme : " + this.arme;
        }

        /// <summary>
        /// permet de changer le sens du sprite selon la direction du personnage
        /// </summary>
        /// <author>Martin DeLima</author>
        public void RefreshSpriteOrientation(string direction)
        {
            switch (direction)
            {
                case "GAUCHE":
                    this.ChangeScale(1, 1);
                    break;
                case "DROITE":
                    this.ChangeScale(-1, 1);
                    break;
                case "BAS":
                    break;
                case "HAUT":
                    break;
            }
        }

        /// <summary>
        /// permet de changer les coordonnées du personnage
        /// </summary>
        /// <author>Martin DeLima</author>
        protected void RefreshXY(double x, double y)
        {
            this.XPos += x;
            this.YPos += y;
        }


        public override void CollideEffect(GameItem other)
        {
        }

        public virtual void KeyDown(Key key) { }

        public virtual void KeyUp(Key key) { }
    }
}
