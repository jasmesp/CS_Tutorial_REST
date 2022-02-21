using System;
using System.Text.Json.Serialization;

namespace ConsoleApp1;

public class Repository
{
    [JsonPropertyName("name")] public string Name { get; set; }
}