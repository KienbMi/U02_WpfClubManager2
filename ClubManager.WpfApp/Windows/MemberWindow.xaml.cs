using ClubManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClubManager.WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        private Member _memberToEdit;
        private Member _member;

        public MemberWindow()
        {
            InitializeComponent();
            Loaded += MemberWindow_Loaded;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            tblHeadline.Text = "Neuen Member anlegen";
        }

        public MemberWindow(Member memberToEdit) : this()
        {
            _memberToEdit = memberToEdit;
            tblHeadline.Text = "Member editieren";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_memberToEdit == null)
            {
                Repository.GetInstance().Add(_member);
            }
            else
            {
                _memberToEdit.Firstname = _member.Firstname;
                _memberToEdit.Lastname = _member.Lastname;
                _memberToEdit.BirthDate = _member.BirthDate;
            }
            Close();
        }

        private void MemberWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _member = new Member();

            if (_memberToEdit != null)
            {
                _member.Firstname = _memberToEdit.Firstname;
                _member.Lastname = _memberToEdit.Lastname;
                _member.BirthDate = _memberToEdit.BirthDate;
            }
            else
            {
                _member.Firstname = "Bitte Vornamen eingeben";
                _member.Lastname = "Bitte Nachnamen eingeben";
            }

            DataContext = _member;
        }
    }
}
