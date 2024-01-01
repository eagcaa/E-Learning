using Entity;

namespace ElearningPresentation.Models
{
    public class DashboardViewModel
    {
        public List<Course> CompletedCourses { get; set; }
        public List<Course> AvailableCourses { get; set; }
        public List<Course> EnrolledCourses { get; set; }
    }
}
