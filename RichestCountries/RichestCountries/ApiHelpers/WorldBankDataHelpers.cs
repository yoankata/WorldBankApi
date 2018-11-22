using System;
using System.Collections.Generic;
using System.Linq;
using RichestCountries.Models;

namespace RichestCountries.ApiHelpers
{
    public static class WorldBankDataHelpers
    {
        public static List<GdpEntry> GetTop10RichestCountriesByGdpUsd()
        {
            var countries = WorldBankApi.GetWorldBankApiCountries();
            var gdps = WorldBankApi.GetWorldBankApiGdps();

            // some countries are just regions, get those Ids
            var aggregateCountryIds =
                countries
                    .Where(ce => ce.Region.Name.ContainsAny("Aggregates", "Not classified"))
                    .Select(c => c.Iso2Code)
                    .ToList();

            // filter out countries that are regions 
            var countriesOnlyWithoutRegionalAggregates =
                gdps
                    .Where(g => !(aggregateCountryIds.Contains(g.CountryEntry.Id)))
                    .Where(c => !(c.Gdp is null))
                    .ToList();

            // sort by GDP (eventhough it's string it will sort correctly) and select top 10 GDPs
            var top10CountriesSortedByGdp =
                    countriesOnlyWithoutRegionalAggregates
                        .OrderByDescending(c => Convert.ToDouble(c.Gdp))
                        .Take(10)
                        .ToList();

            return top10CountriesSortedByGdp;

        }
    }
}
