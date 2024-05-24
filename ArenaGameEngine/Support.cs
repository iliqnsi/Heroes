using System;

namespace ArenaGameEngine
{
    public class Support : Hero
    {
        public Support(string name) : base(name)
        {

        }

        public int HealingPower { get; private set; }

        public Support(string name) : base(name)
        {
            Health = 450;  // Малко повече здраве от Mage
            Strength = 40; // Основна сила малко по-ниска
            HealingPower = 60; // Лечебна сила
        }

        public void Heal(Hero otherHero)
        {
            if (otherHero.IsAlive)
            {
                otherHero.ReceiveHealing(HealingPower);
                Console.WriteLine($"{Name} лекува {otherHero.Name} за {HealingPower} здраве.");
            }
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
        }

        public void ReceiveHealing(int healing)
        {
            Health += healing;
        }
    }
}