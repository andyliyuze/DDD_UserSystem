using DDD_UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
  public  class StudentApplicationService
    {

        private IStudentRepository _studentRepository;
        private IDbContext _context;
        public StudentApplicationService(IDbContext context, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _context = context;

        }

        public bool ChangePassword(Guid userId, string oldPwd, string newPwd)
        {
            Student student = _studentRepository.Get(userId);
            student.ChangePassword(oldPwd, newPwd);
            _context.Commit();
            return true;
        }


        public bool AddStudent(Student student)
        {
            _studentRepository.Add(student);
            int i=  _context.Commit();
            return i > 0;
        }
    }
}
