using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternMatching
{
  class Program
  {
    static bool IsShawInCategoryOne(PositionalClass p)
    {
      // This is a positional based match, it uses the Deconstruct
      // method to get the data, then matches the parameters at the
      // given position in the tuple to filter them.
      // Input object can either be typed or generic IE: object
      // as the "p is xxxx" will only be true if that type matches
      return p is PositionalClass(_, "Shaw", 1);

      // for ref, you could take an object in and do something like:
      // if(p is PositionalClass)
      // {
      //   return p is PositionalClass(_, "Shaw", 1);
      // }
      // if(p is AnotherClass)
      // {
      //   return p is AnotherClass(5, 1, "Hello");
      // }
      // Allowing one method that handles multiple types

    }

    static bool IsNameTony(object o)
    {
      // This is property and class type based, just as mentioned
      // above the input is an object so with if/then you can match
      // multiple types.
      // Here the matching is all about matching on named properties
      return
        o is PositionalClass p &&
        p is { Forename: "Tony" };

      // For ref, you can NEST classes too, so for example if you had
      // a public property with a location class, you could do things like
      // the following
      //
      // return
      //   o is PositionalClass p &&
      //   p is { Forname: "Tony", Location: { City: "New York" }}
      //
      // This nesting also works with positional pattern matching
      // allowing you to do so very complex filtering.
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Pattern Matching:");

      List<PositionalClass> myClasses = new List<PositionalClass>()
      {
        new PositionalClass("Peter", "Shaw", 1),
        new PositionalClass("Tony", "Stark", 2),
        new PositionalClass("Elizabeth", "Shaw", 1),
        new PositionalClass("Joe", "Blogs", 3)
      };

      List<PositionalClass> shawClasses =
        myClasses.Where(r => IsShawInCategoryOne(r)).ToList();

      PositionalClass ironMan =
        myClasses.FirstOrDefault(r => IsNameTony(r));

    }
  }
}
