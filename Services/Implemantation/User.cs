﻿using AutoMapper;
using DTO.Models;
using Microsoft.Extensions.Configuration;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services.Implemantation;

public class User: IServices.IUser
{
    private readonly IUser userRepository;

    public User(IUser userRepo)
    {
        userRepository = userRepo;
    }

      public User() 
    {
        //userRepository = new Repositories.Implementation.User();
    }

    MapperConfig myMapper = MapperConfig.Instance;

    /// <summary>
    /// This function gets an user's details and registered it to database.
    /// </summary>
    /// <param name="loginUser"></param>
    /// <returns></returns>
    public UserInfo? Login(LoginUser loginUser)
    {
        if (loginUser.UserName != null && loginUser.Password != null)
        {
            IMapper mapper = myMapper.UserMapper.CreateMapper();
            //TODO: send to the reposetories to function that check if the user exist
            string name = loginUser.UserName;
            string password = loginUser.Password;
            Repositories.Models.User? u = userRepository.Login(name, password);
            try
            {
                ArgumentNullException.ThrowIfNull(u);// continue just if u is not null
                UserInfo uInfo = mapper.Map<Repositories.Models.User, UserInfo>(u);
                return uInfo;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        else { return null; }
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
            if (newUser == null) { return -1; }
            else
            {
                IMapper mapper = myMapper.UserMapper.CreateMapper();
                Repositories.Models.User user = mapper.Map<DTO.Models.User, Repositories.Models.User>(newUser);
                //Repositories.Models.User user = mapper.Map<DTO.Models.User, Repositories.Models.User>(newUser);
                return userRepository.SignIn(user);
            }
        }
        catch (Exception e)
        {
            return -1;
        }
       
     
    }

    public bool IsUserExists(LoginUser newUser)
    {
        throw new NotImplementedException();
    }
}
