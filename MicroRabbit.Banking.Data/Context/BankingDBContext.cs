using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDBContext : DbContext
    {
        // This is used for Design Time issues when doing Migration
        public BankingDBContext()
        {
            
        }
        // This works with the default contructor above
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                //"DefaultConnection": "Server=localhost,1433;Database=DrinkAndGo;User=sa;Password=myPassw0rd;"

                //var connectionString = @"Data Source=SQL5042.site4now.net;Initial Catalog=DB_9D9472_kaylaaDb;User Id=DB_9D9472_kaylaaDb_admin;Password=@Kaylaa_2019#";
                var connectionString = @"Server=localhost,1433;Database=BankingDB;User=sa;Password=Brainbox23@";
                optionsBuilder.UseSqlServer(connectionString);

            }
        }
        
       
        public BankingDBContext(DbContextOptions options) : base(options)
        {
            
        }
        
       

        public DbSet<Account> Accounts { get; set; }
    }
}