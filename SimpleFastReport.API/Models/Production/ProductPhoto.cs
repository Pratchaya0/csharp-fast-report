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
    /// Product images.
    /// </summary>
    public partial class ProductPhoto
    {
        public ProductPhoto()
        {
            ProductProductPhotos = new HashSet<ProductProductPhoto>();
        }

        /// <summary>
        /// Primary key for ProductPhoto records.
        /// </summary>
        public int ProductPhotoId { get; set; }
        /// <summary>
        /// Small image of the product.
        /// </summary>
        public byte[] ThumbNailPhoto { get; set; }
        /// <summary>
        /// Small image file name.
        /// </summary>
        public string ThumbnailPhotoFileName { get; set; }
        /// <summary>
        /// Large image of the product.
        /// </summary>
        public byte[] LargePhoto { get; set; }
        /// <summary>
        /// Large image file name.
        /// </summary>
        public string LargePhotoFileName { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; }
    }
}