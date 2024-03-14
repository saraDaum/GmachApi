using Arch.EntityFrameworkCore.Query.Internal;
using AutoMapper;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Repositories.Implementation;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUser = Repositories.Interfaces.IUser;

namespace Services.Implemantation;

public class User : IServices.IUser
{
    private readonly IUser userRepository;

    // constructors
    public User(IUser userRepo)
    {
        userRepository = userRepo;
    }
    public User()
    {
        userRepository = new Repositories.Implementation.User();
    }

    
    MapperConfig myMapper = MapperConfig.Instance;

    /// <summary>
    /// This function gets an user's details and registered it to database.
    /// </summary>
    /// <param name="loginUser"></param>
    /// <returns></returns>
    public UserInfo? Login(LoginUser loginUser)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(loginUser.UserName);// Continue just if it is not null
            ArgumentNullException.ThrowIfNull(loginUser.Password);// Continue just if it is not null

            
            IMapper mapper = myMapper.UserInfoMapper.CreateMapper();
            string name = loginUser.UserName;
            string password = loginUser.Password;
            Users? u = userRepository.Login(name, password);
            ArgumentNullException.ThrowIfNull(u);// continue just if u is not null
            UserInfo uInfo = mapper.Map<Users, UserInfo>(u);
            return uInfo;

        }
        catch (Exception ex)
        {
            return null;
        }
    }


    /// <summary>
    /// Helping function that check if the user already exist
    /// </summary>
    /// <param name="newUser">User</param>
    /// <returns>If the user exist</returns>
    public int SignIn(DTO.Models.User newUser)
    {
        try
        {
            //checks that the user not exsist or null
            if (newUser == null) { return -1; }
            if (IsUserExists(new LoginUser(newUser.UserName, newUser.UserPassword))) { return -2; }            
            //send it to the Repository Layer
            IMapper mapper = myMapper.UserMapper.CreateMapper();
            Users user = mapper.Map<DTO.Models.User, Users>(newUser);
            return userRepository.SignIn(user);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }


    }

    /// <summary>
    /// Helping function that check if the user exist
    /// </summary>
    /// <param name="newUser">the user details</param>
    /// <returns> true/ false</returns>
    public bool IsUserExists(LoginUser newUser)
    {
        try
        {
            IMapper mapper = myMapper.LoginUserMapper.CreateMapper();
            LogInUser isUserExist = mapper.Map<LoginUser, LogInUser>(newUser);
            ArgumentNullException.ThrowIfNull(newUser);// Continue just if newUser is not null
            Users? isExist = userRepository.GetUser(isUserExist);
            if (isExist == null) { return false; }
            else return true;
        }
        catch(Exception e) 
        {
            Console.WriteLine(e);
            return false;
        }

    }

    public List<DTO.Models.User> GetAllUsers() {
        try
        {
            IMapper mapper = myMapper.UserMapper.CreateMapper();
            List<Repositories.Models.Users> allUsers = userRepository.GetAll();
            List<DTO.Models.User> users = allUsers.ConvertAll<DTO.Models.User>(user => mapper.Map<Repositories.Models.Users, DTO.Models.User>(user));
            return users;
        }
        catch
        {
            return new List<DTO.Models.User>();
        }
    }


    public bool DeleteUser(int userId)
    {
        try
        {
            Repositories.Models.Users? deleteUser = userRepository.GetUser(userId);
            if (deleteUser != null)
                return userRepository.DeleteUser(deleteUser);
            else return false;
        }
        catch
        {
            return false;
        }

    }

    public bool AdminLogIn(LoginUser isAdmin)
    {
        try
        {
            int isEmailAdmin = userRepository.isAdmin(isAdmin.UserName);//check if userName(email) is equal to admin email. And if password is match.
            if (isEmailAdmin > 0)
            {
                if (isAdmin.Password == "23578951")
                    return true;
                return false;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
    public bool IsUserExist(int userId)
    {
        return userRepository.IsUserExist(userId);
    }

    public DTO.Models.User? GetUser(int UserId)
    {
        try
        {
            Repositories.Models.Users User = userRepository.GetUser(UserId);
            if (User != null) {
                IMapper mapper  = myMapper.UserMapper.CreateMapper();
                DTO.Models.User user = mapper.Map<Repositories.Models.Users, DTO.Models.User>(User);
                return user;    
            }
            return null;
            
        }
        catch
        {
            return null;
        }
    }


    public string GetUserPassword(int id)
    {
        try
        {
            return userRepository.GetUserPassword(id);
        }
        catch
        {
            return "";
        }
    }

    public string GetUserName(int id)
    {
        try
        {
            return userRepository.GetUserName(id);
        }
        catch
        {
            return "";
        }
    }

    public string GetUserEmail(int id)
    {
        try
        {
            return userRepository.GetUserEmail(id);
        }
        catch
        {
            return string.Empty;
        }
    }

    public bool ChangePassword(ChangPassword changPassword)
    {
        try
        {
            
            if (!IsUserExists(new LoginUser() { UserName = changPassword.UserName, Password = changPassword.OldPassword }))
                return false;
            if (IsUserExists(new LoginUser() { UserName = changPassword.UserName, Password = changPassword.NewPassword }))
                return false;

            return userRepository.ChangePassword(changPassword.UserName, changPassword.OldPassword, changPassword.NewPassword);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}

