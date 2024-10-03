using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDBContext Context { get; set; } = new ApplicationDBContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MakeAppointment()
        {
            var Doctors = Context.Doctors.ToList();
            return View(Doctors);
        }
        
        public IActionResult CompleteAppointment(int id)
        {
            var Doctor = Context.Doctors.Where(e=>e.Id == id ).FirstOrDefault();
            if (Doctor != null) 
               return View(Doctor);

           return RedirectToAction("PageNotFound");
        }
        [HttpPost]
        public IActionResult CompleteAppointment(Appointment appointment)
        {
          
           Context.Appointments.Add(appointment);
            Context.SaveChanges();
            return RedirectToAction("GetAppointments");
        }
        public IActionResult GetAppointments()
        {
            var appointments = Context.Appointments.ToList(); 
            return View(appointments);
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
