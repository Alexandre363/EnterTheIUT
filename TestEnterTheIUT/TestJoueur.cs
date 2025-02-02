using EnterTheIUT.Metier.Armes;
using EnterTheIUT.Metier.Personnages;
using EnterTheIUT.View;
using EnterTheIUT;
using IUTGame;
using IUTGame.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using TestUnitaire;
using EnterTheIUT.Metier.Bonus;

namespace TestEnterTheIUT
{
    /// <summary>
    /// Classe de TestUnitaire sur toutes les interractions possible d'un joueur avec les autres entités du jeu
    /// </summary>
    /// <author>Alexandre Moreau</author>
    /// <author>Lakhdar Gibril</author>
    public class TestJoueur
    {
        
        [Fact]
        public void TestChangementArme()
        {
            FakeScreen screen = new FakeScreen();
            Jeu fakeGame=new Jeu(screen);
            Joueur joueur = new("",0, 0, 0, 0, 0, 0, new Sceptre(0, 0, fakeGame), fakeGame);
            
            Assert.Equal("sceptre", joueur.Arme.TypeName);
            
        }

        /// <summary>
        /// Permet de savoir si le joueur à bien un boost de vitesse précis données
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void TestVitesse()
        {
            FakeScreen screen = new FakeScreen();
            Jeu jeu = new Jeu(screen);
            BonusVitesse bonusVitesse = new BonusVitesse(0,0, jeu);
            
            Joueur joueur = new("",0, 0, 0, 0, 0, 0, null, jeu);
            joueur.AugmenterStatistiques(bonusVitesse.TypeName);
            Assert.Equal(3, joueur.Vitesse);
        }

        /// <summary>
        /// Test Unitaire permettant de savoir si le joueur à bien un boost de resistance précis données
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void TestResistance()
        {
            FakeScreen screen = new FakeScreen();
            Jeu jeu = new Jeu(screen);
            BonusResistance bonusResistance = new BonusResistance(0, 0, jeu);

            Joueur joueur = new("",0, 0, 0, 0, 0, 0, null, jeu);
            joueur.AugmenterStatistiques(bonusResistance.TypeName);
            Assert.Equal(10, joueur.Defense);
        }

        /// <summary>
        /// Test Unitaire permettant de savoir si le joueur à bien été soigné.
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void TestSoin()
        {
            FakeScreen screen = new FakeScreen();
            Jeu jeu = new Jeu(screen);
            BonusRegeneration bonusRegeneration = new BonusRegeneration(0, 0, jeu);

            Joueur joueur = new("",0, 0, 0, 0, 0, 0, null, jeu);
            joueur.AugmenterStatistiques(bonusRegeneration.TypeName);
            Assert.Equal(3, joueur.PointsDeVie);
        }

        /// <summary>
        /// Test Unitaire permettant de savoir si le joueur est bien immunisé à toute sources de dégâts.
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void TestInvulnerabilite()
        {
            FakeScreen screen = new FakeScreen();
            Jeu jeu = new Jeu(screen);
            BonusInvulnerable bonusInvulnerable = new BonusInvulnerable(0, 0, jeu);

            Joueur joueur = new("",0, 0, 0, 0, 0, 0, null, jeu);
            joueur.AugmenterStatistiques(bonusInvulnerable.TypeName);
            Assert.True(joueur.IsInvunerable);
        }
    }
}
