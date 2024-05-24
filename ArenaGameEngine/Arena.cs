namespace ArenaGameEngine
{
    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }
        public GameEventListener EventListener { get; set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;
            attacker = HeroA;
            defender = HeroB;
            while (true)
            {
                if (attacker is Support support)
                {
                    // Support hero heals itself or the defender instead of attacking
                    support.Heal(attacker);
                    if (defender.IsAlive)
                    {
                        support.Heal(defender);
                    }
                }
                else
                {
                    int damage = attacker.Attack();
                    defender.TakeDamage(damage);

                    if (EventListener != null)
                    {
                        EventListener.GameRound(attacker, defender, damage);
                    }

                    if (defender.IsDead) return attacker;
                }

                Hero temp = attacker;
                attacker = defender;
                defender = temp;
            }
        }
    }
}
