using Microsoft.AspNetCore.Mvc;
using StudentsTestCore.Business.interfaces;
using StudentsTestCore.Entities.DTOs;
using System;
using System.Threading.Tasks;

namespace StudentsTestCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InitialDataController : ControllerBase
    {

        private readonly IInitialDataProcess _initialDataProcess;

        public InitialDataController(IInitialDataProcess initialDataProcess)
        {
            _initialDataProcess = initialDataProcess;
        }

        /// <summary>
        /// Obtener todos los estudiantes en la BD.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var result = await _initialDataProcess.GetAllStudents();
                return Ok(result);
            } catch (Exception e)
            {
                return NotFound("Students not found. " + e.Message);
            }
        }

        /// <summary>
        /// Obtener un estudiante por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent(long id)
        {
            try
            {
                var result = await _initialDataProcess.GetStudentById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Students not found. " + e.Message);
            }
        }

        /// <summary>
        /// Crear estudiante.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentRequest student)
        {
            try
            {
                var result = await _initialDataProcess.CreateStudent(student);
                return CreatedAtAction(nameof(GetStudent), result, student);
            }
            catch (Exception e)
            {
                return NotFound("Students not found. " + e.Message);
            }
        }

        /// <summary>
        /// Actualizar un estudiante.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] long id, [FromBody] StudentRequest student)
        {
            try
            {
                var result = await _initialDataProcess.UpdateStudent(id, student);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Students not found. " + e.Message);
            }
        }

        /// <summary>
        /// Eliminar un estudiante.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] long id)
        {
            try
            {
                var result = await _initialDataProcess.DeleteStudent(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Students not found. " + e.Message);
            }
        }
    }
}