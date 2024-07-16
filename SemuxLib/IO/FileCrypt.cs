namespace libSemux.Modules.IO
{
    public static class FileCrypt
    {
        private static string LOCAL_PATH_DIR = "Data";
        public static async Task<string> ReadAsync(this string name)
        {
            return await File.ReadAllTextAsync(Path.Combine(LOCAL_PATH_DIR, name));
        }
        public static async Task WriteAsync(this string name, string data)
        {
            await File.WriteAllTextAsync(Path.Combine(LOCAL_PATH_DIR, name), data);
        }
    }
}
