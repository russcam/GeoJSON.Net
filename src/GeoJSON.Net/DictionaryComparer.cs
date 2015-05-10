using System.Collections.Generic;

namespace GeoJSON.Net
{
    /// <summary>
    /// Compares dictionaries for equality by having the same keys and values
    /// </summary>
    public class DictionaryComparer: IEqualityComparer<Dictionary<string, object>>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first dictionary to compare.</param>
        /// <param name="y">The second dictionary  to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(Dictionary<string, object> x, Dictionary<string, object> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }

            foreach (var kvp in x)
            {
                object otherValue;

                if (!y.TryGetValue(kvp.Key, out otherValue))
                {   
                    return false; 
                }

                if (!Equals(kvp.Value, otherValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(Dictionary<string, object> obj)
        {
            return obj.GetHashCode();
        }
    }
}