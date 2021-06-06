using System;
using System.Collections.Generic;
using System.Text;

namespace MyTodo.Models
{
    public class MenuModel
    {
        public string IconFont { get; set; }
        public string Title { get; set; }
        public string BackColor { get; set; }
        public int  Count{ get; set; }
        public bool Display { get; set; } = true;
    }
}
