using EnterTheIUT.Metier.Bonus;
using EnterTheIUT.Metier.Personnages;
using EnterTheIUT;
using IUTGame;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using IUTGame.WPF;
using EnterTheIUT.View;
using System.Windows.Controls;
using System.Windows;
using TestUnitaire;

namespace TestEnterTheIUT
{
    /// <summary>
    /// Classe publique contenant des tests unitaires servant à la classe Bonus.
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public class TestBonus
    {

        /// <summary>
        /// Test unitaire permettant de savoir si les bonus de même types sont bien égaux. 
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void IsBonusEquals()
        {

            FakeScreen screen = new FakeScreen();
            Jeu? jeu = new Jeu(screen);

            // Test pour le bonus invulnerable.
            BonusInvulnerable bonusInvulnerable_1 = new(0, 0, jeu);
            BonusInvulnerable bonusInvulnerable_2 = new(0,0, jeu);

            Assert.True(bonusInvulnerable_1.Equals(bonusInvulnerable_2));

            //Test pour le bonus regeneration. 
            BonusRegeneration bonusRegeneration_1 = new(0, 0, jeu);
            BonusRegeneration bonusRegeneration_2 = new(0, 0, jeu);

            Assert.True(bonusRegeneration_1.Equals(bonusRegeneration_2));

            //Test pour le bonus resistance. 
            BonusResistance bonusResistance_1 = new(0, 0, jeu);
            BonusResistance bonusResistance_2 = new(0, 0, jeu);

            Assert.True(bonusResistance_1.Equals(bonusResistance_2));

            //Test pour le bonus vitesse. 
            BonusVitesse bonusVitesse_1 = new(0, 0, jeu);
            BonusVitesse bonusVitesse_2 = new(0, 0, jeu);

            Assert.True(bonusVitesse_1.Equals(bonusVitesse_2));

            //Test pour des bonus différents entre eux pour voir qu'ils soient bien différents. 
            Assert.False(bonusInvulnerable_1.Equals(bonusVitesse_2));
            Assert.False(bonusRegeneration_1.Equals(bonusResistance_1));
        }

        /// <summary>
        /// Test unitaire permettant de savoir si un Hash code d'un objet bonus soit égal à un hash code du même type
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void BonusHashCodeEquals ()
        {
            FakeScreen screen = new FakeScreen();
            Jeu? jeu = new Jeu(screen);

            // Test pour le bonus invulnerable.
            BonusInvulnerable bonusInvulnerable_1 = new(0, 0, jeu);
            BonusInvulnerable bonusInvulnerable_2 = new(0, 0, jeu);

            Assert.Equal(bonusInvulnerable_1.GetHashCode(),bonusInvulnerable_2.GetHashCode());

            //Test pour le bonus regeneration. 
            BonusRegeneration bonusRegeneration_1 = new(0, 0, jeu);
            BonusRegeneration bonusRegeneration_2 = new(0, 0, jeu);

            Assert.Equal(bonusRegeneration_1.GetHashCode(), bonusRegeneration_2.GetHashCode());

            //Test pour le bonus resistance. 
            BonusResistance bonusResistance_1 = new(0, 0, jeu);
            BonusResistance bonusResistance_2 = new(0, 0, jeu); 
            
            Assert.Equal(bonusResistance_1.GetHashCode(), bonusResistance_2.GetHashCode());

            //Test pour le bonus vitesse. 
            BonusVitesse bonusVitesse_1 = new(0, 0, jeu);
            BonusVitesse bonusVitesse_2 = new(0, 0, jeu); 
            
            Assert.Equal(bonusVitesse_1.GetHashCode(), bonusVitesse_2.GetHashCode());

            //Test pour des bonus différents entre eux pour voir qu'ils soient bien différents. 
            Assert.NotEqual(bonusInvulnerable_1.GetHashCode(),bonusRegeneration_1.GetHashCode());
            Assert.NotEqual(bonusRegeneration_2.GetHashCode(),bonusVitesse_1.GetHashCode());
        }
    }
}
