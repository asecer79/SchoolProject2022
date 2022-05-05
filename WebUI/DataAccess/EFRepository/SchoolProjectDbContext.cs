using Microsoft.EntityFrameworkCore;
using WebUI.Entities;

namespace WebUI.DataAccess.EFRepository
{
    public class SchoolProjectDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.; initial catalog =SchoolProjectDb;Trusted_Connection=True;");
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }

        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<ExamType>? ExamTypes { get; set; }
        public DbSet<Lecturer>? Lecturers { get; set; }
        public DbSet<Semester>? Semesters { get; set; }
        public DbSet<StudentCourse>? StudentCourses { get; set; }
        public DbSet<StudentExam>? StudentExams { get; set; }

    }
}
