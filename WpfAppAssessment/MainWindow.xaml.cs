using NETWORKLIST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfAppAssessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Details details;
        private readonly INetworkListManager _networkListManager;


        public MainWindow()
        {
            InitializeComponent();
            _networkListManager = new NetworkListManager();
            GetRequest();
        }
        public async void GetRequest()
        {
            try
            {
                if (IsConnected())
                {
                    Uri getUri = new Uri("https://assets.acmeaom.com/interview-project/uwpvideos.json");
                    HttpClient client = new HttpClient();
                    HttpResponseMessage responseGet = await client.GetAsync(getUri);
                    responseGet.EnsureSuccessStatusCode(); // Throw if not a success code.
                    string content = await responseGet.Content.ReadAsStringAsync();
                    ListInfo.ItemsSource = JsonConvert.DeserializeObject<List<Root>>(content);
                }
                else
                {
                    MessageBox.Show("No internet access!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

        }

        public bool IsConnected()
        {
            return _networkListManager.IsConnectedToInternet;
        }

        private void ListInfo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (details == null)
            {
                details = new Details();

            }
            // Show the window
            if (ListInfo.SelectedItem != null)
            {
                try
                {
                    var item = ListInfo.SelectedItem as Root;
                    details.Id.Text = item.id;
                    details.Title.Text = item.title;
                    details.BulletText.Text = item.bulletText;
                    details.Description.Text = item.description;
                    details.RunningTime.Text = Convert.ToString(item.runningTime);


                    details.ArtUrl.Source = (new ImageSourceConverter()).ConvertFromString(item.artUrl) as ImageSource;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                details.Show();

            }
        }


    }
}
