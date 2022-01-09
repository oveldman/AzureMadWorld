using System;
namespace MadWorld.Console.Operator
{
	public class TestShip
	{
		public Guid ID { get; set; }
		public string Name { get; set; }

		public static implicit operator TestShip(string name)
		{
			return new TestShip
			{
				ID = Guid.NewGuid(),
				Name = name
			};
		}

		//Don't need a casting type
		//string testShipName = ship;
		public static implicit operator string(TestShip ship)
        {
			return ship.Name;
        }

		//Must at casting type
		//Guid shipID = (Guid)ship
		public static explicit operator Guid(TestShip ship)
		{
			return ship.ID;
		}
	}
}

