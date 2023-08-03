using System.Xml.Serialization;

namespace OffersXamarin
{
	[XmlRoot("yml_catalog")]
	public class YmlCatalog
	{
		[XmlElement("shop")]
		public Shop Shop { get; set; }
	}

	[XmlRoot("shop")]
	public class Shop
	{
		[XmlArray("offers"), XmlArrayItem("offer")]
		public Offer[] Offers { get; set; }
	}

	[XmlRoot("offer")]
	public class Offer
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlAttribute("available")]
		public bool IsAvailable { get; set; }

		[XmlElement("url")]
		public string Url { get; set; }

		[XmlElement("price")]
		public decimal Price { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }
	}
}