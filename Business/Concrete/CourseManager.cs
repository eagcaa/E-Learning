using Business.Abstract;
using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void TDelete(Course course)
        {
            _courseDal.Delete(course);
        }

        public Course TGetByID(int id)
        {
            return _courseDal.GetByID(id);
        }

        public List<Course> TGetList()
        {
            return _courseDal.GetList();
        }

        public void TInsert(Course course)
        {
            _courseDal.Insert(course);
        }

        public void TUpdate(Course course)
        {
            _courseDal.Update(course);

        }
 
        public List<Course> GetCoursesByCategory(string category)
        {
            return _courseDal.GetCoursesByCategory(category);
        }

        public List<Course> GetInstructorCourses(int instructorId)
        {
            return _courseDal.GetInstructorCourses(instructorId);
        }

        public List<Course> GetAvailableCourses()
        {
            return _courseDal.GetAvailableCourses();
        }
        public List<Course> GetAllCourses()
        {
            return _courseDal.GetAllCourses();
        }

        public List<Course> GetAllCourses(int instructorId)
        {
            return _courseDal.GetInstructorCourses(instructorId);
        }
    }
}
