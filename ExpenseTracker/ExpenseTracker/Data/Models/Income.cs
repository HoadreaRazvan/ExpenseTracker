namespace ExpenseTracker.Data.Models
{

    using System.ComponentModel;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }
    }

    public enum IncomeType
    {
        [Description("Salary")]
        Salary,

        [Description("Scholarship")]
        Scholarship,

        [Description("Gift")]
        Gift,

        [Description("Lucky Winnings")]
        LuckyWinnings
    }


    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IncomeType Type { get; set; }
    }
}
