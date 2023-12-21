using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces;

public interface IGuarantor
{
    int Add(Models.Guarantor item);

    IEnumerable<Models.Guarantor> Get(Func<Models.Guarantor, bool>? func = null);
}
