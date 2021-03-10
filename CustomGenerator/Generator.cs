using System;
using System.IO;
using System.Xml;

namespace CustomGenerator
{
	public class Generator
	{
		//TODO: use Path
		string domainPath = @"W:\CustomGenerator\CustomGenerator\Domain";
		public void GenerateCustom()
		{
			string xmlFileName = "DomainScheme.xml";
			string dir = @"W:\CustomGenerator\CustomGenerator"; //Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

			string xmlPath = Path.Combine(dir, xmlFileName);
			XmlDocument doc = new XmlDocument();

			doc.Load(xmlPath);

			foreach (XmlNode domain in doc.ChildNodes[0].ChildNodes)
			{
				string domainKey = string.Empty;
				string domainData = string.Empty;

				foreach (XmlNode prop in domain.ChildNodes)
				{
					var propertyType = prop.SelectSingleNode("Type").InnerText;
					var propertyName = prop.SelectSingleNode("Name").InnerText;

					if(propertyName == "Id")
					{
						domainKey = $"{propertyType} {propertyName}" + " { get; }";
						continue;
					}
					else
					{
						domainData += $"{propertyType} {propertyName}" + " {get;}\n";
					}
				}

				string domainName = domain.Attributes["Name"].InnerText;
				var domainClass = GetDomainClass(domainName, domainKey, domainData);

				CreateDomainInterface(domainClass, domainName);
			}
		}

		private string GetDomainClass(string name, string key, string data)
		{
			var res = Properties.Resources.DomainInterface;

			res = res.Replace("DomainName", name);
			res = res.Replace("DomainData", data);
			res = res.Replace("DomainKey", key);

			return res;
		}

		private void CreateDomainInterface(string domainBody, string domainName)
		{
			try
			{
				var fullPath = $"{domainPath}\\{domainName}.cs";
				using (StreamWriter sw = new StreamWriter(fullPath, false, System.Text.Encoding.Default))
				{
					sw.WriteLine(domainBody);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}	
}
