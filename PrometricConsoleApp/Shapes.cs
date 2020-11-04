using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace PrometricConsoleApp
{
    class Shapes
    {
        private long startmem; 
        private List<Shape> shapes; 
        //dictonary for possible o(1) search shape types 
        public Shapes()
        {
            this.shapes = new List<Shape>();
            startmem = GC.GetTotalMemory(true); 
        }



        public void addShape(Shape shape)
        {
            this.shapes.Add(shape); 
        }

        public void viewShapes()
        {
            foreach (Shape s in this.shapes)
            {
                Console.WriteLine("Shape: {0,20}, Area: {1,30},  Perimeter{2,40}\n", s.getName(), s.getArea(), s.getPerimeter());
            }
            Console.WriteLine("\n\n");
        }

        public void sortByArea()
        {
            this.shapes.Sort(delegate (Shape a, Shape b)
            {
                return a.getArea().CompareTo(b.getArea()); 
            });

            foreach (Shape s in this.shapes)
            {
                Console.WriteLine("Shape: {0,20}, Area: {1,30}, Perimeter{2,40}\n", s.getName(), s.getArea(), s.getPerimeter());
               
            }

            Console.WriteLine("\n\n");


        }


        public void sortByPerimeter()
        {
            shapes.Sort(delegate (Shape a, Shape b)
            {
                return a.getPerimeter().CompareTo(b.getPerimeter());
            });

            foreach (Shape s in this.shapes)
            {
                Console.WriteLine("Shape: {0,7}, Area: {1,14}, Perimeter{2,21}\n", s.getName(), s.getArea(), s.getPerimeter());
            }
            Console.WriteLine("\n\n");
        }

        public void calculateMemoryUsage()
        {
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
