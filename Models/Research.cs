using System;

namespace ep1.Models
{
    public class Research
    {
        public int CoodX { get; set; }
        public int CoodY { get; set; }
        public int PeopleId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Research place &&
                CoodX == place.CoodX &&
                CoodY == place.CoodY &&
                PeopleId == place.PeopleId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CoodX, CoodY, PeopleId);
        }

        public bool IsValid(int value)
        {
            return value != 0;
        }
    }
}