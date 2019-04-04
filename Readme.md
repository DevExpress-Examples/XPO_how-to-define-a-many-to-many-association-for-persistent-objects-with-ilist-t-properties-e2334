<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/ManyToMany/MainPage.xaml) (VB: [MainPage.xaml](./VB/ManyToMany/MainPage.xaml))
* [MainPage.xaml.cs](./CS/ManyToMany/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/ManyToMany/MainPage.xaml.vb))
* [WndUsers.xaml](./CS/ManyToMany/WndUsers.xaml) (VB: [WndUsers.xaml](./VB/ManyToMany/WndUsers.xaml))
* [WndUsers.xaml.cs](./CS/ManyToMany/WndUsers.xaml.cs) (VB: [WndUsers.xaml.vb](./VB/ManyToMany/WndUsers.xaml.vb))
* **[XpoClasses.cs](./CS/ManyToMany/XpoClasses.cs) (VB: [XpoClasses.vb](./VB/ManyToMany/XpoClasses.vb))**
* [XpoHelper.cs](./CS/ManyToMany/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/ManyToMany/XpoHelper.vb))
<!-- default file list end -->
# How to define a many-to-many association for persistent objects with IList<T> properties


<p>The <a href="http://documentation.devexpress.com/#XPO/CustomDocument2054">How to: Implement Many-to-Many Relationships</a> article provides a solution for a many-to-many association with XPCollection properties. If List<T> properties compose an association, a different approach is to be used. This is the case in Silverlight applications.</p><p>To create a many-to-many association with List<T> properties, use the ManyToManyAlias attribute. It requires an explicit declaration of an intermediate persistent class, and two one-to-many associations.</p>


<h3>Description</h3>

<p>Silverlight 5 is required.</p>

<br/>


