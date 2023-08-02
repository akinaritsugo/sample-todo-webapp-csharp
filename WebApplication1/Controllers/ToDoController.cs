using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ToDoController : Controller
    {
        private IConfiguration _configuration;

        private ToDoRepository _repository;

        private int _userId = 1;

        public ToDoController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._repository = new ToDoRepository(this._configuration);
        }

        public IActionResult Index()
        {
            List<ToDoModel> list = this._repository.GetList(this._userId);
            return this.View(list);
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
