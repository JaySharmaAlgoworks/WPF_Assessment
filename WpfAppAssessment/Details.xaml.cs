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
using System.Windows.Shapes;

namespace WpfAppAssessment
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details()
        {
            InitializeComponent();


        }
        private bool _close;

      
        public new void Close()
        {
            _close = true;
            base.Close();
        }

       
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_close) return;

            // Hide the window (instead of closing it)
            e.Cancel = true;
            Hide();

        }
    }
}

