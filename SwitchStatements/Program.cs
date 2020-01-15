using System;

namespace SwitchStatements
{
  class Program
  {

    static decimal ComputeDeliveryCost(Parcel parcel)
    {
      // OLD way of decoding the delivery cost, using horrible nested
      // switches, and long terse layout.

      decimal cost = (parcel.Weight * 4.0M); // Default

      switch(parcel.ParcelType)
      {
        case ParcelTypes.FirstClass:
          bool isLightParcel = parcel.IsLessThan100;
          switch(isLightParcel)
          {
            case true:
              cost = (parcel.Weight * 1.24M);
              break;

            case false:
              cost = (parcel.Weight * 1.74M);
              break;
          }
          break;

        case ParcelTypes.SecondClass:
          cost = (parcel.Weight * 1.14M);
          break;

        case ParcelTypes.RecordedDelivery:
          cost = (parcel.Weight * 3.0M);
          break;

        case ParcelTypes.NextDayCourier:
          cost = (parcel.Weight * 2.5M);
          break;

        case ParcelTypes.StoreCollection:
          cost = (parcel.Weight * 0.75M);
          break;

        case ParcelTypes.FreeDelivery:
          cost = (parcel.Weight * 0.0M);
          break;
      }

      return cost;
    }

    // New way of using switch statments.  Note how we reduced the
    // complexity of the nested switch, by implementing property
    // lambdas on our class object, then used property based pattern
    // matching to match them.
    public static decimal NewComputeDeliveryCost(Parcel parcel) =>
      parcel switch
      {
        { ParcelType: ParcelTypes.FirstClass, IsLessThan100: true} => parcel.Weight * 1.24M,
        { ParcelType: ParcelTypes.FirstClass, IsLessThan100: false } => parcel.Weight * 1.74M,
        { ParcelType: ParcelTypes.SecondClass } => parcel.Weight * 1.14M,
        { ParcelType: ParcelTypes.RecordedDelivery } => parcel.Weight * 3.0M,
        { ParcelType: ParcelTypes.NextDayCourier } => parcel.Weight * 2.5M,
        { ParcelType: ParcelTypes.StoreCollection } => parcel.Weight * 0.75M,
        { ParcelType: ParcelTypes.FreeDelivery } => parcel.Weight * 0.0M,
        _ => parcel.Weight * 4.0M
      };

    static void Main(string[] args)
    {
      Console.WriteLine("Switch Statements:");

      Parcel myParcel = new Parcel()
      {
        Description = "My Parcel",
        Weight = 100,
        ParcelType = ParcelTypes.RecordedDelivery
      };

      Console.WriteLine
        ($"Delivery cost is {ComputeDeliveryCost(myParcel)}");


    }
  }
}
