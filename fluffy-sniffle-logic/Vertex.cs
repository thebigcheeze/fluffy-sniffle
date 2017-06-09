using System;
using System.Collections.Generic;
using System.Text;

namespace fluffy_sniffle_logic
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }

        // inspired by https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        // GetHashCode is overridden in order to make comparisons easier to calculate.
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            var objAsVertex = obj as Vertex;
            if (objAsVertex == null)
                return false;

            return objAsVertex.GetHashCode() == this.GetHashCode();
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
