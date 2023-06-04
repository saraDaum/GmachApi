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
    public MapperConfig()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Repositories.Models.User, DTO.Models.User>()
        .ReverseMap();

       

    }
}