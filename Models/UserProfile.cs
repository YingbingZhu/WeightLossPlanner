using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightLossPlannerAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public double HeightCm  { get; set; }
        public double WeightKg  { get; set; }
        public string Gender  { get; set; } = "";
    }
}