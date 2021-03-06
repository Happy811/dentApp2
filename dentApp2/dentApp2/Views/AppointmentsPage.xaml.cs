﻿using dentApp2.Models;
using dentApp2.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dentApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentsPage : ContentPage
    {
        AppointmentsViewModel AppointmentsViewModel;

        public AppointmentsPage()
        {
            InitializeComponent();
            BindingContext = AppointmentsViewModel = new AppointmentsViewModel();
        }

        async void ItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new AppointmentItemDetailPage(item));
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void ToolbarItem_Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage(Item.status.Appointment));
        }
    }
}