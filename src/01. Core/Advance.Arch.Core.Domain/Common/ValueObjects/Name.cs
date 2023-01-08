namespace Advance.Arch.Core.Domain.Common.ValueObjects;

public class Name : BaseValueObject<Name>
{
    public string Value { get; set; }

    public Name(string value)
    {
        Value = value;
    }

    public override bool ObjectIsEqual(Name otherObject) => Value == otherObject.Value;
    public override int ObjectGetHashCode() => Value.GetHashCode();

    public static explicit operator string(Name name) => name.Value;
    public static implicit operator Name(string value) => new(value);

    #region Methods

    public static Name FromString(string value) => new(value);
    public override string ToString() => Value;

    #endregion
}