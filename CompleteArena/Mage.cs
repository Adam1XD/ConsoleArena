using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CompleteArena
{
    public class Mage : Warrior
    {
        private int Mana;
        private int MaxMana;
        private int MagicAttack;

        public Mage(string name, int hp, int attack, int deffence, string description, Dice dice, int mana, int magicattack) : base(name, hp, attack, deffence, description, dice)
        {
            Mana = mana;
            MaxMana = mana;
            MagicAttack = magicattack;
        }

        public override void Attack(Warrior enemy)
        {
            int power = 0;
            if(Mana < MaxMana)
            {
                Mana += 10;
                if(Mana > MaxMana)
                {
                    Mana = MaxMana;
                }
                base.Attack(enemy);
            }
            else
            {
                power = MagicAttack + dice.Roll();
                SetUpMessage(String.Format("{0} used magic for {1} dmg", Name, power));
                enemy.Deffend(power);
                Mana = 0;
            }
            
        }

        public string ReturnMana()
        {
            return GraphicPointer(Mana, MaxMana) + Mana + "mana";
        }
    }
}
