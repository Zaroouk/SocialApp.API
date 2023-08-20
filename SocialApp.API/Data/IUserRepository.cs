using Microsoft.AspNetCore.Mvc;
using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface IUserRepository
{
    public void AddUser<T>(T comment);
    public void RemoveUser<T>(T comment);
    public bool SaveChanges();
    public IEnumerable<User> GetAllUsers();
    public User GetSingleUser(int id);
    public User GetUserByEmail(string email);
}