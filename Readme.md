<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/ManyToMany/MainPage.xaml)
* [MainPage.xaml.cs](./CS/ManyToMany/MainPage.xaml.cs)
* [WndUsers.xaml](./CS/ManyToMany/WndUsers.xaml)
* [WndUsers.xaml.cs](./CS/ManyToMany/WndUsers.xaml.cs)
* [XpoClasses.cs](./CS/ManyToMany/XpoClasses.cs)
* [XpoHelper.cs](./CS/ManyToMany/XpoHelper.cs)
<!-- default file list end -->
# How to define a many-to-many association for persistent objects with IList<T> properties


<p>The <a href="http://documentation.devexpress.com/#XPO/CustomDocument2054">How to: Implement Many-to-Many Relationships</a> article provides a solution for a many-to-many association with XPCollection properties. If List<T> properties compose an association, a different approach is to be used. This is the case in Silverlight applications.</p><p>To create a many-to-many association with List<T> properties, use the ManyToManyAlias attribute. It requires an explicit declaration of an intermediate persistent class, and two one-to-many associations.</p>

<br/>


