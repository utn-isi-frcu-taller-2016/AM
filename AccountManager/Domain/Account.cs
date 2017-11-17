using System;
using System.Linq;
using System.Collections.Generic;

namespace AccountManager.Domain
{
    /// <summary>
    /// Clase de Dominio (y de datos) de Cuenta
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Identificador de la cuenta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la cuenta
        /// </summary>
        public String Name { get; set; }
        
        /// <summary>
        /// Limite de descubierto
        /// </summary>
        public double OverdraftLimit { get; set; }

        /// <summary>
        /// Cliente de la cuenta
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Movimientos de la cuenta
        /// </summary>
        public virtual IList<AccountMovement> Movements { get; set; }

        /// <summary>
        /// Obtención de los n movimientos de la cuenta
        /// </summary>
        /// <param name="pCount">Cantidad de movimientos</param>
        /// <returns>Movimiento de la cuenta</returns>
        IEnumerable<AccountMovement> GetLastMovements(int pCount = 7)
        {
            return this.Movements.Take(pCount);
        }

        /// <summary>
        /// Obtiene el balance de la cuenta
        /// </summary>
        /// <returns>Balance de la cuenta</returns>
        public double GetBalance()
        {
            return this.Movements.Sum(t => t.Amount);
        }

    }
}
