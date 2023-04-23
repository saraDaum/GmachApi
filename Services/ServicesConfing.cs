using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServicesConfig
    {
        public static void AddBLServices(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(Repositories.Interfaces.IUserRepository), typeof(Repositories.UserRepository));
            collection.AddDbContext<Repositories.Models.FullStackMoreshetdbContext>();
        }
    }
}

