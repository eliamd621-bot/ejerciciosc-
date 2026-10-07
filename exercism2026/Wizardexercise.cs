namespace ejercicio.wizard
{
    using System;

    public abstract class Character
    {
        public override string ToString()
        {
            return $"Character is a {GetType().Name}";
        }

        public virtual bool Vulnerable()
        {
            return false;
        }

        public abstract int DamagePoints(Character opponent);
    }

    public class Warrior : Character
    {
        public override int DamagePoints(Character opponent)
        {
            return opponent.Vulnerable() ? 10 : 6;
        }
    }

    public class Wizard : Character
    {
        private bool spellPrepared = false;

        public void PrepareSpell()
        {
            spellPrepared = true;
        }

        public override bool Vulnerable()
        {
            return !spellPrepared;
        }

        public override int DamagePoints(Character opponent)
        {
            return spellPrepared ? 12 : 3;
        }
    }

    class Program
    {
        static void Main()
        {
            var warrior = new Warrior();
            var wizard = new Wizard();

            Console.WriteLine(warrior.ToString());          
            Console.WriteLine(wizard.ToString());           

            Console.WriteLine("Warrior vulnerable: " + warrior.Vulnerable());   
            Console.WriteLine("Wizard vulnerable (sin preparar): " + wizard.Vulnerable());

            
            Console.WriteLine("Warrior ataca a Wizard sin preparar: " + warrior.DamagePoints(wizard));

            wizard.PrepareSpell();
            Console.WriteLine("Wizard vulnerable (ya preparo): " + wizard.Vulnerable()); 

            
            Console.WriteLine("Wizard (preparado) ataca a Warrior: " + wizard.DamagePoints(warrior));

            
            Console.WriteLine("Warrior ataca a Wizard preparado: " + warrior.DamagePoints(wizard));
        }
    }
}