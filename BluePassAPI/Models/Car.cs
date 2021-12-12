using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluePassAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int UserId { get; set; }
    }
}
