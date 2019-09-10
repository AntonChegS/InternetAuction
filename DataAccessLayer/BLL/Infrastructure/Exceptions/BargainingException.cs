using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Exceptions
{
    public class BargainingException: Exception
    {
        public BargainingException(string message): base(message){ }
    }
}
