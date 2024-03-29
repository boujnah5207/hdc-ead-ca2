﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using UserList.Resources;
using System.Collections.Generic;
using Newtonsoft.Json;
using UserList.Models;


namespace UserList.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://localhost:3242/api/User";
        
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            if (this.IsDataLoaded == false)
            {
                this.Items.Clear();
                this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "Please Wait...", LineTwo = "Please wait while the catalog is downloaded from the server.", LineThree = null });
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }

        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.Items.Clear();
                if (e.Result != null)
                {
                    var users = JsonConvert.DeserializeObject<UserInfo[]>(e.Result);
                    int id = 0;
                    foreach (UserInfo user in users)
                    {
                        this.Items.Add(new ItemViewModel()
                        {
                            ID = (id++).ToString(),
                            LineOne = user.Name,
                            LineTwo = user.Phone_Number,
                            LineThree = user.Post_Code
                        });
                    }
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    LineOne = "An Error Occurred",
                    LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}