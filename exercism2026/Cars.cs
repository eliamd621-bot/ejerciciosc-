namespace Cars
{
    using System;

    namespace AssemblyLineApp
    {
        public static class AssemblyLine
        {
            // 1. Tasa de éxito según la velocidad (de 0 a 10)
            public static double SuccessRate(int speed)
            {
                if (speed == 0)
                {
                    return 0.0;
                }
                else if (speed >= 1 && speed <= 4)
                {
                    return 1.0;
                }
                else if (speed >= 5 && speed <= 8)
                {
                    return 0.9;
                }
                else if (speed == 9)
                {
                    return 0.8;
                }
                else // speed == 10
                {
                    return 0.77;
                }
            }

            // 2. Producción total exitosa por hora (221 elementos base/hora por nivel de velocidad)
            public static double ProductionRatePerHour(int speed)
            {
                double baseRate = speed * 221;
                return baseRate * SuccessRate(speed);
            }

            // 3. Producción exitosa por minuto (redondeado hacia abajo como entero)
            public static int WorkingItemsPerMinute(int speed)
            {
                double perHour = ProductionRatePerHour(speed);
                return (int)(perHour / 60);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Pruebas a velocidad 6
                int velocidadTest = 6;

                Console.WriteLine($"--- Pruebas para velocidad {velocidadTest} ---");
                Console.WriteLine($"Tasa de éxito: {AssemblyLine.SuccessRate(velocidadTest) * 100}%");
                Console.WriteLine($"Producción por hora: {AssemblyLine.ProductionRatePerHour(velocidadTest)} items");
                Console.WriteLine($"Producción por minuto: {AssemblyLine.WorkingItemsPerMinute(velocidadTest)} items");

                Console.WriteLine("\n--- Tabla de producción por velocidad (0 a 10) ---");
                for (int speed = 0; speed <= 10; speed++)
                {
                    Console.WriteLine($"Velocidad {speed,2} | Éxito: {AssemblyLine.SuccessRate(speed) * 100,3}% | Por hora: {AssemblyLine.ProductionRatePerHour(speed),6:F1} | Por min: {AssemblyLine.WorkingItemsPerMinute(speed),2}");
                }
            }
        }
    }
}