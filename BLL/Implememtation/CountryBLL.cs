using AutoMapper;
using BLL.Interface;
using BLL.Utility;
using DAL.UnitOfWork;
using ENT.Ent;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace BLL.Implememtation
{
    public class CountryBLL : ICountryBLL
    {
        private IMapper iMapper = null;
        private UnitOfWork unitOfWork;
        private string NameCache = string.Empty;
        CacheManager<List<CountryVM>> cacheManager;
        IMemoryCache _cache;
        public CountryBLL(IMemoryCache memCache)
        {
            var config = BLL.Automapper.AutoMapperConfig.ConfigurationAutomapper();
            iMapper = config.CreateMapper();
            this.unitOfWork = new UnitOfWork();
            this.NameCache = this.GetType().Name;
            _cache = memCache;
            cacheManager = new CacheManager<List<CountryVM>>(_cache);
        }

        public CountryVM Create(CountryVM Entity)
        {
            var entity = iMapper.Map<CountryVM, Country>(Entity);
            var Result = iMapper.Map<Country, CountryVM>(unitOfWork.CountryRepository.add(entity));
            if (Result != null)
            {
                CacheManager<List<CountryVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }

        public CountryVM GetById(int id)
        {
            return GetList().Where(c => c.Id == id).FirstOrDefault();
        }

        public List<CountryVM> GetList()
        {
            List<CountryVM> result = CacheManager<List<CountryVM>>.TryGetFromCache(NameCache);
            if (result == null)
            {
                result = iMapper.Map<List<Country>, List<CountryVM>>(unitOfWork.CountryRepository.Getall().ToList());
                CacheManager<List<CountryVM>>.TryAddToCacheDefaultTime(NameCache, result);
            }
            return result;
        }

        public CountryVM Put(CountryVM country)
        {
            var newCountryVM = iMapper.Map<CountryVM, Country>(country);
            var Result = iMapper.Map<Country, CountryVM>(unitOfWork.CountryRepository.AddOrUpdate(newCountryVM));
            if (Result != null)
            {
                CacheManager<List<CountryVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }

        public async Task<CountryVM> GetByIdAsync(int id)
        {
            var listCountryVM = await GetListAsync();
            return listCountryVM.Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<CountryVM> CreateAsync(CountryVM Country)
        {
            var newCountry = iMapper.Map<CountryVM, Country>(Country);
            var Result = iMapper.Map<Country, CountryVM>(await unitOfWork.CountryRepository.addAsyc(newCountry));
            if (Result != null)
            {
                CacheManager<List<CountryVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }

        public async Task<List<CountryVM>> GetListAsync()
        {
            int TimeHourDefault = 1;

            var cacheEntry = await
            _cache.GetOrCreateAsync(NameCache, async entry =>
            {
                entry.SlidingExpiration = new TimeSpan(TimeHourDefault, 0, 0);
                return Task.FromResult(iMapper.Map<List<Country>, List<CountryVM>>((await unitOfWork.CountryRepository.GetallAsyc()).ToList()));
            });

            return cacheEntry.Result;
        }

        public async Task<CountryVM> PutAsync(CountryVM Country)
        {
            var newCountryVM = iMapper.Map<CountryVM, Country>(Country);
            var newCountry = await unitOfWork.CountryRepository.AddOrUpdateAsync(newCountryVM);
            var Result = iMapper.Map<Country, CountryVM>(newCountry);
            if (Result != null)
            {
                CacheManager<List<CountryVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }

    }
}
