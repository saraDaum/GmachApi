using AutoMapper;
using DTO.Models;
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
  private readonly IUser userRepository;// = new Repositories.Implementation.User(new GmachimSaraAndShaniContext());//todo: check the problem here!

    public User(IUser _userRepo)
    {
        userRepository = _userRepo;
    }
    //Mapper userInfo = new Mapper();
    MapperConfig myMapper = MapperConfig.Instance;

    /// <summary>
    /// This function gets an user's details and registered it to database.
    /// </summary>
    /// <param name="loginUser"></param>
    /// <returns></returns>
    public UserInfo? Login(LoginUser loginUser)
    {
        IMapper mapper = myMapper.UserMapper.CreateMapper();
        //TODO: send to the reposetories to function that check if the user exist
        Repositories.Models.User? u = userRepository.Login(loginUser.UserName, loginUser.Password);
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

   

    public bool IsUserExists(DTO.Models.User newUser)
    {
        try
        {
            IMapper mapper = myMapper.UserMapper.CreateMapper();
            Repositories.Models.User isUserExist = mapper.Map<DTO.Models.User, Repositories.Models.User>(newUser);
            Repositories.Models.User isExist = userRepository.GetUser(isUserExist);
            DTO.Models.User user = mapper.Map< Repositories.Models.User,DTO.Models.User>(isExist);
            ;
            if (user!=null)
                return true;
            return false;
        }
        catch 
        {

        }
        return false;
    }

    public int SignIn(DTO.Models.User newUser)
    {
        throw new NotImplementedException();
    }

    /*int IServices.IUser.SignIn(DTO.Models.User newUser)
    {
        throw new NotImplementedException();
    */
}
