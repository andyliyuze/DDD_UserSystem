using DDD_UserSystem.Domain.Model;
using System;

namespace UserDomain
{
    public  interface IStudentRepository
    {
        Student Get(Guid userId);
        void Add(Student student);
        void Update(Student student);
    }
}
