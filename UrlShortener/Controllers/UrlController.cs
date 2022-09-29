using LinqToDB;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Interfaces;

namespace UrlShortener.Controllers;

[ApiController]
public class UrlController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult Get(string id)
    {
        using var db = new DataConnection();
        var query = db.GetTable<Url>().FirstOrDefault(x => x.Id == id);

        if (query == null)
            return NotFound("Nothing here");

        if (query.TimeToLive == null || query.TimeToLive > DateTime.Now)
            return Redirect(query.RedirectUrl);

        db.Delete(query);
        return NotFound("Nothing here");
    }
}