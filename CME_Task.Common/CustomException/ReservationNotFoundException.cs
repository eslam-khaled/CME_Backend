using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Common.CustomException
{
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException(string message) : base(message)
        {
        }
    }

}
