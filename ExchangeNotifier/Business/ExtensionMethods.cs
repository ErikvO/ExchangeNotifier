using System.Collections.Generic;

namespace System.Linq
{
	/// <summary>
	/// 
	/// </summary>
	public static class Linq
	{
		/// <summary>
		/// Returns a distinct list of items in the current sequence.
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">Current sequence.</param>
		/// <param name="uniqueCheckerMethod">Selector to use to define the uniqueness of items in current sequence.</param>
		/// <returns>A IEnumerable of distinct items of the source sequence.</returns>
		public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, object> uniqueCheckerMethod)
		{
			return source.Distinct(new GenericComparer<T>(uniqueCheckerMethod));
		}

		/// <summary>
		/// Produces the set union of two sequences by using a specified System.Collections.Generic.IEqualityComparer&lt;T&gt;.
		/// </summary>
		/// <typeparam name="T">The type of the elements of both IEnumerables.</typeparam>
		/// <param name="source">An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form the first set for the union.</param>
		/// <param name="unionWith">An System.Collections.Generic.IEnumerable&lt;T&gt; whose distinct elements form the second set for the union.</param>
		/// <param name="uniqueCheckerMethod">Selector to use to define the uniqueness of items in current sequence.</param>
		/// <returns>An System.Collections.Generic.IEnumerable&lt;T&gt; that contains the elements from both input sequences, excluding duplicates.</returns>
		public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<T> unionWith, Func<T, object> uniqueCheckerMethod)
		{
			return source.Union(unionWith, new GenericComparer<T>(uniqueCheckerMethod));
		}

		/// <summary>
		/// Calls an action on each item in the IEnumerable
		/// </summary>
		/// <typeparam name="T">The type of the elements of source.</typeparam>
		/// <param name="source">>Current sequence.</param>
		/// <param name="action">Action to call on each element in source.</param>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (T item in source)
				action(item);

			return source;
		}

		/// <summary>
		///Invokes a transform function on each element of current sequence and returns the maximum resulting value or the specified emptyCollectionResult when current sequence is empty.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
		/// <param name="source">A sequence of values to determine the maximum value of.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <param name="emptyCollectionResult">The value to return when current sequence is empty.</param>
		/// <returns>The maximum value in the sequence or emptyCollectionResult when current sequence is empty.</returns>
		public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult emptyCollectionResult)
		{
			if (source.Count() > 0)
				return source.Max(selector);
			else
				return emptyCollectionResult;
		}

		/// <summary>
		/// Returns the maximal element of the given sequence, based on the given projection or the specified emptyCollectionResult when current sequence is empty.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
		/// <param name="source">Source sequence</param>
		/// <param name="selector">Selector to use to pick the results to compare</param>
		/// <param name="emptyCollectionResult">The value to return when current sequence is empty.</param>
		/// <returns>The maximal element, according to the projection or emptyCollectionResult when current sequence is empty.</returns>
		public static TSource MaxBy<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TSource emptyCollectionResult)
		{
			if (source.Count() > 0)
				return source.MaxBy(selector);
			else
				return emptyCollectionResult;
		}

		/// <summary>
		/// Returns the maximal element of the given sequence, based on the given projection.
		/// </summary>
		/// <remarks>
		/// If more than one element has the maximal projected value, the first one encountered will be returned. This overload uses the default comparer
		/// for the projected type. This operator uses immediate execution, but only buffers a single result (the current maximal element).
		/// </remarks>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TKey">Type of the projected element</typeparam>
		/// <param name="source">Source sequence</param>
		/// <param name="selector">Selector to use to pick the results to compare</param>
		/// <returns>The maximal element, according to the projection.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="selector"/> is null</exception>
		/// <exception cref="InvalidOperationException"><paramref name="source"/> is empty</exception>
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MaxBy(selector, Comparer<TKey>.Default);
		}

		/// <summary>
		/// Returns the maximal element of the given sequence, based on the given projection and the specified comparer for projected values. 
		/// </summary>
		/// <remarks>
		/// If more than one element has the maximal projected value, the first one encountered will be returned. This overload uses the default comparer
		/// for the projected type. This operator uses immediate execution, but only buffers a single result (the current maximal element).
		/// </remarks>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TKey">Type of the projected element</typeparam>
		/// <param name="source">Source sequence</param>
		/// <param name="selector">Selector to use to pick the results to compare</param>
		/// <param name="comparer">Comparer to use to compare projected values</param>
		/// <returns>The maximal element, according to the projection.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="selector"/> 
		/// or <paramref name="comparer"/> is null</exception>
		/// <exception cref="InvalidOperationException"><paramref name="source"/> is empty</exception>
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			if (selector == null)
				throw new ArgumentNullException("selector");

			if (comparer == null)
				throw new ArgumentNullException("comparer");

			using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
			{
				if (!sourceIterator.MoveNext())
					throw new InvalidOperationException("Sequence was empty");
				TSource max = sourceIterator.Current;
				TKey maxKey = selector(max);
				while (sourceIterator.MoveNext())
				{
					TSource candidate = sourceIterator.Current;
					TKey candidateProjected = selector(candidate);
					if (comparer.Compare(candidateProjected, maxKey) > 0)
					{
						max = candidate;
						maxKey = candidateProjected;
					}
				}
				return max;
			}
		}
	}

	/// <summary>
	/// Helper class for Distinct function.
	/// </summary>
	/// <typeparam name="T">The type of objects to compare.</typeparam>
	internal class GenericComparer<T> : IEqualityComparer<T>
	{
		public GenericComparer(Func<T, object> uniqueCheckerMethod)
		{
			_uniqueCheckerMethod = uniqueCheckerMethod;
		}

		private Func<T, object> _uniqueCheckerMethod;

		bool IEqualityComparer<T>.Equals(T x, T y)
		{
			return _uniqueCheckerMethod(x).Equals(_uniqueCheckerMethod(y));
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return _uniqueCheckerMethod(obj).GetHashCode();
		}
	}
}