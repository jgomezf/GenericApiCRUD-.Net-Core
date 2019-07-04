using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.ViewModels;

namespace WEBAPI.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonBLL _personBLL;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="personBLL"></param>
        public PersonController(IPersonBLL personBLL)
        {
            this._personBLL = personBLL;
        }

        #region Methods No Async

        /// <summary>
        /// GET: api/GetPerson
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPersons")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_personBLL.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// GET: api/GetPerson/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPerson")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_personBLL.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// POST: api/PostPerson
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("PostPerson")]
        public IActionResult Post(PersonVM value)
        {
            try
            {
                return Ok(_personBLL.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// PUT: api/PutPerson/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutPerson")]
        public IActionResult Put(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var x = _personBLL.Put(value);

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE: api/Person/5
        //public void Delete(int id)
        //{
        //}
        #endregion

        #region Methods Async

        /// <summary>
        /// GET: api/GetAllAsyncPersons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllAsyncPersons")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var x = await _personBLL.GetListAsync();
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        /// <summary>
        /// GET: api/GetAsyncPerson/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAsyncPerson")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var x = await _personBLL.GetByIdAsync(id);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// POST: api/PostAsyncPerson
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostAsyncPerson")]
        public async Task<IActionResult> PostAsync(PersonVM value)
        {
            try
            {
                var x = await _personBLL.CreateAsync(value);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// PUT: api/PutAsyncPerson/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutAsyncPerson")]
        public async Task<IActionResult> PutAsync(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var x = await _personBLL.PutAsync(value);

                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        } 
        #endregion

    }
}