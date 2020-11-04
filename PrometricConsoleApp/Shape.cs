using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace PrometricConsoleApp
{
	public class Shape
	{
		protected String name;
		protected double perimeter;
		protected double area;

		public Shape()
		{
		}

		public String getName()
        {
			return this.name; 
        }

		public double getArea()
		{
			return this.area;
		}

		public double getPerimeter()
		{
			return this.perimeter;
		}

		public Shape(String name, double perimieter, double area)
		{
			this.name = name;
			this.perimeter = perimeter;
			this.area = area;
		}

	}
}