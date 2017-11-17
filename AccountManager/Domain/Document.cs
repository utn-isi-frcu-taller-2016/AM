using System;

namespace AccountManager.Domain
{
    /// <summary>
    /// Clase Documento de un cliente
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Tipo
        /// </summary>
        public DocumentType Type { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public String Number { get; set; }

    }

    public enum DocumentType
    {

        DNI,

        CUIL,

        LC,

        LE

    }
}