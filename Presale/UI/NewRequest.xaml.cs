using Microsoft.Win32;
using Presale.Data;
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
        public string? RequestMembers { get; set; }
        public OpenFileDialog? RequestFiles {  get; set; }

        List<Contacts> contacts = new List<Contacts>();
        List<Contacts> listRequestMembers = new List<Contacts>();
        List<string> fileNames = new List<string>();
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
        private void AddMember(object sender, RoutedEventArgs e)
        {
            if (listViewUsersGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не выбраны участники", "Alert");
                return;
            }
            foreach (Contacts contact in listViewUsersGroup.SelectedItems)
            {
                listRequestMembers.Add(contact);
                listViewRequestMembers.Items.Add(contact);
            }
            foreach (Contacts contact in listRequestMembers)
            {
                contacts.Remove(contact);
                listViewUsersGroup.Items.Remove(contact);
            }
        }
        private void RemoveMember(object sender, RoutedEventArgs e)
        {
            if (listViewRequestMembers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не выбраны участники для удаления", "Alert");
                return;
            }
            foreach (Contacts contact in listViewRequestMembers.SelectedItems)
                contacts.Add(contact);

            foreach (Contacts contact in contacts)
            {
                listViewRequestMembers.Items.Remove(contact);
                listRequestMembers.Remove(contact);
            }
        }
        private void AttachFiles(object sender, RoutedEventArgs e)
        {
            RequestFiles = new OpenFileDialog
            {
                Filter = "Excel files|*.xlsx;*.xlsb;*.xls|Word files|*.doc;*.docx|All files (*.*)|*.*",
                Multiselect = true
            };
            RequestFiles.ShowDialog();

            if (RequestFiles.FileName == "")
            {
                fileNames.Clear();
                listViewFiles.ItemsSource = null;

                return;
            }

            fileNames = [.. RequestFiles.SafeFileNames];
            listViewFiles.ItemsSource = fileNames;
        }
        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            if (txtRequestName.Text != "" && txtRequestMessage.Text != "")
            {
                RequestName = labRequestNumber.Content + " " + txtRequestName.Text;
                RequestMessage = txtRequestMessage.Text;

                foreach (Contacts contact in listViewRequestMembers.Items)
                    RequestMembers += contact.Login.ToString() + ":";

                RequestMembers = RequestMembers?.Remove(RequestMembers.Length - 1);
                Close();
            }
            else
            {
                MessageBox.Show("Заполните название запроса и/или текст запроса", "Ошибка");
                return;
            }
        }
        private void Cancel(object sender, RoutedEventArgs e) { Close(); }
    }
}
