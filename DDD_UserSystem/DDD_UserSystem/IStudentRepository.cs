using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
  public  interface IStudentRepository
    {
        Student Get(Guid userId);
        void Add(Student student);
    }
}
