using CME_Task.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Service.IService
{
    public interface ICustomerService
    {
        Task Save(CustomerDTO customerDTO);
    }
}
