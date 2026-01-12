using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Fruit
{
    public string? Name { get; set; }
    public string? Color { get; set; }
    public double Price { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
    
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"products.json");
        string jsonString = File.ReadAllText(filePath);

        List<Fruit>? fruits = JsonConvert.DeserializeObject<List<Fruit>>(jsonString);

        if (fruits == null)
        {
            Console.WriteLine("Failed to deserialize JSON. Check file contents.");
            return;
        }

        foreach (var fruit in fruits)
        {
            Console.WriteLine(
                $"Name: {fruit.Name}, Color: {fruit.Color}, Price: ${fruit.Price:F2}"
            );
        }
    }
}
