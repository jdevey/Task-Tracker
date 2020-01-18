using System;
using System.Collections.Generic;
using TaskTracker.Actions;

namespace TaskTracker
{
	class Program
	{
		private static char page = 'm';

		private static string joinWords(string[] words, int len)
		{
			string line = "";
			for (int i = 0; i < len; ++i)
			{
				line += words[i];
			}

			return line;
		}

		private static void createAction(UserState state, string line)
		{
			string[] words = line.Split(null);
			string actionText = joinWords(words, words.Length - (page == 'h' ? 2 : 1));
			string habitType = page == 'h' ? words[^2] : "";
			long value = long.Parse(words[^1]);
			switch (page)
			{
				case 'h':
					state.addHabit(new Habit(actionText, value, habitType[0] == 'p' ? Habit.HabitType.Positive : Habit.HabitType.Negative));
					break;
					case 'd':
						state.addDaily(new Daily(actionText, value));
						break;
					case 't':
						state.addTask(new Task(actionText, value));
					break;
					case 'r':
						state.addReward(new Reward(actionText, value));
						break;
			}
		}

		private static void eraseAction(UserState state, string line)
		{
			int num = int.Parse(line.Split(null)[1]);
			switch (page)
			{
				case 'h':
					state.removeHabit(num);
					break;
				case 'd':
					state.removeDaily(num);
					break;
				case 't':
					state.removeTask(num);
					break;
				case 'r':
					state.removeReward(num);
					break;
			}
		}

		private static void fulfillAction(UserState state, string line)
		{
			int num = int.Parse(line.Split(null)[1]);
			switch (page)
			{
				case 'h':
					state.fulfillHabit(num);
					break;
				case 'd':
					state.fulfillDaily(num);
					break;
				case 't':
					state.fulfillTask(num);
					break;
				case 'r':
					state.fulfillReward(num);
					break;
			}	
		}

		// TODO implement rest of xml serialization
		static void Main(string[] args)
		{
			Printing.printWelcome();
			
			UserState state = new UserState();

			char read = '\0';
			string line;

			while ((read = Console.ReadKey().KeyChar) != 'q')
			{
				switch (read)
				{
					case (char)13:
					case 'p':
						Printing.printControls();
						break;
					
					case 'm':
					case 'h':
					case 'd':
					case 't':
					case 'r':
						page = read;
						break;
					case 'c':
						line = Console.ReadLine();
						createAction(state, line);
						break;
					case 'e':
						line = Console.ReadLine();
						eraseAction(state, line);
						break;
					case 'f':
						line = Console.ReadLine();
						fulfillAction(state, line);
						break;
				}
			}
			
		}
	}
}
