using System.Text;

namespace Lekce11.OrderStructure
{
    public class Order
    {
        public OrderHeader Header { get; set; }
        public OrderLine[] Lines { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Header.Name} - {Header.Description}");
            foreach (var line in Lines)
            {
                sb.AppendLine($"{line.Item.Name}- amount: {line.Amount}, price: {line.Price}");
            }

            return sb.ToString();
        }
    }
}
