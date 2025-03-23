using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightLossPlannerAPI.Models
{
    public class MealLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MealName { get; set; } = "";
        public double Calories { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}