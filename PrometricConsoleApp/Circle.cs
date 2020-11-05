using System;
using System.Collections.Generic;
using System.Text;

namespace PrometricConsoleApp
{


    class Circle : Shape
    {
        
        private double radius;
        

        public Circle()
        {
        }

        //Circle constructor
        // When supplied radius, Area and perimeter will be calculated 
        public Circle(double radius)
        {
            this.name = "Circle"; 
            this.radius = radius;
            calculateArea();
            calculatePerimeter();
        }

        // calculates area based on its property radius 
        public void calculateArea()
        {
            this.area = Math.Round((this.radius * this.radius) * 3.14 ,2); 
        }

        //calculates perimeter based on its property radius 
        public void calculatePerimeter()
        {
            this.perimeter = Math.Round((this.radius * 2) * 3.14,2);
        }

    }
}
