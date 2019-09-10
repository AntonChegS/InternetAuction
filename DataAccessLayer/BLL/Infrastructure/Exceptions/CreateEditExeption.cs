using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    class CreateEditExeption:Exception
    {
        public CreateEditExeption(string message) : base(message) { }
    }
}
