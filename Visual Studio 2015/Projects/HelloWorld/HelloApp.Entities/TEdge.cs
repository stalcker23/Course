using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class TEdge : IComparable<TEdge>
    {
        public int row;
        public int col;
        public int val;
        public TEdge(int r, int c, int v)
        {
            this.row = r;
            this.col = c;
            this.val = v;
        }

        public int CompareTo(TEdge obj)
        {
            if (this.row > obj.row)
                return 1;
            else if
                (this.row < obj.row)
                return -1;
            else return 0;

        }
       
    }

}