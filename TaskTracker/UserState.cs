using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TaskTracker.Actions;

namespace TaskTracker
{
	public class UserState : IXmlSerializable
	{
		public long gold { get; private set; }
		public long xp { get; private set; }

		public readonly List<Habit> habits = new List<Habit>();
		public readonly List<Daily> dailies = new List<Daily>();
		public readonly List<Task> tasks = new List<Task>();
		public readonly List<Reward> rewards = new List<Reward>();

		public void addHabit(Habit habit)
		{
			habits.Add(habit);
		}

		public void removeHabit(int pos)
		{
			if (pos >= 0 && pos < habits.Count)
			{
				habits.Remove(habits[pos]);
			}
		}

		public void fulfillHabit(int pos)
		{
			if (pos >= 0 && pos < habits.Count)
			{
				Habit habit = habits[pos];
				gold += habit.value * (habit.habitType == Habit.HabitType.Positive ? 1 : -1);
			}
		}

		public void addDaily(Daily daily)
		{
			dailies.Add(daily);
		}

		public void removeDaily(int pos)
		{
			if (pos >= 0 && pos < dailies.Count)
			{
				dailies.Remove(dailies[pos]);
			}
		}

		public void fulfillDaily(int pos)
		{
			if (pos >= 0 && pos < dailies.Count)
			{
				Daily daily = dailies[pos];
				gold += daily.value;
			}
		}

		public void addTask(Task task)
		{
			tasks.Add(task);
		}

		public void removeTask(int pos)
		{
			if (pos >= 0 && pos < tasks.Count)
			{
				tasks.Remove(tasks[pos]);
			}
		}

		public void fulfillTask(int pos)
		{
			if (pos >= 0 && pos < tasks.Count)
			{
				Task task = tasks[pos];
				gold += task.value;
			}
		}

		public void addReward(Reward reward)
		{
			rewards.Add(reward);
		}

		public void removeReward(int pos)
		{
			if (pos >= 0 && pos < rewards.Count)
			{
				rewards.Remove(rewards[pos]);
			}
		}

		public void fulfillReward(int pos)
		{
			if (pos >= 0 && pos < rewards.Count)
			{
				Reward reward = rewards[pos];
				gold += reward.value;
				removeReward(pos);
			}
		}

		private long getNextLevelAmt(long n)
		{
			return n * Constants.LEVEL_INC_NUM / Constants.LEVEL_INC_DENOM;
		}

		public long getLevel()
		{
			long levelCnt = 0;
			long basexp = Constants.XP_BASE;
			long xpTotal = basexp;
			while (xp >= xpTotal)
			{
				++levelCnt;
				basexp = getNextLevelAmt(basexp);
				xpTotal += basexp;
			}

			return levelCnt;
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("gold");
			writer.WriteValue(gold);
			writer.WriteEndElement();
			writer.WriteStartElement("xp");
			writer.WriteValue(xp);
			writer.WriteEndElement();

			writer.WriteStartElement("Habits");
			foreach (Habit habit in habits)
			{
				habit.WriteXml(writer);
			}

			writer.WriteEndElement();

			writer.WriteStartElement("Dailies");
			foreach (Daily daily in dailies)
			{
				daily.WriteXml(writer);
			}

			writer.WriteEndElement();

			writer.WriteStartElement("Tasks");
			foreach (Task task in tasks)
			{
				task.WriteXml(writer);
			}

			writer.WriteEndElement();

			writer.WriteStartElement("Rewards");
			foreach (Reward reward in rewards)
			{
				reward.WriteXml(writer);
			}

			writer.WriteEndElement();
		}

		public void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement();
			gold = long.Parse(reader.ReadInnerXml());
			xp = long.Parse(reader.ReadInnerXml());
			
			// Read habits
			bool isEmpty = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (!isEmpty)
			{
				while (reader.NodeType != XmlNodeType.EndElement)
				{
					Habit habit = new Habit();
					habit.ReadXml(reader);
					habits.Add(habit);
				}
			}

			// Read dailies
			isEmpty = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (!isEmpty)
			{
				while (reader.NodeType != XmlNodeType.EndElement)
				{
					Daily daily = new Daily();
					daily.ReadXml(reader);
					dailies.Add(daily);
				}
			}

			// Read tasks
			isEmpty = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (!isEmpty)
			{
				while (reader.NodeType != XmlNodeType.EndElement)
				{
					Task task = new Task();
					task.ReadXml(reader);
					tasks.Add(task);
				}
			}

			// Read rewards
			isEmpty = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (!isEmpty)
			{
				while (reader.NodeType != XmlNodeType.EndElement)
				{
					Reward reward = new Reward();
					reward.ReadXml(reader);
					rewards.Add(reward);
				}
			}

			reader.ReadEndElement();
			reader.ReadEndElement();
		}

		public XmlSchema GetSchema()
		{
			return null;
		}
	}
}