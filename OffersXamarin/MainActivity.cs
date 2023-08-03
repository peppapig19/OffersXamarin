using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using System.Text.Json;
using System.Net.Http;
using System.IO;

namespace OffersXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);

			Offer[] offers = Task.Run(async () => await GetAsync()).Result.Shop.Offers;
			List<int> ids = offers.Select(o => o.Id).ToList();

			ListView listView = FindViewById<ListView>(Resource.Id.listView);
			listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, ids);

			listView.ItemClick += (s, e) => {
				Offer offer = offers[e.Position];

				Intent intent = new Intent(this, typeof(DetailsActivity));
				intent.PutExtra("Offer", JsonSerializer.Serialize(offer));
				StartActivity(intent);
			};
		}

		async Task<YmlCatalog> GetAsync()
		{
			YmlCatalog catalog;

			using (HttpClient client = new HttpClient())
			{
				Stream content = await client.GetStreamAsync("http://partner.market.yandex.ru/pages/help/YML.xml");

				XmlSerializer serializer = new XmlSerializer(typeof(YmlCatalog));
				catalog = (YmlCatalog)serializer.Deserialize(content);
			}

			return catalog;
		}
	}
}