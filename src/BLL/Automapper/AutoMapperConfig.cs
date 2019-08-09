using AutoMapper;
using ENT.Ent;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ViewModels;

namespace BLL.Automapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration ConfigurationAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create mapping of entities and/or Models
                cfg.CreateMap<Person, PersonVM>();
                cfg.CreateMap<PersonVM, Person>();

                cfg.CreateMap<Country, CountryVM>();
                cfg.CreateMap<CountryVM, Country>();
            });

            return config;
        }
    }
}
