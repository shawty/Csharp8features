using System;
using System.Collections.Generic;
using System.Linq;

namespace RangesAndIndexes
{
  class Program
  {
    static IEnumerable<int> GetNumbers()
    {
      var results = new List<int>();
      for (int i = 0; i < 100; i++)
      {
        results.Add(i);
      }

      return results;
    }

    static void NormalLoop(int[] numbers)
    {
      Console.Write("|");
      foreach (var num in numbers)
      {
        Console.Write($"{num}|");
      }
      Console.WriteLine();
    }

    static void Numbs20To30(int[] numbers)
    {
      // REMEMBER: Opening number is inclusive, closing number is exclusive
      Console.Write("|");
      foreach (var num in numbers[20..30])
      {
        Console.Write($"{num}|");
      }
      Console.WriteLine();
    }

    static void AllExceptFirstAndLast(int[] numbers)
    {
      Console.Write("|");
      foreach (var num in numbers[1..^1])
      {
        Console.Write($"{num}|");
      }
      Console.WriteLine();
    }

    static void AllExceptFirst10AndLast10(int[] numbers)
    {
      Console.Write("|");
      foreach (var num in numbers[10..^10])
      {
        Console.Write($"{num}|");
      }
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Indexes and Ranges:");

      var numbers = GetNumbers().ToArray();

      NormalLoop(numbers);
      Console.WriteLine("--------------------------");
      Numbs20To30(numbers);
      Console.WriteLine("--------------------------");
      AllExceptFirstAndLast(numbers);
      Console.WriteLine("--------------------------");
      AllExceptFirst10AndLast10(numbers);

    }
  }
}
