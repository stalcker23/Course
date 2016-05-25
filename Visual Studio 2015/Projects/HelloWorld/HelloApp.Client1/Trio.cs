using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DrawWay
{
    public class Trio
    {
        public int vertex;
        public float x;
        public float y;
        public Trio(float x, float y, int vertex)
        {
            this.x = x;
            this.y = y;
            this.vertex = vertex;
        }
    }
}
