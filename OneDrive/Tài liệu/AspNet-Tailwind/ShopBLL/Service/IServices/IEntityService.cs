using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBussinessLogic.Service.IServices
{
    public interface IEntityService<T>
    {
        Task<List<T>> GetListsAsync(CancellationToken cancellationToken = default);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T toAddDTO);
        Task<T> UpdateAsync(T toUpdateDTO);
        Task DeleteAsync(int id);
    }
}
