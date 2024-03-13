using Presale.Models;
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
        public string? RequestName { get; set; }
        public string? RequestMessage { get; set; }
        List<Contacts> contacts = new List<Contacts>();
        public NewRequest()
        {
            InitializeComponent();
        }

        public void BuildUI()
        {
            string requestNum = DateTime.Now.ToString();
            Regex regex = new Regex("[:. ]");
            requestNum = regex.Replace(requestNum, "");

            labRequestNumber.Content = requestNum;

            contacts = (List<Contacts>)DataContext;
            var departments = contacts.Select(o => o.Department).Distinct().ToList();
            foreach (var department in departments)
                cmbDepartments.Items.Add(department);
        }

        private void CMBSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listViewUsersGroup.Items.Clear();
            foreach (var contact in contacts)
                if (contact.Department == cmbDepartments.SelectedItem.ToString())
                    listViewUsersGroup.Items.Add(contact);
        }

        private void AttachFiles(object sender, RoutedEventArgs e)
        {

        }
        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            if (txtRequestName.Text != "" && txtRequestMessage.Text != "")
            {
                RequestName = labRequestNumber.Content + " " + txtRequestName.Text;
                RequestMessage = txtRequestMessage.Text;
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
