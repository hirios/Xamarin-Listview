using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;


namespace primeiroAPP
{
    public partial class MainPage : ContentPage
    {
        PYTHON PYTHON = new PYTHON();

        public MainPage()
        {
            InitializeComponent();
        }

        public async void clicado(object sender, EventArgs e)
        {
            string pesquisa = "My hero";
            string output = await PYTHON.Requests("http://187.56.241.214:5000/" + pesquisa);
            ParseItem date = JsonConvert.DeserializeObject<ParseItem>(output);
            listview.ItemsSource = date.Items;
        }


        private CancellationTokenSource throttleCts = new CancellationTokenSource();

        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
            Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token) // if no keystroke occurs, carry on after 500ms
                .ContinueWith(
                    delegate { PerformSearch(e.NewTextValue); }, // Pass the changed text to the PerformSearch function
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async void PerformSearch(string FilterString)
        {
            string pesquisa = FilterString;
            string output = await PYTHON.Requests("http://187.56.241.214:5000/" + pesquisa);
            ParseItem date = JsonConvert.DeserializeObject<ParseItem>(output);
            listview.ItemsSource = date.Items;
        }
    }
}
