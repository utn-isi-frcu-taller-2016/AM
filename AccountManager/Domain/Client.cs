using System;
using System.Collections.Generic;

namespace AccountManager.Domain
{
    /// <summary>
    /// Clase de dominio y de datos Cliente
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Documento del cliente
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Cuentas del cliente
        /// </summary>
        public virtual IList<Account> Accounts { get; set; }

    }
}
