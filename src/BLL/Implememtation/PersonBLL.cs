using AutoMapper;
using BLL.Interface;
using BLL.Utility;
using DAL.UnitOfWork;
using ENT.Ent;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace BLL.Implememtation
{
    public class PersonBLL : IPersonBLL
    {
        private IMapper iMapper = null;
        private UnitOfWork unitOfWork;
        private string NameCache = string.Empty;
        CacheManager<List<PersonVM>> cacheManager;
        IMemoryCache _cache;

        public PersonBLL(IMemoryCache memCache)
        {
            var config = BLL.Automapper.AutoMapperConfig.ConfigurationAutomapper();
            iMapper = config.CreateMapper();
            this.unitOfWork = new UnitOfWork();
            this.NameCache = this.GetType().Name;
            _cache = memCache;
            cacheManager = new CacheManager<List<PersonVM>>(_cache);
        }
        public PersonVM Create(PersonVM person)
        {
            var newPerson = iMapper.Map<PersonVM, Person>(person);
            var result = iMapper.Map<Person, PersonVM>(unitOfWork.PersonRepository.add(newPerson));
            if (result != null)
            {
                CacheManager<List<PersonVM>>.RemoveItemFromCache(NameCache);
            }
            return result;
        }

        public async Task<PersonVM> CreateAsync(PersonVM person)
        {
            var newPerson = iMapper.Map<PersonVM, Person>(person);
            var result = iMapper.Map<Person, PersonVM>(await unitOfWork.PersonRepository.addAsyc(newPerson));
            if (result != null)
            {
                CacheManager<List<PersonVM>>.RemoveItemFromCache(NameCache);
            }
            return result;
        }

        public PersonVM GetById(int id)
        {
            return GetList().Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<PersonVM> GetByIdAsync(int id)
        {
            var listPersonVM = await GetListAsync();
            return listPersonVM.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<PersonVM> GetList()
        {
            List<PersonVM> result = CacheManager<List<PersonVM>>.TryGetFromCache(NameCache);
            if (result == null)
            {
                result = iMapper.Map<List<Person>, List<PersonVM>>(unitOfWork.PersonRepository.Getall().ToList());
                CacheManager<List<PersonVM>>.TryAddToCacheDefaultTime(NameCache, result);
            }
            return result;
        }

        public async Task<List<PersonVM>> GetListAsync()
        {
            int TimeHourDefault = 1;

            var cacheEntry = await
            _cache.GetOrCreateAsync(NameCache, async entry =>
            {
                entry.SlidingExpiration = new TimeSpan(TimeHourDefault, 0, 0);
                return Task.FromResult(iMapper.Map<List<Person>, List<PersonVM>>((await unitOfWork.PersonRepository.GetallAsyc()).ToList()));
            });

            return cacheEntry.Result;
        }

        public PersonVM Put(PersonVM person)
        {
            var newPersonVM = iMapper.Map<PersonVM, Person>(person);
            var Result = iMapper.Map<Person, PersonVM>(unitOfWork.PersonRepository.AddOrUpdate(newPersonVM));
            if (Result != null)
            {
                CacheManager<List<PersonVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }

        public async Task<PersonVM> PutAsync(PersonVM person)
        {
            var newPersonVM = iMapper.Map<PersonVM, Person>(person);
            var newPerson = await unitOfWork.PersonRepository.AddOrUpdateAsync(newPersonVM);
            var Result = iMapper.Map<Person, PersonVM>(newPerson);
            if (Result != null)
            {
                CacheManager<List<PersonVM>>.RemoveItemFromCache(NameCache);
            }
            return Result;
        }
    }
}
