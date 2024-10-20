using FuzzySharp;

namespace PetshopExercicio.Utility;

internal static class StringCheck
{
    public static string NullOrEmpty(string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Valor inválido! Digite novamente");
            input = Console.ReadLine()!;
        }
        return input;
    }
    public static bool IsSimilar(string str1, string str2)
    {
        bool similar = false;

        int similarity01 = Fuzz.Ratio(str1, str2);
        int similarity02 = Fuzz.Ratio(str1.ToUpper(), str2.ToUpper());
        int similarity = Math.Max(similarity01, similarity02);

        if (similarity >= 82)
        {
            similar = true;
        }

        return similar;
    }
}
