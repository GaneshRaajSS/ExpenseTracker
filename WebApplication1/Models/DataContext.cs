using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<RecurringTxn> RecurringTxns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .Property(c => c.exchangeRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(c => c.amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(r => r.txn_Type)
                .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Txn_Type_Status>(v)
                );

            modelBuilder.Entity<Transaction>()
                .Property(r => r.payment_Method)
                .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Txn_Method_Status>(v)
                );

            modelBuilder.Entity<RecurringTxn>()
                .Property(r => r.frequencyStatus)
                .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Frequency_Status>(v)
                );

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),          
                    v => Enum.Parse<UserRole>(v)
                );

            //User Relations
            modelBuilder.Entity<User>()
               .HasMany(u => u.RecurringTxns)
               .WithOne(r => r.Users)
               .HasForeignKey(r => r.userId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Categories)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.userId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Budgets)
                .WithOne(b => b.Users)
                .HasForeignKey(b => b.userId);

            //Transaction Relationships
            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Categories)
               .WithMany()
               .HasForeignKey(t => t.categoriesId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Currencies)
                .WithMany()
                .HasForeignKey(t => t.currencyCode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Users)
                .WithMany() 
                .HasForeignKey(t => t.userId)
                .OnDelete(DeleteBehavior.NoAction);

            // RecurringTxn Relationships
            modelBuilder.Entity<RecurringTxn>()
                .HasOne(r => r.Users)
                .WithMany(u => u.RecurringTxns)
                .HasForeignKey(r => r.userId);

            // Budget Relationships
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Users)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.userId);

            // Category Relationships
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Users)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.userId);

            // Currency Relationships
            modelBuilder.Entity<Currency>()
                .HasKey(c => c.currencyCode);

            base.OnModelCreating(modelBuilder);


        }
    }
}
