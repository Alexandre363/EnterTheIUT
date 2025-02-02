using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterTheIUT.Metier.Armes;
using EnterTheIUT.Metier.Carte;
using EnterTheIUT.Metier.Carte.Salles;
using EnterTheIUT.Metier.Personnages;
using IUTGame;
using System.Windows;
using Microsoft.VisualBasic;

namespace EnterTheIUT
{
    public class Jeu:Game
    {
        private string playerName = String.Empty;
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        public Jeu(IScreen screen) : base(screen, "Sprites", "Sounds")
        {

        }

        protected override void InitItems()
        {
            Carte carte = new(this);
            Sceptre sceptre = new(500, 500, this);
            Joueur joueur = new(this.PlayerName,1000, 5, 5, 1, (int)this.Screen.Width/2 , (int)this.Screen.Height/2,null,this);
            CreationEnnemi ennemi = new(joueur, 1600, 1600, this);
            BaguetteMagique baguetteMagique = new(300,300,this);
            
            AddItem(baguetteMagique);
            AddItem(joueur);
            AddItem(sceptre);
            AddItem(ennemi);
        }


        protected override void RunWhenLoose()
        {
            System.Windows.MessageBox.Show("vous avez perdu");
        }

        protected override void RunWhenWin()
        {
            //TODO
        }
    }
}
