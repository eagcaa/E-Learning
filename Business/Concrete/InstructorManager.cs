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
    public class InstructorManager : IinstructorService
    {
        private readonly IinstructorDal _instructorDal;

        public InstructorManager(IinstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public void AddCourseToInstructor(int instructorId, Course course)
        {
            var instructor = _instructorDal.GetByID(instructorId);

            if (instructor != null)
            {
                // Eğitmene kursu ekle
                instructor.Courses.Add(course);
                _instructorDal.Update(instructor);
            }
            else
            {
                // Belirtilen ID'ye sahip eğitmen bulunamadı
                // Hata işlemleri burada gerçekleştirilebilir
                throw new InvalidOperationException("Belirtilen ID'ye sahip eğitmen bulunamadı.");
            }
        }

        public void DeleteCourse(int courseId)
        {
            var courseToDelete = _instructorDal.GetCourseById(courseId);

            if (courseToDelete != null)
            {
                // Eğer kursa kayıtlı kullanıcılar varsa, kursu silemezsiniz
                if (courseToDelete.Users != null && courseToDelete.Users.Any())
                {
                    // Hata işlemleri burada gerçekleştirilebilir
                    throw new InvalidOperationException("Kursa kayıtlı kullanıcılar olduğu için kursu silemezsiniz.");
                }

                // Kursu sil
                _instructorDal.DeleteCourse(courseToDelete);
            }
            else
            {
                // Belirtilen ID'ye sahip kurs bulunamadı
                // Hata işlemleri burada gerçekleştirilebilir
                throw new InvalidOperationException("Belirtilen ID'ye sahip kurs bulunamadı.");
            }
        }

        public List<Course> GetAllCourses()
        {
            // Tüm kursları getir
            return _instructorDal.GetAllCourses();
        }

        public List<Course> GetAllCourses(int instructorId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAvailableCourses()
        {
            // Uygun kursları getir (örneğin, henüz başlamamış olanlar)
            return _instructorDal.GetAvailableCourses();
        }

        public List<Course> GetCoursesByCategory(string category)
        {
            // Belirli bir kategoriye ait kursları getir
            return _instructorDal.GetCoursesByCategory(category);
        }

        public List<Course> GetInstructorCourses(int instructorId)
        {
            // Eğitmene ait kursları getir
            return _instructorDal.GetInstructorCourses(instructorId);
        }

        public List<User> GetUsersInCourse(int courseId)
        {
            var course = _instructorDal.GetCourseById(courseId);

            if (course != null)
            {
                // Kursa kayıtlı kullanıcıları getir
                return course.Users.ToList();
            }
            else
            {
                // Belirtilen ID'ye sahip kurs bulunamadı
                // Hata işlemleri burada gerçekleştirilebilir
                throw new InvalidOperationException("Belirtilen ID'ye sahip kurs bulunamadı.");
            }
        }

        public void TDelete(Instructor instructor)
        {
            // Eğitmeni sil
            _instructorDal.Delete(instructor);
        }

        public Instructor TGetByID(int id)
        {
            // Belirtilen ID'ye sahip eğitmeni getir
            return _instructorDal.GetByID(id);
        }

        public List<Instructor> TGetInstructorsList(int id)
        {
            // Eğitmen listesini getir (belirli bir kategoriye ait)
            return _instructorDal.GetList(id);
        }

        public List<Instructor> TGetList()
        {
            // Tüm eğitmenleri getir
            return _instructorDal.GetList();
        }

        public void TInsert(Instructor instructor)
        {
            // Yeni eğitmen ekle
            _instructorDal.Insert(instructor);
        }

        public void TUpdate(Instructor instructor)
        {
            // Eğitmeni güncelle
            _instructorDal.Update(instructor);
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = _instructorDal.GetCourseById(course.CourseId);

            if (existingCourse != null)
            {
                // Kursu güncelle
                existingCourse.Title = course.Title;
                existingCourse.Description = course.Description;
                existingCourse.StartDate = course.StartDate;
                existingCourse.EndDate = course.EndDate;
                existingCourse.Category = course.Category;
                existingCourse.InstructorType = course.InstructorType;
                existingCourse.Capacity = course.Capacity;
                existingCourse.CostPerDay = course.CostPerDay;
                existingCourse.DurationInDays = course.DurationInDays;

                _instructorDal.UpdateCourse(existingCourse);
            }
            else
            {
                // Belirtilen ID'ye sahip kurs bulunamadı
                // Hata işlemleri burada gerçekleştirilebilir
                throw new InvalidOperationException("Belirtilen ID'ye sahip kurs bulunamadı.");
            }
        }
    }
}
