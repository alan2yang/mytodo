using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
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
            MenuModels.Add(new MenuModel() { IconFont = "\xe635", BackColor = "#FF3E8E6C", Title = "我的一天", Count = 2,Display=false });
            MenuModels.Add(new MenuModel() { IconFont = "\xe6b6", BackColor = "#FFAC395D", Title = "重要", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe6e1", BackColor = "#836FFF", Title = "已计划日程", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe614", BackColor = "#9400D3", Title = "已分配给你", Count = 2 });
            MenuModels.Add(new MenuModel() { IconFont = "\xe755", BackColor = "#FFD700", Title = "任务", Count = 2 });
            //设置默认值
            this.MenuModel = MenuModels[0];

            SelectedCommand = new RelayCommand<MenuModel>(t => { this.Select(t); });
            SelectedTaskCommand = new RelayCommand<TaskInfo>(t => { this.SelectTask(t); });
        }


        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { SetProperty(ref menuModels,value); }
        }


        public RelayCommand<MenuModel> SelectedCommand { get; set; }
        public RelayCommand<TaskInfo> SelectedTaskCommand { get; set; }

        //用于右侧显示任务列表
        private MenuModel menuModel;

        public MenuModel MenuModel
        {
            get { return menuModel; }
            set { SetProperty(ref menuModel, value); }
        }

        //用于显示任务详情
        private TaskInfo selectedTaskInfo;
        public TaskInfo SelectedTaskInfo
        {
            get { return selectedTaskInfo; }
            set { SetProperty(ref selectedTaskInfo, value); }
        }

        //选中左侧列表时，设置右侧任务列表的数据模型
        private void Select(MenuModel menuModel)
        {
            this.MenuModel = menuModel;
        }

        public void AddTask(string content)
        {
            var task = new TaskInfo { Content = content };

            this.menuModel.TaskInfos.Add(task);

        }

        public void SelectTask(TaskInfo taskInfo)
        {
            WeakReferenceMessenger.Default.Send<TaskInfo>(taskInfo);//发送消息
            this.SelectedTaskInfo = taskInfo;
        }
    }
}
