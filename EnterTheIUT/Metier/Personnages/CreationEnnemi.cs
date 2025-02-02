using EnterTheIUT.Metier.Armes;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheIUT.Metier.Personnages
{
    /// <summary>
    /// Genere les vagues d'ennemi
    /// </summary>
    /// <author>Alexandre Moreau</author>
    public class CreationEnnemi:GameItem,IAnimable
    {
        private List<Ennemi> ennemis = new List<Ennemi>();
        private TimeSpan vague = TimeSpan.Zero;
        private Joueur joueur;
        public CreationEnnemi(Joueur joueur, double x, double y, Game game, string spriteName = "", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            this.joueur = joueur;
        }

        /// <summary>
        /// Genere aléatoirement les ennemis
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public void RandomEnnemi()
        {
            Arme arme;
            Sceptre sceptre = new(1600, 1600, TheGame);
            BaguetteMagique baguette = new(1600, 1600, TheGame);
            Random random = new Random();
            int nbEnnemi = random.Next(1, 4);
            

            for (int i = 0; i < nbEnnemi; i++)
            {
                switch (random.Next(1, 3))
                {
                    case 1:
                        arme = sceptre;
                        break;
                    case 2:
                        arme = baguette;
                        break;
                    default:
                        arme= baguette;
                        break;
                }
                Ennemi ennemi = new(this.joueur, random.Next(0, 80), 20, 5, 5, 1, random.Next(200,1000), random.Next(200, 800), arme, TheGame);
                TheGame.AddItem(ennemi);
                ennemis.Add(ennemi);
            }
        }

        public override void CollideEffect(GameItem other)
        {
            
        }

        /// <summary>
        /// Genere toute les 15 secondes des ennemis
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public void Animate(TimeSpan dt)
        {
            if (vague <= TimeSpan.Zero)
            {
                RandomEnnemi();
                vague = new(0, 0, 15);
            }
            this.vague=this.vague.Subtract(dt);
        }

        public List<Ennemi> Ennemis
        {
            get 
            {
                RandomEnnemi();
                return ennemis;
            }
        }

        public override string TypeName => "creation Ennemi";
    }
}
