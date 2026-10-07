namespace bird_watcher
{
    using System;
    using System.Linq;

    namespace BirdWatcher
    {
        public class BirdCount
        {
            private readonly int[] birdsPerDay;

            public BirdCount(int[] birdsPerDay)
            {
                this.birdsPerDay = birdsPerDay;
            }

            public static int[] LastWeek()
            {
                return new int[] { 0, 2, 5, 3, 7, 8, 4 };
            }

            public int Today()
            {
                return birdsPerDay[birdsPerDay.Length - 1];
            }

            public void IncrementTodaysCount()
            {
                birdsPerDay[birdsPerDay.Length - 1]++;
            }

            public bool HasDayWithoutBirds()
            {
                return birdsPerDay.Any(count => count == 0);
            }

            public int CountForFirstDays(int numberOfDays)
            {
                return birdsPerDay.Take(numberOfDays).Sum();
            }

            public int BusyDays()
            {
                return birdsPerDay.Count(count => count >= 5);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Datos de prueba para esta semana (7 días)
                int[] birdsThisWeek = new int[] { 2, 5, 0, 7, 4, 1, 3 };
                BirdCount birdCount = new BirdCount(birdsThisWeek);

                // 1. Conteo de la semana pasada (método estático)
                Console.WriteLine("Pájaros la semana pasada: " + string.Join(", ", BirdCount.LastWeek()));

                // 2. Conteo de hoy
                Console.WriteLine("Pájaros hoy: " + birdCount.Today());

                // 3. Incrementar el conteo de hoy
                birdCount.IncrementTodaysCount();
                Console.WriteLine("Pájaros hoy después de incrementar: " + birdCount.Today());

                // 4. Verificar si hubo algún día sin pájaros
                Console.WriteLine("¿Hubo algún día sin pájaros?: " + birdCount.HasDayWithoutBirds());

                // 5. Suma de los primeros N días (ejemplo: primeros 4 días)
                Console.WriteLine("Pájaros en los primeros 4 días: " + birdCount.CountForFirstDays(4));

                // 6. Días ocupados (días con 5 o más pájaros)
                Console.WriteLine("Número de días ocupados: " + birdCount.BusyDays());
            }
        }
    }
}