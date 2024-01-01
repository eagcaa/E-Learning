using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUserDal :IGenericDal<User>
    {
        List<User> GetUserList(int id);
        List<Course> GetUserCourses(int userId);
        void AddCourseToUser(int userId, Course course);
        void CompleteCourse(int userId, Course course);
        void RemoveCourseFromUser(int userId, Course course);

    }
}
