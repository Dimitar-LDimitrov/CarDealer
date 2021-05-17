namespace CarDealer.App.Infrastructure.Extentions
{
    public static class StringExtentions
    {
        public static string ToPrice(this double price)
        {
            return $"${price.ToString("F2")}";
        }

        public static string ToPercentage(this double number)
        {
            return $"{number.ToString("F2")}%";
        }
    }
}
