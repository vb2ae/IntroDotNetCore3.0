# Introduction to .Net Core 3.0
Introduction to .Net Core 3.0

C#8 was released with .net core 3.0. We will be speaking about the new features like Nullable Reference Type, Async streams, Default Interface members, and some changes to the switch statement.

We will talk about some of the new things added to .net core 3.0 like Windows Forms, WPF, and gRPC.


# Asynchronous streams

Basically IAsyncEnumerable<T> is an asynchronous version of IEnumerable<T>.   To use it in a you await a foreach loop to consume the elements

```cs
await foreach (var location in GetISSLocationSequence())
{
    Console.WriteLine(location);
}
```

GetISSLocationSequence is an async function which yield 20 IIS locations.  
It waits 2 second between getting locations

```cs
public static async System.Collections.Generic.IAsyncEnumerable<string> GetISSLocationSequence()
{
    using HttpClient http = new HttpClient();
    for (int i = 0; i < 20; i++)
    {
        var json = await http.GetStringAsync("http://api.open-notify.org/iss-now.json");
        await Task.Delay(2000);
        yield return json;
    }
}
```
      
One thing worth noting is that the new way you can use an using block.  Once declared like below it will be disposed of when exiting the function

```cs
using HttpClient http = new HttpClient();
```


When creating a console application if you want to use async in the main function change it from a void to async Task

```cs
        static async Task Main(string[] args)
        {
            await foreach (var location in GetISSLocationSequence())
            {
                Console.WriteLine(location);
            }
        }
```


# Default interface members

You can now add default implementions for functions in Interfaces in c# 8.   This is similar to Abstract Classes.  I would probably only use this for simple calulations that wont get an error.

Here is a simple example which adds to properties to a IRoom interface.  I also added a function which multiplies the length by width to get the Square feet of the room

```cs
    public interface IRoom
    {
        public double length { get; set; }

        public double width { get; set; }

        public double SquareFeet { get => length * width; }
    }
```

Here is a class which implements the interface.

```cs
    public class LivingRoom : IRoom
    {
        public double length { get; set; }
        public double width { get; set; }
    }
```

You can see when using the class you have access to the SquareFeet propery

```cs
   IRoom livingRoom = new LivingRoom { length = 12, width = 10 }; 

   Console.WriteLine($"Square feet in living room {livingRoom.SquareFeet}");
```

# Pattern Matching

There is also some changes in pattern matching.  You can now match pattern with enum, tuples, properties in classes, etc..

An example of matching a property in a class you can see below


```cs
            string size = livingRoom switch
            {
                { width: 12 } => size = "Perfect dozen width",
                { length: 12 } => size = "Perfect dozen length",
                _ => size = "Not a perfect dozen size"
            };
```

You put the property names in { } with a : to the expected value.  {PropertyName: Value}.   Use this _ for else.


# Nullable reference types

One new feature in C# 8 is Nullable reference types.   Once this is turned you will get warning telling you about possible places you could get a null reference exceptions

To turn it on for the whole project by editing the project file and adding 2 lines into the PropertyGroup

```xml
    <LangVersion>8.0</LangVersion>
    <Nullable>enabled</Nullable>
  </PropertyGroup>
```

The other way to do if you only want to do it for one file is by adding the line to top of cs file.  Make sure you are using C# 8 before doing so.  The main reason to do by file is this project was migrated to .Net Core 3.0 and you would need to make a lot of changes at once.

```cs
#nullable enable

namespace NullableDemo
```

