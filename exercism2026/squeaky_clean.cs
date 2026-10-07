namespace squeaky_clean
{
    using System;
    using System.Text;

    namespace SqueakyClean
    {
        public static class Identifier
        {
            private const char GreekLower = 'α'; // U+03B1
            private const char GreekUpperBound = 'ω'; // U+03C9

            public static string Clean(string identifier)
            {
                var result = new StringBuilder();

                for (int i = 0; i < identifier.Length; i++)
                {
                    char c = identifier[i];

                    // 1. Reemplazar espacios por guiones bajos
                    if (c == ' ')
                    {
                        result.Append('_');
                        continue;
                    }

                    // 2. Reemplazar caracteres de control por "CTRL"
                    if (char.IsControl(c))
                    {
                        result.Append("CTRL");
                        continue;
                    }

                    // 3. Convertir kebab-case a camelCase (eliminar '-' y hacer mayúscula la siguiente letra)
                    if (c == '-')
                    {
                        if (i + 1 < identifier.Length && char.IsLetter(identifier[i + 1]))
                        {
                            result.Append(char.ToUpper(identifier[i + 1]));
                            i++; // Saltear el siguiente carácter ya procesado
                        }
                        continue;
                    }

                    // 4. Omitir letras griegas en minúscula (de α a ω)
                    if (c >= GreekLower && c <= GreekUpperBound)
                    {
                        continue;
                    }

                    // 5. Mantener solo letras válidas y guiones bajos (descarta números, símbolos y emojis)
                    if (char.IsLetter(c) || c == '_')
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Pruebas de los diferentes casos de uso
                Console.WriteLine($"Espacios a '_': '{Identifier.Clean("my   name")}'");                     // "my___name"
                Console.WriteLine($"Caracteres de Control: '{Identifier.Clean("my\0name")}'");                  // "myCTRLname"
                Console.WriteLine($"Kebab-case a camelCase: '{Identifier.Clean("kebab-case")}'");               // "kebabCase"
                Console.WriteLine($"Omitir minúsculas griegas: '{Identifier.Clean("MyαβγName")}'");            // "MyName"
                Console.WriteLine($"Omitir números y símbolos: '{Identifier.Clean("a123b!@#")}'");             // "ab"
            }
        }
    }
}