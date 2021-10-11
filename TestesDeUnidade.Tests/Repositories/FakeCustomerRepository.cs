using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeUnidade.Domain.Entities;
using TestesDeUnidade.Domain.Repositories;

namespace TestesDeUnidade.Tests.Repositories
{
    class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("Bruce Waynde", "batman@dc.com");

            return null;
        }
    }
}
