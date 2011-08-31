//-----------------------------------------------------------------------
// <copyright file="LambdaComparer.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Comparer with lambda expression
    /// </summary>
    /// <typeparam name="T">Object type to compare</typeparam>
    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Whatever
        /// </summary>
        private readonly Func<T, T, bool> _lambdaComparer;
        
        /// <summary>
        /// whatever
        /// </summary>
        private readonly Func<T, int> _lambdaHash;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lambdaComparer">Lambda Expression</param>
        public LambdaComparer(Func<T, T, bool> lambdaComparer) :
            this(lambdaComparer, o => 0)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lambdaComparer">Lambda expression</param>
        /// <param name="lambdaHash">i don't know</param>
        public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
        {
            if (lambdaComparer == null)
            {
                throw new ArgumentNullException("lambdaComparer");
            }

            if (lambdaHash == null)
            {
                throw new ArgumentNullException("lambdaHash");
            }

            _lambdaComparer = lambdaComparer;
            _lambdaHash = lambdaHash;
        }

        /// <summary>
        /// Used to implement Equility comparer i suppose
        /// </summary>
        /// <param name="x">first object</param>
        /// <param name="y">second object</param>
        /// <returns>True if equals</returns>
        public bool Equals(T x, T y)
        {
            return _lambdaComparer(x, y);
        }

        /// <summary>
        /// Used to implement Equility comparer i suppose
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>integer</returns>
        public int GetHashCode(T obj)
        {
            return _lambdaHash(obj);
        }
    }
}
