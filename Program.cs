using JsonIsNotJustAnyJson.Adapters;
using JsonIsNotJustAnyJson.Transformers;


class Program
{
    static async Task Main(string[] args)
    {
        var adapter = new Adapter();

        var response = adapter.Receive().Result;

        var transformer = new WeatherDataTransformer();

        var transformed = transformer.Transform(response);

        Console.WriteLine(transformed.WeatherDescription);
    }
}