using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace BLL.Interface
{
    public interface ICountryBLL
    {
        List<CountryVM> GetList();
        CountryVM GetById(int id);
        CountryVM Create(CountryVM Entity);
        CountryVM Put(CountryVM Entity);
        Task<List<CountryVM>> GetListAsync();
        Task<CountryVM> GetByIdAsync(int id);
        Task<CountryVM> CreateAsync(CountryVM Entity);
        Task<CountryVM> PutAsync(CountryVM Entity);
    }
}
