using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeUnidade.Domain.Entities;

namespace TestesDeUnidade.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}
