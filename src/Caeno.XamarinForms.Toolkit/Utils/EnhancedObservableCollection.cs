using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Caeno.XamarinForms.Toolkit
{

    /// <summary>
    /// An Observable Collection with added operations.
    /// </summary>
    public class EnhancedObservableCollection<T> : ObservableCollection<T> {

        #region Constructors

        public EnhancedObservableCollection() 
            : base() {}

        public EnhancedObservableCollection(IEnumerable<T> collection) 
            : base(collection) {}

        #endregion

        public void Append(IEnumerable<T> range)
        {
			if (range == null)
				return;

            var startIndex = Items.Count;
            foreach (var item in range) {
                Items.Add(item);
            }

			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void ClearAndAppend(IEnumerable<T> range)
        {
            Items.Clear();
            Append(range);
        }

    }
}

