using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;

namespace KCached
{
	public class CacheTypeConf : ConfigurationElement
	{
		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string ExpiredTimePropertyName = "expiredTime";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string ExpiredTimeTypePropertyName = "expiredTimeType";

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		internal const string TypePropertyName = "type";

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

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"), Description("The Type."), ConfigurationProperty("type", IsRequired = true, IsKey = true, IsDefaultCollection = false)]
		public virtual string Type
		{
			get
			{
				return (string)base["type"];
			}
			set
			{
				base["type"] = value;
			}
		}

		[GeneratedCode("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
		public override bool IsReadOnly()
		{
			return false;
		}
	}
}
