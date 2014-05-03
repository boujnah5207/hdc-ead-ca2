using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.Http;
using System.Net.Http.Headers;
using DatingPhoneApp.Resources;
using CA_Mini_Project_V4.Models;

namespace DatingPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // URI for RESTful service (implemented using Web API)
        private const String serviceURI = "http://ITTDating.cloudapp.net/";

        //Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        //display user when button clicked
        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(serviceURI);                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../api/User
                    // get all stock Users asynchronously - await the result (i.e. block and return control to caller)
                    HttpResponseMessage response = await client.GetAsync("api/User");

                    // continue
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result and display on UI

                        var users = await response.Content.ReadAsAsync<IEnumerable<UserInfo>>();

                        // set the data source for the priceList long list selector
                        userList.ItemsSource = new ObservableCollection<UserInfo>(users);
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception)
            {
                //;
            }
        }


        
        }
    }


