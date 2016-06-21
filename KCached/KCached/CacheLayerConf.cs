using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace KCached
{
	public class CacheLayerConf : ConfigurationElement
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string NamePropertyName = "name";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string MaxCountPropertyName = "maxCount";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string ExpiredTimeTypePropertyName = "expiredTimeType";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string ExpiredTimePropertyName = "expiredTime";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string UpgradeHitPropertyName = "upgradeHit";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The Name."), ConfigurationProperty("name", IsRequired = true, IsKey = true, IsDefaultCollection = false)]
		public virtual string Name
		{
			get
			{
				return (string)base["name"];
			}
			set
			{
				base["name"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The MaxCount."), ConfigurationProperty("maxCount", IsRequired = true, IsKey = false, IsDefaultCollection = false, DefaultValue = 10000)]
		public virtual int MaxCount
		{
			get
			{
				return (int)base["maxCount"];
			}
			set
			{
				base["maxCount"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The ExpiredTimeType."), ConfigurationProperty("expiredTimeType", IsRequired = true, IsKey = false, IsDefaultCollection = false, DefaultValue = "M")]
		public virtual string ExpiredTimeType
		{
			get
			{
				return (string)base["expiredTimeType"];
			}
			set
			{
				base["expiredTimeType"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The ExpiredTime."), ConfigurationProperty("expiredTime", IsRequired = true, IsKey = false, IsDefaultCollection = false, DefaultValue = 10)]
		public virtual int ExpiredTime
		{
			get
			{
				return (int)base["expiredTime"];
			}
			set
			{
				base["expiredTime"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The UpgradeHit."), ConfigurationProperty("upgradeHit", IsRequired = true, IsKey = false, IsDefaultCollection = false, DefaultValue = 5)]
		public virtual int UpgradeHit
		{
			get
			{
				return (int)base["upgradeHit"];
			}
			set
			{
				base["upgradeHit"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
