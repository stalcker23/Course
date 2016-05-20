using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloApp.Entities
{
    public class Vertex
    {
        public  Dictionary<int, List<Tuple<int, int>>> arrayWeighted { get; set; } = new Dictionary<int, List<Tuple<int, int>>>();

    }
}