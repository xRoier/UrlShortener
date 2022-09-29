[![Github All Releases](https://img.shields.io/github/downloads/xRoier/UrlShortener/total?color=blueviolet&style=for-the-badge)]()
# UrlShortener
Simple Url Shortener written in C#

**This Url Shortener makes use of a MySQL database to fetch the Urls, it supports expirable Urls after X time**

## Configuration
You can find the configuration file as ``appsettings.json``
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "MySQL": {
    "Host": "localhost",
    "Port": 3306,
    "Database": "database",
    "Username": "root",
    "Password": "password"
  },
  "RunningPort": 5000,
  "NotFoundResponse": "Nothing Here"
}
```
<h5>The only interesting things in here:</h5>
<h4>**MySQL Section**: ``It contains the MySQL connection values.``</h4>
<h4>**RunningPort**: ``It defines in what port the program should run (5000 by default).``</h4>
<h4>**NotFoundResponse**: ``It defines the response that the program should display to a user when they try to open an invalid URL.``</h4>
_Everything else is just Asp.NET junky stuff, you can ignore that._

## Executing

### Linux
I recommend using some sort of terminal instancing, something like ``screen`` or ``tmux`` on Linux.

To run it just use:
```shell
# Add executing permissions to the file.
chmod +x UrlShortener

# (Recommended) Run it with screen, this will create an unattached screen running the program.
screen -dmS UrlShortener ./UrlShortener
# OR
# Execute the program as it is.
./UrlShortener
```

### Windows
Just execute ``UrlShortener.exe`` and have fun.

## Adding URLs
Right now the only way to do this is inserting the Urls from MySQL or PhpMyAdmin, I'll create another way to do this in a future, for example using a POST endpoint.

## MySQL Structure
**Simple but it works.**
<br/>
![](https://i.imgur.com/VS2p0H3.png)