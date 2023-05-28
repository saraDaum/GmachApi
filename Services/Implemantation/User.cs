using AutoMapper;
using DTO.Models;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implemantation;

public class User: IServices.IUser
{
    Repositories.Interfaces.IUser user = new Repositories.Implementation.User(GmachimSaraAndShaniContext);//todo: check the problem here!
    Mapper userInfo = new Mapper();
    
    public UserInfo? Login(LoginUser loginUser)
    {
        IMapper mapper = userInfo.UserInfoConfiguration.CreateMapper();
        //TODO: send to the reposetories to function that check if the user exist
        Repositories.Models.User? u = user.Login(loginUser.UserName, loginUser.Password);
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
}