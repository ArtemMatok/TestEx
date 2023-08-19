using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using WebApplication12.Service;

namespace WebApplication12.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message message, User user)
        {
            #region detected
            //var existingUser = DB.allUsers.FirstOrDefault(x => x.Name == user.Name);

            //if(existingUser == null)
            //{
            //    var newUser = new User()
            //    {
            //        Id = DB.allUsers.Count + 1,
            //        Name = user.Name,
            //        Messages = new List<Message> { message },
            //        DataCreate = DateTime.Now,
            //    };
            //    DB.allMessages.Add(message);
            //    DB.allUsers.Add(newUser);
            //}
            //else
            //{
            //    existingUser.Messages.Add(message);
            //    DB.allMessages.Add(message);
            //}
            #endregion
            _userRepository.Create(message, user);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult GetAllMessagesByName(User user)
        {
            var messages = _userRepository.GetAllMessagesByName(user);
            return PartialView("_GetAllMessagesByName", messages);
        }
    }
}
