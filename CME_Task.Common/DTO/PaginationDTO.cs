using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Common.DTO
{
    public class PaginationDTO<T> where T : class
    {
        public int Count { get; set; }
        public IEnumerable<T> PagesList { get; set; }
    }
}
