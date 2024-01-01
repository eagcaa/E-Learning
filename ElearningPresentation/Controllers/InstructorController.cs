using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPresentation.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IinstructorService _instructorService;
        private readonly ICourseService _courseService;

        public InstructorController(IinstructorService instructorService, ICourseService courseService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var instructors = _instructorService.TGetList();
            return View(instructors);
        }

        public IActionResult Courses(int instructorId)
        {
            var instructorCourses = _instructorService.GetInstructorCourses(instructorId);
            return View(instructorCourses);
        }

        public IActionResult UsersInCourse(int courseId)
        {
            var usersInCourse = _instructorService.GetUsersInCourse(courseId);
            return View(usersInCourse);
        }

        public IActionResult EditCourse(int courseId)
        {
            var course = _courseService.TGetByID(courseId);
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _instructorService.UpdateCourse(course);
                return RedirectToAction("Courses", new { instructorId = course.InstructorId });
            }

            // Model geçerli değilse, hata mesajları ile tekrar düzenleme sayfasını göster
            return View(course);
        }

        public IActionResult DeleteCourse(int courseId)
        {
            try
            {
                _instructorService.DeleteCourse(courseId);
                return RedirectToAction("Courses", new { instructorId = _courseService.TGetByID(courseId)?.InstructorId });
            }
            catch (InvalidOperationException ex)
            {
                // Hata durumunda hata mesajını görüntüle
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
