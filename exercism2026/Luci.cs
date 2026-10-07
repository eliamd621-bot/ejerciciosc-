namespace Luci
{
    class Lasagna
    {

        public int ExpectedMinutesInOven()
        {
            return 40;
        }

        public int RemainingMinutesInOven(int actualMinutes)
        {
            return ExpectedMinutesInOven() - actualMinutes;
        }

        public int PreparationTimeInMinutes(int layers)
        {
            return layers * 2;
        }

        public int ElapsedTimeInMinutes(int layers, int actualMinutesInOven)
        {
            return PreparationTimeInMinutes(layers) + actualMinutesInOven;
        }
    }
}
    
