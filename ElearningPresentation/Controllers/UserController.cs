using Business.Abstract;
using ElearningPresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPresentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;

        public UserController(IUserService userService, ICourseService courseService)
        {
            _userService = userService;
            _courseService = courseService;
        }

        // Kullanıcı paneli
        // Kullanıcının kaydolduğu kursları görüntüleyebilmesi
        public IActionResult Dashboard(int userId)
        {
            var user = _userService.TGetByID(userId);
            var userCourses = _userService.GetUserCourses(userId);

            ViewBag.UserName = $"{user.FirstName} {user.LastName}";
            return View(userCourses);
        }

        // Kullanıcının yeni kursa kayıt olabilmesi
        public IActionResult RegisterToCourse(int userId, int courseId)
        {
            _userService.AddCourseToUser(userId, _courseService.TGetByID(courseId));
            return RedirectToAction("Dashboard", new { userId });
        }

        // Kullanıcının kaydolduğu kursları silebilmesi
        public IActionResult UnregisterFromCourse(int userId, int courseId)
        {
            _userService.RemoveCourseFromUser(userId, _courseService.TGetByID(courseId));
            return RedirectToAction("Dashboard", new { userId });
        }

        // Kullanıcının kursu tamamlaması
        public IActionResult CompleteCourse(int userId, int courseId)
        {
            _userService.CompleteCourse(userId, _courseService.TGetByID(courseId));
            return RedirectToAction("Dashboard", new { userId });
        }
        public IActionResult Dashboard()
        {
            // Kullanıcının tamamladığı, alabileceği ve kayıtlı olduğu kursları getir
            var userId = 1; // Kullanıcının gerçek ID'sini buraya ekleyin
            var completedCourses = _userService.GetAllCoursesForUser(userId);
            var availableCourses = _courseService.GetAvailableCourses();
            var enrolledCourses = _userService.GetUserCourses(userId);

            // Model oluştur
            var model = new DashboardViewModel
            {
                CompletedCourses = completedCourses,
                AvailableCourses = availableCourses,
                EnrolledCourses = enrolledCourses
            };

            return View(model);
        }
    }
}
