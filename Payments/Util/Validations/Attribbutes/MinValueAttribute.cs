using Payments.Extensions;
using Payments.Properties;
using System.ComponentModel.DataAnnotations;
namespace Payments.Util.Validations.Attribbutes
{
    /// <summary>
    /// 最小值
    /// </summary>
    public class MinValueAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            if (!name.IsEmpty())
            {
                return name;
            }
            return string.Format(PayResource.GreateThan, Value);
        }
        public double Value { get; }

        public bool IsContain { get; }

        public MinValueAttribute(double value, bool isContaion = false)
        {
            Value = value;
            IsContain = IsContain;
        }
        public override bool IsValid(object @value)
        {
            if (double.TryParse(@value?.ToString(), out double decimalValue))
            {
                if (IsContain)
                {
                    if (decimalValue >= Value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (decimalValue > Value)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

    }
}
