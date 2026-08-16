using LeaveManagement.Application.Models;

namespace LeaveManagement.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Student",
                DateOfBirth = new DateTime(2000, 9, 25)
            };
            return View(data);
        }
    }
}
