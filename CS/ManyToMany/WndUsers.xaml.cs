using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ManyToMany {
    public partial class WndUsers : ChildWindow {
        public WndUsers() {
            InitializeComponent();
        }

        public WndUsers(IList<User> dataSource, string group) : this() {
            lbUsers.ItemsSource = dataSource;
            Title = string.Format("Add a member to {0}", group);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        public User SelectedUser {
            get { return (User)lbUsers.SelectedItem; }
        }
    }
}

