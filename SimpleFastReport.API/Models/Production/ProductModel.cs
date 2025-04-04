﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using SimpleFastReport.API.Models.HumanResourcesSchema;
using SimpleFastReport.API.Models.PersonSchema;
using SimpleFastReport.API.Models.ProductionSchema;
using SimpleFastReport.API.Models.PurchasingSchema;
using SimpleFastReport.API.Models.SalesSchema;


namespace SimpleFastReport.API.Models.ProductionSchema
{
    /// <summary>
    /// Product model classification.
    /// </summary>
    public partial class ProductModel
    {
        public ProductModel()
        {
            ProductModelIllustrations = new HashSet<ProductModelIllustration>();
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key for ProductModel records.
        /// </summary>
        public int ProductModelId { get; set; }
        /// <summary>
        /// Product model description.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Detailed product catalog information in xml format.
        /// </summary>
        public string CatalogDescription { get; set; }
        /// <summary>
        /// Manufacturing instructions in xml format.
        /// </summary>
        public string Instructions { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; }
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}