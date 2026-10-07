namespace Calling_Connoisseur_ejercicio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace EjercicioDialingCodes
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== Demostración de DialingCodes ===\n");

                
                var emptyDict = DialingCodes.GetEmptyDictionary();
                Console.WriteLine($"1. Diccionario vacío: Cantidad de elementos = {emptyDict.Count}");

                
                var existingDict = DialingCodes.GetExistingDictionary();
                Console.WriteLine($"2. Diccionario existente: {FormatDict(existingDict)}");

                
                var singleDict = DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
                Console.WriteLine($"3. Añadir a vacío: {FormatDict(singleDict)}");

                
                DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
                Console.WriteLine($"4. Añadir a existente: {FormatDict(existingDict)}");

                
                string country55 = DialingCodes.GetCountryNameFromDictionary(existingDict, 55);
                string country999 = DialingCodes.GetCountryNameFromDictionary(existingDict, 999);
                Console.WriteLine($"5. Buscar 55: '{country55}' | Buscar 999: '{country999}'");

                
                bool exists55 = DialingCodes.CheckCodeExists(existingDict, 55);
                bool exists999 = DialingCodes.CheckCodeExists(existingDict, 999);
                Console.WriteLine($"6. Existe 55? {exists55} | Existe 999? {exists999}");

                
                DialingCodes.UpdateDictionary(existingDict, 1, "Les États-Unis");
                DialingCodes.UpdateDictionary(existingDict, 999, "Newlands");
                Console.WriteLine($"7. Actualizado: {FormatDict(existingDict)}");

                
                DialingCodes.RemoveCountryFromDictionary(existingDict, 91);
                Console.WriteLine($"8. Tras eliminar 91: {FormatDict(existingDict)}");

                
                string longest = DialingCodes.FindLongestCountryName(existingDict);
                Console.WriteLine($"9. Nombre más largo: '{longest}'");

                Console.WriteLine("\nPresiona cualquier tecla para salir...");
                Console.ReadKey();
            }

            
            private static string FormatDict(Dictionary<int, string> dict)
            {
                return string.Join(", ", dict.Select(kvp => $"{kvp.Key} => \"{kvp.Value}\""));
            }
        }

        public static class DialingCodes
        {
            
            public static Dictionary<int, string> GetEmptyDictionary()
            {
                return new Dictionary<int, string>();
            }

            
            public static Dictionary<int, string> GetExistingDictionary()
            {
                return new Dictionary<int, string>
                {
                    [1] = "United States of America",
                    [55] = "Brazil",
                    [91] = "India"
                };
            }

            
            public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
            {
                var dictionary = new Dictionary<int, string>();
                dictionary.Add(countryCode, countryName);
                return dictionary;
            }

            // Tarea 4
            public static Dictionary<int, string> AddCountryToExistingDictionary(
                Dictionary<int, string> existingDictionary, int countryCode, string countryName)
            {
                existingDictionary.Add(countryCode, countryName);
                return existingDictionary;
            }

            // Tarea 5
            public static string GetCountryNameFromDictionary(
                Dictionary<int, string> existingDictionary, int countryCode)
            {
                if (existingDictionary.TryGetValue(countryCode, out string countryName))
                {
                    return countryName;
                }

                return string.Empty;
            }

            // Tarea 6
            public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
            {
                return existingDictionary.ContainsKey(countryCode);
            }

            // Tarea 7
            public static Dictionary<int, string> UpdateDictionary(
                Dictionary<int, string> existingDictionary, int countryCode, string countryName)
            {
                if (existingDictionary.ContainsKey(countryCode))
                {
                    existingDictionary[countryCode] = countryName;
                }

                return existingDictionary;
            }

            // Tarea 8
            public static Dictionary<int, string> RemoveCountryFromDictionary(
                Dictionary<int, string> existingDictionary, int countryCode)
            {
                existingDictionary.Remove(countryCode);
                return existingDictionary;
            }

            
            public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
            {
                if (existingDictionary == null || existingDictionary.Count == 0)
                {
                    return string.Empty;
                }

                return existingDictionary.Values.MaxBy(name => name.Length) ?? string.Empty;
            }
        }
    }
}