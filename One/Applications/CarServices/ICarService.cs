using One.Roots;
using One.RootsDTO;

namespace One.Applications.CarServices
{
    public interface ICarService
    {
        public Task<List<Car>> GetAllCarsAsync();
        public Task<Car> GetByIdCarAsync(int id);
        public Task<string> CreateCarAsync(CarDTO car);
        public Task<string> UpdateCarAsync(int id, CarDTO car);
        public Task<string> DeleteCarAsync(int id);
    }
}
