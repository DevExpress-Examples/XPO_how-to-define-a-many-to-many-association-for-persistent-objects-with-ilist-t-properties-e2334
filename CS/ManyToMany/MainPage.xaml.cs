using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpo;

namespace ManyToMany {
    public partial class MainPage : UserControl {
        Session session = new UnitOfWork();

        public MainPage() {
            XpoHelper.Init();

            InitializeComponent();

            List<Group> groups = new XPQuery<Group>(session).ToList();
            lbGroups.ItemsSource = groups;
        }

        public Group Group {
            get {
                return (Group)lbGroups.SelectedItem;
            }
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e) {
            List<User> users = 
                (from u in new XPQuery<User>(session)
                where !this.Group.Members.Contains(u)
                select u).ToList();
            
            WndUsers wnd = new WndUsers(users, Group.Name);
            wnd.Closed += new EventHandler(wnd_Closed);
            wnd.Show();            
        }

        void wnd_Closed(object sender, EventArgs e) {
            WndUsers wnd = (WndUsers)sender;
            if(wnd.DialogResult == true && wnd.SelectedUser != null) {
                this.Group.Members.Add(wnd.SelectedUser);
                RefreshMembersListBox();
            }
        }

        private void RefreshMembersListBox() {
            lbMembers.ItemsSource = null;
            lbMembers.ItemsSource = this.Group.Members;
        }

        private void btnRemoveMember_Click(object sender, RoutedEventArgs e) {
            User selectedUser = (User)lbMembers.SelectedItem;
            this.Group.Members.Remove(selectedUser);
            RefreshMembersListBox();
        }

        private void lbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(this.Group == null)
                lbMembers.ItemsSource = null;
            else
                lbMembers.ItemsSource = Group.Members;

            btnAddMember.IsEnabled = (this.Group != null);
        }

        private void lbMembers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnRemoveMember.IsEnabled = (lbMembers.SelectedItem != null);
        }        
    }
}
