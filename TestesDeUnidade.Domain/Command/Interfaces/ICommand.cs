using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDeUnidade.Domain.Command.Interfaces
{
    public interface ICommand
    {
        void Validate();
    }
}
