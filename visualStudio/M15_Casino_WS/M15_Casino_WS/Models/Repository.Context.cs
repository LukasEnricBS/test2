﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace M15_Casino_WS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class casinoEntities : DbContext
    {
        public casinoEntities()
            : base("name=casinoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<GameCard> GameCards { get; set; }
        public virtual DbSet<GameTable> GameTables { get; set; }
        public virtual DbSet<MoneyRequest> MoneyRequests { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerTable> PlayerTables { get; set; }
    }
}