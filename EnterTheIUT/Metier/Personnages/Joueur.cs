using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IUTGame;
using EnterTheIUT;
using EnterTheIUT.Metier.Armes;
using System.Threading;
using EnterTheIUT.Metier.Carte;
using EnterTheIUT.Metier.Carte.Salles;
using EnterTheIUT.GestionSaves;

namespace EnterTheIUT.Metier.Personnages
{

    /// <summary>
    /// Classe joueur, héritée de Personnage
    /// </summary>
    /// <author>Martin De Lima</author>
    /// <author>Alexandre Moreau</author>
    public class Joueur : Personnage,IAnimable
    {

        public Joueur(string name,float hp, float def, float atk, float spd, int xPos, int yPos, Arme arme, Game g, string spriteName = "joueur/1.png") 
            : base(hp, def, atk, spd, xPos, yPos, arme, g, spriteName) 
        { 
            this.arme = arme; 
            this.nom = name;
        }
        public override string TypeName => "joueur";
        private double angle=180;
        private Arme arme;
        private Key lastMove;
        private TimeSpan cadence = TimeSpan.Zero;
        private TimeSpan waitingArme = TimeSpan.Zero;
        private TimeSpan waitingCollide = TimeSpan.Zero;
        private TimeSpan time = TimeSpan.Zero;
        private bool isInvunerable = false;
        private int score = 0;
        private string nom;

        public bool IsInvunerable
        {
            get
            {
                return isInvunerable;
            }
        }

        /// <summary>
        /// permet au joueur de se déplacer
        /// </summary>
        /// <param name="key"></param>
        /// <author>Martin DeLima</author>
        public override void KeyDown(Key key)
        {
            lastMove = key;
            switch (key)
            {
                case Key.Z:
                    MoveXY(0, -(10 * this.Vitesse));
                    this.RefreshXY(0, -(10 * this.Vitesse));
                    this.RefreshSpriteOrientation("HAUT");
                    this.angle = 270;
                    break;
                case Key.S:
                    MoveXY(0, 10 * this.Vitesse);
                    this.RefreshXY(0, 10 * this.Vitesse);
                    this.RefreshSpriteOrientation("BAS");
                    this.angle = 90;
                    break;
                case Key.Q:
                    MoveXY((-10 * this.Vitesse), 0);
                    this.RefreshXY((-10 * this.Vitesse), 0);
                    this.RefreshSpriteOrientation("GAUCHE");
                    this.angle = 180;
                    break;
                case Key.D:
                    MoveXY(10 * this.Vitesse, 0);
                    this.RefreshXY(10 * this.Vitesse, 0);
                    this.RefreshSpriteOrientation("DROITE");
                    this.angle = 0;
                    break;
                case Key.E:
                    if (this.arme != null) { this.Attaquer(); }
                    break;
            }
        }

        /// <summary>
        /// Permet d'attaquer
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public void Attaquer()
        {
            cadence= this.arme.Attaque(this.XPos, this.YPos, this.angle,"ennemi",cadence);
        }

        /// <summary>
        /// permet de changer d'arme
        /// </summary>
        /// <param name="arme">Arme ramassé</param>
        /// <author>Alexandre Moreau</author>
        public void ChangerArme(Arme arme)
        {
            if (this.arme != null)
            {
                if (this.arme.TypeName == "sceptre")
                {
                    Sceptre sceptre1 = new Sceptre(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(sceptre1);
                }
                else if (this.arme.TypeName == "baguette_magique")
                {
                    BaguetteMagique baguetteMagique1 = new BaguetteMagique(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(baguetteMagique1);
                }
            }
            this.arme = arme;
            this.Vitesse *= arme.Poids;
            
        }
        /// <summary>
        /// permet de gerer les bonus
        /// </summary>
        /// <param name="typeBonus">identification du bonus récupérer</param>
        /// <author>Gibril Lakhdar</author>
        public void AugmenterStatistiques(string typeBonus)
        {
            switch (typeBonus)
            {
                case "Bonus Regeneration":
                    this.PointsDeVie += 3;
                    break;
                case "Bonus Resistance":
                    if (time <= TimeSpan.Zero)
                    {
                        this.Defense += 10;
                        time = new TimeSpan(0, 0, 15);
                    } 
                    break;
                case "Bonus Vitesse":
                    if (time <= TimeSpan.Zero)
                    {
                        this.Vitesse += 3;
                        time=new TimeSpan(0,0,10);
                    }
                    break;
                case "Bonus Invulnerable":
                    if (time <= TimeSpan.Zero)
                    {
                        isInvunerable = true;
                        time = new TimeSpan(0, 0, 5);
                    }
                    break;
            }
        }

        /// <summary>
        /// gestion des collision du joueur
        /// </summary>
        /// <param name="other">GameItem rencontrer</param>
        /// <author>Alexandre Moreau</author>
        public override void CollideEffect(GameItem other)
        {
            if (waitingCollide <= TimeSpan.Zero)
            {
                if (other.TypeName == "projectile_ennemi")
                {
                    if (this.isInvunerable == false) 
                    {
                        this.PrendreDegats(10);
                        if (this.PointsDeVie <= 0)
                        {
                            TheGame.RemoveItem(this);
                            TheGame.Loose();
                        }
                        TheGame.RemoveItem(other);
                        waitingCollide = new TimeSpan(0, 0, 0, 0, 500);
                    }
                }
            }
            if ((other.TypeName == "sceptre"||other.TypeName=="baguette_magique")&&this.waitingArme<=TimeSpan.Zero)
            {
                this.ChangeSprite($"joueurArmee/1{other.TypeName}.png");
                Sceptre sceptre = new Sceptre(1600, 1600, TheGame);
                BaguetteMagique baguetteMagique = new BaguetteMagique(1600, 1600, TheGame);
                if (other.TypeName == "sceptre")
                {
                    this.ChangerArme(sceptre);
                    
                }
                else
                {
                    this.ChangerArme(baguetteMagique);
                    
                }
                this.waitingArme=new TimeSpan(0,0,0,1,500);
                TheGame.RemoveItem(other);
            }
            if (other.TypeName == "Mur")
            {
                switch (this.lastMove)
                {
                    case Key.Z:
                        MoveXY(0, 10 * this.Vitesse);
                        this.RefreshXY(0, 10 * this.Vitesse);
                        this.RefreshSpriteOrientation("HAUT");
                        break;
                    case Key.S:
                        MoveXY(0,(-10 * this.Vitesse));
                        this.RefreshXY(0,(-10 * this.Vitesse));
                        this.RefreshSpriteOrientation("BAS");
                        break;
                    case Key.Q:
                        MoveXY(10 * this.Vitesse, 0);
                        this.RefreshXY(10 * this.Vitesse, 0);
                        this.RefreshSpriteOrientation("GAUCHE");
                        break;
                    case Key.D:
                        MoveXY((-10 * this.Vitesse), 0);
                        this.RefreshXY((-10 * this.Vitesse), 0);
                        this.RefreshSpriteOrientation("DROITE");
                        break;
                }
            }
            if (other.TypeName == "Bonus Resistance")
            {
                this.AugmenterStatistiques(other.TypeName);
                TheGame.RemoveItem(other);
            }

            if (other.TypeName == "Bonus Regeneration")
            {
                this.AugmenterStatistiques(other.TypeName);
                TheGame.RemoveItem(other);
            }

            if (other.TypeName == "Bonus Vitesse")
            {
                this.AugmenterStatistiques(other.TypeName);
                TheGame.RemoveItem(other);
            }

            if (other.TypeName == "Bonus Invulnerable")
            {
                this.AugmenterStatistiques(other.TypeName);
                TheGame.RemoveItem(other);
            }

        }

        /// <summary>
        /// permet de créer des temps d'attente
        /// </summary>
        /// <param name="ts">temps ecoulé</param>
        /// <author>Alexandre Moreau</author>
        public new void Animate(TimeSpan ts)
        {
            this.time = this.time.Subtract(ts);
            this.cadence = this.cadence.Subtract(ts);
            this.waitingCollide = this.waitingCollide.Subtract(ts);
            this.waitingArme = this.waitingArme.Subtract(ts);
            if (this.Vitesse > 1&&this.time<=TimeSpan.Zero)
            {
                this.Vitesse = 1;
            }
            if (this.Defense > 5 && this.time <= TimeSpan.Zero)
            {
                this.Vitesse = 5;
            }
            if(isInvunerable&& this.time <= TimeSpan.Zero)
            {
                this.isInvunerable=false;
            }
        }

        /// <summary>
        /// permet de recuperer le score
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public int Score
        {
            get { return score;}
        }

        /// <summary>
        /// permet de incrementer de 1 le score
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public void AddScore()
        {
            this.score += 100;
            SavesHandler saveHandler = new SavesHandler();
            saveHandler.AppendScore(this.nom,this.score);
        }

    }
}
