using System;

namespace DefaultInterfaces
{
  public class MyClass : MyInterface
  {
    public void AddNumbers(int numberOne, int numberTwo)
    {
      Console.WriteLine
        ($"{numberOne} + {numberTwo} = {numberOne + numberTwo}");
    }

  }
}
