using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Text.RegularExpressions;

namespace OffersXamarin
{
	[Activity(Label = "Детали предложения")]
	public class DetailsActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_details);

			TextView textView = FindViewById<TextView>(Resource.Id.textView);
			string json = Intent.GetStringExtra("Offer");
			textView.Text = Regex.Unescape(json);

			Button returnButton = FindViewById<Button>(Resource.Id.return_button);
			returnButton.Click += delegate
			{
				Finish();
			};
		}
	}
}