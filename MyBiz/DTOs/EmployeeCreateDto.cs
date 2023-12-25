

using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBiz.DTOs
{
    public class EmployeeCreateDto
    {
        public string FullName {  get; set; }
        public string Position { get; set; }
        public string Department {  get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
    public class EmployeeCreateDtoValidatior:AbstractValidator<EmployeeCreateDto> 
    {
        public EmployeeCreateDtoValidatior()
        {
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(50).WithMessage("Max 50 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(50).WithMessage("Max 50 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
            RuleFor(x => x.Department)
                 .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(50).WithMessage("Max 50 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");



        }
    }
 }
   
