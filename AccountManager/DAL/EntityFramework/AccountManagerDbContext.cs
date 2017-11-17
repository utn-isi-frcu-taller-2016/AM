using AccountManager.DAL.EntityFramework.Mappings;
using AccountManager.Domain;
using System.Data.Entity;

namespace AccountManager.DAL.EntityFramework
{
    /// <summary>
    /// Clase contexto de acceso a DB
    /// </summary>
    internal class AccountManagerDbContext : DbContext
    {
        /// <summary>
        /// Clientes
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Cuentas
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Movimientos de la cuenta
        /// </summary>
        public DbSet<AccountMovement> AccountMovements { get; set; }

        public AccountManagerDbContext() : base("AccountManagerContext")
        {
            //Database.SetInitializer<AccountManagerDbContext>(new CreateDatabaseIfNotExists<AccountManagerDbContext>());
            //Database.SetInitializer<AccountManagerDbContext>(new DropCreateDatabaseIfModelChanges<AccountManagerDbContext>());
            //Database.SetInitializer<AccountManagerDbContext>(new DropCreateDatabaseAlways<AccountManagerDbContext>());

            // Se establece la estrategia personalizada de inicialización de la BBDD.
            Database.SetInitializer<AccountManagerDbContext>(new DatabaseInitializationStrategy());
        }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.Add(new ClientMap());
            pModelBuilder.Configurations.Add(new AccountMap());
            pModelBuilder.Configurations.Add(new AccountMovementMap());

            base.OnModelCreating(pModelBuilder);
        }
    }
}