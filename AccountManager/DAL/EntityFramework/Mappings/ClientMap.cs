using AccountManager.Domain;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace AccountManager.DAL.EntityFramework.Mappings
{
    class ClientMap : EntityTypeConfiguration<Client>
    {

        public ClientMap()
        {

            // Nombre de la tabla que tendrá la entidad, en este caso 'Client'.
            this.ToTable("Client");

            // Clave primaria de la entidad, indicando que la columna se llama 'ClientId' y que es autoincremental.
            this.HasKey(pClient => pClient.Id)
                .Property(pClient => pClient.Id)
                .HasColumnName("ClientId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'DocumentType', que como es un enumerado se terminará mapeando con un tipo int.
            this.Property(pClient => pClient.Document.Type)
                .HasColumnName("DocumentType")
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'DocumentNumber', con una longitud máxima de 15 caracteres [varchar(15)].
            this.Property(pClient => pClient.Document.Number)
                .HasColumnName("DocumentNumber")
                .IsRequired()
                .HasMaxLength(15);

            // Se establece la columna obligatoria (NOT NULL) 'FirstName', con una longitud máxima de 20 caracteres [varchar(20)].
            this.Property(pClient => pClient.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            // Se establece la columna obligatoria (NOT NULL) 'LastName', con una longitud máxima de 20 caracteres [varchar(20)].
            this.Property(pClient => pClient.LastName)
                .IsRequired()
                .HasMaxLength(20);

            // Se crea un índice único por tipo y número de documento.
            this.HasIndex("IX_Document",
                IndexOptions.Unique,
                pEntity => pEntity.Property(pClient => pClient.Document.Type),
                pEntity => pEntity.Property(pClient => pClient.Document.Number));

            // Se establece la relación de uno a muchos entre las entidades Client y Account, habilitando la 
            // navegación tanto desde la instancia de Client hacia sus instancias de Account, como de Account
            // hacia la instancia de Client a la que pertenece. Si se elimina la entidad Client, entonces se
            // eliminarán en cascada todas las entidades Account relacionadas. El nombre de la columna de
            // la FK se nombra 'ClientId'.
            this.HasMany<Account>(pClient => pClient.Accounts)
                .WithRequired(pAccount => pAccount.Client)
                .Map(pMapping => pMapping.MapKey("ClientId"))
                .WillCascadeOnDelete();
        }

    }
}
