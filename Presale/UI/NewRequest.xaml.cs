using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presale.UI
{
    public partial class NewRequest : Window
    {
        public NewRequest()
        {
            InitializeComponent();

            string requestNum = DateTime.Now.ToString();
            Regex regex = new Regex("[:. ]");
            requestNum = regex.Replace(requestNum, "");

            labRequestNumber.Content = requestNum;

            List<string> listDepartments = new List<string> { "IT", "Info Business", "Masters" };

            for (int i = 0; i < listDepartments.Count; i++)
            {
                cmbDepartments.Items.Add(listDepartments[i]);
            }
        }
        private void AttachFiles(object sender, RoutedEventArgs e)
        {

        }
        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            if (txtRequestName.Text != "" && txtRequestMessage.Text != "")
            {
                string chatName = labRequestNumber.Content + " " + txtRequestName.Text;
                string chatMessage = txtRequestMessage.Text;
                string chatMembers = "";
            }
            else
            {
                MessageBox.Show("Заполните название запроса и/или текст запроса", "Error");
                return;
            }
        }
    }
}
