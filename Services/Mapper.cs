using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class Mapper
{
    //todo: write mappers for the transformation between repository and servieces Moudels
    public MapperConfiguration AcountConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.Acount, Repositories.Models.Acount>()
    .ReverseMap());

    public MapperConfiguration BorrowerConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.Borrower, Repositories.Models.Borrower>()
    .ReverseMap());

    public MapperConfiguration DepositConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.Deposit, Repositories.Models.Deposit>()
    .ReverseMap());

    public MapperConfiguration DepositorConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.Depositor, Repositories.Models.Depositor>()
    .ReverseMap());

    public MapperConfiguration GuarantorConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.Guarantor, Repositories.Models.Guarantor>()
    .ReverseMap());

    public MapperConfiguration LoanDetailConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<DTO.Models.LoansDetail, Repositories.Models.LoansDetail>()
    .ReverseMap());

    public MapperConfiguration UserInfoConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<Repositories.Models.User, DTO.Models.UserInfo>()
    ); 
    public MapperConfiguration UserSighInConfiguration = new MapperConfiguration(cnf =>
    cnf.CreateMap<Repositories.Models.User, Repositories.Models.User>()
    );
}
