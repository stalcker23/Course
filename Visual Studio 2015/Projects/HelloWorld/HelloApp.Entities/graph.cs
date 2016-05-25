using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GraphMatrix
    {
        public int[] pointerB; // указатели на начало списка связанных ребер
        public int[] column; // индексы связанных вершин
        public int[] value; // веса ребер
        public int sizeV; // количество вершин
        public int sizeE; // количество ребер
    }
}
