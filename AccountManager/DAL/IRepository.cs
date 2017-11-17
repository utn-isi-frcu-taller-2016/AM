using System.Collections.Generic;

namespace AccountManager.DAL
{
    /// <summary>
    /// Interfaz de basica de repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Agrega la entidad
        /// </summary>
        /// <param name="pEntity">Entidad</param>
        void Add(TEntity pEntity);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="pEntity">Entidad</param>
        void Remove(TEntity pEntity);

        /// <summary>
        /// Obtiene la entidad por Id
        /// </summary>
        /// <param name="pId">Identificador de la entidad</param>
        /// <returns>Entidad</returns>
        TEntity Get(int pId);

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns>Coleccion de entidades</returns>
        IEnumerable<TEntity> GetAll();

    }
}
