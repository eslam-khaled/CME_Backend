using CME_Task.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Common.DTO
{
    public class SearchBaseDTO<T>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string SortColumn { get; set; }
        public T Filter { get; set; }
        public Enum_SortingType Sort { get; set; } = Enum_SortingType.Ascending;
    }
}
