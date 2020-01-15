using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreams
{
  class Program
  {
    // ThreadID shows which thread the console writeline
    // in the main loop is actually running on
    static int ThreadId =>
      Thread.CurrentThread.ManagedThreadId;

    // Main is now an asyc capable method
    static async Task Main(string[] args)
    {
      Console.WriteLine("Async Streams:");

      var lotteryGenerator = new LotteryNumberCreator();
      Console.WriteLine("Your lottery numbers are:");

      // Our foreach is now awaitable
      await foreach (var number in lotteryGenerator.CreateLotteryNumbers(6))
      {
        Console.WriteLine($"[{ThreadId}] Number is - {number.TheNumber}");
      }

      Console.WriteLine("All done Hope you won!!!");
    }
  }
}