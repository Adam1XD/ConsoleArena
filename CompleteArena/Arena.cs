using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CompleteArena
{
    public class Arena
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private Dice dice;

        public Arena(Warrior warrior1, Warrior warrior2, Dice dice)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.dice = dice;
        }

        private void Draw()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- \n");
            Console.WriteLine("Zdraví bojovníků: \n");
            ReturnWarrior(warrior1);
            Console.WriteLine();
            ReturnWarrior(warrior2);
            Console.WriteLine();
        }

        public void ReturnWarrior(Warrior a)
        {
            Console.WriteLine(a);
            Console.WriteLine("Hp: ");
            Console.WriteLine(a.ReturnHp());
            if(a is Mage)
            {
                Console.WriteLine("Mana: ");
                Console.WriteLine(((Mage)a).ReturnMana());
            }
        }

        private void GiveMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1500);
        }

        public void Fight()
        {
            Warrior w1 = warrior1;
            Warrior w2 = warrior2;
            Console.WriteLine("Welcome to Arena!");
            Console.WriteLine("Today two fighters will face each other.");
            Console.WriteLine("Defending champion: " + warrior1.DescriptionToString() + warrior1.ToString() + "!");
            Console.WriteLine("And the challenger: " + warrior2.DescriptionToString() + warrior2.ToString() + "!");
            bool warrior2begins = (dice.Roll() <= dice.GiveWallNumber() / 2);
            if (warrior2begins)
            {
                w1 = warrior2;
                w2 = warrior1;
            }
            Console.WriteLine("Začínat bude bojovník {0}!\nLet the fight begin...", w1);
            Console.ReadKey();
            while (w1.Alive() && w2.Alive())
            { 
                Draw();
                w1.Attack(w2);  
                GiveMessage(w1.GetLastMessage());
                GiveMessage(w2.GetLastMessage());

                if (w2.Alive()) 
                { 
                    Draw();
                    w2.Attack(w1);
                    GiveMessage(w2.GetLastMessage());
                    GiveMessage(w1.GetLastMessage());
                    
                }
                Console.WriteLine();
            }
            Draw();
            Console.WriteLine("Good fight.");
        }
    }
}
