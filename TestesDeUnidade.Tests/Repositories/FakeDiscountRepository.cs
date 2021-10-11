using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeUnidade.Domain.Entities;
using TestesDeUnidade.Domain.Repositories;

namespace TestesDeUnidade.Tests.Repositories
{
    class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "12345678")
                return new Discount(10, DateTime.Now.AddDays(5));

            if (code == "11111111")
                return new Discount(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}
