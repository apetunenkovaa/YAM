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

namespace YP_session_one.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto 
    {
        public PageAuto()
        {
            InitializeComponent();
        }

        private void Number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int n = Convert.ToInt32(Number.Text);

            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
