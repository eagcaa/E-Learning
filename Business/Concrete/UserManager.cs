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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserRoleService _userRoleService;

        public UserManager(IUserDal userDal, IUserRoleService userRoleService)
        {
            _userDal = userDal;
            _userRoleService = userRoleService;
        }

        public List<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAvailableCourses()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetInstructorCourses(int instructorId)
        {
            throw new NotImplementedException();
        }

        public void TDelete(User user)
        {

            _userDal.Delete(user);
        }

        public User TGetByID(int id)
        {

            return _userDal.GetByID(id);
        }

        public List<User> TGetList()
        {

            return _userDal.GetList();
        }

        public List<User> TGetUserList(int id)
        {

            return _userDal.GetUserList(id);
        }

        public void TInsert(User user)
        {
            _userDal.Insert(user);
        }

        public void TUpdate(User user)
        {
            _userDal.Update(user);
        }

        public List<Course> GetAllCoursesForUser(int userId)
        {
            // Kullanıcının aldığı tüm kursları getir
            var user = _userDal.GetByID(userId);

            // Eğer kullanıcı null değilse ve kullanıcının aldığı kurslar varsa
            if (user != null && user.CompletedTrainings != null)
            {
                // Kullanıcının aldığı tüm kursları getir
                var courses = user.CompletedTrainings.Select(ct => ct.Course).ToList();
                return courses;
            }

            return new List<Course>();
        }

        public List<Course> GetAllCourses(int instructorId)
        {
            throw new NotImplementedException();
        }
        public void AddCourseToUser(int userId, Course course)
        {
            // Kullanıcıyı belirli bir kursa kaydettir
            _userDal.AddCourseToUser(userId, course);
        }

        public void CompleteCourse(int userId, Course course)
        {
            // Kullanıcı belirli bir kursu tamamladığını işaretle
            _userDal.CompleteCourse(userId, course);
        }

        public void RemoveCourseFromUser(int userId, Course course)
        {
            // Kullanıcının belirli bir kurs kaydını sil
            _userDal.RemoveCourseFromUser(userId, course);
        }

        public List<Course> GetUserCourses(int userId)
        {
            // Kullanıcının aldığı tüm kursları getir
            var user = _userDal.GetByID(userId);

            // Eğer kullanıcı null değilse ve kullanıcının aldığı kurslar varsa
            if (user != null && user.CompletedTrainings != null)
            {
                // Kullanıcının aldığı tüm kursları getir
                var courses = user.CompletedTrainings.Select(ct => ct.Course).ToList();
                return courses;
            }
            return new List<Course>();
        }
        //Kullanıcının rol bilgileri kontrol ediliyor
        public async Task AssignRoleAsync(AppUser user, string roleName)
        {
            await _userRoleService.AssignRoleAsync(user, roleName);
        }

        public async Task RemoveRoleAsync(AppUser user, string roleName)
        {
            await _userRoleService.RemoveRoleAsync(user, roleName);
        }
    }

}
