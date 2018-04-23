Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace ManyToMany
	Public NotInheritable Class XpoHelper
		Private Sub New()
		End Sub
		Public Shared Sub Init()
			InitDal()
			CreateDefaultObjects()
		End Sub

		Private Shared Sub InitDal()
			XpoDefault.DataLayer = New SimpleDataLayer(New InMemoryDataStore())
		End Sub
		Private Shared Sub CreateDefaultObjects()
			Using uow As New UnitOfWork()
				If uow.FindObject(Of User)(Nothing) IsNot Nothing Then
					Return
				End If

				Dim adminGroup As New Group(uow)
				adminGroup.Name = "Administrators"

				Dim userGroup As New Group(uow)
				userGroup.Name = "Users"

				Dim u1 As New User(uow)
				u1.FullName = "Mario Esprito"
				u1.MemberOfGroups.Add(adminGroup)

				Dim u2 As New User(uow)
				u2.FullName = "Carter Jones"
				u2.MemberOfGroups.Add(adminGroup)

				Dim u3 As New User(uow)
				u3.FullName = "Bart Richdale"
				u3.MemberOfGroups.Add(userGroup)

				Dim u4 As New User(uow)
				u4.FullName = "Cindy Harwell"
				u4.MemberOfGroups.Add(userGroup)

				uow.CommitChanges()
			End Using
		End Sub
	End Class
End Namespace
