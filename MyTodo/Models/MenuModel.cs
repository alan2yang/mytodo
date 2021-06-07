using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTodo.Models
{
    public class MenuModel:ObservableObject
    {
        public string IconFont { get; set; }
        public string Title { get; set; }
        public string BackColor { get; set; }
        public int Count { get; set; }
        public bool Display { get; set; } = true;

        public ObservableCollection<TaskInfo> taskInfos=new ObservableCollection<TaskInfo>();
        public ObservableCollection<TaskInfo> TaskInfos 
        {
            get { return taskInfos; }
            set { SetProperty(ref taskInfos, value); } 
        }
    }

    public class TaskInfo
    {
        public string Content { get; set; }
    }
}
