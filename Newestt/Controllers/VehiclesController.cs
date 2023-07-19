using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Newestt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private static List<Vehicles> vehicles = new List<Vehicles>
            {
                new Vehicles { Id = 1,
                    VehicleName = "Volvo",
                    VehicleType = "Busss",
                    VehiclesLocation = "London"},

                new Vehicles { Id = 2,
                    VehicleName = "Mercedes",
                    VehicleType = "Truck",
                    VehiclesLocation = "USA"},
            };

        [HttpGet]
        public async  Task<ActionResult<List<Vehicles>>> Get()
        {
            return Ok(vehicles);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> Get(int id)
        {
            var vehicle = vehicles.Find(x => x.Id == id);
            if (vehicle == null)
            {
                return BadRequest("That Vehicle not found");
            }
            return Ok(vehicle);
        }


        [HttpPost]
        public async Task<ActionResult<List<Vehicles>>> AddVehicles(Vehicles vehicle)
        {
            vehicles.Add(vehicle);
            return Ok(vehicles);
        }

        [HttpPut]

        public async Task<ActionResult<List<Vehicles>>> UpdateVehicles(Vehicles request)
        {
            var vehicle = vehicles.Find(x => x.Id == request.Id);
            if (vehicle == null)
            {
                return BadRequest("That Vehicle not found");
            }
            vehicle.VehicleName = request.VehicleName;
            vehicle.VehicleType = request.VehicleType;
            vehicle.VehiclesLocation = request.VehiclesLocation;           

            return Ok(vehicles);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vehicles>>> DeleteVehicle(int id)
        {
            var vehicle = vehicles.Find(x => x.Id == id);
            if (vehicle == null)
            {
                return BadRequest("That Vehicle not founddd");
            }
       
            vehicles.Remove(vehicle);
            return Ok(vehicles);
            
        }


    }
}
