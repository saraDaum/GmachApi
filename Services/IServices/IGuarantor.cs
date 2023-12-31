using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IGuarantor
{
    int AddNewGuarantor(DTO.Models.Guarantor guarantor);

    IEnumerable<int> GetLoansByGuarantorIdentityNumber(string guarantorIdentityNumber);

    int GetLoanByGuarantorId(int guarantorId);

    IEnumerable<DTO.Models.Guarantor> GetGuarantorsByLoadId(int loanId);
    List<Guarantor> GetAll();


}

