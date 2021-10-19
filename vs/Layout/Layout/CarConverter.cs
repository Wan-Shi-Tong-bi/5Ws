using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout
{
    class CarConverter: UriTypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string)
            {
                string sval = value as string;
                if (string.IsNullOrEmpty(sval))
                 return new Car { Brand = "No Brand", PS = 0 };
                else
                {
                    string[] teile = sval.Split(' ');
                    int iPS = 0;
                    if (teile.Length >= 2 && int.TryParse(teile[1], out iPS))
                        return new Car { Brand = teile[0], PS = iPS };
                }
                
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
