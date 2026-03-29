using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{

    public class GeoLocation
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        //Konstruktorn för GeoLocation klassen
        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // Override GetHashCode för kunna använda  latitude och longitude för hashtabelen
        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        // Override Equals för kunna jämföra latitude och longitude 
        public override bool Equals(object obj)
        {
            if (obj is GeoLocation other)
            {
                return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
            }
            return false;
        }       

    }
}
