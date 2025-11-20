// © 2025 Billy Flatman. All rights reserved.

namespace NameSorter.Core.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides extension methods for converting synchronous sequences
    /// into asynchronous streams.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts a synchronous <see cref="IEnumerable{T}"/> into an
        /// <see cref="IAsyncEnumerable{T}"/> sequence.
        /// </summary>
        /// <typeparam name="T">The element type of the sequence.</typeparam>
        /// <param name="source">
        /// The synchronous sequence to convert.
        /// </param>
        /// <returns>
        /// An asynchronous stream that yields items from the original sequence
        /// without loading additional data into memory.
        /// </returns>
        public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                yield return item;
                await Task.Yield(); // ensures it's truly asynchronous
            }
        }
    }
}
