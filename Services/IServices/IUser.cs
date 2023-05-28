using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices;

public interface IUser
{
    /// <summary>
    /// Login function
    /// Check if user Exist
    /// </summary>
    /// <param name="name">user name</param>
    /// <param name="password">user name</param>
    /// <returns>String with two params:
    /// 1. True/ False- If the user exist
    /// 2. The user important details - If the user exist</returns>
    public string[] Login(string name, string password);
}
