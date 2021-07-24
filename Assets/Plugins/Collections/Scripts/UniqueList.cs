using System.Collections.Generic;

namespace Z.Collections
{
	public class UniqueList<T>
	{
		private readonly HashSet<T> _set = new HashSet<T> ();
		private readonly List<T> _list = new List<T> (10);

		public T this [int index] => _list [index];
		public int Count => _list.Count;

		public void Add (T item)
		{
			if (_set.Add (item))
				_list.Add (item);
		}

		public void Remove (T actionableObj)
		{
			if (_set.Remove (actionableObj))
				_list.Remove (actionableObj);
		}
	}
}
