using GuamanEjercicioApi.Models;
using Newtonsoft.Json;

namespace GuamanEjercicioApi.Views;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
		AGlat.Text = "-0.22";
        AGlon.Text = "-78.52";
    }

    private async void AGConsultar(object sender, EventArgs e)
    {
		String AGlatitud = AGlat.Text;
        String AGlongitud = AGlon.Text;

		if(Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient())
			{
				string AGurl = $"https://api.openweathermap.org/data/2.5/weather?lat=" + AGlatitud + "&lon=" + AGlongitud + "&appid=2ba66bfe1fe9e531068d9bd9e868a33e";
				var AGresponse  = await client.GetAsync(AGurl);
				if (AGresponse.IsSuccessStatusCode)	
				{
					var AGjson = await AGresponse.Content.ReadAsStringAsync();
                    var AGclima = JsonConvert.DeserializeObject<Rootobject>(AGjson);




                    AGweatherLabel.Text = "  "+AGclima.weather[0].main;
					AGcityLabel.Text = AGclima.name;
					AGpaisLabel.Text = AGclima.sys.country;
					AGtempLabel.Text = "" + AGclima.main.temp;
					AGhumedadLabel.Text = "" + AGclima.main.humidity;
					

                }
			}
		}
    }
}