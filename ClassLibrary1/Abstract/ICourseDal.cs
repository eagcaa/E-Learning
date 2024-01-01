using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface ICourseDal : IGenericDal<Course>
    {
        List<Course> GetCoursesByCategory(string category);
        List<Course> GetInstructorCourses(int instructorId);
        List<Course> GetAvailableCourses();
        List<Course> GetAllCourses();
    }
}
