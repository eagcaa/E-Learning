using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService :IGenericService<User>
    {
        public List<User> TGetUserList(int id);
        List<Course> GetAllCoursesForUser(int userId);
        void AddCourseToUser(int userId, Course course);
        void CompleteCourse(int userId, Course course);
        void RemoveCourseFromUser(int userId, Course course);
        List<Course> GetUserCourses(int userId);
    }
}
