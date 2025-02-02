using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Bonus
{
    public class BonusVitesse : Bonus
    {

        

        public override string TypeName => "Bonus Vitesse";

        public override TimeSpan time => new TimeSpan(0, 0, 15);

        public BonusVitesse(double x, double y, Game game, string spriteName = "bonus/vitesse.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
        }

        public override void CollideEffect(GameItem other)
        {
        }


        /// <summary>
        /// Renvoie si un objet est égale un objet de cette classe en renvoyant true, false sinon.
        /// </summary>
        /// <param name="obj">objet quelconque d'une classe</param>
        /// <returns>true or false</returns>
        /// <author>Lakhdar Gibril</author>
        public override bool Equals(object? obj)
        {
            return obj is BonusVitesse vitesse &&
                   TypeName == vitesse.TypeName &&
                   time.Equals(vitesse.time);
        }


        /// <summary>
        /// Renvoie le Hashcode d'un attribut, ici du typename du bonus
        /// </summary>
        /// <returns>int<returns>
        /// <author>Lakhdar Gibril</author>
        public override int GetHashCode()
        {
            return HashCode.Combine(TypeName);
        }
    }
}
