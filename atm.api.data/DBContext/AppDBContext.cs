using Microsoft.EntityFrameworkCore;

using atm.api.data.EntityConfigurations;
using atm.api.domain;

namespace atm.api.data.DBContext
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserAccount> UsersAccount { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }

        public AppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .ApplyConfiguration(new UserAccountEntityTypeConfig());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1, CardNumber = "1234567890123456", PIN = "1234", Balance = 600.00m },
                new Card { Id = 2, CardNumber = "9876543210987654", PIN = "4321", Balance = 600.00m },
                new Card { Id = 3, CardNumber = "1111222233334444", PIN = "5678", Balance = 1000.00m },
                new Card { Id = 4, CardNumber = "5555666677778888", PIN = "8765", Balance = 150.00m },
                new Card { Id = 5, CardNumber = "9999000011112222", PIN = "9876", Balance = 650.00m }
            );

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { Id = 1, Name = "Juan Perez", CardId = 1, LastAccessDate = DateTime.Now },
                new UserAccount { Id = 2, Name = "Daniel Smith", CardId = 2, LastAccessDate = DateTime.Now },
                new UserAccount { Id = 3, Name = "Alicia Perez", CardId = 3, LastAccessDate = DateTime.Now },
                new UserAccount { Id = 4, Name = "Bob Esponja", CardId = 4, LastAccessDate = DateTime.Now },
                new UserAccount { Id = 5, Name = "Pepe Argento", CardId = 5, LastAccessDate = DateTime.Now }
            );

            modelBuilder.Entity<OperationType>().HasData(
                new OperationType { Id = 1, Name = "Inicio de sesión", Description = "Operación de inicio de sesión de usuario" },
                new OperationType { Id = 2, Name = "Retiro", Description = "Operación de retiro" },
                new OperationType { Id = 3, Name = "Saldo", Description = "Operación de consulta de saldo" }
            );

            modelBuilder.Entity<Operation>().HasData(
                new Operation { Id = 1, OperationTypeId = 1, CardId = 1, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(1) },
                new Operation { Id = 2, OperationTypeId = 2, CardId = 1, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(2) },
                new Operation { Id = 3, OperationTypeId = 3, CardId = 1, Amount = 1400, OperationDateTime = DateTime.Now.AddSeconds(3) },
                new Operation { Id = 4, OperationTypeId = 2, CardId = 1, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(4) },
                new Operation { Id = 5, OperationTypeId = 1, CardId = 1, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(5) },
                new Operation { Id = 6, OperationTypeId = 3, CardId = 1, Amount = 1350, OperationDateTime = DateTime.Now.AddSeconds(6) },
                new Operation { Id = 7, OperationTypeId = 2, CardId = 1, Amount = -300, OperationDateTime = DateTime.Now.AddSeconds(7) },
                new Operation { Id = 8, OperationTypeId = 1, CardId = 1, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(8) },
                new Operation { Id = 9, OperationTypeId = 2, CardId = 1, Amount = -200, OperationDateTime = DateTime.Now.AddSeconds(9) },
                new Operation { Id = 10, OperationTypeId = 3, CardId = 1, Amount = 850, OperationDateTime = DateTime.Now.AddSeconds(10) },
                new Operation { Id = 11, OperationTypeId = 2, CardId = 1, Amount = -150, OperationDateTime = DateTime.Now.AddSeconds(11) },
                new Operation { Id = 12, OperationTypeId = 1, CardId = 1, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(12) },
                new Operation { Id = 13, OperationTypeId = 3, CardId = 1, Amount = 700, OperationDateTime = DateTime.Now.AddSeconds(13) },
                new Operation { Id = 14, OperationTypeId = 2, CardId = 1, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(14) },
                new Operation { Id = 15, OperationTypeId = 1, CardId = 1, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(15) },

                new Operation { Id = 16, OperationTypeId = 1, CardId = 2, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(1) },
                new Operation { Id = 17, OperationTypeId = 2, CardId = 2, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(2) },
                new Operation { Id = 18, OperationTypeId = 3, CardId = 2, Amount = 1400, OperationDateTime = DateTime.Now.AddSeconds(3) },
                new Operation { Id = 19, OperationTypeId = 2, CardId = 2, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(4) },
                new Operation { Id = 20, OperationTypeId = 1, CardId = 2, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(5) },
                new Operation { Id = 21, OperationTypeId = 3, CardId = 2, Amount = 1350, OperationDateTime = DateTime.Now.AddSeconds(6) },
                new Operation { Id = 22, OperationTypeId = 2, CardId = 2, Amount = -300, OperationDateTime = DateTime.Now.AddSeconds(7) },
                new Operation { Id = 23, OperationTypeId = 1, CardId = 2, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(8) },
                new Operation { Id = 24, OperationTypeId = 2, CardId = 2, Amount = -200, OperationDateTime = DateTime.Now.AddSeconds(9) },
                new Operation { Id = 25, OperationTypeId = 3, CardId = 2, Amount = 850, OperationDateTime = DateTime.Now.AddSeconds(10) },
                new Operation { Id = 26, OperationTypeId = 2, CardId = 2, Amount = -150, OperationDateTime = DateTime.Now.AddSeconds(11) },
                new Operation { Id = 27, OperationTypeId = 1, CardId = 2, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(12) },
                new Operation { Id = 28, OperationTypeId = 3, CardId = 2, Amount = 700, OperationDateTime = DateTime.Now.AddSeconds(13) },
                new Operation { Id = 29, OperationTypeId = 2, CardId = 2, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(14) },
                new Operation { Id = 30, OperationTypeId = 1, CardId = 2, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(15) },

                new Operation { Id = 31, OperationTypeId = 1, CardId = 3, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(1) },
                new Operation { Id = 32, OperationTypeId = 2, CardId = 3, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(2) },
                new Operation { Id = 33, OperationTypeId = 3, CardId = 3, Amount = 1550, OperationDateTime = DateTime.Now.AddSeconds(3) },
                new Operation { Id = 34, OperationTypeId = 2, CardId = 3, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(4) },
                new Operation { Id = 35, OperationTypeId = 1, CardId = 3, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(5) },
                new Operation { Id = 36, OperationTypeId = 3, CardId = 3, Amount = 1500, OperationDateTime = DateTime.Now.AddSeconds(6) },
                new Operation { Id = 37, OperationTypeId = 2, CardId = 3, Amount = -300, OperationDateTime = DateTime.Now.AddSeconds(7) },
                new Operation { Id = 38, OperationTypeId = 1, CardId = 3, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(8) },
                new Operation { Id = 39, OperationTypeId = 2, CardId = 3, Amount = -200, OperationDateTime = DateTime.Now.AddSeconds(9) },
                new Operation { Id = 40, OperationTypeId = 3, CardId = 3, Amount = 1000, OperationDateTime = DateTime.Now.AddSeconds(10) },

                new Operation { Id = 41, OperationTypeId = 2, CardId = 4, Amount = -150, OperationDateTime = DateTime.Now.AddSeconds(1) },
                new Operation { Id = 42, OperationTypeId = 1, CardId = 4, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(2) },
                new Operation { Id = 43, OperationTypeId = 3, CardId = 4, Amount = 350, OperationDateTime = DateTime.Now.AddSeconds(3) },
                new Operation { Id = 44, OperationTypeId = 2, CardId = 4, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(4) },
                new Operation { Id = 45, OperationTypeId = 1, CardId = 4, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(5) },
                new Operation { Id = 46, OperationTypeId = 3, CardId = 4, Amount = 250, OperationDateTime = DateTime.Now.AddSeconds(6) },
                new Operation { Id = 47, OperationTypeId = 2, CardId = 4, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(7) },
                new Operation { Id = 48, OperationTypeId = 1, CardId = 4, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(8) },
                new Operation { Id = 49, OperationTypeId = 3, CardId = 4, Amount = 200, OperationDateTime = DateTime.Now.AddSeconds(9) },
                new Operation { Id = 50, OperationTypeId = 2, CardId = 4, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(10) },

                new Operation { Id = 51, OperationTypeId = 1, CardId = 5, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(1) },
                new Operation { Id = 52, OperationTypeId = 2, CardId = 5, Amount = -100, OperationDateTime = DateTime.Now.AddSeconds(2) },
                new Operation { Id = 53, OperationTypeId = 3, CardId = 5, Amount = 1050, OperationDateTime = DateTime.Now.AddSeconds(3) },
                new Operation { Id = 54, OperationTypeId = 2, CardId = 5, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(4) },
                new Operation { Id = 55, OperationTypeId = 1, CardId = 5, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(5) },
                new Operation { Id = 56, OperationTypeId = 3, CardId = 5, Amount = 1000, OperationDateTime = DateTime.Now.AddSeconds(6) },
                new Operation { Id = 57, OperationTypeId = 2, CardId = 5, Amount = -300, OperationDateTime = DateTime.Now.AddSeconds(7) },
                new Operation { Id = 58, OperationTypeId = 1, CardId = 5, Amount = 0, OperationDateTime = DateTime.Now.AddSeconds(8) },
                new Operation { Id = 59, OperationTypeId = 3, CardId = 5, Amount = 700, OperationDateTime = DateTime.Now.AddSeconds(9) },
                new Operation { Id = 60, OperationTypeId = 2, CardId = 5, Amount = -50, OperationDateTime = DateTime.Now.AddSeconds(10) }
            );
        }
    }
}
