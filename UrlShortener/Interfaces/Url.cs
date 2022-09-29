using LinqToDB.Mapping;

namespace UrlShortener.Interfaces;

[Table("RedirectUrls")]
public class Url
{
    [Column("id"), PrimaryKey]
    public string Id { get; set; }

    [Column("redirectUrl")]
    public string RedirectUrl { get; set; }

    [Column("ttl"), Nullable]
    public DateTime? TimeToLive { get; set; }
}