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

        public Circle(double radius)
        {
            this.name = "Circle"; 
            this.radius = radius;
            calculateArea();
            calculatePerimeter();
        }

        public void calculateArea()
        {
            this.area = Math.Round((this.radius * this.radius) * 3.14 ,2); 
        }

        public void calculatePerimeter()
        {
            this.perimeter = Math.Round((this.radius * 2) * 3.14,2);
        }

    }
}
