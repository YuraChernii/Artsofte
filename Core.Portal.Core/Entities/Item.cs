
namespace Core.Portal.Core.Entities
{
    public class Item: AggregateId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
    }
}
