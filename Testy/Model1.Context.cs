//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Testy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Projekt_ProgObEntities : DbContext
    {
        public Projekt_ProgObEntities()
            : base("name=Projekt_ProgObEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Dane_Osobowe> Dane_Osobowe { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transakcje> Transakcje { get; set; }
    }
}
