using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<TrainingRequest> TrainingRequests { get; set; }

        public ICollection<CompletedTraining> CompletedTrainings { get; set; }

        public ICollection<Content> Contents { get; set; }
    }

    public class TrainingRequest
    {
        [Key]
        public int TrainingRequestId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }

    public class CompletedTraining
    {
        [Key]
        public int CompletedTrainingId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [MaxLength(200)]
        public string FilePath { get; set; } 

        public ICollection<Course> Courses { get; set; } 
    }

    public enum ContentType
    {
        Book,
        Video,
        Presentation,
        Article,
        MiniProject,
    }

}

