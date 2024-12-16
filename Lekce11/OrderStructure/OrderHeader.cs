namespace Lekce11.OrderStructure
{
    public class OrderHeader
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public DateTime OrderedAt { get; set; }
    }
}
