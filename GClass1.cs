using System;
using System.IO;
using System.Text;
using System.Xml;
using FearCheat;

public static class GClass1
{
	public static void smethod_0()
	{
		if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat"))
		{
			Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat");
		}
		string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat/Config";
		if (File.Exists(path))
		{
			return;
		}
		using StreamWriter streamWriter = new StreamWriter(path);
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
		{
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Settings");
			xmlWriter.WriteAttributeString("Key", string.Empty);
			xmlWriter.WriteAttributeString("Expires", string.Empty);
			xmlWriter.WriteAttributeString("UpdateHash", string.Empty);
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}
		streamWriter.Write(GClass0.smethod_0(stringBuilder.ToString()));
		streamWriter.Close();
	}

	public static string smethod_1(SettingsAttribute settingsAttribute_0)
	{
		string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat/Config";
		if (!File.Exists(path))
		{
			smethod_0();
		}
		using StreamReader streamReader = new StreamReader(path);
		string value = new XmlDocument
		{
			InnerXml = GClass0.smethod_0(streamReader.ReadToEnd())
		}.GetElementsByTagName("Settings")[0].Attributes[settingsAttribute_0.ToString()].Value;
		streamReader.Close();
		return value;
	}

	public static void smethod_2(SettingsAttribute settingsAttribute_0, string string_0)
	{
		string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat/Config";
		if (!File.Exists(path))
		{
			smethod_0();
		}
		XmlDocument xmlDocument = new XmlDocument();
		using (StreamReader streamReader = new StreamReader(path))
		{
			xmlDocument.InnerXml = GClass0.smethod_0(streamReader.ReadToEnd());
			xmlDocument.GetElementsByTagName("Settings")[0].Attributes[settingsAttribute_0.ToString()].Value = string_0;
			streamReader.Close();
		}
		using StreamWriter streamWriter = new StreamWriter(path);
		string value = GClass0.smethod_0(xmlDocument.InnerXml);
		streamWriter.Write(value);
		streamWriter.Close();
	}

	public static void smethod_3()
	{
		smethod_1(SettingsAttribute.Key);
		smethod_1(SettingsAttribute.Expires);
		smethod_1(SettingsAttribute.UpdateHash);
	}

	public static void smethod_4()
	{
		File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FearCheat/Config");
		smethod_0();
	}
}
