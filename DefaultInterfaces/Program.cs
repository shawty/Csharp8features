using System;

namespace DefaultInterfaces
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Default Interfaces");

      MyClass myClass = new MyClass();
      myClass.AddNumbers(2, 2);

      // NOTE that unless you actually implement the new
      // methods in the class, you still won't get to see
      // them in your class even if they are default in
      // the interface contract.
      //myClass.MultiplyNumbers(2, 2);


    }
  }
}
