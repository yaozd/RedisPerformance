using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace KCached
{
	public class CacheSection : ConfigurationSection
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string CacheSectionSectionName = "cacheSection";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string XmlnsPropertyName = "xmlns";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string CacheLayersPropertyName = "cacheLayers";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string CacheTypesPropertyName = "cacheTypes";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public static CacheSection Instance
		{
			get
			{
				return (CacheSection)ConfigurationManager.GetSection("cacheSection");
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), ConfigurationProperty("xmlns", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public string Xmlns
		{
			get
			{
				return (string)base["xmlns"];
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The CacheLayers."), ConfigurationProperty("cacheLayers", IsRequired = true, IsKey = false, IsDefaultCollection = false)]
		public virtual CacheLayerConfCollection CacheLayers
		{
			get
			{
				return (CacheLayerConfCollection)base["cacheLayers"];
			}
			set
			{
				base["cacheLayers"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The CacheTypes."), ConfigurationProperty("cacheTypes", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
		public virtual CacheTypeConfCollection CacheTypes
		{
			get
			{
				return (CacheTypeConfCollection)base["cacheTypes"];
			}
			set
			{
				base["cacheTypes"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
