using Lab456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace Lab456.Controllers.Api
{
    public class CoursesController : ApiController
    {
        // GET: Courses
        public ApplicationDbContext _dbContext { get; set; }
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserName();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerID == userId);
            if(course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}