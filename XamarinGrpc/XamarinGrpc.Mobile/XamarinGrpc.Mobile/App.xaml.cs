using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinGrpc.Common;
using XamarinGrpc.Mobile.Services;
using XamarinGrpc.Mobile.Views;

namespace XamarinGrpc.Mobile
{
    public partial class App : Application
    {
        public const string address = "https://xamarin-grpc-service.azurewebsites.net";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            try
            {
                await Task.Run(async () =>
                {
                    var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
                    {
                        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                    });
                    var client = new Greeter.GreeterClient(channel);

                    for (int i = 0; i < 10; i++)
                    {
                        var response = await client.SayHelloAsync(new HelloRequest { Name = "World " + i });

                        Debug.WriteLine("Greeting: " + response.Message);
                    }


                });
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
