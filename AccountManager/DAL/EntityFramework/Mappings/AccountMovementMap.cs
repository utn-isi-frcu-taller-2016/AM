using AccountManager.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AccountManager.DAL.EntityFramework.Mappings
{
    class AccountMovementMap : EntityTypeConfiguration<AccountMovement>
    {

        public AccountMovementMap()
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'AccountMovement'.
            this.ToTable("AccountMovement");

            // Clave primaria de la entidad, indicando que la columna se llama 'AccountMovementId' y que es autoincremental.
            this.HasKey(pAccountMovement => pAccountMovement.Id)
                .Property(pAccountMovement => pAccountMovement.Id)
                .HasColumnName("AccountMovementId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'Date'.
            this.Property(pAccountMovement => pAccountMovement.Date)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'Description', con una longitud máxima de 50 caracteres [varchar(50)].
            this.Property(pAccountMovement => pAccountMovement.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Se establece la columna obligatoria (NOT NULL) 'Amount'.
            this.Property(pAccountMovement => pAccountMovement.Amount)
                .IsRequired();

        }

    }
}
