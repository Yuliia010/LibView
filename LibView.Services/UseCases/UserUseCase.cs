using LibView.DAL.Local.DataBase;
using LibView.DAL.Local.DataBase.Models;
using LibView.DAL.Local.DataBase.Repositories;
using LibView.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.Domain.UseCases
{
    public class UserUseCase
    {
        static private LibViewContext _context = new LibViewContext();
        static private Repository<User> _repository = new Repository<User>(_context);
        static private UserProvider _provider = new UserProvider(_repository);
        static private List<User> _users => _provider.GetUsers().ToList();

        static public bool Add(User user)
        {
            if (user != null)
            {
                if (_provider.GetUsers().Any(_user => _user.login == user.login))
                {
                    return false;
                }
            }

            _provider.AddUser(user);
            return true;
        }

        static public bool CheckPassword(User user, string password)
        {
            if (user.password == password)
                return true;
            return false;
        }

        static public bool IsAdmin(string username)
        {
            foreach (var user in _users)
            {
                if (user.login == username)
                {
                    if (user.IsAdmin)
                        return true;
                }
            }
            return false;
        }

        static public User GetUser(string login)
        {
            foreach (var user in _users)
            {
                if (user.login == login)
                {
                    return user;
                }
            }
            return null;
        }
        static public User GetUser(int id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        static public int GetUserIdFromName(string userName)
        {
            foreach (var user in _users)
            {
                if (user.Name == userName)
                {
                    return user.Id;
                }
            }
            return 0;
        }

        static public void DeleteUser(int id)
        {
            _provider.RemoveUser(id);

        }
        static public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        static public string GetUserName(int id)
        {
            return _provider.GetUser(id).Name;
        }

        static public void Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(t => t.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.login = user.login;
                existingUser.password = user.password;
                existingUser.IsAdmin = user.IsAdmin;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("User wasn't found!");
            }
        }

    }
}
