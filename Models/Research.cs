using System;
using System.Collections.Generic;

namespace ep1.Models
{
    public class Research
    {
        public string CoodX { get; set; }
        public string CoodY { get; set; }
        public HashSet<ulong> Users { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Research place &&
                CoodX.Equals(place.CoodX) &&
                CoodY.Equals(place.CoodY);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CoodX, CoodY);
        }
    }
}