using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delivery
{
    class Delivery_point : IComparable<Delivery_point>
    {
        public int low, up, num;

        public int CompareTo(Delivery_point obj)
        {
            return up.CompareTo(obj.up);
        }
    }
}
