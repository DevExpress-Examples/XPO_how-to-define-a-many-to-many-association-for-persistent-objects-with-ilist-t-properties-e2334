Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpo

Namespace ManyToMany
	Partial Public Class MainPage
		Inherits UserControl
		Private session As Session = New UnitOfWork()

		Public Sub New()
			XpoHelper.Init()

			InitializeComponent()

			Dim groups As List(Of Group) = New XPQuery(Of Group)(session).ToList()
			lbGroups.ItemsSource = groups
		End Sub

		Public ReadOnly Property Group() As Group
			Get
				Return CType(lbGroups.SelectedItem, Group)
			End Get
		End Property

		Private Sub btnAddMember_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim users As List(Of User) = ( _
					From u In New XPQuery(Of User)(session) _
					Where (Not Me.Group.Members.Contains(u)) _
					Select u).ToList()

			Dim wnd As New WndUsers(users, Group.Name)
			AddHandler wnd.Closed, AddressOf wnd_Closed
			wnd.Show()
		End Sub

		Private Sub wnd_Closed(ByVal sender As Object, ByVal e As EventArgs)
			Dim wnd As WndUsers = CType(sender, WndUsers)
			If wnd.DialogResult = True AndAlso wnd.SelectedUser IsNot Nothing Then
				Me.Group.Members.Add(wnd.SelectedUser)
				RefreshMembersListBox()
			End If
		End Sub

		Private Sub RefreshMembersListBox()
			lbMembers.ItemsSource = Nothing
			lbMembers.ItemsSource = Me.Group.Members
		End Sub

		Private Sub btnRemoveMember_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim selectedUser As User = CType(lbMembers.SelectedItem, User)
			Me.Group.Members.Remove(selectedUser)
			RefreshMembersListBox()
		End Sub

		Private Sub lbGroups_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			If Me.Group Is Nothing Then
				lbMembers.ItemsSource = Nothing
			Else
				lbMembers.ItemsSource = Group.Members
			End If

			btnAddMember.IsEnabled = (Me.Group IsNot Nothing)
		End Sub

		Private Sub lbMembers_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			btnRemoveMember.IsEnabled = (lbMembers.SelectedItem IsNot Nothing)
		End Sub
	End Class
End Namespace
