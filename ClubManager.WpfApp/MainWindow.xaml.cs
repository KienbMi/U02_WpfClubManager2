using ClubManager.Model;
using ClubManager.WpfApp.Windows;
using MahApps.Metro.Controls;
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

namespace ClubManager.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<Member> _members;
        
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            btnNew.Click += BtnNew_Click;
            btnDel.Click += BtnDel_Click;
            btnEdit.Click += BtnEdit_Click;

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            MemberWindow memberWindow = new MemberWindow();
            memberWindow.ShowDialog();
            ReloadListView();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvwMembers.SelectedItem is Member memberToEdit)
            {
                MemberWindow memberWindow = new MemberWindow(memberToEdit);
                memberWindow.ShowDialog();
                ReloadListView();
            }
            else
            {
                MessageBox.Show("Kein Vereinsmitglied angewählt");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvwMembers.SelectedItem is Member memberToDelete)
            {
                Repository.GetInstance().RemoveMember(memberToDelete);
                ReloadListView();
            }
            else
            {
                MessageBox.Show("Kein Vereinsmitglied angewählt");
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadListView();
        }

        private void ReloadListView()
        {
            Repository rep = Repository.GetInstance();
            _members = rep.GetAllMembers();
            lvwMembers.ItemsSource = _members;
        }
    }
}
