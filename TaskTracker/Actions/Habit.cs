using System;
using System.Xml;

namespace TaskTracker.Actions
{
	// TODO add streaks?
	public class Habit : Action
	{
		public enum HabitType
		{
			Positive,
			Negative
		}
		
		public HabitType habitType;

		public Habit(string text, long value, HabitType habitType) : base(text, value)
		{
			this.habitType = habitType;
		}
		
		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(Habit));
			writeTextAndValue(writer);
			writer.WriteStartElement(nameof(habitType));
			writer.WriteString(habitType.ToString());
			writer.WriteEndElement();
			writer.WriteEndElement();
		}

		public override void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement();
			readTextAndValue(reader);
			habitType = Enum.Parse <HabitType>(reader.ReadInnerXml());
			reader.ReadEndElement();
		}
	}
}