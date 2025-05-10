using Microsoft.AspNetCore.Mvc;
using SistemaReservas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaReservas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly List<Cancha> _canchas = new List<Cancha>();
        private int _idCounter = 1;

        // GET: api/canchas
        [HttpGet]
        public ActionResult<IEnumerable<Cancha>> GetCanchas()
        {
            return Ok(_canchas);
        }

        // GET: api/canchas/5
        [HttpGet("{id}")]
        public ActionResult<Cancha> GetCancha(int id)
        {
            var cancha = _canchas.FirstOrDefault(c => c.Id == id);
            if (cancha == null) return NotFound();
            return Ok(cancha);
        }

        // POST: api/canchas
        [HttpPost]
        public ActionResult<Cancha> PostCancha(Cancha cancha)
        {
            cancha.Id = _idCounter++;
            _canchas.Add(cancha);
            return CreatedAtAction(nameof(GetCancha), new { id = cancha.Id }, cancha);
        }

        // PUT: api/canchas/5
        [HttpPut("{id}")]
        public IActionResult PutCancha(int id, Cancha cancha)
        {
            var existingCancha = _canchas.FirstOrDefault(c => c.Id == id);
            if (existingCancha == null) return NotFound();
            existingCancha.Nombre = cancha.Nombre;
            existingCancha.Tipo = cancha.Tipo;
            existingCancha.Ubicacion = cancha.Ubicacion;
            return NoContent();
        }

        // DELETE: api/canchas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCancha(int id)
        {
            var cancha = _canchas.FirstOrDefault(c => c.Id == id);
            if (cancha == null) return NotFound();
            _canchas.Remove(cancha);
            return NoContent();
        }
    }
}
