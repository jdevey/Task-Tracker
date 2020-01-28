using System.Xml;

namespace TaskTracker.Actions
{
	public class Reward : Action
	{
		public Reward()
		{
		}

		public Reward(string text, long value) : base(text, value)
		{
		}
		
		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(Reward));
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