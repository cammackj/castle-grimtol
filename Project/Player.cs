using System.Collections.Generic;

namespace CastleGrimtol.Project
{
	public class Player : IPlayer
	{
		public Dictionary<string, Player> Players = new Dictionary<string, Player>();
		public Player(string name, string description)
		{
			Name = name;
			Description = description;
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public int Score { get; set; }
		public List<Item> Inventory { get; set; }
	}
}