using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        public string InstructorType { get; set; } // "İç Eğitmen" veya "Dış Eğitmen" gibi değerler alabilir.

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal CostPerDay { get; set; }

        [Required]
        public int DurationInDays { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
