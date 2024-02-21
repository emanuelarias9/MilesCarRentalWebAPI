using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRentalWebAPI.Models;
using System.Text.RegularExpressions;

namespace MilesCarRentalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        public readonly MilesCarRentalWebAPIContext dbContext;
        public VehiculoController(MilesCarRentalWebAPIContext _context) {
            dbContext= _context;
        }

        [HttpGet]
        [Route("Consultar/{localidadRecogida}/{localidadDevolucion}")]
        public IActionResult Consultar(string localidadRecogida, string localidadDevolucion) { 
            List<Vehiculo> vehiculos = new();
            try
            {
                IQueryable<Vehiculo> query = dbContext.Vehiculos.Include(v => v.TipoVehiculo);
                if (!string.IsNullOrEmpty(localidadRecogida))
                {
                    query = query.Where(v => v.LocalidadRecogida == localidadRecogida);
                }

                if (!string.IsNullOrEmpty(localidadDevolucion))
                {
                    query = query.Where(v => v.LocalidadDevolucion == localidadDevolucion);
                }
                vehiculos= query.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = vehiculos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = vehiculos });
            }
        }

    }
}
