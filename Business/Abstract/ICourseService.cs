using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        public interface ICourseService : IGenericService<Course>
        {
            List<Course> GetCoursesByCategory(string category);
            List<Course> GetInstructorCourses(int instructorId);
            List<Course> GetAvailableCourses();
            List<Course> GetAllCourses();
        }
    }
}
