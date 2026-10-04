using ejercicio_9;

namespace ejercicio_9
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Languages
    {
        public static List<string> NewList()
        {
            return new List<string>();
        }

        public static List<string> GetExistingLanguages()
        {
            return new List<string> { "C#", "Clojure", "Elm" };
        }

        public static List<string> AddLanguage(List<string> languages, string language)
        {
            languages.Add(language);
            return languages;
        }

        public static int CountLanguages(List<string> languages)
        {
            return languages.Count;
        }

        public static bool HasLanguage(List<string> languages, string language)
        {
            return languages.Contains(language);
        }

        public static List<string> ReverseList(List<string> languages)
        {
            var reversed = new List<string>(languages);
            reversed.Reverse();
            return reversed;
        }

        public static bool IsExciting(List<string> languages)
        {
            if (languages.Count > 0 && languages[0] == "C#")
            {
                return true;
            }

            if (languages.Count >= 2 && languages[1] == "C#" &&
                (languages.Count == 2 || languages.Count == 3))
            {
                return true;
            }

            return false;
        }

        public static List<string> RemoveLanguage(List<string> languages, string language)
        {
            languages.Remove(language);
            return languages;
        }

        public static bool IsUnique(List<string> languages)
        {
            return languages.Distinct().Count() == languages.Count;
        }
    }
}
class Program
{
    static void Main()
    {
        var langs = Languages.GetExistingLanguages();
        Console.WriteLine(string.Join(", ", langs));
        Console.WriteLine("Count: " + Languages.CountLanguages(langs));
        Console.WriteLine("Has Elm: " + Languages.HasLanguage(langs, "Elm"));
        Console.WriteLine("Reversed: " + string.Join(", ", Languages.ReverseList(langs)));
        Console.WriteLine("Is exciting: " + Languages.IsExciting(langs));
    }
}