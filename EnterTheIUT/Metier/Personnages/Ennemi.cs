using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IUTGame;
using EnterTheIUT.Metier.Armes;
using EnterTheIUT;
using System.Reflection.Metadata;
using System.Threading;
using EnterTheIUT.Metier.Bonus;

namespace EnterTheIUT.Metier.Personnages
{

    /// <summary>
    /// Classe ennemi, héritée de Personnage
    /// </summary>
    /// <author>Alexandre Moreau</author>
    /// <author>Martin De Lima</author>
    public class Ennemi : Personnage,IAnimable
    {
        private Arme arme;
        private double direction;
        private Random random ;
        private TimeSpan waiting = TimeSpan.Zero;
        private TimeSpan cadence = TimeSpan.Zero;
        private TimeSpan waitingCollide = TimeSpan.Zero;
        private Joueur joueur;
        public Ennemi(Joueur joueur, double direction, float hp, float def, float atk, float spd, int xPos, int yPos, Arme arme, Game g, string spriteName = "ennemi/1.png") : base(hp, def, atk, spd, xPos, yPos, arme, g, spriteName)
        {
            this.joueur = joueur;
            this.direction = direction;
            this.random = new Random();
            this.arme = arme;
        }
        public override string TypeName => "ennemi";

        /// <summary>
        /// gestion de la collision de l'ennemi
        /// </summary>
        /// <param name="other"></param>
        /// <author>Alexandre Moreau</author>
        public override void CollideEffect(GameItem other)
        {
            if (waitingCollide <= TimeSpan.Zero)
            {
                if (other.TypeName == "projectile")
                {
                    this.PrendreDegats(10);
                    if (this.PointsDeVie <= 0)
                    {
                        this.joueur.AddScore();
                        this.DropBonus();
                        TheGame.RemoveItem(this);
                    }
                    TheGame.RemoveItem(other);
                    waitingCollide = new TimeSpan(0, 0, 0, 0, 500);
                }
            }
                if (other.TypeName == "Mur")
                {
                    this.direction = this.direction + 190;
                }
            
        }

        /// <summary>
        /// Permet de générer aléatoirement un Bonus lorsque l'ennemie meurt
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public void DropBonus()
        {
            switch (this.random.Next(4))
            {
                case 0:
                    BonusResistance bonusResistance = new BonusResistance(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(bonusResistance);
                    break;
                case 1:
                    BonusInvulnerable bonusInvulnerable = new BonusInvulnerable(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(bonusInvulnerable);
                    break;
                case 2:
                    BonusRegeneration bonusRegeneration = new BonusRegeneration(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(bonusRegeneration);
                    break;
                case 3:
                    BonusVitesse bonusVitesse = new BonusVitesse(this.XPos, this.YPos, TheGame);
                    TheGame.AddItem(bonusVitesse);
                    break;
            }
        }

        /// <summary>
        /// Permet à l'ennemi d'attaquer
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public void Attaquer()
        {
            cadence = this.arme.Attaque(this.XPos, this.YPos, this.direction,"joueur",cadence);
        }
        /// <summary>
        /// Permet le déplacement de l'ennemi 
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public new void Animate(TimeSpan ts)
        {
            if (this.Top < 0)
            {
                Top = 0;
                this.direction = 90;
            }
            else if (Bottom > GameHeight)
            {
                this.direction = 270;
                Bottom = GameHeight;
            }
            else if (Left < 0)
            {
                this.direction = 0;
                Left = 0;
            }
            else if (Right > GameWidth)
            {
                this.direction = 180;
                Right = GameWidth;
            }
            else
            {
                if (waiting <= TimeSpan.Zero)
                {
                    int ran = random.Next() % 4;
                    this.direction = ran * 90;
                    this.waiting = new TimeSpan(0, 0, 0, 1);
                }
            }
           
            this.Attaquer();
            this.cadence = this.cadence.Subtract(ts);
            double distance = 200 * this.Vitesse * ts.TotalSeconds;
            this.waiting=this.waiting.Subtract(ts);
            double x = distance * Math.Cos(direction * Math.PI / 180.0);
            double y = distance * Math.Sin(direction * Math.PI / 180.0);
            MoveXY(x, y);
            this.RefreshXY(x, y);
            this.waitingCollide=this.waitingCollide.Subtract(ts);

        }
    }
}
