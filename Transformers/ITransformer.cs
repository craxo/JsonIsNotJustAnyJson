using Newtonsoft.Json.Linq;

namespace JsonIsNotJustAnyJson.Transformers
{
    public interface ITransformer<TInput, TOutput>
    {
        TOutput Transform(JObject input);
    }
}
