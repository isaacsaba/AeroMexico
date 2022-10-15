using ApiAeroMexico.Context;
using ApiAeroMexico.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;

namespace ApiAeroMexico.Services
{
    public class LoginService : ILoginService
    {
        AeroMexicoContext context;

        public LoginService(AeroMexicoContext context)
        {
            this.context = context;
        }
        public async Task CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync(); 
        }

        public  User GetUser(User user)
        {
            return  context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        }

    }
    
}
public interface ILoginService
{
    Task CreateUser(User user);
    User GetUser(User user);
}
