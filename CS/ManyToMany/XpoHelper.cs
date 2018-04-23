using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace ManyToMany {
    public static class XpoHelper {
        public static void Init() {
            InitDal();
            CreateDefaultObjects();
        }

        private static void InitDal() {
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());
        }
        private static void CreateDefaultObjects() {
            using(UnitOfWork uow = new UnitOfWork()) {
                if(uow.FindObject<User>(null) != null) return;

                Group adminGroup = new Group(uow);
                adminGroup.Name = "Administrators";

                Group userGroup = new Group(uow);
                userGroup.Name = "Users";

                User u1 = new User(uow);
                u1.FullName = "Mario Esprito";
                u1.MemberOfGroups.Add(adminGroup);

                User u2 = new User(uow);
                u2.FullName = "Carter Jones";
                u2.MemberOfGroups.Add(adminGroup);

                User u3 = new User(uow);
                u3.FullName = "Bart Richdale";
                u3.MemberOfGroups.Add(userGroup);

                User u4 = new User(uow);
                u4.FullName = "Cindy Harwell";
                u4.MemberOfGroups.Add(userGroup);

                uow.CommitChanges();
            }
        }
    }
}
