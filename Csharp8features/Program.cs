using System;
using System.Collections.Generic;

namespace NullRefTypes
{
  class Program
  {
    static List<PersonName> people = new List<PersonName>()
    {
      new PersonName("Peter", "Shaw") { MiddleName = "Jack"},
      new PersonName("Ronald", "Donald") { MiddleName = "Mac"},
      new PersonName("John", "Smith"),
      new PersonName("Jane", "Doe")
    };

    static void Main(string[] args)
    {
      Console.WriteLine("Null Ref types:");

      foreach (var person in people)
      {
        Console.WriteLine(person.GetDisplayName());
      }


    }

  }
}
