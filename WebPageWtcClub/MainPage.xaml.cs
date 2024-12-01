using Azure.Identity;
using WebPageWtcClub.ContextDataBase;

namespace WebPageWtcClub
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }       
        public void LoginClient(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(passWord.Text) && !string.IsNullOrEmpty(userName.Text))
            {
                WtcContext context = new WtcContext();
                //var numberUrl = context.ConsultarLoginCliente(userName.Text, passWord.Text);

                var urlRequest = $"https://evento.wtcclub.com.br/perguntas.aspx?{4939}-{013351}"; //Mudar 4909 para 0 para o bruno tratar
                Launcher.OpenAsync(urlRequest).Wait();
            }
            else
            {
                DisplayAlert("Alert", "Usarname or Passwoord not informed", "Ok");
            }
        }
    }
}
