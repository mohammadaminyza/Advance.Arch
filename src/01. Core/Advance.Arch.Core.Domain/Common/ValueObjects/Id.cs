namespace Advance.Arch.Core.Domain.Common.ValueObjects;

public class Id : BaseValueObject<Id>
{
    public Guid Value { get; private set; }

    public Id(Guid value)
    {
        Value = value;
    }
    public Id(string value)
    {
        Value = Guid.Parse(value);
    }

    public Id()
    {
        Value = Guid.NewGuid();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator Guid(Id id) => id.Value;
    public static implicit operator Id(Guid value) => new(value);

    #region Methods

    public static Id FromGuid(Guid value) => new(value);
    public static Id FromString(string value) => new(value);
    public static Id NewId() => new();

    #endregion
}