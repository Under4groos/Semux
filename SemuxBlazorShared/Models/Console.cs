using System.Diagnostics;

namespace SemuxBlazorShared.Models
{
    public class Console
    {
        public static void WriteLine(object obj)
        {
            System.Console.WriteLine(obj);
            Debug.WriteLine(obj);
        }
    }
}
