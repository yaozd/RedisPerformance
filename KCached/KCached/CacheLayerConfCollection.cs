using System;
using System.CodeDom.Compiler;
using System.Configuration;

namespace KCached
{
	[ConfigurationCollection(typeof(CacheLayerConf), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMapAlternate, AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
	public class CacheLayerConfCollection : ConfigurationElementCollection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string CacheLayerConfPropertyName = "cacheLayerConf";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.AddRemoveClearMapAlternate;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override string ElementName
		{
			get
			{
				return "cacheLayerConf";
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheLayerConf this[int index]
		{
			get
			{
				return (CacheLayerConf)base.BaseGet(index);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheLayerConf this[object name]
		{
			get
			{
				return (CacheLayerConf)base.BaseGet(name);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override bool IsElementName(string elementName)
		{
			return elementName == "cacheLayerConf";
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CacheLayerConf)element).Name;
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override ConfigurationElement CreateNewElement()
		{
			return new CacheLayerConf();
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public void Add(CacheLayerConf cacheLayerConf)
		{
			base.BaseAdd(cacheLayerConf);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public void Remove(CacheLayerConf cacheLayerConf)
		{
			base.BaseRemove(this.GetElementKey(cacheLayerConf));
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheLayerConf GetItemAt(int index)
		{
			return (CacheLayerConf)base.BaseGet(index);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheLayerConf GetItemByKey(string name)
		{
			return (CacheLayerConf)base.BaseGet(name);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
