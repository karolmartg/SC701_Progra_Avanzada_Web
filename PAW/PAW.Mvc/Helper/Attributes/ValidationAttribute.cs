using System.ComponentModel.DataAnnotations;

namespace PAW.Mvc.Helper.Attributes;

public class ValidateID : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if ((int)value < 0 && (int)value < int.MaxValue)
            return true;
        return base.IsValid(value);
    }
}