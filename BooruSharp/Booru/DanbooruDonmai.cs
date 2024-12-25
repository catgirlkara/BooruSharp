namespace BooruSharp.Booru
{
    /// <summary>
    /// Danbooru.
    /// <para>https://danbooru.donmai.us/</para>
    /// </summary>
    public sealed class DanbooruDonmai : Template.Danbooru
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DanbooruDonmai"/> class.
        /// </summary>
        public DanbooruDonmai()
            : base("danbooru.donmai.us")
        { }

        /// <inheritdoc/>
        public override bool IsSafe => false;
    }
}
