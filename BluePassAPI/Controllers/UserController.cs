
using BluePassAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluePassAPI.Controllers
{
    public class UserController : ControllerBase
    {
        BluePassContext db = new BluePassContext();
        [Route("api/users")]
        [HttpGet]
        public List<User> UserList()
        {
            List<User> users = db.User.ToList();
            return users;
        }
        [Route("api/user/{id}")]
        [HttpGet]
        public User User(int id)
        {
            User user = db.User.Where(m => m.Id == id).SingleOrDefault();
            return user;
        }
        [Route("api/user/{id}/cars")]
        [HttpGet]
        public IEnumerable<Car> Cars(int id)
        {
            IEnumerable<Car> cars = db.Car.Where(m => m.UserId == id).Take(1000);
            return cars;
        }
        [Route("api/addUser")]
        [HttpPost]
        public User AddUser(User car)
        {
            User newU = new User();
            newU.Id = car.Id;
            newU.Name = car.Name;
            newU.Surname = car.Surname;
            newU.Password = car.Password;
            newU.Phone = car.Phone;
            newU.Email = car.Email;
            db.User.Add(newU);
            db.SaveChanges();
            return newU;
        }
        [Route("api/updateUser")]
        [HttpPut]
        public User UpdateUser(User user)
        {
            User updateU = db.User.Where(m => m.Id ==
           user.Id).SingleOrDefault();
            if (user != null)
            {
                updateU.Id = user.Id;
                updateU.Phone = user.Phone;
                updateU.Password = user.Password;
                updateU.Email = user.Email;
                updateU.Name = user.Name;
                updateU.Surname = user.Surname;
            }
            db.SaveChanges();
            return user;
        }
        [Route("api/deleteUser/{id}")]
        [HttpDelete]
        public bool DeleteUser(int id)
        {
            User user = db.User.Where(m => m.Id == id).SingleOrDefault();
            if (user != null)
            {
                db.User.Remove(user);
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