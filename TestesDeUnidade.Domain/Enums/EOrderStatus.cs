using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDeUnidade.Domain.Enums
{
    public enum EOrderStatus
    {
        waitingPayment = 1,
        waitingDelivery = 2,
        canceled = 3,
    }
}
