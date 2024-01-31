using DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GmachApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuarantorController : ControllerBase
{
    internal Services.IServices.IGuarantor servGuarantor = new Services.Implemantation.Guarantor();

    // GET: api/<GuarantorController>
    [HttpGet("GelAll")]
    [Authorize(Policy = "AdminOnly")]
    public List<Guarantor> GetAll()
    {
        try
        {
            return servGuarantor.GetAll();
        }
        catch (Exception ex)
        {
            return new List<Guarantor>();
        }
    }

    // GET: api/<GuarantorController>
    [HttpGet("GetLoanGuarantors")]
    public IEnumerable<Guarantor> GetLoanGuarantors(int loanId) 
    {
        try
        {
            return servGuarantor.GetGuarantorsByLoadId(loanId);
        }
        catch (Exception ex)
        {
            return new List<Guarantor>();
        }
    }

}
