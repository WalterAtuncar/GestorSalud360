using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class FilterParams : PaginationParams
    {
        public string filter { get; set; } = string.Empty;
    }
}
