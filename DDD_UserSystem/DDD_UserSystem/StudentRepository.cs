using DDD_UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
    public class StudentRepository : IStudentRepository
    {
        private UserContext _context;


        public StudentRepository(IDbContext context) { _context = context as UserContext; }
        public void Add(Student student)
        {
            if (student.UserId == null) { throw new Exception("Id不能为空"); }
            _context.Student.Add(student);
        }

        public Student Get(Guid userId)
        {
            Student stu  =  _context.Student.Find(userId);
            return stu;
        }


    }
}
