using ArenaGameEngine;

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void GameRound(Hero attacker, Hero defender, int attack)
        {
            string message;
            if (attacker is Support)
            {
                message = $"{attacker.Name} лекува себе си или {defender.Name}";
            }
            else
            {
                message = $"{attacker.Name} атакува {defender.Name} за {attack} точки щети";
                if (defender.IsAlive)
                {
                    message = message + $" но {defender.Name} оцеля.";
                }
                else
                {
                    message = message + $" и {defender.Name} умря.";
                }
            }
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight("Sir John");
            Rogue rogue = new Rogue("Slim Shady");
            Mage mage = new Mage("Gandalf");
            Support support = new Support("Heal");
            
            Arena arena = new Arena(knight, rogue);
            arena.EventListener = new ConsoleGameEventListener();

            Console.WriteLine("Battle begins.");
            Hero winner = arena.Battle();
            Console.WriteLine($"Battle ended.  Winner is: {winner.Name}");
            Console.ReadLine();
        }
    }
}
