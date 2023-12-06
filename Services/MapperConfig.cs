﻿using AutoMapper;
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

    public MapperConfiguration GuarantorMapper = new MapperConfiguration(cnf =>
        cnf.CreateMap<DTO.Models.Guarantor, Repositories.Models.Guarantor>()
        .ForMember(dest => dest.Account, opt => opt.MapFrom(src =>
            MapperConfig.Instance.AccountMapper.CreateMapper()
            .Map<Repositories.Models.Account>(src.Account)))
    );


    public MapperConfiguration LoanDetailsMapper = new MapperConfiguration(cnf =>
        cnf.CreateMap<DTO.Models.LoanDetails, Repositories.Models.LoanDetails>()
            .ForMember(dest => dest.Guarantors, opt => opt.MapFrom(src => 
                src.Guarantors.Select(g =>
                   MapperConfig.Instance.GuarantorMapper.CreateMapper()
                   .Map<Repositories.Models.Guarantor>(g)
                ).ToList()))
            
    );

    public MapperConfiguration UserInfoMapper = new MapperConfiguration(cnf =>
        cnf.CreateMap<Users, UserInfo>()
        .ReverseMap()
    );

    public MapperConfiguration UserMapper => new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Users, DTO.Models.User>()
         .ReverseMap();
    });

    public MapperConfiguration LoginUserMapper => new MapperConfiguration(cfg =>
    {

        cfg.CreateMap<LoginUser, LogInUser>()
         .ReverseMap();
    });

    public MapperConfiguration DepositsMapper => new MapperConfiguration(cnf =>
    {
        cnf.CreateMap<Repositories.Models.Deposit, DTO.Models.Deposit>()
        .ReverseMap();
    });

    public MapperConfiguration AccountMapper => new MapperConfiguration(cnf =>
    {
        cnf.CreateMap<Repositories.Models.Account, DTO.Models.Account>()
        .ReverseMap();
    });
}
