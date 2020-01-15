using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchStatements
{
  public class Parcel
  {
    public decimal Weight { get; set; }
    public ParcelTypes ParcelType { get; set; }
    public string Description { get; set; }

    public bool IsLessThan100
      => Weight < 100.0M;

    public bool IsGreaterThanOrEqual100
      => Weight >= 100.0M;
  }
}
