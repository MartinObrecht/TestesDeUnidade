using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeUnidade.Domain.Entities;
using TestesDeUnidade.Domain.Repositories;

namespace TestesDeUnidade.Tests.Repositories
{
    class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
        
        }
    }
}
