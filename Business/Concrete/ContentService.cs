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
    public class ContentService : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentService(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourses(int instructorId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAvailableCourses()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentsByType(ContentType contentType)
        {
            return _contentDal.GetContentsByType(contentType);
        }

        public List<Course> GetCoursesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetInstructorCourses(int instructorId)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content TGetByID(int id)
        {
            return _contentDal.GetByID(id);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public void TInsert(Content content)
        {
            _contentDal.Insert(content);
        }

        public void TUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        List<Course> IGenericService<Content>.GetAllCourses()
        {
            throw new NotImplementedException();
        }
    }
}
