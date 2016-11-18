using AccountManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AccountManager.DAL.EntityFramework
{
    class DatabaseInitializationStrategy : CreateDatabaseIfNotExists<AccountManagerDbContext>
    {

        protected override void Seed(AccountManagerDbContext pContext)
        {

            pContext.Clients.Add(new Client
            {
                Document = new Document
                {
                    Type = DocumentType.DNI,
                    Number = "12345678"
                },
                FirstName = "Juan Carlos",
                LastName = "Alberto González",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Name = "Caja Ahorros",
                        OverdraftLimit = 1000,
                        Movements = new List<AccountMovement>
                        {
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-10),
                                Description = "Acreditación de sueldo",
                                Amount = 20000
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-5),
                                Description = "Pago de tarjeta de crédito",
                                Amount = -15200.5
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-3),
                                Description = "Pago de seguro de vida",
                                Amount = -120
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-3),
                                Description = "Pago de seguro automotor",
                                Amount = -1000
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-1),
                                Description = "Devolución del IVA",
                                Amount = 75
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now,
                                Description = "Transferencia bancaria",
                                Amount = -6000
                            }
                        }
                    }
                }
            });

            pContext.Clients.Add(new Client
            {
                Document = new Document
                {
                    Type = DocumentType.CUIL,
                    Number = "20111222335"
                },
                FirstName = "Lucía",
                LastName = "Pérez",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Name = "Caja Ahorros",
                        OverdraftLimit = 2000,
                        Movements = new List<AccountMovement>
                        {
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-10),
                                Description = "Acreditación de sueldo",
                                Amount = 35000
                            },
                            new AccountMovement
                            {
                                Date = DateTime.Now.AddDays(-5),
                                Description = "Pago de tarjeta de crédito",
                                Amount = -7570
                            }
                        }
                    },
                    new Account
                    {
                        Name = "Cuenta Corriente",
                        OverdraftLimit = 5000
                    }
                }
            });

            base.Seed(pContext);
        }

    }
}
