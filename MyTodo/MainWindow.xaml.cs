using MyTodo.Models;
using MyTodo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace MyTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            WeakReferenceMessenger.Default.Register<TaskInfo>(this, (o, task) => { this.ExpandColumn(task); });//消息机制？？？？
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                string inputValue = inputText.Text;
                if (inputValue=="")
                {
                    return;
                }

                var mViewModel = this.DataContext as MainViewModel;

                mViewModel.AddTask(inputValue);
                inputText.Text = string.Empty;
            }
        }

        private void ExpandColumn(TaskInfo task)
        {
            var cdf= grc.ColumnDefinitions;


            if (cdf[1].Width == new GridLength(280))
            {
                var mainViewModel = this.DataContext as MainViewModel;
                
                if (task == null||task.Content==mainViewModel.SelectedTaskInfo.Content)
                {
                    cdf[1].Width = new GridLength(0);

                    this.minbtn.Foreground = new SolidColorBrush(Colors.White);
                    this.maxbtn.Foreground = new SolidColorBrush(Colors.White);
                    this.closebtn.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    return;
                }

                
            }
            else
            {
                cdf[1].Width = new GridLength(280);

                this.minbtn.Foreground = new SolidColorBrush(Colors.Black);
                this.maxbtn.Foreground = new SolidColorBrush(Colors.Black);
                this.closebtn.Foreground = new SolidColorBrush(Colors.Black);
            }
            

        }
    }
}
