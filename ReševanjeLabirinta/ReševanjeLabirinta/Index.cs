using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReševanjeLabirinta
{
    public class Index : IEquatable<Index>
    {
        public int row, column;

        public Index(int r, int c)
        {
            this.row = r;
            this.column = c;
        }

        public bool Equals(Index other)
        {
            if (other.column == this.column && other.row == this.row)
                return true;
            else
                return false;
        }
    }
}
