namespace Weighing_Machine
{
    using System;

    namespace WeighingMachineApp
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== Demostración de WeighingMachine ===\n");

                // Tarea 1: Probar precisión fija desde el constructor
                var wm = new WeighingMachine(precision: 3);
                Console.WriteLine($"1. Precision (get-only): {wm.Precision}");

                // Tarea 2: Asignar y obtener el peso
                wm.Weight = 60.567;
                Console.WriteLine($"2. Weight actual: {wm.Weight}");

                // Tarea 5: Verificar valor por defecto de TareAdjustment (debe ser 5.0)
                Console.WriteLine($"3. TareAdjustment (por defecto): {wm.TareAdjustment}");

                // Tarea 6: DisplayWeight con tara por defecto (60.567 - 5.0 = 55.567 kg)
                Console.WriteLine($"4. DisplayWeight (con tare = 5.0): \"{wm.DisplayWeight}\"");

                // Tarea 4 y 6: Modificar TareAdjustment a 10.0 y volver a medir
                wm.TareAdjustment = 10.0;
                Console.WriteLine($"5. DisplayWeight (con tare = 10.0): \"{wm.DisplayWeight}\"");

                // Tarea 3: Prueba de validación (Peso negativo)
                Console.WriteLine("\n--- Prueba de Excepción (Peso Negativo) ---");
                try
                {
                    wm.Weight = -10.0;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Excepción capturada correctamente: {ex.GetType().Name}");
                    Console.WriteLine($"Mensaje: {ex.Message}");
                }

                Console.WriteLine("\nPresiona cualquier tecla para finalizar...");
                Console.ReadKey();
            }
        }

        public class WeighingMachine
        {
            // Tarea 1: Propiedad de solo lectura establecida desde el constructor
            public int Precision { get; }

            // Tarea 2 y 3: Propiedad Weight con variable de respaldo y validación
            private double weight;

            public double Weight
            {
                get => weight;
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");
                    }
                    weight = value;
                }
            }

            // Tarea 4 y 5: Propiedad TareAdjustment con valor inicial de 5.0
            public double TareAdjustment { get; set; } = 5.0;

            // Tarea 6: Propiedad calculada con formato de precisión y sufijo "kg"
            public string DisplayWeight
            {
                get
                {
                    double displayValue = Weight - TareAdjustment;
                    return $"{displayValue.ToString($"F{Precision}")} kg";
                }
            }

            // Constructor
            public WeighingMachine(int precision)
            {
                Precision = precision;
            }
        }
    }
}