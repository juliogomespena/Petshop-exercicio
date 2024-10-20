using FuzzySharp;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PetshopExercicio.Entidades;

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
        int similarity03 = Fuzz.PartialRatio(str1, str2);
        int similarity04 = Fuzz.PartialRatio(str1.ToUpper(), str2.ToUpper());
        int similarity = ((int)new[] { similarity01, similarity02, similarity03, similarity04 }.Max());

        if (similarity >= 78)
        {
            similar = true;
        }

        return similar;
    }
}
