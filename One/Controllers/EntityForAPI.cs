using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One.Applications.CarServices;
using One.Roots;
using One.RootsDTO;
using System.Globalization;

namespace One.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntityForAPI : ControllerBase
    {
        private readonly ICarService _service;

        public EntityForAPI(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Car>> GetAllCars() 
        {
            var result = await _service.GetAllCarsAsync();

            return result;
        }

        [HttpGet]
        public async Task<Car> GetByIdCar(int id)
        {
            var result = await _service.GetByIdCarAsync(id);
            
            return result;
        }

        [HttpPost]
        public async Task<string> CreateCar(CarDTO car)
        {
            var result = await _service.CreateCarAsync(car);

            return result;
        }

        [HttpPut]
        public async Task<string> UpdateCar(int id, CarDTO car)
        {
            var result = await _service.UpdateCarAsync(id, car);

            return result;
        }

        [HttpDelete]
        public async Task<string> DeleteCar(int id)
        {
            var result = _service.DeleteCarAsync(id);

            return await result;
        }
    }
}
