using IUTGame;
using IUTGame.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterTheIUT.Metier.Personnages;

namespace EnterTheIUT.Metier.Armes
{

    /// <summary>
    /// Classe Sceptre héritant de la classe Arme, et désigne une sceptre magique pouvant être tenu par un ennemi ou un joueur.
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    /// <author>Alexandre Moreau</author>
    public class Sceptre : Arme
    {
        
        public override string TypeName => "sceptre";
        public override float Degat => 0.8f;

        public override float VitesseAttaque => 0.5f;

        public override float Poids => 1.1f;

        public Sceptre(double x, double y, Game game) : base(x, y, game,"armes/sceptre.png")
        {
        }

        public override void CollideEffect(GameItem other)
        {

        }

        /// <summary>
        /// Création des projectiles de l'arme
        /// </summary>
        /// <param name="x">coordonnée x</param>
        /// <param name="y">coordonnée y</param>
        /// <param name="angle">direction du tir</param>
        /// <param name="cible"></param>
        /// <param name="cadence">cadence de tir</param>
        /// <returns>le temps à attendre avant le prochain tir</returns>
        /// <author>Alexandre Moreau</author>
        public override TimeSpan Attaque(double x, double y,double angle,string cible,TimeSpan cadence)
        {
            if (cadence <= TimeSpan.Zero)
            {
                if (cible == "ennemi")
                {
                    Projectile projectile = new Projectile(0, x, y, this.TheGame);
                    Projectile projectile1 = new Projectile(90, x, y, this.TheGame);
                    Projectile projectile2 = new Projectile(180, x, y, this.TheGame);
                    Projectile projectile3 = new Projectile(270, x, y, this.TheGame);
                    TheGame.AddItem(projectile);
                    TheGame.AddItem(projectile1);
                    TheGame.AddItem(projectile2);
                    TheGame.AddItem(projectile3);
                }
                else
                {
                    ProjectileEnnemi projectile = new ProjectileEnnemi(0, x, y, this.TheGame);
                    ProjectileEnnemi projectile1 = new ProjectileEnnemi(90, x, y, this.TheGame);
                    ProjectileEnnemi projectile2 = new ProjectileEnnemi(180, x, y, this.TheGame);
                    ProjectileEnnemi projectile3 = new ProjectileEnnemi(270, x, y, this.TheGame);
                    TheGame.AddItem(projectile);
                    TheGame.AddItem(projectile1);
                    TheGame.AddItem(projectile2);
                    TheGame.AddItem(projectile3);
                }
                int time = (int)(500 / this.VitesseAttaque);
                cadence = new TimeSpan(0, 0, 0, 0, time);
            }
            return cadence;
        }

        public override void Animate(TimeSpan dt)
        {
            
        }

        public override string ToString()
        {
            return "sceptre";
        }
    }
}
