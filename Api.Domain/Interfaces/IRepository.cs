using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    //Interface é apenas uma assinatura que me obriga a usar os metodos herdados dela
    //<T> siginifica qualquer coisa mas pode ser qualquer letra 
    public interface IRepository<T> where T:BaseEntity
    {
        //Task é utilizado para métodos assíncronos.
                 Task<T> InsertAsync (T item);
                 Task<T> UpdateAsync(T item);
                 Task<bool> DeleteAsync(Guid id);
                 Task<T> SelectAsync(Guid id);
                 //USAR IEnumerable por se tratar de uma lista
                 Task<IEnumerable<T>> SelectAsync();
                Task<bool> ExitingAsync(Guid id);
    }
}
