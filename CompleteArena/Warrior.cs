using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteArena
{
    public class Warrior
    {
        protected string Name;
        protected int Hp;
        protected int MaxHp;
        protected int AttackPower;
        protected int Deffence;
        protected string Description;
        protected Dice dice;
        private string Message;

        public Warrior(string name, int hp, int attack, int deffence, string description, Dice dice)
        {
            Name = name;
            Hp = hp;
            MaxHp = hp;
            AttackPower = attack;
            Deffence = deffence;
            Description = description;
            this.dice = dice;
        }

        public override string ToString()
        {
            return Name;
        }

        public  string DescriptionToString()
        {
            return Description.ToString();
        }

        public bool Alive()
        {
            return (Hp > 0);
        }

        protected string GraphicPointer(int current , int max)
        {
            string s = "[";
            int total = 20;
            double count = Math.Round(((double)current / max) * total);
            if ((count == 0) && (Alive()))
                count = 1;
            for (int i = 0; i < count; i++)
                s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        public string ReturnHp()
        {
            return GraphicPointer(Hp, MaxHp) + Hp + "hp";
        }

        public void Deffend(int power)
        {
            int injury = power - (Deffence + dice.Roll());
            if(injury > 0)
            {
                Hp -= injury;
                Message = String.Format("{0} got {1} damage after block.", Name, injury);
                if (Hp <= 0)
                {
                    Hp = 0;
                    Message += " died.";
                }
            }
            else
            {
                Message = String.Format("{0} blocked the attack.", Name);
            }
            SetUpMessage(Message);
        }

        public virtual void Attack(Warrior enemy)
        {
            int power = AttackPower + dice.Roll();
            SetUpMessage(String.Format("{0} is attacking with {1} damage.", Name, power));
            enemy.Deffend(power);
        }

        protected void SetUpMessage(string message)
        {
            Message = message;
        }

        public string GetLastMessage()
        {
            return Message;
        }
    }
}
