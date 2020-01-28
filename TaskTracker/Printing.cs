using System;
using System.Collections;
using TaskTracker.Actions;

namespace TaskTracker
{
	public static class Printing
	{
		public static string padValue(long value)
		{
			string valueString = value.ToString();
			return valueString.Length >= Constants.MAX_VALUE_WIDTH
				? valueString
				: new string(' ', Constants.MAX_VALUE_WIDTH - valueString.Length) + valueString;
		}

		public static string makeMedium(string s)
		{
			return "--- " + s + " ---";
		}

		public static string makeLarge(string s)
		{
			return "===== " + s + " =====";
		}

		public static void printList(ArrayList a)
		{
			for (int i = 0; i < a.Count; ++i)
			{
				Console.WriteLine((i + 1).ToString() + ") " + a[i].ToString());
			}
		}
		
		public static void printWelcome()
		{
			Console.WriteLine(makeLarge("Welcome to Task Tracker!"));
			Console.WriteLine();
		}

		public static void printCurrentPage(UserState state, char page)
		{
			switch (page)
			{
				case 'p':
					printControls();
					break;
				case 'm':
					printMainPage(state);
					break;
				case 'h':
					printHabitsPage(state);
					break;
				case 'd':
					printDailiesPage(state);
					break;
				case 't':
					printTasksPage(state);
					break;
				case 'r':
					printRewardsPage(state);
					break;
			}
		}

		public static void printControls()
		{
			Console.WriteLine(makeLarge("Help Page"));
			Console.WriteLine("q := QUIT program");
			Console.WriteLine("p := PRINT help page");
			Console.WriteLine("m := Go to MAIN menu");
			Console.WriteLine("h := Go to HABITS page");
			Console.WriteLine("d := Go to DAILIES page");
			Console.WriteLine("t := Go to TASKS page");
			Console.WriteLine("r := Go to REWARDS page");
			Console.WriteLine("c := CREATE new action for current page (c <action-text> <value>)");
			Console.WriteLine("e := ERASE action on current page (e <action-number>)");
			Console.WriteLine("f := FULFILL action on current page (f <action-number>)");
			Console.WriteLine();
		}
		
		public static void printMainPage(UserState state)
		{
			Console.WriteLine(makeLarge("Main Menu"));
			Console.WriteLine("Level: " + state.getLevel());
			Console.WriteLine("Experience: " + state.xp);
			Console.WriteLine("Gold: " + state.gold);
			Console.WriteLine();
		}

		public static void printHabitsPage(UserState state)
		{
			Console.WriteLine(makeLarge("Habits Page"));
			for (int i = 0; i < state.habits.Count; ++i)
			{
				Habit habit = state.habits[i];
				Console.WriteLine(i + 1 + ") " + habit.text + ": " + habit.value + " gold");
			}

			if (state.habits.Count == 0)
			{
				Console.WriteLine("You haven't added any habits yet!");
			}
			Console.WriteLine();
		}

		public static void printDailiesPage(UserState state)
		{
			Console.WriteLine(makeLarge("Dailies Page"));
			for (int i = 0; i < state.dailies.Count; ++i)
			{
				Daily daily = state.dailies[i];
				Console.WriteLine(i + 1 + ") " + daily.text + ": " + daily.value + " gold");
			}
			
			if (state.dailies.Count == 0)
			{
				Console.WriteLine("You haven't added any dailies yet!");
			}
			Console.WriteLine();
		}

		public static void printTasksPage(UserState state)
		{
			Console.WriteLine(makeLarge("Tasks Page"));
			for (int i = 0; i < state.tasks.Count; ++i)
			{
				Task task = state.tasks[i];
				Console.WriteLine(i + 1 + ") " + task.text + ": " + task.value + " gold");
			}
			
			if (state.tasks.Count == 0)
			{
				Console.WriteLine("You haven't added any tasks yet!");
			}
			Console.WriteLine();
		}
		
		public static void printRewardsPage(UserState state)
		{
			Console.WriteLine(makeLarge("Rewards Page"));
			for (int i = 0; i < state.rewards.Count; ++i)
			{
				Reward reward = state.rewards[i];
				Console.WriteLine(i + 1 + ") " + reward.text + ": " + reward.value + " gold");
			}
			
			if (state.rewards.Count == 0)
			{
				Console.WriteLine("You haven't added any rewards yet!");
			}
			Console.WriteLine();
		}
	}
}