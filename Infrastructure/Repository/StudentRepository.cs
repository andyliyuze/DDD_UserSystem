using AutoMapper;
using DDD_UserSystem;
using DDD_UserSystem.Data.EF.DataModel;
using DDD_UserSystem.DataMap;
using DDD_UserSystem.Domain.Model;
using DDD_UserSystem.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UserDomain
{
    public class StudentRepository : IStudentRepository
    {
        private IDbContext _context;
        private IUnitOfWork _unitofwork;

        public StudentRepository(IDbContext context, IUnitOfWork unitofwork) {
            _context = context;
            _unitofwork = unitofwork;
        }
        public void Add(Student student)
        {
            if (student.ID == null) { throw new Exception("Id不能为空"); }
            foreach (var contact in student.Contacts) 
            {
               //var contactDataModel= ContactMap.MapToDataModel(contact,student.ID);
                var contactDataModel = Mapper.Map<Contact, ContactDataModel>(contact);
                contactDataModel.UserId = student.ID;
               _context.Contacts.Add(contactDataModel);
            }
            _context.Student.Add(student);
        }

        public Student Get(Guid userId)
        {
            Student stu  =  _context.Student.Find(userId);
            if (stu == null) { throw new Exception("找不到该学生"); }
            List<ContactDataModel> dataModel = _context.Contacts.Where(a => a.UserId == userId).ToList();
            var contacts = new List<Contact>();
            foreach (var contact in dataModel)
            {
                var domain = ContactMap.MapToDomainModel(contact, userId);             
                contacts.Add(domain);
            }
            stu.Contacts = contacts;
            return stu;
        }

        public void Update(Student student)
        {

            //此逻辑符合添加或删除Contact的业务用例

            //先删除数据所有该用户数据
            List<ContactDataModel> SQLDataList = _context.Contacts.Where(a => a.UserId == student.ID).ToList();
            _context.Contacts.RemoveRange(SQLDataList);         
            //再添加数据
            foreach (var domainModel in student.Contacts)
            {
                var dataModel = ContactMap.MapToDataModel(domainModel, student.ID);
                _context.Contacts.Add(dataModel);
            }
            _unitofwork.RegisterDirty<Student>(student);
        }

          
    }
}
