// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Threading;

Console.Write("Radius: ");
int myRadius = int.Parse(System.Console.ReadLine());
Circle myCircle = new Circle(myRadius);

Console.Write("Iterations: ");
int iterations = int.Parse(System.Console.ReadLine());
// System.Console.WriteLine(myCircle.Radius);
myCircle.Test(iterations);

public class Circle
{
  

  public int Radius;
  public Circle(int radius)
  {
    Radius = radius;
  }

  public void Test(int iterations)
  {
    // Performance Counter
    Stopwatch stopWatch = new Stopwatch();
    for (int i = 0; i < iterations; i++)
    {
      stopWatch.Start();
      Generate();
      stopWatch.Stop();
      // stopWatch.Reset();
    }
      System.Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + "ms");
  }

  public void Generate()
  {

  
    // // Setup performance tracker
    // int inc = 0;
    // int dec = 0;
    // int shf = 0;
    // int add = 0;
    // int sub = 0;
    // int mul = 0;
    // int cmp = 0;



    int radiusSquare = Radius * Radius;
    // mul++; // performance tracker
    radiusSquare = radiusSquare << 2;
    // shf++; // performance tracker


    // setup square table
    int[] xSquareTable = new int[Radius];
    int[] ySquareTable = new int[Radius];
    int hx;
    for (int i = 0; i < Radius; i++)
    {
      hx = i << 1;
      // shf++; // performance tracker
      hx++;
      // inc++; // performance tracker
      xSquareTable[i] = hx * hx;
      // mul++; // performance tracker
      ySquareTable[i] = radiusSquare - xSquareTable[i];
      // sub++; // performance tracker
      // System.Console.WriteLine(xSquareTable[i]);
      // System.Console.WriteLine(ySquareTable[i]);
      // cmp++; // performance tracker
    }

    // Double the radius to calculate half-pixels using integers
    // hx = Radius << 1;
    // hx--;
    // System.Console.WriteLine(hx);

    // find Y Values
    int[] yTable = new int[Radius];
    int symmetryX = 0;
    int lastSq = 1;
    for (int x = Radius - 1; x >= 0; x--)
    {
      // cmp++; // performance tracker
      if (x < symmetryX)
      {
        break;
      }

      yTable[x] = Radius;
      for (int sq = lastSq; sq < Radius; sq++)
      {
        // cmp++; // performance tracker
        if (ySquareTable[x] < xSquareTable[sq])
        {
          yTable[x] = sq;
          lastSq = sq;
          for (int sx = symmetryX; sx < yTable[x]; sx++)
          {
            yTable[sx] = x + 1;
            // inc++; // performance tracker
            // cmp++; // performance tracker
            // inc++; // performance tracker
          }
          symmetryX = yTable[x];
          // System.Console.WriteLine(ySquareTable[x]);
          // System.Console.WriteLine(sq);
          break;
        }
        // cmp++; // performance tracker
        // inc++; // performance tracker
      }
      // System.Console.WriteLine(x);
      // System.Console.WriteLine(yTable[x]);
      // cmp++; // performance tracker
      // dec++; // performance tracker
    }

    // for (int x = 0; x < Radius; x++)
    // {
    //   System.Console.WriteLine(yTable[x]);
    // }

    // System.Console.WriteLine("INC: " + inc.ToString());
    // System.Console.WriteLine("DEC: " + dec.ToString());
    // System.Console.WriteLine("ADD: " + add.ToString());
    // System.Console.WriteLine("SUB: " + sub.ToString());
    // System.Console.WriteLine("SHF: " + shf.ToString());
    // System.Console.WriteLine("MUL: " + mul.ToString());
    // System.Console.WriteLine("CMP: " + cmp.ToString());

    // return yTable;



    // screw it, let's just put it in the Generate() function
    // Top hemicircle
    for (int y = Radius; y > 0; y--)
    {
      // Upper-left quadrant
      for (int x = Radius - 1; x >= 0; x--)
      {
        if (yTable[x] >= y)
        {
          System.Console.Write('@');
        } else {
          System.Console.Write(' ');
        }
      }

      // Upper-right quadrant
      for (int x = 0; x < Radius; x++)
      {
        if (yTable[x] >= y)
        {
          System.Console.Write('@');
        } else {
          System.Console.Write(' ');
        }
      }
      System.Console.WriteLine("");
    }

    // Bottom hemicircle
    for (int y = 1; y <= Radius; y++)
    {

      // Bottom-left quadrant
      for (int x = Radius - 1; x >= 0; x--)
      {
        if (yTable[x] >= y)
        {
          System.Console.Write('@');
        } else {
          System.Console.Write(' ');
        }
      }

      // Bottom-right quadrant
      for (int x = 0; x < Radius; x++)
      {
        if (yTable[x] >= y)
        {
          System.Console.Write('@');
        } else {
          System.Console.Write(' ');
        }
      }
      System.Console.WriteLine("");
    }
  }

  // public void Print()
  // {
  //   int[] yTable = Generate(); // c# types are stupid
  //   for (int x = 0; x < yTable.Length; x++)
  //   {
  //     System.Console.WriteLine(yTable[x]);
  //   }
  // }
}
