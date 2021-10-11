using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDeUnidade.Domain.Repositories
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipCode);
    }
}
