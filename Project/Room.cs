using System.Collections.Generic;

namespace CastleGrimtol.Project
{
	public class Room : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public Dictionary<string, Item> Items { get; set; }
		public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
		

		public Room(string name, string description)
		{
			Name = name;
			Description = description;
			Items = new Dictionary<string, Item>();
		}


		public void UseItem(Item item)
		{

		}

	}
}