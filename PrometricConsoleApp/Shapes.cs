using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace PrometricConsoleApp
{
    /* Shapes class 
     * holds shape objects for a single user 
     * To which our program interacts with 
     */
    class Shapes
    {
        //property for holding starting memory size 
        //TODO research more about calculating the size of shape structures for user 
        // ex. Marshal, MemoryMarshal, Garbage Collection 
        private long startmem; 

        //Collection storing all shape objects 
        private List<Shape> shapes; 
         
        //no args allow us to create a new collection at start of main 
        public Shapes()
        {
            this.shapes = new List<Shape>();
            startmem = GC.GetTotalMemory(true); 
        }


        //adds shape to collection 
        public void addShape(Shape shape)
        {
            this.shapes.Add(shape); 
        }

        // iterate through collection and print out shape name , area and perimeter 
        public void viewShapes()
        {
            foreach (Shape s in this.shapes)
            {
                //TODO fix padding 
                Console.WriteLine("Shape: {0,20}, Area: {1,30},  Perimeter{2,40}\n", s.getName(), s.getArea(), s.getPerimeter());
            }
            Console.WriteLine("\n\n");
        }

        //Sorts the shapes within the collection based on area property of shape asscending 
        public void sortByArea()
        {
            this.shapes.Sort(delegate (Shape a, Shape b)
            {
                return a.getArea().CompareTo(b.getArea()); 
            });

            foreach (Shape s in this.shapes)
            {
                //TODO Fix Padding 
                Console.WriteLine("Shape: {0,20}, Area: {1,30}, Perimeter{2,40}\n", s.getName(), s.getArea(), s.getPerimeter());
               
            }

            Console.WriteLine("\n\n");

        }

        //Sorts the shapes within the collection based on perimeter of the shape ascending 
        public void sortByPerimeter()
        {
            shapes.Sort(delegate (Shape a, Shape b)
            {
                return a.getPerimeter().CompareTo(b.getPerimeter());
            });

            foreach (Shape s in this.shapes)
            {
                // TODO Fix Padding 
                Console.WriteLine("Shape: {0,7}, Area: {1,14}, Perimeter{2,21}\n", s.getName(), s.getArea(), s.getPerimeter());
            }
            Console.WriteLine("\n\n");
        }

        //Calculate memory for the amount of shape objects user has created 
        //TODO get better method (see in class property above)
        //TODO determine object size for each class object and determine memory allocation 
        public void calculateMemoryUsage()
        {
            //TODO remove old code 

            /*
            Console.WriteLine("\nCurrent Memory Usage\n");
            Console.WriteLine("\nGeeration: {0}", GC.GetGeneration(this.shapes));
            
            GC.Collect();
             //Console.WriteLine("Shapes Size: {0}", Marshal.SizeOf(s));
                Memory<Shape> m = new Memory<Shape>();
                MemoryMarshal.AsBytes<Shape>(Span<Shape>);
                Console.WriteLine();
                var array = new byte[100]; 
                var mem = new Span<byte>(array); 
                Console.WriteLine("Shapes Size: {0}", MemoryMarshal.TryWrite(mem,Shape));
            */
            GC.KeepAlive(this.shapes);
            Console.WriteLine("Total Memory Usage:{0} Bytes", this.startmem - GC.GetTotalMemory(false));

            //Console.WriteLine("Shapes Size: {0}", Marshal.SizeOf(this.shapes));


        }

    }
}
