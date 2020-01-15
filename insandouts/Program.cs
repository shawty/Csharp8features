using System;

namespace insandouts
{
  class Program
  {
    static void OutMethod(out string response)
    {
      // Trying to use the "response" here before it's set
      // causes a build error, even if you do set it prior
      // to calling.
      response = "The OUT method was called";
      // Here and on return, it's set and can be used.
      Console.WriteLine($"I AM OUT! - {response}");
    }

    static void RefMethod(ref string response)
    {
      // Trying to use response here on entry works, beacuse
      // what ever it's set to before calling is usable.
      Console.WriteLine($"I AM REF! - {response}");
      // Var however is not protected, and can be overwritten
      // possibly destroying a globally held var being passed
      // in as a ref
      response = "The REF method was called";
    }

    static void InMethod(in string response)
    {
      // IN marks "response" as being readable like ref, but
      // protects against trying to over write the variable
      // so now you get the speed increase using ref vars
      // provides, and the protection against damaging them
      Console.WriteLine($"I AM IN! - {response}");

      // Uncomment this and it'll generate a build error
      //response = "The IN method was called";
    }

    static void Main(string[] args)
    {
      Console.WriteLine("IN and OUT parameters:");

      string myText = "I Am Calling OUT...";
      OutMethod(out myText);
      Console.WriteLine(myText);

    }
  }
}
