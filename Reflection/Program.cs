using System.Diagnostics;
using Newtonsoft.Json;

namespace Reflection
{
    public class Program
    {
        static void Main()
        {
            var f = TestedClass.Get();
            var result = string.Empty;
            int inreationCount = 100000;

            Console.WriteLine($"Iterations count: {inreationCount}");
            Console.WriteLine("My implementation:");
            result = Serialize(f, inreationCount, CustomCsvSerializer.Serialize);
            Deserialize(result, inreationCount, CustomCsvSerializer.Deserialize<TestedClass>);

            Console.WriteLine("NewtonsoftJson:");
            result = Serialize(f, inreationCount, JsonConvert.SerializeObject);
            Deserialize(result, inreationCount, JsonConvert.DeserializeObject<TestedClass>);
        }

        static string Serialize(object obj, int testCount, Func<object, string> serializeFunc)
        {
            var serialized = string.Empty;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < testCount; i++)
            {
                serialized = serializeFunc(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Serialization time: {stopwatch.ElapsedMilliseconds} ms");
            return serialized;
        }

        static void Deserialize(string serialized, int testCount, Func<string, object> deserializeFunc)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < testCount; i++)
            {
                var deserialized = deserializeFunc(serialized);
            }
            stopwatch.Stop();
            Console.WriteLine($"Deserialization: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}