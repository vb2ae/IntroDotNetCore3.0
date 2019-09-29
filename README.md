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
