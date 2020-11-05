using System;
using System.Collections.Generic;
using System.Text;

namespace PrometricConsoleApp
{
    class Triangle : Shape
    {
        //Triange extends parent properties from parent Shape class 

        public Triangle()
        {
        }

        // Trainge constructor with arguments being sides of three lengths 
        // input is validated in main to ensure valid triangle can be made 
        public Triangle(double l1, double l2, double l3)
        {
            this.perimeter = l1 + l2 + l3;
            this.area = getArea(l1, l2, l3); 
            //depending on if sides are equal , unique or two are the same , we can identify what typeof triangle we are creating 
            if(l1 == l2 && l2 == l3)
            {
               this.name = "Equalateral Triangle";
                
                
            }
            else if(l2 == l1 || l2 == l3 ||  l1 == 13)
            {
                this.name = "Isosceles Triangle";
                
                
            }
            else
            {
                this.name = "Scalene Triangle"; 
            }
            
            

        }


        //use Heron's formula to calculate area knowing 3 side lengths 
        public double getArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2.0; 
            double area = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)),2);
            return area; 
        }





    }
}
