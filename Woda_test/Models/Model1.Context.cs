﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Woda_test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wodaEntities : DbContext
    {
        public wodaEntities()
            : base("name=wodaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<table_address> table_address { get; set; }
        public virtual DbSet<table_demographic> table_demographic { get; set; }
        public virtual DbSet<table_home_facilities> table_home_facilities { get; set; }
        public virtual DbSet<table_house_senior_detail> table_house_senior_detail { get; set; }
    }
}
