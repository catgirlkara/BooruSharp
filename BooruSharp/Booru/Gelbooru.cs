﻿using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace BooruSharp.Booru
{
    public sealed class Gelbooru : Booru
    {
        public Gelbooru(BooruAuth auth = null) : base("gelbooru.com", auth, UrlFormat.indexPhp, 20000, BooruOptions.noWiki, BooruOptions.noRelated)
        { }

        public override bool IsSafe()
            => false;

        public override Search.Post.SearchResult GetPostSearchResult(object json)
        {
            var elem = ((JArray)json).FirstOrDefault();
            if (elem == null)
                throw new Search.InvalidTags();
            return new Search.Post.SearchResult(
                    new Uri(elem["file_url"].Value<string>()),
                    new Uri("https://gelbooru.com/thumbnails/" + elem["directory"].Value<string>() + "/thumbnail_" + elem["image"].Value<string>()),
                    GetRating(elem["rating"].Value<string>()[0]),
                    elem["tags"].Value<string>().Split(' '),
                    elem["id"].Value<int>(),
                    null,
                    elem["height"].Value<int>(),
                    elem["width"].Value<int>(),
                    null,
                    null,
                    elem["created_at"].Value<DateTime>(),
                    elem["source"].Value<string>(),
                    elem["score"].Value<int>()
                );
        }
    }
}
