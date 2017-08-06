using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
    public class StudentRepository : IStudentRepository
    {
        public Student Get(Guid userId)
        {

            Student stu = new Student();
            return stu;
        }


    }
}
