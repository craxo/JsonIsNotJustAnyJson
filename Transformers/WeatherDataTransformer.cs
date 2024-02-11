using Fluid;
using JsonIsNotJustAnyJson.DTOs;
using Newtonsoft.Json.Linq;

namespace JsonIsNotJustAnyJson.Transformers
{
    public class WeatherDataTransformer : ITransformer<JObject, OurCustomDTO>
    {
        private readonly IFluidTemplate _template;

        public WeatherDataTransformer()
        {
            var templatePath = "Templates/WeatherDataTemplate.liquid";
            var templateSource = File.ReadAllText(templatePath);

            var parser = new FluidParser();
            if (!parser.TryParse(templateSource, out var template, out var error))
            {
                throw new InvalidOperationException($"Failed to parse template: {error}");
            }

            _template = template;
        }

        public OurCustomDTO Transform(JObject input)
        {
            var context = new TemplateContext();
            foreach (var prop in input.Properties())
            {
                context.SetValue(prop.Name, prop.Value.ToObject<object>());
            }

            // Render the template with the context
            var result = _template.Render(context);

            var dto = new OurCustomDTO
            {
                WeatherDescription = result
            };

            return dto;
        }
    }
}
