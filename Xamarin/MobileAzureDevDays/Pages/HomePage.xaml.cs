﻿using System;

using Xamarin.Forms;

using MobileAzureDevDays.ViewModels;

namespace MobileAzureDevDays.Pages
{
    public partial class HomePage : ContentPage
    {
        readonly HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.SentimentAnalyisFailed += HandleSentimentAnalyisFailed;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            viewModel.SentimentAnalyisFailed -= HandleSentimentAnalyisFailed;
        }

        void HandleSentimentAnalyisFailed(object sender, string ErrorMessage) =>
            Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Error", ErrorMessage, "OK"));
    }
}
