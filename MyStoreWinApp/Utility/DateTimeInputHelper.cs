using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace MyStoreWinApp.Utility
{
    public class DateTimeInputHelper : IInputHelper<string>
    {
        public static readonly string DateFormat = "dd/MM/yyyy";

        [RegularExpression("^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$")]
        public string Input { get; set; }
        public DateTime CompareDate { get; set; }
        public DateTimeCompareType CompareType { get; set; }

        public bool ValidateInput()
        {
            try
            {
                Input = PreProcessInput(Input);
                Validator.ValidateObject(this, new ValidationContext(this), true);
                DateTime inputDate;

                bool isValid = DateTime.TryParseExact
                (
                    Input,
                    format: DateFormat,
                    provider: CultureInfo.InvariantCulture,
                    style: DateTimeStyles.None,
                    out inputDate
                );
                if (!isValid) return false;

                // If no CompareDate
                if (CompareDate == default) return true;

                return CompareType switch
                {
                    DateTimeCompareType.Equal => inputDate.CompareTo(CompareDate) == 0,
                    DateTimeCompareType.EarlierThan => inputDate.CompareTo(CompareDate) < 0,
                    DateTimeCompareType.LaterThan => inputDate.CompareTo(CompareDate) > 0,
                    _ => true
                };
            }
            catch (ValidationException)
            {
                return false;
            }
        }

        private string PreProcessInput(string input)
        {
            var tokens = $"{string.Empty + input}".Split("/", StringSplitOptions.TrimEntries);
            if (tokens.Length != 3) return string.Empty;

            var stringBuilder = new StringBuilder();
            string date = tokens[0].Length <= 1 ? "0" + tokens[0] : $"{tokens[0]}";
            string month = tokens[1].Length <= 1 ? "0" + tokens[1] : $"{tokens[1]}";
            string year = tokens[2];
            stringBuilder.Append(date).Append('/').Append(month).Append('/').Append(year);
            return stringBuilder.ToString();
        }
    }
}
