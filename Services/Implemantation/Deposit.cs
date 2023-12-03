using AutoMapper;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class Deposit : IServices.IDeposit
{
    MapperConfig myMapper = MapperConfig.Instance;
    Repositories.Implementation.Deposit reposDeposit = new Repositories.Implementation.Deposit();

    IEnumerable<DTO.Models.Deposit> IDeposit.AllUserDeposits(int userId)
    {
        try
        {
            IEnumerable<Repositories.Models.Deposit> allDeposits = reposDeposit.AllUserDeposits(userId);
            ArgumentNullException.ThrowIfNull(allDeposits);// Continue just if it is not null.
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            return  allDeposits.Select(deposit => mapper.Map<Repositories.Models.Deposit, DTO.Models.Deposit>(deposit));
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<DTO.Models.Deposit>();
            throw new Exception(ex.Message);
        }

    }

    public int AddADeposit(DTO.Models.Deposit newDeposit)
    {
        try
        {
            IMapper mapper = myMapper.DepositsMapper.CreateMapper();
            Repositories.Models.Deposit newRepoDeposit = mapper.Map<DTO.Models.Deposit, Repositories.Models.Deposit>(newDeposit);
            ArgumentNullException.ThrowIfNull(newRepoDeposit);// Continue just if it is not null.
            return reposDeposit.AddADeposit(newRepoDeposit);
        }
        catch
        {
            return -1;
        }
    }
}