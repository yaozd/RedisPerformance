using System;

namespace KCached
{
	internal class CacheItem
	{
		public string Key
		{
			get;
			set;
		}

		public object Value
		{
			get;
			set;
		}

		public DateTime CreateTime
		{
			get;
			set;
		}

		public int Hit
		{
			get;
			set;
		}

		public DateTime HitTime
		{
			get;
			set;
		}
	}
}
