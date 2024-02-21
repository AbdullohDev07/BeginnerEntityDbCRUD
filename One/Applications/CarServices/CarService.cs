using Microsoft.EntityFrameworkCore.Metadata.Internal;
using One.Infrastructure;
using One.Roots;
using One.RootsDTO;

namespace One.Applications.CarServices
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            var result = _context.Cars.ToList();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Car> GetByIdCarAsync(int id)
        {
            var result = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<string> CreateCarAsync(CarDTO car)
        {
            var model = new Car
            {
                Name = car.Name,
                Brand = car.Brand,
                Price = car.Price,
            };
            await _context.AddAsync(model);
            await _context.SaveChangesAsync(); 

            return "Ma'lumot yaratildi";
        }

        public async Task<string> UpdateCarAsync(int id, CarDTO car)
        {
            var result = _context.Cars.FirstOrDefault(x => x.Id == id);
            
            if (result != null)
            {
                result.Name = car.Name;
                result.Brand = car.Brand;
                result.Price = car.Price;

                _context.SaveChangesAsync();

                return "Yangilandi";
            }
            return null;
        }

        public async Task<string> DeleteCarAsync(int id)
        {
            var result = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                _context.Cars.Remove(result);
                await _context.SaveChangesAsync();

                return "O'chirildi";
            }
            return null;
        }
    }
}
