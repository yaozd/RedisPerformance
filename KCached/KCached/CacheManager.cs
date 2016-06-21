using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace KCached
{
	public class CacheManager
	{
		private Timer mDetectTime;

		private IList<CacheLayer> mLayers = new List<CacheLayer>();

		private Hashtable mCacheType = new Hashtable();

		public IList<CacheLayer> Layers
		{
			get
			{
				return this.mLayers;
			}
		}

		public CacheManager(string section)
		{
			CacheSection cacheSection = (CacheSection)ConfigurationManager.GetSection(section);
			foreach (CacheLayerConf cacheLayerConf in cacheSection.CacheLayers)
			{
				CacheLayer cacheLayer = new CacheLayer(cacheLayerConf.MaxCount, (ExpiredTimeType)Enum.Parse(typeof(ExpiredTimeType), cacheLayerConf.ExpiredTimeType), cacheLayerConf.ExpiredTime, cacheLayerConf.UpgradeHit);
				cacheLayer.Name = cacheLayerConf.Name;
				this.mLayers.Add(cacheLayer);
			}
			if (cacheSection.CacheTypes != null)
			{
				foreach (CacheTypeConf cacheTypeConf in cacheSection.CacheTypes)
				{
					CacheType cacheType = new CacheType((ExpiredTimeType)Enum.Parse(typeof(ExpiredTimeType), cacheTypeConf.ExpiredTimeType), cacheTypeConf.ExpiredTime);
					this.mCacheType.Add(Type.GetType(cacheTypeConf.Type), cacheType);
					cacheType.Remove = new Action<IList<string>>(this.OnRemove);
				}
			}
			this.mDetectTime = new Timer(new TimerCallback(this.OnDetect), null, 60000, 60000);
		}

		private void OnDetect(object state)
		{
			foreach (CacheLayer current in this.mLayers)
			{
				current.Detect();
			}
			foreach (CacheType cacheType in this.mCacheType.Values)
			{
				cacheType.Detect();
			}
		}

		private void OnRemove(IList<string> keys)
		{
			foreach (string current in keys)
			{
				this.Delete(current);
			}
		}

		public void Set(string key, object value)
		{
			lock (this)
			{
				CacheItem cacheItem;
				for (int i = 0; i < this.mLayers.Count; i++)
				{
					CacheLayer cacheLayer = this.mLayers[i];
					cacheItem = cacheLayer.Get(key);
					if (cacheItem != null)
					{
						cacheLayer.Set(key, value);
						return;
					}
				}
				cacheItem = this.mLayers[this.mLayers.Count - 1].Set(key, value);
				if (cacheItem != null)
				{
					Type type = value.GetType();
					CacheType cacheType = (CacheType)this.mCacheType[type];
					if (cacheType != null)
					{
						cacheType.Add(key);
					}
				}
			}
		}

		public object Get(string key)
		{
			for (int i = 0; i < this.mLayers.Count; i++)
			{
				CacheLayer cacheLayer = this.mLayers[i];
				CacheItem cacheItem = cacheLayer.Get(key);
				if (cacheItem != null)
				{
					CacheType cacheType = (CacheType)this.mCacheType[cacheItem.Value.GetType()];
					if ((cacheType == null || cacheType.Get(key)) && i > 0 && cacheItem.Hit > cacheLayer.UpgradeHit)
					{
						this.mLayers[i - 1].Set(key, cacheItem.Value);
					}
					return cacheItem.Value;
				}
			}
			return null;
		}

		public T Get<T>(string key)
		{
			return (T)((object)this.Get(key));
		}

		public void Delete(params string[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				this.Delete(keys[i]);
			}
		}

		public void Delete(string key)
		{
			for (int i = 0; i < this.mLayers.Count; i++)
			{
				if (this.mLayers[i].Delete(key))
				{
					return;
				}
			}
		}
	}
}
