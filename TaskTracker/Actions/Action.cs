using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TaskTracker.Actions
{
	public abstract class Action : IXmlSerializable
	{
		public string text;
		public long value;

		public Action()
		{
		}

		public Action(string text, long value)
		{
			this.text = text;
			this.value = value;
		}

		public void writeTextAndValue(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(text));
			writer.WriteString(text);
			writer.WriteEndElement();
			writer.WriteStartElement(nameof(value));
			writer.WriteValue(value);
			writer.WriteEndElement();
		}

		public void readTextAndValue(XmlReader reader)
		{
			text = reader.ReadInnerXml();
			value = long.Parse(reader.ReadInnerXml());
		}

		public abstract void WriteXml(XmlWriter writer);
		
		public abstract void ReadXml(XmlReader reader);
		
		public XmlSchema GetSchema()
		{
			return null;
		}
	}
}