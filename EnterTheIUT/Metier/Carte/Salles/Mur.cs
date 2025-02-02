using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Carte.Salles
{
    /// <summary>
    /// Mur d'un salle
    /// </summary>
    /// <author>GUYENET Julien</author>
    public class Mur : GameItem
    {

        public override string TypeName => "Mur";
        /// <summary>
        /// Crée un sprite de mur
        /// </summary>
        /// <param name="x">position X</param>
        /// <param name="y">position y</param>
        /// <param name="game">appartenance au jeu</param>
        /// <param name="spriteName">depend du mur (haut, bas ,droit, gauche)</param>
        /// <author>GUYENET Julien</author>
        public Mur(double x, double y, Game game , string spriteName) : base(x, y, game, spriteName ,-1)
        {
        }

        public override void CollideEffect(GameItem other)
        {
            ;
        }
    }
}
