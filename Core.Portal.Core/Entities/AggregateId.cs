namespace Core.Portal.Core.Entities
{
    public abstract class AggregateId: IEquatable<AggregateId>
    {
        public int Id { get; set; }

        public AggregateId()
        {
                
        }
        public AggregateId(int value)
        {
            if (value == 0)
            {
                throw new Exception("Invalid AggregateId");
            }

            Id = value;
        }

        public bool Equals(AggregateId other)
        {
            if (Id == 0)
            {
                throw new Exception("Invalid AggregateId");
            }
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (Id == 0)
            {
                throw new Exception("Invalid AggregateId");
            }
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AggregateId)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
