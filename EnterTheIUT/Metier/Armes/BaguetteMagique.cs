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
    /// Classe Baguette Magique héritant de la classe Arme, et désigne une baguette magique pouvant être tenu par un ennemi ou un joueur.
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    /// <author>Alexandre Moreau</author>
    public class BaguetteMagique : Arme
    {

        public override string TypeName => "baguette_magique";
        public override float Degat => 0.3f;

        public override float VitesseAttaque => 2f;

        public override float Poids => 1.5f;

        public BaguetteMagique(double x, double y, Game game, string spriteName = "armes/baguette_magique.png") : base(x, y, game, spriteName)
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
        public override TimeSpan Attaque(double x,double y,double angle,string cible,TimeSpan cadence)
        {
            if (cadence <= TimeSpan.Zero)
            {
                if (cible == "ennemi")
                {
                    Projectile projectile = new Projectile(angle, x, y, this.TheGame);
                    TheGame.AddItem(projectile);
                }
                else
                {
                    ProjectileEnnemi projectile = new ProjectileEnnemi(angle, x, y, this.TheGame);
                    TheGame.AddItem(projectile);
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
            return "baguette_magique";
        }
    }
}
