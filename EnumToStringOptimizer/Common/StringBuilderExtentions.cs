using System.Text;

namespace EnumToStringOptimizer.Common
{
    public static class StringBuilderExtentions
    {
        public const string TAB = "    ";
        public static StringBuilder AppendLine(this StringBuilder sb, string text, int margin)
        {
            sb.AppendLine($"{Margin(margin)}{text}");
            return sb;
        }

        private static string Margin(int number)
        {
            StringBuilder marginBuilder = new();
            for (int i = 0; i < number; i++)
            {
                marginBuilder.Append(TAB);
            }
            return marginBuilder.ToString();
        }
    }
}
