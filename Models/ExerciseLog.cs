using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightLossPlannerAPI.Models
{
    public class ExerciseLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; } = "";
        public double DurationMinutes { get; set; }
        public double CaloriesBurned { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}