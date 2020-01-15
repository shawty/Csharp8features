using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonExample
{
  class Program
  {
    private static string DecodeTokenType(Utf8JsonReader json) =>
    json.TokenType switch
    {
      JsonTokenType.StartObject => "START OBJECT",
      JsonTokenType.EndObject => "END OBJECT",
      JsonTokenType.StartArray => "START ARRAY",
      JsonTokenType.EndArray => "END ARRAY",
      JsonTokenType.PropertyName => $"PROPERTY NAME: {json.GetString()}",
      JsonTokenType.Comment => $"COMMENT: {json.GetString()}",
      JsonTokenType.String => $"STRING: {json.GetString()}",
      JsonTokenType.Number => $"NUMBER: {json.GetInt32()}",
      JsonTokenType.True => $"BOOL: {json.GetBoolean()}",
      JsonTokenType.False => $"BOOL: {json.GetBoolean()}",
      JsonTokenType.Null => $"NULL",
      _ => $"UNHANDLED TOKEN: {json.TokenType}"
    };

    static void Main(string[] args)
    {
      Console.WriteLine("JSON Example");

      // If you want low level control on a char by char basis then
      // use the Utf8JsonReader, the counterpart Utf8JsonWriter gives
      // you the same level of control for writing.
      var jsonFile = File.ReadAllBytes("airports.json");
      var jsonSpan = jsonFile.AsSpan();
      var json = new Utf8JsonReader(jsonSpan);

      while (json.Read())
      {
        Console.WriteLine(DecodeTokenType(json));
      }

      // Using the serializer/DeSerializer is identical
      // to using newtonsoft JSON, create a class deserialize
      // things to that type and boom, all is good....
      //
      // Not demoed here, but there are settings to deal with casing
      // pascal vs camel etc if you require that.
      var jsonText = File.ReadAllText("airports.json");
      var airports = JsonSerializer.Deserialize<List<Airport>>(jsonText);

      // There is also a JSONDocument type which has an interface very
      // similar to XDocument/XElement used for XML data

    }

  }
}
