using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TaskTracker.Actions;

namespace TaskTracker
{
	public class UserState : IXmlSerializable
	{
		public long gold { get; set; } = 0;
		public long exp { get; set; } = 0;

		public ArrayList habits = new ArrayList ();
		public ArrayList dailies = new ArrayList ();
		public ArrayList tasks = new ArrayList ();
		public ArrayList rewards = new ArrayList ();
		
		public UserState()
		{
			
		}

		public void addHabit(Habit habit)
		{
			habits.Add(habit);
		}

		public void removeHabit(int pos)
		{
			if (pos < 0 || pos >= habits.Count)
			{
				return;
			}
			habits.Remove(habits[pos]);
		}

		public void fulfillHabit(int pos)
		{
			if (pos < 0 || pos >= habits.Count)
			{
				return;
			}

			Habit habit = (habits[pos] as Habit);
			gold += habit.value * (habit.habitType == Habit.HabitType.Positive ? 1 : -1);
		}
		
		public void addDaily(Daily daily)
		{
			dailies.Add(daily);
		}

		public void removeDaily(int pos)
		{
			if (pos < 0 || pos >= dailies.Count)
			{
				return;
			}
			dailies.Remove(dailies[pos]);
		}

		public void fulfillDaily(int pos)
		{
			if (pos < 0 || pos >= dailies.Count)
			{
				return;
			}

			Daily daily = dailies[pos] as Daily;
			gold += daily.value;
		}
		
		public void addTask(Task task)
		{
			tasks.Add(task);
		}

		public void removeTask(int pos)
		{
			if (pos < 0 || pos >= tasks.Count)
			{
				return;
			}
			tasks.Remove(tasks[pos]);
		}

		public void fulfillTask(int pos)
		{
			if (pos < 0 || pos >= tasks.Count)
			{
				return;
			}
			Task task = tasks[pos] as Task;
			gold += task.value;
		}
		
		public void addReward(Reward reward)
		{
			rewards.Add(reward);
		}

		public void removeReward(int pos)
		{
			if (pos < 0 || pos >= rewards.Count)
			{
				return;
			}
			rewards.Remove(rewards[pos]);
		}

		public void fulfillReward(int pos)
		{
			if (pos < 0 || pos >= rewards.Count)
			{
				return;
			}

			Reward reward = rewards[pos] as Reward;
			gold += reward.value;
			removeReward(pos);
		}

		private long getNextLevelAmt(long n)
		{
			return n * Constants.LEVEL_INC_NUM / Constants.LEVEL_INC_DENOM;
		}

		public long getLevel()
		{
			long levelCnt = 0;
			long baseExp = Constants.EXP_BASE;
			long expTotal = baseExp;
			while (exp >= expTotal)
			{
				++levelCnt;
				baseExp = getNextLevelAmt(baseExp);
				expTotal += baseExp;
			}

			return levelCnt;
		}

		public void WriteXml(XmlWriter writer)
		{
			// TODO
		}

		public void ReadXml(XmlReader reader)
		{
			// TODO
		}
		
		public XmlSchema GetSchema()
		{
			return null;
		}
	}
}