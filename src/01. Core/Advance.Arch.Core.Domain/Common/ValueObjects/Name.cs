namespace Advance.Arch.Core.Domain.Common.ValueObjects;

public class Name : BaseValueObject<Name>
{
    public string Value { get; private set; }

    public Name(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(Name name) => name.Value;
    public static implicit operator Name(string value) => new(value);


    #region Methods

    public static Name FromString(string value) => new(value);
    public override string ToString() => Value;

    #endregion
}