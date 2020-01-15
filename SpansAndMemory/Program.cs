using System;
using System.Diagnostics;

namespace SpansAndMemory
{
  class Program
  {
    static string[] GpsData =
  {
  "$GPGGA,131419.000,5451.0844,N,00160.4141,W,1,03,5.9,249.1,M,48.0,M,,0000*45",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.9,1.0*30",
  "$GPRMC,131419.000,A,5451.0844,N,00160.4141,W,0.55,23.96,090519,,*2D",
  "$GPGGA,131420.000,5451.0845,N,00160.4141,W,1,03,5.9,249.0,M,48.0,M,,0000*4F",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.9,1.0*30",
  "$GPRMC,131420.000,A,5451.0845,N,00160.4141,W,0.43,21.85,090519,,*21",
  "$GPGGA,131421.000,5451.0847,N,00160.4141,W,1,03,5.9,249.0,M,48.0,M,,0000*4C",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.249.0,M,48.0,M,,0000*40",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.9,1.0*30",
  "$GPRMC,131428.000,A,5451.0850,N,00160.4142,W,0.26,27.55,090519,,*26",
  "$GPGGA,131429.000,5451.0853,N,00160.4142,W,1,03,5.9,248.9,M,48.0,M,,0000*4A",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.9,1.0*30",
  "$GPRMC,131429.000,A,5451.0853,N,00160.4142,W,0.34,19.85,090519,,*27",
  "$GPGGA,131430.000,5451.0857,N,00160.4142,W,1,03,5.9,248.8,M,48.0,M,,0000*47",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,6.0,5.9,1.0*30",
  "$GPRMC,131430.000,A,5451.0857,N,00160.4142,W,0.36,18.63,090519,,*20",
  "$GPGGA,131431.000,5451.0859,N,00160.4142,W,1,03,5.9,248.8,M,48.0,M,,0000*48",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,5.9,5.9,1.0*3A1",
  "$GPGSV,3,1,12,29,67,073,27,31,59,225,29,26,42,285,31,25,37,108,26*72",
  "$GPGSV,3,2,12,21,25,169,23,02,14,037,,23,14,324,33,16,13,283,*7E",
  "$GPGSV,3,3,12,05,09,068,26,14,05,225,,12,03,104,22,09,01,354,*76",
  "$GPRMC,131431.000,A,5451.0859,N,00160.4142,W,0.39,22.16,090519,,*2B",
  "$GPGGA,131432.000,5451.0859,N,00160.4143,W,1,03,5.9,248.8,M,48.0,M,,0000*4A",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,5.9,5.9,1.0*3A",
  "$GPRMC,131432.000,A,5451.0859,N,00160.4143,W,0.28,23.77,090519,,*2F",
  "$GPGGA,131433.000,5451.0861,N,00160.4143,W,1,03,5.9,248.7,M,48.0,M,,0000*4F",
  "$GPGSA,A,2,29,25,26,,,,,,,,,,5.9,5.9,1.0*3A",
  "$GPRMC,131433.000,A,5451.0861,N,00160.4143,W,0.27,24.39,090519,,*27",
  "$GPGGA,131434.000,5451.0864,N,00160.4143,W,1,03,5.9,248.7,M,48.0,M,,0000*4D"
    };


    static void Main(string[] args)
    {
      Console.WriteLine("Spans and Memory:");

      // The data above is raw NMEA GPS data from a phones GPS device, the sample is a 10
      // second window, with one sentance/line eventing approxamately every 0.3 of a second
      // in 1 second bursts.
      //
      // The timing below uses the system stopwatch in "ticks" mode (These are 1,000,000 th of 
      // the Ms (1000 = 1sec) timing your used to.

      // The old method will cause a re-allocation on the heap for each time it parses the first
      // 5 chars out of the string, that's 29 boxing and unboxing operations just for the 10
      // second snapshot above, scale that up to 60 seconds or even an hour and you quickly see
      // how fast that can multiply.  If this is on a device with limited memory such as a mobile
      // phone or IoT device then your quickly going to have a problem.
      Stopwatch oldMethodTime = new Stopwatch();
      oldMethodTime.Start();
      foreach (string sentance in GpsData)
      {
        string command = sentance.Substring(1, 5);
        // be carefull enabling the write statements here
        // they will skew the stopwatch results
        //Console.WriteLine($"Command : {command}");
      }
      oldMethodTime.Stop();
      Console.WriteLine
        ($"Old string manipulation methods took {oldMethodTime.Elapsed} for 29 reallocations on substrings");

      // The new method using spans performs NO reallocation of strings and instead just plucks the data
      // straight out, and even at the point where we use "ToString()" to display it there is no reallocation
      // on the heap as where not saving the var just boxing it then displaying it once.
      Stopwatch newMethodTime = new Stopwatch();
      newMethodTime.Start();
      foreach (ReadOnlySpan<char> sentance in GpsData)
      {
        ReadOnlySpan<char> command = sentance.Slice(1, 5);
        // be carefull enabling the write statements here
        // they will skew the stopwatch results
        //Console.WriteLine($"Command : {command.ToString()}");
      }
      newMethodTime.Stop();
      Console.WriteLine
        ($"New string manipulation methods took {newMethodTime.Elapsed} with 0 reallocations on substrings");


    }
  }
}
