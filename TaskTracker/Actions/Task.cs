using System.Xml;

namespace TaskTracker.Actions
{
	public class Task : Action
	{
		public Task(string text, long value) : base(text, value)
		{
		}
		
		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(Task));
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