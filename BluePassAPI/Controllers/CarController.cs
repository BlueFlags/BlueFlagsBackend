using BluePassAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluePassAPI.Controllers
{
    public class CarController : ControllerBase
    {
        BluePassContext db = new BluePassContext();
        [Route("api/cars")]
        [HttpGet]
        public List<Car> CarList()
        {
            List<Car> cars = db.Car.ToList();
            return cars;
        }
        [Route("api/car/{id}")]
        [HttpGet]
        public Car Car(int id)
        {
            Car car = db.Car.Where(m => m.Id == id).SingleOrDefault();
            return car;
        }
        [Route("api/addCar")]
        [HttpPost]
        public Car AddCar(Car car)
        {
            Car newC = new Car();
            newC.Id = car.Id;
            newC.Plate = car.Plate;
            newC.UserId = car.UserId;
            db.Car.Add(newC);
            db.SaveChanges();
            return newC;
        }
        [Route("api/updateCar")]
        [HttpPut]
        public Car UpdateCar(Car car)
        {
            Car updateC = db.Car.Where(m => m.Id ==
           car.Id).SingleOrDefault();
            if (car != null)
            {
                updateC.Id = car.Id;
                updateC.Plate = car.Plate;
                updateC.UserId = car.UserId;
            }
            db.SaveChanges();
            return car;
        }
        [Route("api/deleteCar/{id}")]
        [HttpDelete]
        public bool DeleteCar(int id)
        {
            Car car = db.Car.Where(m => m.Id == id).SingleOrDefault();
            if (car != null)
            {
                db.Car.Remove(car);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
