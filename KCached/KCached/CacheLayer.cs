using System;
using System.Collections;
using System.Collections.Generic;

namespace KCached
{
	public class CacheLayer
	{
		private TimeSpan mTimeout;

		private int mCount;

		private Hashtable mTables;

		private LinkedList<CacheItem> mItems = new LinkedList<CacheItem>();

		public string Name
		{
			get;
			set;
		}

		public int UpgradeHit
		{
			get;
			set;
		}

		public int Count
		{
			get
			{
				return this.mItems.Count;
			}
		}

		public CacheLayer(int count, ExpiredTimeType type, int validTime, int upgradeHit)
		{
			this.mTables = new Hashtable(count);
			this.mCount = count;
			switch (type)
			{
			case ExpiredTimeType.D:
				this.mTimeout = new TimeSpan(validTime, 0, 0, 0);
				break;
			case ExpiredTimeType.H:
				this.mTimeout = new TimeSpan(validTime, 0, 0);
				break;
			case ExpiredTimeType.M:
				this.mTimeout = new TimeSpan(0, validTime, 0);
				break;
			default:
				this.mTimeout = new TimeSpan(1, 0, 0, 0);
				break;
			}
			this.UpgradeHit = upgradeHit;
		}

		internal CacheItem Set(string key, object value)
		{
			CacheItem value2;
			lock (this)
			{
				LinkedListNode<CacheItem> linkedListNode = (LinkedListNode<CacheItem>)this.mTables[key];
				if (linkedListNode == null)
				{
					if (this.mTables.Count >= this.mCount)
					{
						LinkedListNode<CacheItem> last = this.mItems.Last;
						this.mItems.Remove(last);
						this.mTables.Remove(last.Value.Key);
					}
					linkedListNode = new LinkedListNode<CacheItem>(new CacheItem());
					linkedListNode.Value.Value = value;
					linkedListNode.Value.Key = key;
					linkedListNode.Value.CreateTime = DateTime.Now;
					linkedListNode.Value.Hit = 0;
					this.mTables.Add(key, linkedListNode);
					this.mItems.AddFirst(linkedListNode);
					value2 = linkedListNode.Value;
				}
				else
				{
					linkedListNode.Value.Value = value;
					value2 = linkedListNode.Value;
				}
			}
			return value2;
		}

		internal bool Delete(string key)
		{
			bool result;
			lock (this)
			{
				LinkedListNode<CacheItem> linkedListNode = (LinkedListNode<CacheItem>)this.mTables[key];
				if (linkedListNode != null)
				{
					this.mTables.Remove(key);
					this.mItems.Remove(linkedListNode);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		internal bool Delete(CacheItem item)
		{
			return this.Delete(item.Key);
		}

		internal CacheItem Get(string key)
		{
			LinkedListNode<CacheItem> linkedListNode = (LinkedListNode<CacheItem>)this.mTables[key];
			if (linkedListNode != null)
			{
				linkedListNode.Value.Hit++;
				linkedListNode.Value.HitTime = DateTime.Now;
				lock (this)
				{
					if (linkedListNode.List == this.mItems)
					{
						if (linkedListNode.Value.Hit > this.UpgradeHit)
						{
							this.Delete(key);
						}
						else
						{
							this.mItems.Remove(linkedListNode);
							this.mItems.AddFirst(linkedListNode);
						}
					}
				}
				return linkedListNode.Value;
			}
			return null;
		}

		internal void Detect()
		{
			lock (this)
			{
				DateTime now = DateTime.Now;
				LinkedListNode<CacheItem> last = this.mItems.Last;
				while (last != null && now - last.Value.HitTime > this.mTimeout)
				{
					this.Delete(last.Value.Key);
					last = this.mItems.Last;
				}
			}
		}

		internal void Clear()
		{
			lock (this)
			{
				this.mTables.Clear();
				this.mItems.Clear();
			}
		}
	}
}
