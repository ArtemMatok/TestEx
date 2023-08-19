using WebApplication12.Models;

namespace WebApplication12.Service
{
    public class UserRepository
    {
        public User Create(Message message, User user)
        {
            var existingUser = DB.allUsers.FirstOrDefault(x => x.Name == user.Name);

            if (existingUser == null)
            {
                var newUser = new User()
                {
                    Id = DB.allUsers.Count + 1,
                    Name = user.Name,
                    Messages = new List<Message> { message },
                    DataCreate = DateTime.Now,
                };
                DB.allMessages.Add(message);
                DB.allUsers.Add(newUser);
            }
            else
            {
                existingUser.Messages.Add(message);
                DB.allMessages.Add(message);
            }

            return existingUser;
        }

        public IEnumerable<User> GetAllMessagesByName(User user)
        {
            var messages = DB.allUsers.OrderByDescending(x => x.DataCreate).Take(10).Where(x => x.Name == user.Name).ToList();
            return messages;
        }
    }
}
