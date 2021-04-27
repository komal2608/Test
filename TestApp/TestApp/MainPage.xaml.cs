using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        DataModel _userData = new DataModel();
        public DataModel UserData { get { return _userData; } set { _userData = value; } }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

            UserData.data = new ObservableCollection<MainModel>();
            Task.Run(async () => { await GetData(); }); 
        }

        public async void submit_clicked (object s, EventArgs eventArgs)
        {
            //this.submittedFirstName.Text = this.firstName.Text;
            //this.submittedLastName.Text = this.lastName.Text;
            //this.submittedEmail.Text = this.email.Text;
            //GetData();
            MainModel mvm = new MainModel();

            mvm.firstName = this.firstName.Text;
            mvm.lastName = this.lastName.Text;
            mvm.email = this.email.Text;
            await PostData(mvm);
            await GetData();
        }

        public async Task GetData()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://cila-test-api.herokuapp.com/v1/users");
            var response = JsonConvert.DeserializeObject<DataModel>(result);
            UserData = response;

            Device.BeginInvokeOnMainThread(() => {
                userListView.ItemsSource = null;
                userListView.ItemsSource = UserData.data;
            });

        }
        public async Task PostData(MainModel pmvm)
        {
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(pmvm);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://cila-test-api.herokuapp.com/v1/users", data);

            if (response.IsSuccessStatusCode)
                 await DisplayAlert("TestApp", "Data submitted successfully", "Ok");
        }
    }
}
