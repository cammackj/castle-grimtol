using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Project.Game MyGame = new Project.Game();
			MyGame.StartGame();
			Console.ReadKey();
		}
	}
}
