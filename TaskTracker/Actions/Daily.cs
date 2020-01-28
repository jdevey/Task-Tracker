using System.Xml;

namespace TaskTracker.Actions
{
	public class Daily : Action
	{
		public Daily() {}
		
		public Daily(string text, long value) : base(text, value)
		{
		}

		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(Daily));
			writeTextAndValue(writer);
			writer.WriteEndElement();
		}

		public override void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement();
			readTextAndValue(reader);
			reader.ReadEndElement();
		}
	}
}