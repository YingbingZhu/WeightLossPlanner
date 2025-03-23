using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeightLossPlannerAPI.Data;
using WeightLossPlannerAPI.Models;

namespace WeightLossPlannerAPI.Controllers
{   
    /// <summary>
    /// Manages user-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // sets the base URL
    public class UserProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserProfileController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all user profiles from the database.
        /// </summary>
        /// <returns>A list of user profiles.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserProfile>> GetAllUsers()
        {
            return Ok(_context.UserProfiles.ToList());
        }

        /// <summary>
        /// Creates a new user profile.
        /// </summary>
        /// <param name="user">The user profile data to create.</param>
        /// <returns>The newly created user profile.</returns>
        [HttpPost]
        public ActionResult<UserProfile> CreateUser(UserProfile user)
        {
            _context.UserProfiles.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
        }
    }
}