using System.Globalization;

namespace MyStoreWinApp.Utility
{
    public enum DateTimeCompareType
    {
        Equal,
        EarlierThan,
        LaterThan
    }

    public sealed class BuiltInFormat
    {
        public string Format { get; }

        private BuiltInFormat(string format) => Format = format;

        public static readonly BuiltInFormat ddMMyyyy = new BuiltInFormat("dd/MM/yyyy");
        public static readonly BuiltInFormat ddMMyyyy_HHmmss = new BuiltInFormat("dd/MM/yyyy HH:mm:ss");
        public static readonly BuiltInFormat Default = ddMMyyyy;
        public static readonly BuiltInFormat MMddyyyy = new BuiltInFormat("MM/dd/yyyy");
        public static readonly BuiltInFormat ddMMyy = new BuiltInFormat("dd/MM/yy");
    }

    public sealed class DateTimeHelper
    {
        public BuiltInFormat OutputFormat { get; set; } = BuiltInFormat.Default;

        private static readonly DateTimeHelper Default = new DateTimeHelper();
        public static DateTimeHelper Instance { get => Default; }

        public DateTimeHelper() { }

        /// <summary>
        /// Return a string that represent for the inputDateTime based on this instance OutputFormat
        /// </summary>
        /// <remarks>Throw <see cref="ArgumentNullException"/> if OutputFormat is set <b>null</b> </remarks>
        /// <param name="inputDateTime"></param>
        /// <exception cref="ArgumentNullException">
        ///     When <paramref name="instance" /> is null
        /// </exception>
        /// <returns>string represent for the inputDateTime</returns>
        public string ToStringWithCurrentOutputFormat(DateTime? inputDateTime)
        {
            if (OutputFormat is null) throw new ArgumentNullException("Please input valid BuiltInFormat");
            return inputDateTime.HasValue ? inputDateTime?.ToString(OutputFormat.Format) : "";
        }

        public string ToStringWithFormat(DateTime? inputDateTime, BuiltInFormat format)
        {
            if (format is null) throw new ArgumentNullException("Please input valid BuiltInFormat");
            return inputDateTime.HasValue ? inputDateTime?.ToString(format.Format) : "";
        }

        public DateTime ToDateTimeWithFormat(string input)
        {
            if (OutputFormat is null) throw new ArgumentNullException("Please input valid BuiltInFormat");
            return DateTime.ParseExact(
                        input,
                        format: OutputFormat.Format,
                        provider: CultureInfo.InvariantCulture,
                        style: DateTimeStyles.None);
        }

        public bool Compare(DateTime t1, DateTime t2, DateTimeCompareType type, bool datePartOnly)
        {
            t1 = datePartOnly ? t1.Date : t1;
            t2 = datePartOnly ? t2.Date : t2;

            return type switch
            {
                DateTimeCompareType.Equal => t1.CompareTo(t2) == 0,
                DateTimeCompareType.EarlierThan => t1.CompareTo(t2) < 0,
                DateTimeCompareType.LaterThan => t1.CompareTo(t2) > 0,
                _ => true
            };
        }
    }
}
