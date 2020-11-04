using System;
using System.Collections.Generic;
using System.Text;

namespace PrometricConsoleApp
{
    class Square : Shape
    {

       
        
        public Square()
        {}
        public Square(double sideLength)
        {
            this.name = "Square";
            this.area = Math.Round(sideLength * sideLength,2);
            this.perimeter = Math.Round(sideLength * 4,2); 
        }


    }
}
