﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IinstructorService : IGenericService<Instructor>
    {
        List<Instructor> TGetInstructorsList(int id);
        List<Course> GetInstructorCourses(int instructorId);
        List<User> GetUsersInCourse(int courseId);
        void AddCourseToInstructor(int instructorId, Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
    }
}
