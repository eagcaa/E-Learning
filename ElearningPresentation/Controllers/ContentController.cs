using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPresentation.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            // Tüm içerikleri getir ve view'e gönder
            var allContents = _contentService.TGetList();
            return View(allContents);
        }

        public IActionResult ContentDetails(int id)
        {
            // Belirli bir içeriği getir ve view'e gönder
            var content = _contentService.TGetByID(id);
            return View(content);
        }

        public IActionResult ContentsByType(ContentType contentType)
        {
            // Belirli bir içerik türüne sahip içerikleri getir ve view'e gönder
            var contents = _contentService.GetContentsByType(contentType);
            return View(contents);
        }
    }
}
