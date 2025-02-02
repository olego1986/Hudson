namespace Hudson.DB.Extension
{
    public static class DbExtension
    {
        public static async Task<List<T>> ConvertToEnumerable<T>(IAsyncEnumerable<T> asyncEnumerable)
        {
            var list = new List<T>();
            await foreach (var item in asyncEnumerable)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
