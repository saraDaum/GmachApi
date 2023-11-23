using AutoMapper;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        catch (Exception e)
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
}

