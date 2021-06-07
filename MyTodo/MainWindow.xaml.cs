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

        private void ExpandColumn()
        {
            var cdf= grc.ColumnDefinitions;
            cdf[1].Width = new GridLength(280);

            this.minbtn.Foreground = new SolidColorBrush(Colors.Black);
            this.maxbtn.Foreground = new SolidColorBrush(Colors.Black);
            this.closebtn.Foreground = new SolidColorBrush(Colors.Black);

        }
    }
}
