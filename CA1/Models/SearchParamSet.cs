using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA1
{
    public class SearchParamSet
    {
        public IOrderedQueryable query { get; set; }
        public string searchTerm { set; get; }
        public string sortBy { set; get; }
    }
}