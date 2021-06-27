using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;



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
            string output = await PYTHON.Requests("https://api.reelgood.com/v3.0/content/search/content?page=1&pageSize=50&region=us&take=50&terms=" + pesquisa);
            ParseItem date = JsonConvert.DeserializeObject<ParseItem>(output);
            listview.ItemsSource = date.Items;
        }

        public async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            string pesquisa = searchBar.Text;
            string output = await PYTHON.Requests("https://api.reelgood.com/v3.0/content/search/content?page=1&pageSize=50&region=us&take=50&terms=" + pesquisa);
            ParseItem date = JsonConvert.DeserializeObject<ParseItem>(output);
            listview.ItemsSource = date.Items;
        }

    }
}
