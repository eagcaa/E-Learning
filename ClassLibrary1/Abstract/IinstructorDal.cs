using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IinstructorDal : IGenericDal<Instructor>
    {
        List<Instructor> GetList(int id);
        List<Course> GetInstructorCourses(int instructorId);
        List<User> GetUsersInCourse(int courseId);
        void AddCourseToInstructor(int instructorId, Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
        List<Course> GetAllCourses(int instructorId);
        Course GetCourseById(int courseId);
        void DeleteCourse(Course course);
        List<Course> GetAvailableCourses();
        List<Course> GetCoursesByCategory(string category);
        List<Course> GetAllCourses();
    }
}
