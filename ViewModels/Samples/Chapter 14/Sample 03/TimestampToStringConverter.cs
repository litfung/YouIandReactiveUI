namespace Book.ViewModels.Samples.Chapter14.Sample03
{
    using ReactiveUI;
    using System;

    public sealed class TimestampToStringConverter : IBindingTypeConverter
    {
        public static readonly TimestampToStringConverter Instance =
            new TimestampToStringConverter();

        private TimestampToStringConverter()
        {
        }

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            if (toType == typeof(string) && fromType == typeof(Timestamp))
            {
                return 100;
            }

            return 0;
        }

        public bool TryConvert(
            object from,
            Type toType,
            object conversionHint,
            out object result)
        {
            var timestamp = (Timestamp)from;

            result = new DateTime(timestamp.Ticks).ToString("HH:mm:ss");
            return true;
        }
    }
}