using System;

namespace ArenaGameEngine
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {

        }

        public int MagicPower { get; private set; }

        public Mage(string name) : base(name)
        {
            Health = 400;  // По-малко здраве от базовия герой
            Strength = 50; // Основна сила малко по-ниска
            MagicPower = 70; // Допълнителна магическа сила
        }

        public override int Attack()
        {
            int baseAttack = base.Attack();
            int magicAttack = (MagicPower * Random.Shared.Next(80, 121)) / 100;
            return baseAttack + magicAttack;
        }
    }
}