﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using SimpleFastReport.API.Models.HumanResourcesSchema;
using SimpleFastReport.API.Models.PersonSchema;
using SimpleFastReport.API.Models.ProductionSchema;
using SimpleFastReport.API.Models.PurchasingSchema;
using SimpleFastReport.API.Models.SalesSchema;


namespace SimpleFastReport.API.Models.HumanResourcesSchema
{
    /// <summary>
    /// Résumés submitted to Human Resources by job applicants.
    /// </summary>
    public partial class JobCandidate
    {
        /// <summary>
        /// Primary key for JobCandidate records.
        /// </summary>
        public int JobCandidateId { get; set; }
        /// <summary>
        /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        public int? BusinessEntityId { get; set; }
        /// <summary>
        /// Résumé in XML format.
        /// </summary>
        public string Resume { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}