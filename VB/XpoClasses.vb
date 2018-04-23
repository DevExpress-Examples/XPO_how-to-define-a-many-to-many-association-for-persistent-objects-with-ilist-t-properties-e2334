Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace ManyToMany
	<NonPersistent> _
	Public Class MyPersistentBase
		Inherits PersistentBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key(True)> _
		Public Oid As Integer
	End Class

	Public Class User
		Inherits MyPersistentBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _FullName As String
		Public Property FullName() As String
			Get
				Return _FullName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("FullName", _FullName, value)
			End Set
		End Property

		<Association, Browsable(False)> _
		Public ReadOnly Property UserToGroupLinks() As IList(Of UserToGroupLink)
			Get
				Return GetList(Of UserToGroupLink)("UserToGroupLinks")
			End Get
		End Property

		<ManyToManyAlias("UserToGroupLinks", "LinkGroup")> _
		Public ReadOnly Property MemberOfGroups() As IList(Of Group)
			Get
				Return GetList(Of Group)("MemberOfGroups")
			End Get
		End Property
	End Class
	Public Class Group
		Inherits MyPersistentBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property

		<Association, Browsable(False)> _
		Public ReadOnly Property UserToGroupLinks() As IList(Of UserToGroupLink)
			Get
				Return GetList(Of UserToGroupLink)("UserToGroupLinks")
			End Get
		End Property

		<ManyToManyAlias("UserToGroupLinks", "LinkUser")> _
		Public ReadOnly Property Members() As IList(Of User)
			Get
				Return GetList(Of User)("Members")
			End Get
		End Property
	End Class

	Public Class UserToGroupLink
		Inherits MyPersistentBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _LinkUser As User
		<Association> _
		Public Property LinkUser() As User
			Get
				Return _LinkUser
			End Get
			Set(ByVal value As User)
				SetPropertyValue("LinkUser", _LinkUser, value)
			End Set
		End Property
		Private _LinkGroup As Group
		<Association> _
		Public Property LinkGroup() As Group
			Get
				Return _LinkGroup
			End Get
			Set(ByVal value As Group)
				SetPropertyValue("LinkGroup", _LinkGroup, value)
			End Set
		End Property
	End Class

End Namespace
