using System;
using System.Collections.Generic;
using System.Text;

namespace PrometricConsoleApp
{
    class Square : Shape
    {
        //Square gets properties from parent class rectangle 
        
       
        
        public Square()
        {}
        //square's area and perimeter can be calculated with a single side length 
        public Square(double sideLength)
        {
            this.name = "Square";
            this.area = Math.Round(sideLength * sideLength,2);
            this.perimeter = Math.Round(sideLength * 4,2); 
        }


    }
}
