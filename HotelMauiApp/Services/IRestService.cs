using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMauiApp.Services
{
    public interface IRestService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
    }
}