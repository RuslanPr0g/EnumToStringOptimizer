namespace EnumToStringOptimizer.Common
{
    public static class EnumExtensions
    {
        public static string FastToString(this MediaType enumModel)
        {
            string result = enumModel switch
            {
                MediaType.LiveStream => nameof(MediaType.LiveStream),
                MediaType.Video => nameof(MediaType.Video),
                MediaType.Image => nameof(MediaType.Image),
                MediaType.Album => nameof(MediaType.Album),
                _ => throw new System.ArgumentOutOfRangeException(nameof(enumModel), enumModel, null),
            };
            return result;
        }
    }
}
