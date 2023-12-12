using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class Guarantor : IServices.IGuarantor
{
    MapperConfig GuarantorAutoMapper = MapperConfig.Instance;
    Repositories.Interfaces.IGuarantor RepoGuarantor { get; set; } = new Repositories.Implementation.Guarantor();
    public int AddNewGuarantor(DTO.Models.Guarantor guarantor)
    {
        try
        {
            //check if the loanId belong to a real loan
            LoanDetails loanDetails = new LoanDetails();
            if (!loanDetails.IsLoanExist(guarantor.LoanId))
            {
                return -1;
            }

            IMapper mapper = GuarantorAutoMapper.GuarantorMapper.CreateMapper();
            Repositories.Models.Guarantor ModelsRepoGuarantor = mapper.Map<Repositories.Models.Guarantor>(guarantor);

            return RepoGuarantor.Add(ModelsRepoGuarantor);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return -1;
        }


    }

    public IEnumerable<DTO.Models.Guarantor> GetGuarantorsByLoadId(int loanId)
    {
        throw new NotImplementedException();
    }

    public int GetLoanByGuarantorId(int guarantorId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> GetLoansByGuarantorIdentityNumber(string guarantorIdentityNumber)
    {
        throw new NotImplementedException();
    }
}
