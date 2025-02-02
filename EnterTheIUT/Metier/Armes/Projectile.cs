using IUTGame;
using IUTGame.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Armes
{
    /// <summary>
    /// La classe Projectile designe le projectile de la classe baguette magique
    /// </summary>
    /// <author>Alexandre Moreau</author>
    public class Projectile :GameItem, IAnimable
    {
        private double angle;
        public Projectile(double angle, double x, double y, Game game, string spriteName = "projectiles/player_projectile.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            this.angle = angle;
 
        }

        public override string TypeName => "projectile";

        /// <summary>
        /// Déplacement du projectile
        /// </summary>
        /// <param name="dt">temps écoulé</param>
        /// <author>Alexandre Moreau</author>
        public void Animate(TimeSpan dt)
        {
            MoveDA(1000*dt.TotalSeconds, angle);
        }

        /// <summary>
        /// Interaction avec les GameItem
        /// </summary>
        /// <param name="other">GameItem rencontré</param>
        /// <author>Alexandre Moreau</author>
        public override void CollideEffect(GameItem other)
        {
            
                if (other.TypeName == "Mur")
                {
                    TheGame.RemoveItem(this);
                    MoveXY(1600, 1600);
                }

            
        }

    }
}
