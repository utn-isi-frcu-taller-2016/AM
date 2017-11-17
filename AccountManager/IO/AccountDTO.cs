using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.IO
{
    /// <summary>
    /// Clase DTO de Account
    /// </summary>
    class AccountDTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la cuenta
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Límite de descubierto
        /// </summary>
        public double OverDraftLimit { get; set; }
        
        /// <summary>
        /// Balance de la cuenta
        /// </summary>
        public double Balance { get; set; }
    }
}
