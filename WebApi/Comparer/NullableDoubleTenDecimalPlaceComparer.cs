using System;
using System.Collections.Generic;

namespace WebApi.Geo
{
    /// <summary>
    ///     Compares nullable doubles for equality.
    /// </summary>
    /// <remarks>
    ///     10 decimal places equates to accuracy to 11.1 μm.
    /// </remarks>
    public class NullableDoubleTenDecimalPlaceComparer : IEqualityComparer<double?>
    {
        public bool Equals(double? x, double? y)
        {
            return Math.Abs(x.GetValueOrDefault() - y.GetValueOrDefault()) < 0.0000000001;
        }

        public int GetHashCode(double? obj)
        {
            return obj.HasValue ? obj.Value.GetHashCode() : 0;
        }
    }
}
