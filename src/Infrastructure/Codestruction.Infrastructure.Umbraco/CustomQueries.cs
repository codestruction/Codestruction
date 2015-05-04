using System;
using Codestruction.Infrastructure.Umbraco;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace Codestruction.Infrastructure.Umbraco
{
    public static class CustomQueries
    {
        
    public static MultiFieldQueryParser GetParser()
    {
        return new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29,
            new string[] {Consts.ContentIndexFields.Title, Consts.ContentIndexFields.Content},
            new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
    }

    public static string Content(string query)
    {
        var parser = GetParser();

        var titleQuery = parser.GetWildcardQuery(Consts.ContentIndexFields.Title, query.RightWildcard());
        titleQuery.SetBoost(5f);

        var teaserQuery = parser.GetFieldQuery(Consts.ContentIndexFields.Teaser, query.RightWildcard());
        teaserQuery.SetBoost(0.5f);

        var contentQuery = parser.GetFieldQuery(Consts.ContentIndexFields.Content, query.RightWildcard());
        contentQuery.SetBoost(0.5f);

        var booleanQuery = new BooleanQuery();

        booleanQuery.Add(titleQuery, BooleanClause.Occur.SHOULD);
        booleanQuery.Add(contentQuery, BooleanClause.Occur.SHOULD);
        booleanQuery.Add(teaserQuery, BooleanClause.Occur.SHOULD);
        return booleanQuery.ToString();
    }
}
}
