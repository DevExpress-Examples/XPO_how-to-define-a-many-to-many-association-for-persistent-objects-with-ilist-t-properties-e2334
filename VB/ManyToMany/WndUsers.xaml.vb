Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace ManyToMany
	Partial Public Class WndUsers
		Inherits ChildWindow
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal dataSource As IList(Of User), ByVal group As String)
			Me.New()
			lbUsers.ItemsSource = dataSource
			Title = String.Format("Add a member to {0}", group)
		End Sub

		Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.DialogResult = True
		End Sub

		Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.DialogResult = False
		End Sub

		Public ReadOnly Property SelectedUser() As User
			Get
				Return CType(lbUsers.SelectedItem, User)
			End Get
		End Property
	End Class
End Namespace

