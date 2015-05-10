// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeatureCollection.cs" company="Joerg Battermann">
//   Copyright © Joerg Battermann 2014
// </copyright>
// <summary>
//   Defines the FeatureCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GeoJSON.Net.Feature
{
    /// <summary>
    ///     Defines the FeatureCollection type.
    /// </summary>
    public class FeatureCollection : GeoJSONObject
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FeatureCollection" /> class.
        /// </summary>
        public FeatureCollection() : this(new List<Feature>())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FeatureCollection" /> class.
        /// </summary>
        /// <param name="features">The features.</param>
        public FeatureCollection(List<Feature> features)
        {
            if (features == null)
            {
                throw new ArgumentNullException("features");
            }

            Features = features;
            Type = GeoJSONObjectType.FeatureCollection;
        }

        /// <summary>
        ///     Gets the features.
        /// </summary>
        /// <value>The features.</value>
        [JsonProperty(PropertyName = "features", Required = Required.Always)]
        public List<Feature> Features { get; private set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((FeatureCollection)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Features != null ? Features.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(FeatureCollection left, FeatureCollection right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(FeatureCollection left, FeatureCollection right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        protected bool Equals(FeatureCollection other)
        {
            return base.Equals(other) && Features.SequenceEqual(other.Features);
        }
    }
}