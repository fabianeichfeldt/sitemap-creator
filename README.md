# Sitemap-Creator
Creates xml sitemap for better seo support of your website, which is crucial for websites, which are:
- changing frequently
- have many sub sites
- missing links to its sub sites

## Usage

Creates a XML file in sitemap format which can be parsed by most search engines.

```
var sitemap = new SitemapCreator.SitemapCreator();
sitemap.Add(new SiteUrl
{
    Url = $"https://meet2train.de/map/events/{ev.Id}",
    Frequency = ChangeFrequency.Daily,
    Priority = 0.8
});
sitemap.Write("./sitemap.xml");
```

The resulting sitemap needs to be public accessible by search engines. To make the sitemap known to google you need to add this to [Google Search Console](https://search.google.com/search-console)