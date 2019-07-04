using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using ENT.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.ViewModels;

namespace WEBAPI.Controllers
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryBLL _CountryBLL;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CountryBLL"></param>
        public CountryController(ICountryBLL CountryBLL)
        {
            this._CountryBLL = CountryBLL;
        }

        #region methods No Async

        /// <summary>
        /// GET: api/GetAllCountry
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCountries")]
        public IEnumerable<CountryVM> GetAll()
        {
            Singleton.Instance.Audit = true;

            return _CountryBLL.GetList();
        }

        /// <summary>
        /// GET: api/GetCountry/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCountry")]
        public CountryVM Get(int id)
        {
            return _CountryBLL.GetById(id);
        }

        /// <summary>
        /// POST: api/PostCountry
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("PostCountry")]
        public void Post(CountryVM value)
        {
            _CountryBLL.Create(value);
        }

        /// <summary>
        /// PUT: api/PutCountry/5
        /// </summary>        
        /// <param name="value"></param>
        [HttpPut]
        [Route("PutCountry")]
        public IActionResult Put(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var x = _CountryBLL.Put(value);

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        ///// <summary>
        ///// DELETE: api/Country/5
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete]
        //public void Delete(int id)
        //{
        //} 
        #endregion

        #region methods Async

        /// <summary>
        /// GET: api/GetAllAsyncCountries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllAsyncCountries")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var x = await _CountryBLL.GetListAsync();
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// GET: api/GetAsyncCountry/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAsyncCountry")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var x = await _CountryBLL.GetByIdAsync(id);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// POST: api/PostAsyncCountry
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("PostAsyncCountry")]
        public async Task<IActionResult> PostAsync(CountryVM value)
        {
            try
            {
                var x = await _CountryBLL.CreateAsync(value);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            };
        }

        /// <summary>
        /// PUT: api/PutAsyncCountry/5
        /// </summary>        
        /// <param name="value"></param>
        [HttpPut]
        [Route("PutAsyncCountry")]
        public async Task<IActionResult> PutAsync(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var x = await _CountryBLL.PutAsync(value);

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        ///// <summary>
        ///// DELETE: api/Country/5
        ///// </summary>
        ///// <param name="id"></param>
        //[HttpDelete]
        //[Route("DeleteAsync")]
        //public IHttpActionResult DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var x = await _CountryBLL.DeleteAsyn(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        #endregion
    }
}