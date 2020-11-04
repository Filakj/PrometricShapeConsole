using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PrometricConsoleApp
{
    class Program
    {
        public static Shapes userShapes;

        //public static List<Shape> shapes = new ArrayList(); 
        static async System.Threading.Tasks.Task Main(string[] args)
        {


            restart:
            Console.WriteLine("Hello ! Welcome to the Shape Console. \nLet's Make Some Shapes!\n");
            System.Threading.Thread.Sleep(3000);

            
            try
            {

                
                String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shapes1.txt");
                String jsonString1 = File.ReadAllText(path);
                userShapes = JsonSerializer.Deserialize<Shapes>(jsonString1);  
                

            }
            catch (Exception e)
            {
                Console.WriteLine("No Previous Data");
                userShapes = new Shapes();
            }
            
            Boolean session = true;
        mainMenue:
            while (session)
            {
                


                
                Console.WriteLine("What would you like to do ?\n");
                Console.WriteLine("(C) Create a shape. \n");
                Console.WriteLine("(V) View your shapes. \n");
                Console.WriteLine("(S) Serielize your shapes and exit. \n\n");

                String input1 = Console.ReadLine();
                if (input1 == "C")
                {
                    Console.Clear();
                    Console.WriteLine("Create Shape\n");
                    goto createShape; 
                }

                if (input1 == "V")
                {
                    Console.Clear();
                    Console.WriteLine("View Your Shapes\n");
                    goto viewShapes; 
                }

                if (input1 == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Saving Objects and Exiting \n");

                    using (FileStream fs = File.Create("test.txt"))
                    {
                        await JsonSerializer.SerializeAsync(fs, userShapes);
                    }
                    
                    String jsonString = JsonSerializer.Serialize(userShapes);
                    String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shapes1.txt"); 
                    File.WriteAllText(path,jsonString);
                    

                    Console.Clear(); 
                    goto restart;
                    
                }

                else
                {
                    Console.WriteLine("Invalid Input\n");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                }

            }//while main menue





        createShape:
            while (session)
            {
                
                Console.WriteLine("What kind of shape do you want to create?\n");
                Console.WriteLine("(c) Circle\n");
                Console.WriteLine("(t) Triangle\n");
                Console.WriteLine("(s) Square\n");
                Console.WriteLine("(r) Rectangle\n");
                Console.WriteLine("(g) Generic Shape\n");
                Console.WriteLine("(m) Return to Main Menus\n");
                String input2 = Console.ReadLine();

                switch (input2){
                    case "c":
                        Console.WriteLine("\nCircle\n");
                        Boolean makeCircle = true;
                        while (makeCircle)
                        {
                            Console.WriteLine("What is the radius of the circle you wish to create?\n");
                            String userRadius = Console.ReadLine();
                            try
                            {
                                double circleRadius = Convert.ToDouble(userRadius);
                                if(circleRadius <= 0)
                                {
                                    Console.WriteLine("Your input for radius must be a number greater than 0\n");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    break;
                                }
                                Shape tempCircle = new Circle(circleRadius);
                                Console.WriteLine("Your new circle has an area of " + Math.Round(tempCircle.getArea(),2) );
                                Console.WriteLine("Your new circle has an perimeter of " + Math.Round(tempCircle.getPerimeter(),2) + "\n");
                                userShapes.addShape(tempCircle);
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                Console.Clear(); 
                                goto createShape; 

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\nInvalid Input\n Please enter either an integer or a floating point decimal number;");
                                System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                            }

                            }
                        makeCircle = false; 
                        break;


                        case "s":
                            Console.WriteLine("\nSquare\n");
                            Boolean makeSquare = true;
                            while (makeSquare)
                            {
                                Console.WriteLine("What is the length of the side of the square you wish to create?\n");
                                String userSideLength = Console.ReadLine();
                                try
                                {
                                    double squareSide = Convert.ToDouble(userSideLength);
                                    if (squareSide <= 0)
                                    {
                                        Console.WriteLine("Your input for a side length must be a number greater than 0\n");
                                        System.Threading.Thread.Sleep(3000);
                                        Console.Clear();
                                        break;
                                    }
                                    Shape tempSquare = new Square(squareSide);
                                    Console.WriteLine("Your new square has an area of " + Math.Round(tempSquare.getArea(),2));
                                    Console.WriteLine("Your new square has an perimeter of " + Math.Round(tempSquare.getPerimeter(),2) + "\n");
                                    userShapes.addShape(tempSquare);
                                    Console.WriteLine("\nPress any key to continue");
                                    Console.ReadKey();
                                    //System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    goto createShape;

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nInvalid Input\n Please enter either an integer or a floating point decimal number;");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                }

                            }
                            makeSquare = false;
                            break;


                    case "m":
                        Console.WriteLine("\nReturning to Main Menus");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        goto mainMenue;

                    case "t":
                        Console.WriteLine("\nTriangle\n");
                        Boolean makeTriangle = true;
                        while (makeTriangle)
                        {
                            sideLengths:
                            Console.WriteLine("What are the lengths of the sides of the Triangle you wish to create?\n");
                            String userSides = Console.ReadLine();
                            Console.WriteLine();
                            try
                            {
                                
                                String[] sides = userSides.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                                
                                if (sides.Length != 3)
                                {
                                    Console.WriteLine("Invalid number of sides\nPlease enter exactly 3 numbers.");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    goto sideLengths; 
                                    
                                }

                                double a = Math.Round(Convert.ToDouble(sides[0]),2);
                                double b = Math.Round(Convert.ToDouble(sides[1]),2); 
                                double c = Math.Round(Convert.ToDouble(sides[2]),2);


                                if (a <= 0 || b <= 0 || c <= 0)
                                {
                                    Console.WriteLine("Each sidelength must be a number greater than 0\n");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    goto sideLengths;
                                    break;
                                }

                                if(a + b < c || a + c < b || b + c < a)
                                {
                                    Console.WriteLine("For a triangle to exist, every permutation of 2 side lengths must be greater than the third. ");
                                    Console.WriteLine("a + b must be greater than c, and c + a must be greater than b");
                                    System.Threading.Thread.Sleep(10000);
                                    Console.Clear();
                                    goto sideLengths;


                                }
                                Shape tempTriangle = new Triangle(a,b,c);
                                Console.WriteLine("You created a " + tempTriangle.getName()); 
                                Console.WriteLine("Your new triangle has an area of " + Math.Round(tempTriangle.getArea(),2));
                                Console.WriteLine("Your new triangle has an perimeter of " + Math.Round(tempTriangle.getPerimeter(),2) + "\n");
                                userShapes.addShape(tempTriangle);
                                Console.WriteLine("\nPress any key to continue");
                                
                                Console.ReadKey();
                               // System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                                goto createShape;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\nInvalid Input\nPlease enter either an integer or a floating point decimal number for each of the three sides separted with spaces;");
                                System.Threading.Thread.Sleep(4000);
                                Console.Clear();
                            }

                        }
                        makeTriangle = false;
                        break;

                    case "r":
                        Console.WriteLine("\nRectangle\n");
                        Boolean makeRectangle = true;
                        while (makeRectangle)
                        {
                            Console.WriteLine("What are the lengths of the 2 sides of the Rectangle you wish to create?\n");
                            String userSides = Console.ReadLine();
                            Console.WriteLine();
                            try
                            {
                                String[] sides = userSides.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                                if (sides.Length != 2)
                                {
                                    Console.WriteLine("Invalid number of sides\nPlease enter exactly 2 numbers.");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    break;
                                }

                                double a = Convert.ToDouble(sides[0]);
                                double b = Convert.ToDouble(sides[1]);
                                


                                if (a <= 0 || b <= 0)
                                {
                                    Console.WriteLine("Each sidelength must be a number greater than 0\n");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    break;
                                }

                                if(a == b)
                                {
                                    Shape tempSquare = new Square(a);
                                    Console.WriteLine("Since your width and height of your Rectangle are the same, you made a square!\n");
                                    Console.WriteLine("Your new square has an area of " + tempSquare.getArea());
                                    Console.WriteLine("Your new square has an perimeter of " + tempSquare.getPerimeter() + "\n");
                                    userShapes.addShape(tempSquare);
                                    Console.WriteLine("\nPress any key to continue");
                                    Console.ReadKey();
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();
                                    goto createShape;
                                }

                                Shape tempRectangle = new Rectangle(a, b);
                            
                                Console.WriteLine("Your new rectangle has an area of " + tempRectangle.getArea());
                                Console.WriteLine("Your new rectangle has an perimeter of " + tempRectangle.getPerimeter() + "\n");
                                userShapes.addShape(tempRectangle);
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                //System.Threading.Thread.Sleep(3000);
                                Console.Clear();
                                goto createShape;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\nInvalid Input\n Please enter either an integer or a floating point decimal number for both sides separted with spaces;");
                                System.Threading.Thread.Sleep(4000);
                                Console.Clear();
                            }

                        }
                        makeRectangle = false;
                        break;




                    default:
                        Console.WriteLine("Invalid Input");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                        
                }

            }//session create shape 


        viewShapes:
            Console.WriteLine("Let's Take A Look At Your Shapes!\n");
            userShapes.viewShapes();
            while (session)

            {

                //Console.WriteLine("Let's Take A Look At Your Shapes!\n");
                //userShapes.viewShapes();
                //viewChoices:
                Console.WriteLine("More Options\n");
                Console.WriteLine("(a) Sort your shapes by area size \n");
                Console.WriteLine("(p) Sort your shapes by perimeter size\n");
                Console.WriteLine("(c) View memory consumption of shapes \n");
                Console.WriteLine("(m) Return to main menues\n");
                String input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        Console.Clear();
                        Console.WriteLine("\nShapes Sorted by Area Size\n");
                        userShapes.sortByArea();
                        Console.WriteLine("\nPress any key to continue\n");
                        Console.ReadKey();
                        goto viewShapes;

                    case "p":
                        Console.Clear();
                        Console.WriteLine("\nShapes Sorted by Perimeter Size\n");
                        userShapes.sortByPerimeter();
                        Console.WriteLine("\nPress any key to continue\n");
                        Console.ReadKey();
                        goto viewShapes;

                    case "c":
                        Console.Clear();
                        userShapes.calculateMemoryUsage();
                        Console.WriteLine("\nPress any key to continue\n");
                        Console.ReadKey();
                        goto viewShapes;

                    case "m":
                        Console.WriteLine("Returning to Main Menus");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        goto mainMenue;

                    default:
                        Console.WriteLine("Invalid Input");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;

                }
            }



            }// main 

        }
    }

