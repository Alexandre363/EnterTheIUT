using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Carte.Salles
{
    /// <summary>
    /// Porte d'une salle
    /// </summary>
    /// <author>GUYENET Julien</author>
    public class Porte : GameItem
    {
        public override string TypeName => "Porte";
        /// <summary>
        /// Utile pour savoir avec quelle porte l'utilisateur rentre en contacte
        /// </summary>
        /// <author>GUYENET Julien</author>
        private string type;

        public string Type { get { return type; } set { type = value; } }

        /// <summary>
        /// Crée une porte
        /// </summary>
        /// <param name="x">Position x</param>
        /// <param name="y">Position y</param>
        /// <param name="game">appartenance au Jeu</param>
        /// <param name="spriteName">sprite de la porte (haut,bas, droit, gauche)</param>
        /// <param name="type">type de la porte (haut,bas,droit,gauche)</param>
        /// <author>GUYENET Julien</author>
        public Porte(double x, double y, Game game, string spriteName, string type) : base(x, y, game, spriteName, 0)
        {
            this.type = type;
        }

        public override void CollideEffect(GameItem other)
        {
            ;
        }
    }
}
