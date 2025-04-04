﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using SimpleFastReport.API.Models.HumanResourcesSchema;
using SimpleFastReport.API.Models.PersonSchema;
using SimpleFastReport.API.Models.ProductionSchema;
using SimpleFastReport.API.Models.PurchasingSchema;
using SimpleFastReport.API.Models.SalesSchema;


namespace SimpleFastReport.API.Models.SalesSchema
{
    /// <summary>
    /// Lookup table containing standard ISO currencies.
    /// </summary>
    public partial class Currency
    {
        public Currency()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            CurrencyRateFromCurrencyCodeNavigations = new HashSet<CurrencyRate>();
            CurrencyRateToCurrencyCodeNavigations = new HashSet<CurrencyRate>();
        }

        /// <summary>
        /// The ISO code for the Currency.
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Currency name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; }
    }
}