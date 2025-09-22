using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }


        private async Task Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                            $"Longitude: {t.lon} \n" +
                            $"Nascer do sol: {t.sunrise} \n" +
                            $"Por do sol: {t.sunset} \n" +
                            $"Temperatura Maxima: {t.temp_max} \n" +
                            $"Temperatura Minima: {t.temp_min} \n";

                    }
                    else
                    {
                        lbl_res.Text = "Sem dados de previsão.";
                    }

                }
                else
                {
                    lbl_res.Text = "Preencha a Cidade.";
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");

            }
        }
    }

}