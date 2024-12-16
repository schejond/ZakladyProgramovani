using Newtonsoft.Json;

namespace Lekce11.OrderStructure
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        public DateTime DataOfMaking { get; set; }
    }
}
