using System;

namespace Roll_the_Die
{
    public class Player
    {
        private readonly Random _random = new Random();

        public int RollDie()
        {
            return _random.Next(1, 19);
        }

        public double GenerateSpellStrength()
        {
            return _random.NextDouble() * 100.0;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var player = new Player();

            Console.WriteLine($"Tirada de dado (1-18): {player.RollDie()}");
            Console.WriteLine($"Fuerza de hechizo (0.0 - 99.99): {player.GenerateSpellStrength()}");
        }
    }
}