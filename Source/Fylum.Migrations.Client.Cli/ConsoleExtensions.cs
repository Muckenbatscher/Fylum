namespace Fylum.Migrations.Client.Cli;

public static class ConsoleExtensions
{
    extension(Console)
    {
        public static void WriteWhitespaceCharacters(int whitespaceLength)
        {
            for (int i = 0; i < whitespaceLength; i++)
                Console.Write(' ');
        }

        public static void WriteRightPadded(string text, int minimumLength)
        {
            var currentColor = Console.ForegroundColor;
            WriteRightPaddedInColor(text, minimumLength, currentColor);
        }
        public static void WriteRightPaddedInColor(string text, int minimumLength, ConsoleColor color)
        {
            Console.WriteInColor(text, color);
            var remainingLength = minimumLength - text.Length;
            if (remainingLength > 0)
                WriteWhitespaceCharacters(remainingLength);
        }

        public static void WriteLeftPadded(string text, int paddingCharacterCount)
        {
            var currentColor = Console.ForegroundColor;
            WriteLeftPaddednColor(text, paddingCharacterCount, currentColor);
        }
        public static void WriteLeftPaddednColor(string text, int paddingCharacterCount, ConsoleColor color)
        {
            WriteWhitespaceCharacters(paddingCharacterCount);
            Console.WriteInColor(text, color);
        }

        public static void WriteInColor(string text, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = previousColor;
        }
    }
}
