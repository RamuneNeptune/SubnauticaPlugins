
namespace RamuneLib.Utils
{
    public static class Log
    {
        public static void Colored(string color, string text)
        {
            ErrorMessage.AddError(color + text + Colors.End);
        }
    }
}
