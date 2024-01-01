using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService <T> where T : class
    {
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        T TGetByID(int id);
        List<T> TGetList();
        List<Course> GetAllCourses();
        List<Course> GetAvailableCourses();
        List<Course> GetInstructorCourses(int instructorId);
        List<Course> GetCoursesByCategory(string category);
        List<Course> GetAllCourses(int instructorId);
    }
}
