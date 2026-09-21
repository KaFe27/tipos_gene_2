namespace Ucu.Poo.Repositories
{
    
    /// La implementan las clases cuyas instancias pueden consultarse por el
    /// nombre de un atributo y su valor, sin que ="Database{T}"
    /// necesite conocer de qué clase se trata.
    public interface IHasValue
    {
        /// Determina si el objeto tiene un valor específico para un atributo
        /// dado.
        bool HasValue(string field, string value);
    }
}