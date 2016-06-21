using System;
using System.CodeDom.Compiler;
using System.Configuration;

namespace KCached
{
	[ConfigurationCollection(typeof(CacheTypeConf), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMapAlternate, AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
	public class CacheTypeConfCollection : ConfigurationElementCollection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string CacheTypeConfPropertyName = "cacheTypeConf";

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
				return "cacheTypeConf";
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheTypeConf this[int index]
		{
			get
			{
				return (CacheTypeConf)base.BaseGet(index);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheTypeConf this[object type]
		{
			get
			{
				return (CacheTypeConf)base.BaseGet(type);
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override bool IsElementName(string elementName)
		{
			return elementName == "cacheTypeConf";
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CacheTypeConf)element).Type;
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		protected override ConfigurationElement CreateNewElement()
		{
			return new CacheTypeConf();
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public void Add(CacheTypeConf cacheTypeConf)
		{
			base.BaseAdd(cacheTypeConf);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public void Remove(CacheTypeConf cacheTypeConf)
		{
			base.BaseRemove(this.GetElementKey(cacheTypeConf));
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheTypeConf GetItemAt(int index)
		{
			return (CacheTypeConf)base.BaseGet(index);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public CacheTypeConf GetItemByKey(string type)
		{
			return (CacheTypeConf)base.BaseGet(type);
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
