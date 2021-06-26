using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace primeiroAPP
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<ParseItem> NewsItemList = new ObservableCollection<ParseItem>();
        PYTHON python = new PYTHON();
        public MainPage()
        {
            InitializeComponent();
            

        }

        void clicado(object sender, EventArgs e)
        {
            string pesquisa = "My hero";
            string output = python.requests("https://api.reelgood.com/v3.0/content/search/content?page=1&pageSize=50&region=us&take=50&terms=" + pesquisa);
            ParseItem date = JsonConvert.DeserializeObject<ParseItem>(output);

            /*Info initsta1 = new Info() { slug = "teste", title = "testing....1...", isVisible = true };*/
            
            listview.ItemsSource = date.Items;

        }

    }
}
