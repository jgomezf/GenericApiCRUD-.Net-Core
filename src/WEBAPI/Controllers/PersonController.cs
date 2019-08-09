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
        [Route("api/people")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _personBLL.GetList();
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
        /// GET: api/GetPerson/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/people/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _personBLL.GetById(id);
                if (result == null)
                {
                    return NotFound(id);
                }
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
        [Route("api/people")]
        public IActionResult Post(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Created("PostPerson", _personBLL.Create(value));                
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
        [Route("api/people")]
        public IActionResult Put(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var result = _personBLL.Put(value);

                return Created("PutCountry", result);
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
        [Route("api/peopleAsync")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _personBLL.GetListAsync();
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
        /// GET: api/GetAsyncPerson/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/peopleAsync/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _personBLL.GetByIdAsync(id);
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
        /// POST: api/PostAsyncPerson
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/peopleAsync")]
        public async Task<IActionResult> PostAsync(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var result = await _personBLL.CreateAsync(value);
                return Created("PostPersonAsync", result);
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
        [Route("api/peopleAsync")]
        public async Task<IActionResult> PutAsync(PersonVM value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                var result = await _personBLL.PutAsync(value);

                return Created("PutPersonAsync", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        } 
        #endregion

    }
}
