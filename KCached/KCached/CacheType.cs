using System;
using System.Collections;
using System.Collections.Generic;

namespace KCached
{
	public class CacheType
	{
		public class CacheTypeItem
		{
			public string Key
			{
				get;
				set;
			}

			public DateTime CreatTime
			{
				get;
				set;
			}
		}

		private TimeSpan mTimeout;

		private int mCount;

		private Hashtable mTables;

		private LinkedList<CacheType.CacheTypeItem> mItems = new LinkedList<CacheType.CacheTypeItem>();

		public Action<IList<string>> Remove;

		public CacheType(ExpiredTimeType type, int validTime)
		{
			this.mTables = new Hashtable(50000);
			switch (type)
			{
			case ExpiredTimeType.D:
				this.mTimeout = new TimeSpan(validTime, 0, 0, 0);
				return;
			case ExpiredTimeType.H:
				this.mTimeout = new TimeSpan(validTime, 0, 0);
				return;
			case ExpiredTimeType.M:
				this.mTimeout = new TimeSpan(0, validTime, 0);
				return;
			default:
				this.mTimeout = new TimeSpan(1, 0, 0, 0);
				return;
			}
		}

		public bool Get(string key)
		{
			bool result;
			lock (this)
			{
				LinkedListNode<CacheType.CacheTypeItem> linkedListNode = (LinkedListNode<CacheType.CacheTypeItem>)this.mTables[key];
				result = (linkedListNode != null);
			}
			return result;
		}

		public void Add(string key)
		{
			lock (this)
			{
				if ((LinkedListNode<CacheType.CacheTypeItem>)this.mTables[key] == null)
				{
					LinkedListNode<CacheType.CacheTypeItem> linkedListNode = new LinkedListNode<CacheType.CacheTypeItem>(new CacheType.CacheTypeItem());
					linkedListNode.Value.CreatTime = DateTime.Now;
					linkedListNode.Value.Key = key;
					this.mTables.Add(key, linkedListNode);
					this.mItems.AddFirst(linkedListNode);
				}
			}
		}

		public void Delete(string key)
		{
			lock (this)
			{
				LinkedListNode<CacheType.CacheTypeItem> linkedListNode = (LinkedListNode<CacheType.CacheTypeItem>)this.mTables[key];
				if (linkedListNode != null)
				{
					this.mTables.Remove(key);
					this.mItems.Remove(linkedListNode);
				}
			}
		}

		internal void Detect()
		{
			IList<string> list = new List<string>();
			lock (this)
			{
				DateTime now = DateTime.Now;
				LinkedListNode<CacheType.CacheTypeItem> last = this.mItems.Last;
				while (last != null && now - last.Value.CreatTime > this.mTimeout)
				{
					this.Delete(last.Value.Key);
					list.Add(last.Value.Key);
					last = this.mItems.Last;
				}
			}
			if (this.Remove != null && list.Count > 0)
			{
				this.Remove(list);
			}
		}

		public void Clear()
		{
			lock (this)
			{
				this.mTables.Clear();
				this.mItems.Clear();
			}
		}
	}
}
