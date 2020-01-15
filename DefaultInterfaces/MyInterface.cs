using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaces
{
  public interface MyInterface
  {
    // Interface starts with just "AddNumbers"
    void AddNumbers(int numberOne, int numberTwo);

    // Uncomment "MultiplyNumbers" but DONT uncomment 
    // the boddy following it, observe that MyClass will
    // now refuse to compile unless you implement MultiplyNumbers
    //
    // Uncomment the 3 following lines, observe my class
    // now builds without problem.

    //void MultiplyNumbers(int numberOne, int numberTwo)
    //{
    //  Console.WriteLine("Hello");
    //}

  }
}
