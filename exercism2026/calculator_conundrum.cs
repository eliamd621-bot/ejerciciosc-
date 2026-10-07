namespace calculator_conundrum_ejercicios
{
    using System;

    namespace SimpleCalculatorApp
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== Demostración de SimpleCalculator ===\n");

                // 1. Operaciones válidas
                Console.WriteLine(SimpleCalculator.Calculate(16, 51, "+")); // "16 + 51 = 67"
                Console.WriteLine(SimpleCalculator.Calculate(32, 6, "*"));  // "32 * 6 = 192"
                Console.WriteLine(SimpleCalculator.Calculate(512, 4, "/")); // "512 / 4 = 128"

                // 2. División por cero (Manejo de excepción interna)
                Console.WriteLine(SimpleCalculator.Calculate(512, 0, "/")); // "Division by zero is not allowed."

                // 3. Pruebas de Excepciones Lanzadas
                Console.WriteLine("\n--- Pruebas de Excepciones ---");

                ProbandoExcepcion(() => SimpleCalculator.Calculate(100, 10, "-"), "Operación no permitida ('-')");
                ProbandoExcepcion(() => SimpleCalculator.Calculate(8, 2, ""), "Operación vacía ('')");
                ProbandoExcepcion(() => SimpleCalculator.Calculate(58, 6, null), "Operación null");

                Console.WriteLine("\nPresiona cualquier tecla para finalizar...");
                Console.ReadKey();
            }

            // Método auxiliar para capturar y mostrar las excepciones lanzadas
            private static void ProbandoExcepcion(Action accion, string descripcion)
            {
                try
                {
                    accion();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{descripcion}] -> Lanza la excepción: {ex.GetType().Name}");
                }
            }
        }

        public static class SimpleCalculator
        {
            public static string Calculate(int operand1, int operand2, string operation)
            {
                return operation switch
                {
                    "+" => $"{operand1} + {operand2} = {Addition(operand1, operand2)}",
                    "*" => $"{operand1} * {operand2} = {Multiplication(operand1, operand2)}",
                    "/" => Divide(operand1, operand2),
                    "" => throw new ArgumentException("Operation cannot be empty.", nameof(operation)),
                    null => throw new ArgumentNullException(nameof(operation), "Operation cannot be null."),
                    _ => throw new ArgumentOutOfRangeException(nameof(operation), "Operation is not supported.")
                };
            }

            private static string Divide(int operand1, int operand2)
            {
                try
                {
                    int result = Division(operand1, operand2);
                    return $"{operand1} / {operand2} = {result}";
                }
                catch (DivideByZeroException)
                {
                    return "Division by zero is not allowed.";
                }
            }

            // Métodos auxiliares de cálculo
            private static int Addition(int operand1, int operand2) => operand1 + operand2;
            private static int Multiplication(int operand1, int operand2) => operand1 * operand2;
            private static int Division(int operand1, int operand2) => operand1 / operand2;
        }
    }
}