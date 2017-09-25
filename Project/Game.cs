using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
	public class Game : IGame
	{
		public Room CurrentRoom { get; set; }
		public Player CurrentPlayer { get; set; }

		//print out game title and overview
		public void StartGame()
		{
			GameTitle();
			Setup();
			Choice();
		}
		public void Setup()
		{
			//Creates Game Rooms
			var room1 = new Room("Hallway", "You find yourself in a small hall there doesnt appear to be anything of interest here. You see a passage to the 'West'");
			var room2 = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about. You see a passage to the West or you can go back to East to the Hallway");
			var room3 = new Room("Castle Courtyard", "You step into the large castle courtyard there is a flowing fountain in the middle of the grounds and a few guards patrolling the area. You see a passage to the West or you can go back to East to the Barracks");
			var room4 = new Room("Captains Quarters", "As you approach the captains Quarters you swallow hard and notice your lips are dry, Stepping into the room you see a few small tables and maps of the countryside sprawled out. You can go back to East to the Hallway");

			//Add Exits to the rooms
			room1.Exits.Add("E", room2);
			room2.Exits.Add("W", room1);
			room2.Exits.Add("E", room3);
			room3.Exits.Add("W", room2);
			room3.Exits.Add("E", room4);
			room4.Exits.Add("W", room3);

			//Creates Players
			var player1 = new Player("Super Josh", "The Ultimate Player");
			var player2 = new Player("Regular Josh", "Just a regular guy");

			player1.Players.Add("Super Josh", player1);
			player2.Players.Add("Regular Josh", player2);

			//Creates Items
			var item1 = new Item();


			CurrentPlayer = player1;
			System.Console.WriteLine("You are playing as " + CurrentPlayer.Name);
			System.Console.WriteLine();
			CurrentRoom = room1;
			System.Console.WriteLine("You are currently in the " + CurrentRoom.Name + "\nDescription: " + CurrentRoom.Description);
		}

		public void EndGame()
		{
			//end of game text
			Console.WriteLine("You have died, the rebellion has failed.");
			System.Console.WriteLine("Press 'Q' to quit the game");
			string input = Console.ReadLine().ToUpper();
			if (input == "Q")
			{
				Environment.Exit(0);
			}
			else
			{
				Choice();
			}
		}
		void Choice()
		{
			System.Console.WriteLine("Which will you choose? E or W?");
			System.Console.WriteLine();
			System.Console.WriteLine("Enter 'H' for the help menu");
			System.Console.WriteLine();
			System.Console.WriteLine("Enter 'Q' to quit the game");
			System.Console.WriteLine();
			System.Console.Write("What is your Choice?: ");
			var input = Console.ReadLine().ToUpper();
			if (input == "E" || input == "W")
			{
				if (CurrentRoom.Exits.ContainsKey(input))
				{
					CurrentRoom = CurrentRoom.Exits[input];
					System.Console.WriteLine(CurrentRoom.Name + ": " + CurrentRoom.Description);
					Choice();
				}
				else
				{
					EndGame();
				}
			}
			else if (input == "H")
			{
				Help();
				System.Console.WriteLine("Press enter to exit menu");
				Console.ReadKey();
				Choice();
			}
			else if (input == "Q")
			{
				EndGame();
			}
		}
		static void GameTitle()
		{
			string Title = @"Castle Grimtol";
			Console.Title = Title;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(Title);
			Console.ResetColor();
			Console.WriteLine("Press enter to start");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("Welcome to Castle Grimtol! \n");
			Console.WriteLine("Brave Young Warrior our forces are failing and the enemy grows stronger everyday.I fear if we don't act now our people will be driven from their homes. These dark times have left us with one final course of action. We must cut the head off of the snake by assasinating the Dark Lord of Grimtol... Our sources have identified a small tunnel that leads into the rear of the castle.\n\n" +
			"Once you `sneak` through the tunnel you will need to find a way to disguise yourself and kill the Dark Lord. We don't know exactly how so you'll need to use your wit and cunning to think of something.\n\n" +
			"Good Luck brave one.\n");
		}

		public void Help()
		{
			System.Console.WriteLine("Directions: `E` for East, `W` for West");
			System.Console.WriteLine("'take' <item>\n- If an item can be picked up this command will put the item in your inventory");
			System.Console.WriteLine("'use' <item>\n- Uses an item from your inventory or in the room");
			System.Console.WriteLine("'inventory'\n - This command will list of the current items in your inventory");
		}
		public void Reset()
		{

		}

		public void UseItem(string itemName)
		{

		}

	}
}