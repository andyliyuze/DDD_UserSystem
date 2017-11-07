using AutoMapper;
using DDD_UserSystem.Data.EF.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain;

namespace DDD_UserSystem.Data.EF
{
    public class DataMapConfig
    {
        public static void MapConfig()
        {

            Mapper.Initialize(cfg =>
            {
               
                cfg.CreateMap<StudentDataModel, Student>().ForMember(
                    d => d.Address, opt => opt.MapFrom(s => new Address() { Contry = s.Detail, Detail = s.Detail })
                   ).ForMember<LoginInfo>(d => d.LoginInfo, opt => opt.MapFrom(s => new LoginInfo() { LoginName = s.LoginName, Password = s.Password }));
                cfg.CreateMap<ContactDataModel, Contact>();
                cfg.CreateMap<Contact, ContactDataModel>();

                cfg.CreateMap<Post, PostInfo>();
                cfg.CreateMap<User, PostInfo>().ForMember(d=>d.AuthorName,opt=>opt.MapFrom(s=>s.RealName));
            });
        }
    }
}
