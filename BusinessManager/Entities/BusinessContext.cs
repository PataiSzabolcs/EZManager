using BusinessManager.Models;
using BusinessManager.Models.JointModels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Entities
{
    public class BusinessContext : DbContext
    {
        public BusinessContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ContactPerson> ContacPeople { get; set; }
        public DbSet<BillingInfo> BillingInfoList { get; set; }
        public DbSet<Document> Documents{ get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Billable> Billables { get; set; }
        public DbSet<ClientAdmin> ClientAdmins { get; set; }
        public DbSet<CaseAdmin> CaseAdmins { get; set; }
        public DbSet<DocumentEvent> DocumentEvents { get; set; }
        public DbSet<UserDocument> UserDocument { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billable>()
                .HasKey(b => new { b.CaseId, b.UserId });

            modelBuilder.Entity<CaseAdmin>()
                .HasKey(c => new { c.CaseId, c.UserId });

            modelBuilder.Entity<ClientAdmin>()
                .HasKey(c => new { c.ClientId, c.UserId });

            modelBuilder.Entity<UserDocument>()
                .HasKey(u => new { u.UserId, u.DocumentId });

            modelBuilder.Entity<UserEvent>()
                .HasKey(u => new { u.UserId, u.EventId });

            modelBuilder.Entity<DocumentEvent>()
                .HasKey(d => new { d.DocumentId, d.EventId });

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Cases)
                .WithOne(c => c.Client)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.ContactPeople)
                .WithOne(c => c.Client)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.BillingInfo)
                .WithOne(b => b.Client);

            modelBuilder.Entity<Billable>()
                .HasMany(b => b.Entries)
                .WithOne(e => e.Billable);

            modelBuilder.Entity<Case>()
                .HasMany(b => b.Entries)
                .WithOne(e => e.Case);

            modelBuilder.Entity<User>()
                .HasMany(b => b.Entries)
                .WithOne(e => e.FeeEarner);
        }
    }
}
