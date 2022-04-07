using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyCSharp
{
    public class IndexPath
    {
        private int section;
        private int row;

        public IndexPath(int section, int row)
        {
            this.section = section;
            this.row = row;
        }
        public int Section
        {
            get
            {
                return section;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
        }
    }
}
