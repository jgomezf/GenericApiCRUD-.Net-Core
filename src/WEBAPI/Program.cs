using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Implememtation;
using BLL.Interface;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Practices.Unity;

namespace WEBAPI
{
    public class Program
    {
        private static UnityContainer unityContainer = new UnityContainer();

        public static void Main(string[] args)
        {
            RegistrarUnity();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void RegistrarUnity()
        {
            unityContainer.RegisterType<IPersonBLL, PersonBLL>();
            unityContainer.RegisterType<ICountryBLL, CountryBLL>();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
