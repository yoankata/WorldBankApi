using System;
using RichestCountries.ApiHelpers;

namespace RichestCountries
{
    class Program
    {
        public static void Main(string[] args)
        {
            var i = 0;
            var top10RichestCountries = WorldBankDataHelpers.GetTop10RichestCountriesByGdpUsd();
            
            top10RichestCountries.ForEach((t) => Console.Write(
                    "{0,3}. Country: {1,-30} GDP (current US$): {2:C}\n", ++i, t.CountryEntry.Name, Convert.ToDouble(t.Gdp)));

            // make sure console output stays on the screen

            Console.ReadKey();
        }
    }
}
