namespace Delivery.Domain.Common;

public abstract class Entity
{
    private int? _requestHashCode;
    private Guid _id;

    public virtual Guid Id
    {
        get => _id;
        protected set => _id = value;
    }

    public bool IsTransient() => this.Id == default(Guid);

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Entity)) return false;

        if (ReferenceEquals(this, obj)) return true;

        if (GetType() != obj.GetType()) return false;

        Entity item = (Entity)obj;

        if (item.IsTransient() || IsTransient()) 
            return false;
        else 
            return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (IsTransient())
        {
            return base.GetHashCode();
        }
        else
        {
            if (_requestHashCode.HasValue)
                return _requestHashCode.Value;

            _requestHashCode = this.Id.GetHashCode() ^ 31;
            return _requestHashCode.Value;
        }
    }
}