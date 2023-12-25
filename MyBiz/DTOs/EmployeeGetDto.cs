using FluentValidation;

namespace MyBiz.DTOs
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position {  get; set; }
    }
    public class EmployeeGetDtoValidatior : AbstractValidator<EmployeeGetDto>
    {
        public EmployeeGetDtoValidatior()
        {
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(50).WithMessage("Max 50 ola biler!")
               .MinimumLength(5).WithMessage("Min 3 ola biler!");
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(50).WithMessage("Max 50 ola biler!")
               .MinimumLength(5).WithMessage("Min 3 ola biler!");
          

        }
    }
}
