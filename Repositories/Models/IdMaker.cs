using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories.Models;

public static class IdMaker
{
    public static int getNextId()
    {
        XElement id = XElement.Load("ID.xml");
        int i = int.Parse(id.Value);
        i++;
        id.Value = i.ToString();
        id.Save("ID");

        return i;
      
    }

   

}
