using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Bonus
{

    /// <summary>
    /// Classe abstraite Bonus, représentant les différents bonus que peut avoir le joueur. 
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public abstract class Bonus : GameItem
    {

        /// <summary>
        /// Propriété abstraite signifiant le temps de l'effet bonus.
        /// </summary>
        public abstract TimeSpan time
        {
            get;
        }

        /// <summary>
        /// Constructeur de la classe Bonus, appelant le constructeur de la classe GameItem. 
        /// </summary>
        /// <param name="x">coordonnées x de l'item</param>
        /// <param name="y">coordonnées y de l'item</param>
        /// <param name="game">à quel jeu ce dernier appartient</param>
        /// <param name="spriteName">chemin d'accès du sprite</param>
        /// <param name="zindex">coordonée z de l'item</param>
        /// <author>Lakhdar Gibril</author>
        public Bonus(double x, double y, Game game, string spriteName = "", int zindex = 0) 
            : base(x, y, game, spriteName, zindex)
        {
        }
    }
}
