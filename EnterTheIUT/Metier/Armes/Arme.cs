using IUTGame;
using IUTGame.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Armes
{

    /// <summary>
    /// Classe abstraite Arme héritant de GameItem, elle nous servira à créer toutes les armes principales du jeux.
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    public abstract class Arme : GameItem,IAnimable 
    {
        public override string TypeName => "Arme";

        protected Arme(double x, double y, Game game, string spriteName = null) : base(x, y, game,spriteName, 1)
        {
        }

        public abstract float Degat
        {
            get;                  
        }

        public abstract float VitesseAttaque
        {
            get;
        }

        public abstract float Poids 
        { 
            get; 
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
        public abstract TimeSpan Attaque(double x, double y,double angle,string cible,TimeSpan cadence);

        public abstract void Animate(TimeSpan dt);

        public override abstract string ToString();
    }
}
