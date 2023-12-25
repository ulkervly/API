using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBiz.Core.Models;
using MyBiz.Data.DAL;
using MyBiz.DTOs;

namespace MyBiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly AppDbContext _context;
        private IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public EmployeesController(AppDbContext context, IWebHostEnvironment environment,IMapper mapper)
        {
            _context = context;
            _environment = environment;
            _mapper = mapper;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            List<Employee> employees = _context.Employees.ToList();

            IEnumerable<EmployeeGetDto> empDtos = new List<EmployeeGetDto>();

            empDtos = employees.Select(x => new EmployeeGetDto { Id = x.Id, FullName = x.FullName,Position=x.Position });

            return Ok(empDtos);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee =  _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            EmployeeGetDto dto=_mapper.Map<EmployeeGetDto>(employee);

            return Ok();

        }
        [HttpPost]
        public IActionResult Create([FromForm] EmployeeCreateDto dto, IFormFile image)
        {
           var emp=_mapper.Map<Employee>(dto);
            if (image != null && image.Length > 0)
            {
                
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Employee", fileName);

                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

               
                string ImagePath = "C:\\Users\\hp\\Desktop\\Yeni qovluq\\MyBiz\\wwwroot\\uploads\\Employee" + fileName; 
            }

            emp.AddedDate = DateTime.UtcNow.AddHours(4);
            emp.UpdatedDate = DateTime.UtcNow.AddHours(4);
            

            emp.IsDeleted = false;
            _context.Employees.Add(emp);
            _context.SaveChanges();

            return StatusCode(201, new { message = "Object created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeUpdateDto dto)
        {
            var emp = _context.Employees.Find(id);

            if (emp is null)
            {
                return NotFound();
            }

           emp=_mapper.Map(dto,emp);
            emp.UpdatedDate = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp is null)
            {
                return NotFound();
            }

            emp.IsDeleted = true;
            emp.UpdatedDate = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return StatusCode(201, new { message = "Object deleted" });
        }
    
    }
}
