using Sitecore.Data;

namespace Sitecore.Feature.Blog
{
    public static class Templates
    {
        public struct BlogFolder
        {
            public const string ID_String = "{2CB58622-B8CC-4A14-B02E-AF6BFACB7A67}";
            public static readonly ID ID = new ID(ID_String);
        }

        public struct BlogArticle
        {
            public const string ID_String = "{866F64BE-080F-4B3B-A324-41E04EEC1AA9}";
            public static readonly ID ID = new ID(ID_String);

            public struct Fields
            {
                public const string Date_String = "{1AB8A251-C387-476F-94DA-19B172447371}";
                public static readonly ID Date = new ID(Date_String);
            }
        }

        public struct BlogAuthor
        {
            public const string ID_String = "{E81141E2-8ED0-4072-94A8-768D256DA4FC}";
            public static readonly ID ID = new ID(ID_String);
        }

        public struct ArticleTheme
        {
            public const string ID_String = "{8C34724C-B08F-4B16-9036-4323F94FBED5}";
            public static readonly ID ID = new ID(ID_String);

            public struct Fields
            {
                public const string ArticleType_String = "{2B02516F-74FD-419E-8809-656662A06609}";
                public static readonly ID ArticleType = new ID(ID_String);
            }
        }

        public struct ArticleType
        {
            public const string ID_String = "{56F518DD-D3B1-4D00-9E41-60F27D71393C}";
            public static readonly ID ID = new ID(ID_String);
        }
    }
}
