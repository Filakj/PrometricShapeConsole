using System;
using System.Collections.Generic;
using System.Text;

namespace PrometricConsoleApp
{
 
    class Rectangle : Shape
    {
        //rectangle uses properties from parent class Shape 

        //when supplied a two side lengths we can calculate area and perimeter 
        public Rectangle(double l1, double l2)
        {
            this.name = "Rectangle";
            this.area = Math.Round(l1 * l2,2);
            this.perimeter = Math.Round((2 * l1) + (2 * l2),2); 
        }
    }
    
}
