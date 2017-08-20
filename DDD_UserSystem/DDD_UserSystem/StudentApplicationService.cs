﻿using DDD_UserSystem;
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
        public StudentApplicationService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        public bool ChangePassword(Guid userId, string oldPwd, string newPwd)
        {
            Student student = _studentRepository.Get(userId);
            student.ChangePassword(oldPwd, newPwd);
            _context.SaveChange();
            return true;
        }
    }
}
