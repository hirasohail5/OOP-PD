using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Ship
    {
        public string Shipnumber;
        public Angle latitude;
        public Angle longitude;
        public Ship(string Shipnumber, Angle latitude, Angle longitude)
        {
            this.Shipnumber = Shipnumber;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
