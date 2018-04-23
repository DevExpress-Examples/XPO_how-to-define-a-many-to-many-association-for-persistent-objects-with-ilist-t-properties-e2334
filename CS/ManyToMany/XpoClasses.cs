using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace ManyToMany {
    [NonPersistent]
    public class MyPersistentBase : PersistentBase {
        public MyPersistentBase(Session session) : base(session) { }

        [Key(true)]
        public int Oid;
    }

    public class User : MyPersistentBase {
        public User(Session session) : base(session) { }

        private string _FullName;
        public string FullName {
            get {
                return _FullName;
            }
            set {
                SetPropertyValue("FullName", ref _FullName, value);
            }
        }

        [Association, Browsable(false)]
        public IList<UserToGroupLink> UserToGroupLinks {
            get {
                return GetList<UserToGroupLink>("UserToGroupLinks");
            }
        }

        [ManyToManyAlias("UserToGroupLinks", "LinkGroup")]
        public IList<Group> MemberOfGroups {
            get {
                return GetList<Group>("MemberOfGroups");
            }
        }
    }
    public class Group : MyPersistentBase {
        public Group(Session session) : base(session) { }

        private string _Name;
        public string Name {
            get {
                return _Name;
            }
            set {
                SetPropertyValue("Name", ref _Name, value);
            }
        }

        [Association, Browsable(false)]
        public IList<UserToGroupLink> UserToGroupLinks {
            get {
                return GetList<UserToGroupLink>("UserToGroupLinks");
            }
        }

        [ManyToManyAlias("UserToGroupLinks", "LinkUser")]
        public IList<User> Members {
            get {
                return GetList<User>("Members");
            }
        }
    }

    public class UserToGroupLink : MyPersistentBase {
        public UserToGroupLink(Session session) : base(session) { }

        private User _LinkUser;
        [Association]
        public User LinkUser {
            get { return _LinkUser; }
            set { SetPropertyValue("LinkUser", ref _LinkUser, value); }
        }
        private Group _LinkGroup;
        [Association]
        public Group LinkGroup {
            get { return _LinkGroup; }
            set { SetPropertyValue("LinkGroup", ref _LinkGroup, value); }
        }
    }

}
