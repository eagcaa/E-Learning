using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPresentation.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            // Tüm kursları getir ve görüntüle
            var allCourses = _courseService.GetAllCourses();
            return View(allCourses);
        }

        public IActionResult Details(int id)
        {
            // Belirli bir kursun detaylarını getir ve görüntüle
            var course = _courseService.TGetByID(id);
            return View(course);
        }

        public IActionResult Create()
        {
            // Yeni kurs oluşturma sayfasını görüntüle
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            // Yeni kurs oluştur
            _courseService.TInsert(course);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // Belirli bir kursu düzenleme sayfasını görüntüle
            var course = _courseService.TGetByID(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            // Belirli bir kursu güncelle
            _courseService.TUpdate(course);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Belirli bir kursu silme sayfasını görüntüle
            var course = _courseService.TGetByID(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Belirli bir kursu sil
            var course = _courseService.TGetByID(id);
            _courseService.TDelete(course);
            return RedirectToAction("Index");
        }

        public IActionResult CoursesByCategory(string category)
        {
            // Belirli bir kategoriye ait kursları getir ve görüntüle
            var courses = _courseService.GetCoursesByCategory(category);
            return View(courses);
        }

    }
}
