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
        [Route("api/countries")]
        public IActionResult GetAll()
        {
            try
            {
                Singleton.Instance.Audit = true;
                var result = _CountryBLL.GetList();
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// GET: api/GetCountry/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/countries/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _CountryBLL.GetById(id);
                if (result == null)
                {
                    return NotFound(id);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// POST: api/PostCountry
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("api/countries")]
        public IActionResult Post(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Created("PostCountry", _CountryBLL.Create(value));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// PUT: api/PutCountry/5
        /// </summary>        
        /// <param name="value"></param>
        [HttpPut]
        [Route("api/countries")]
        public IActionResult Put(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var result = _CountryBLL.Put(value);

                return Created("PutCountry", result);
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
        [Route("api/countriesAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _CountryBLL.GetListAsync();
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
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
        [Route("api/countriesAsync/{}<id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _CountryBLL.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(id);
                }
                return Ok(result);
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
        [Route("api/countriesAsync")]
        public async Task<IActionResult> PostAsync(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var result = await _CountryBLL.CreateAsync(value);
                return Created("PostCountryAsync", result);
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
        [Route("api/countriesAsync")]
        public async Task<IActionResult> PutAsync(CountryVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var result = await _CountryBLL.PutAsync(value);

                return Created("PutCountryAsync", result);
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
