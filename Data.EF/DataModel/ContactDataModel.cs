using System;
using System.ComponentModel.DataAnnotations;

namespace DDD_UserSystem.Data.EF.DataModel
{
    public class ContactDataModel
    {
        [Key]
        public Guid ContactId { get; set; }

        public Guid UserId { get; set; }
        public int QQ { get; set; }
        public int Phone { get; set; }

    }
}
