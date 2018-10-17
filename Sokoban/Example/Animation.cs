using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{



    public class Animation
    {
        int[] iList = new int[0];
        int[] jList = new int[0];
        int[] timeList = new int[0];
        public int[] IList
        {
            get { return iList; }
            set { iList = value; }
        }
        public int[] JList
        {
            get { return jList; }
            set { jList = value; }
        }
        public int[] TimeList
        {
            get { return timeList; }
            set { timeList = value; }
        }



    }
}
