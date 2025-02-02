using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Bonus
{
    public class BonusRegeneration : Bonus
    {
        public override string TypeName => "Bonus Regeneration";

        public override TimeSpan time => new TimeSpan(0, 0, 0);

        public BonusRegeneration(double x, double y, Game game, string spriteName = "bonus/regeneration.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
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
            return obj is BonusRegeneration regeneration &&
                   TypeName == regeneration.TypeName
                   && time.Equals(regeneration.time);
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
