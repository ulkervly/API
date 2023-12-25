using Microsoft.AspNetCore.Http;
using MyBiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.Models
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string? EmployeeImage { get; set; }
        [NotMapped]
        public IFormFile? ImageFile {  get; set; }
    }
}
