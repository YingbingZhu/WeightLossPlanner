using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WeightLossPlannerAPI.Models;

namespace WeightLossPlannerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>(); // Return this value when UserProfiles is accessed.
        public DbSet<MealLog> MealLogs => Set<MealLog>();
        public DbSet<ExerciseLog> ExerciseLogs => Set<ExerciseLog>();
    }
}