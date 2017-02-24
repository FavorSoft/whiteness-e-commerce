using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succeeded, string message, string property)
        {
            Succeeded = succeeded;
            Message = message;
            Property = property;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Property { get; set; }
    }
}
