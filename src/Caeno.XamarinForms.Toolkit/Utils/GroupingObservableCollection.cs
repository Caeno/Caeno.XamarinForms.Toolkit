using System;
using System.Collections.Generic;

namespace Caeno.XamarinForms.Toolkit
{

	/// <summary>
	/// An Observable Collection used to Group data.
	/// </summary>
	public class GroupingObservableCollection<K, T> : EnhancedObservableCollection<T> {

		/// <summary>
		/// Gets the Collection Key.
		/// </summary>
		public K Key  { get; private set; }

		public GroupingObservableCollection(K key, IEnumerable<T> items) {
			Key = key;
			Append(items);
		}

	}
}

