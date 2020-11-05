using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace PrometricConsoleApp
{
	/*Shape class to which all other shape classes inherit from
	 * 
	 */
	public class Shape
	{
		//basic properties are name , area , and perimeter 
		protected String name;
		protected double perimeter;
		protected double area;

		public Shape()
		{
		}

		//getter for a shape's name 
		public String getName()
        {
			return this.name; 
        }

		//getter for a shape's area 
		public double getArea()
		{
			return this.area;
		}

		//getter for a shape's perimeter 
		public double getPerimeter()
		{
			return this.perimeter;
		}



	}
}