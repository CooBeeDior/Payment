using Newtonsoft.Json;
using Payments.Extensions;
using Payments.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Util.Validations.Attribbutes
{
    /// <summary>
    /// 对象最大长度
    /// </summary>
    public class MaxLengthObjectToJson : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            if (!name.IsEmpty())
            {
                return name;
            }
            return string.Format(PayResource.MaxLeng, Value);
        }
        public int Value { get; }

        public bool IsContain { get; }

        public MaxLengthObjectToJson(int value, bool isContaion = false)
        {
            Value = value;
            IsContain = IsContain;
        }
        public override bool IsValid(object @value)
        {
            if (@value.IsNull())
            {
                return true;
            }
            else
            {
                string jsonStr = @value.ToJson();
                if (IsContain)
                {
                    if (jsonStr.Length <= Value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (jsonStr.Length < Value)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

    }
}
