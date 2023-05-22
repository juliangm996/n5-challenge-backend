using Microsoft.EntityFrameworkCore;
using N5.Challenge.Api.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Challenge.Test
{
    public class BaseTest
    {
        protected DataContext BuildContext(string dbName)
        {

            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(dbName).Options;

            DataContext dbContext = new DataContext(options);
            return dbContext;
        }
    }
}
