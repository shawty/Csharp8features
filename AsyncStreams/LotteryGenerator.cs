using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStreams
{
  public class LotteryNumber
  {
    public int TheNumber { get; set; }
  }

  public class LotteryNumberCreator
  {
    private const int minNum = 1;
    private const int maxNum = 99;

    public async IAsyncEnumerable<LotteryNumber> CreateLotteryNumbers(int count)
    {
      for(var i = 0; i < count; i++)
      {
        // Simulated delay as if getting numbers from some network service
        // notice we are "awaiting" on this , which means our entire
        // method is async now.
        await Task.Delay(1000);

        // We use yield return as we have in the past, but note now how
        // the return type is an AsyncEnumerable rather than just a
        // plain old Enumerable.  Most of the Ixxxxxx interfaces in
        // System.Collections now have async capable versions allowing
        // you to keep drip feeding a collection, which yield return
        // will simply just keep allowing you to await on further down
        // the line, until no more data is available for it to return.
        var rnd = new Random();
        yield return
          new LotteryNumber() { TheNumber = rnd.Next(minNum, maxNum) };
      }
    }

  }
}
