﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBD_ClientManagementGood.Models;

namespace NBD_ClientManagementGood.Data
{
    public class NBD_ClientManagementGoodContext : DbContext
    {
        public NBD_ClientManagementGoodContext (DbContextOptions<NBD_ClientManagementGoodContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BidLB> BidLBs { get; set; }
        public DbSet<InvBid> InvBids { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<LabourUnit> LabourUnits { get; set; }
        public DbSet<LabourDepartment> LabourDepartments { get; set; }
        ////public DbSet<HeadStaff> HeadStaff { get; set; }
        //public DbSet<Item> Item { get; set; }
        //public DbSet<Material> Material { get; set; }
        //public DbSet<Plant> Plant { get; set; }
        //public DbSet<Pottery> Pottery { get; set; }
        //public DbSet<Tool> Tools { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CMO");

            //modelBuilder.Entity<BidLB>()
            //    .HasKey(b => new { b.BidID, b.LabourUnitID });

            //modelBuilder.Entity<InvBid>()
            //    .HasKey(b => new { b.BidID, b.ItemID });

            //Prevent Cascade Delete from Country to City
            //This prevents deleting a Country with a City assigned 
            modelBuilder.Entity<Country>()
                .HasMany<City>(d => d.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryID)
                .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete from City to Client
            //This prevents deleting a City with a Client assigned 
            modelBuilder.Entity<City>()
                .HasMany<Client>(d => d.Clients)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityID)
                .OnDelete(DeleteBehavior.Restrict);

            //Add a unique index to the Client Email
            modelBuilder.Entity<Client>()
                .HasIndex(p => p.eMail)
                .IsUnique();

            //Add a unique index to the Client Phone
            modelBuilder.Entity<Client>()
                .HasIndex(p => p.Phone)
                .IsUnique();
        }
    }
}
