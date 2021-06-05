﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using MyTodo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTodo.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel() { IconFont = "\xe635", BackColor = "#FF3E8E6C", Title = "我的一天", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe6b6", BackColor = "#FFAC395D", Title = "重要", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe6e1", BackColor = "#836FFF", Title = "已计划日程", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe614", BackColor = "#9400D3", Title = "已分配给你", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe755", BackColor = "#FFD700", Title = "任务", Count = 2 });
        }


        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { SetProperty(ref menuModels,value); }
        }

    }
}