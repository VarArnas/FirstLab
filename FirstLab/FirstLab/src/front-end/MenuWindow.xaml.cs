﻿using FirstLab.src.back_end.factories.factoryInterfaces;
using FirstLab.src.back_end.utilities;
using FirstLab.XAML;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FirstLab
{
    public partial class MenuWindow : Window
    {
        private HomeView homeView;

        private LogsView logsView;

        private DateTime playWindowEndTime;

        private IServiceProvider serviceProvider;

        public MenuWindow(HomeView homeView, LogsView logsView, IServiceProvider serviceProvider, IFactoryContainer factoryContainer)
        {
            InitializeComponent();
            InitializeMenuFields(homeView,logsView, serviceProvider, factoryContainer);
        }

        private void InitializeMenuFields(HomeView homeView, LogsView logsView, IServiceProvider serviceProvider, IFactoryContainer factoryContainer)
        {
            this.homeView = homeView;
            contentControl.Content = homeView;
            this.logsView = logsView;
            this.serviceProvider = serviceProvider;
            ViewsUtils.menuWindowReference = this;
            StringExtensions.factoryContainer = factoryContainer;
        }

        private void MenuWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation opacityAnimation = serviceProvider.GetRequiredService<DoubleAnimation>();
            opacityAnimation.From = 1.0;
            opacityAnimation.To = 0.1;
            opacityAnimation.Duration = TimeSpan.FromSeconds(2);
            opacityAnimation.AutoReverse = true;
            opacityAnimation.RepeatBehavior = RepeatBehavior.Forever;
            breathingEllipse.BeginAnimation(Ellipse.OpacityProperty, opacityAnimation);
        }

        private void MovingWindow(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ReturnToHomeView(object sender, RoutedEventArgs e)
        {
           if(contentControl.Content is PlayWindow)
           {
                playWindowEndTime = DateTime.Now;
                logsView.CalculateAndCreateLog(homeView.flashcardOptionsView.playWindowStartTime, playWindowEndTime, homeView.flashcardOptionsView.flashcardSet);
           } 
           else if (contentControl.Content is FlashcardCustomization) 
           {
                MessageBox.Show("There are unsaved changes!!");
                return;
           }
           ViewsUtils.ChangeWindow("Menu", homeView);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AccessLogs_Click(object sender, RoutedEventArgs e)
        {
            if (contentControl.Content is PlayWindow)
            {
                playWindowEndTime = DateTime.Now;
                logsView.CalculateAndCreateLog(homeView.flashcardOptionsView.playWindowStartTime, playWindowEndTime, homeView.flashcardOptionsView.flashcardSet);
            }
            else if (contentControl.Content is FlashcardCustomization)
            {
                MessageBox.Show("There are unsaved changes!!");
                return;
            }
            ViewsUtils.ChangeWindow("Logs", logsView);
        }
    }
}
