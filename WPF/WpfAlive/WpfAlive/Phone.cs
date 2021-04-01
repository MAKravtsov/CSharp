using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAlive
{
    public class Phone: DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;

        public static readonly DependencyProperty PriceProperty;

        static Phone()
        {
            var metadata = new FrameworkPropertyMetadata() { CoerceValueCallback = CoerceValueCallback};
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));
            PriceProperty = DependencyProperty.Register("Price", typeof(double), typeof(Phone), metadata, ValidateValueCallback);
        }

        private static object CoerceValueCallback(DependencyObject d, object basevalue)
        {
            var val = (double) basevalue;
            return val > 1000 ? 1000 : val;
        }

        private static bool ValidateValueCallback(object value)
        {
            var val = (double) value;
            return val >= 0;
        }

        public string Title {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public double Price {
            get => (double)GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }
    }
}
