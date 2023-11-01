using AutoMapper;
using DTO.Models;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services;


public class MapperConfig : Profile
{
    //Singelton Instance
    private MapperConfig() { }
    public static MapperConfig Instance { get; } = new MapperConfig();


    //Mapping configurations

    public MapperConfiguration LoanDetailsMapper = new MapperConfiguration(cnf =>
        cnf.CreateMap<Repositories.Models.LoanDetails, DTO.Models.LoanDetails>()
        .ReverseMap()
    );

    /* public MapperConfiguration UserMapper = new MapperConfiguration(cnf =>
         cnf.CreateMap<Repositories.Models.User, DTO.Models.User>()
         .ReverseMap()

     );*/

    public MapperConfiguration UserMapper => new MapperConfiguration(cfg => {
        cfg.CreateMap<LoginUser, LogInUser>()
         .ReverseMap();
 
        cfg.CreateMap<Repositories.Models.User, DTO.Models.User>()
         .ReverseMap(); }
        
        //CreateMap<Repositories.Models.User, DTO.Models.User>();
        //.ReverseMap()
    );
   
        //cfg.AddProfile<UserProfile>(); Was
        }