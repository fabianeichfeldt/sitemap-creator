using System.Xml;
using System.Xml.Serialization;

namespace SitemapCreator;

public class SitemapCreator
{
  private readonly string filePath;
  private List<SiteUrl> urls;

  public SitemapCreator(string filePath)
  {
    this.filePath = filePath;
    urls = new();
  }

  public void AddRange(IEnumerable<SiteUrl> urls)
  {
    this.urls.AddRange(urls);
  }

  public void Add(SiteUrl url)
  {
    this.urls.Add(url);
  }

  public void Write()
  {
    var map = new Sitemap
    {
      Urls = urls.ToArray()
    };


    var writer = XmlWriter.Create(new StreamWriter(filePath));
    var serializer = new XmlSerializer(typeof(Sitemap));

    serializer.Serialize(writer, map);
    writer.Flush();
  }
}

[XmlRoot(Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9", ElementName = "urlset")]
public class Sitemap
{
  [XmlElement(ElementName = "url")] public SiteUrl[] Urls { get; set; } = Array.Empty<SiteUrl>();
}

public class SiteUrl
{
  [XmlElement(ElementName = "loc")] public string Url { get; set; } = string.Empty;
  [XmlElement(ElementName = "priority")] public double Priority { get; set; }

  [XmlElement(ElementName = "changefreq")]
  public ChangeFrequency Frequency { get; set; }

  [XmlElement(ElementName = "lastmod")] public string LastMod { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}

public enum ChangeFrequency
{
  [XmlEnum(Name = "hourly")] Hourly,
  [XmlEnum(Name = "daily")] Daily,
  [XmlEnum(Name = "weekly")] Weekly,
  [XmlEnum(Name = "monthly")] Monthly
}