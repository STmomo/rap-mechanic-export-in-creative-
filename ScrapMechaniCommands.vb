

Public Class Form1

    Dim NewPoint As New System.Drawing.Point
    Dim X, Y As Integer
    Dim RepJeux As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        detection()
        Dim cur As Icon
        cur = (My.Resources.cur1nb)
        Me.Cursor = New Cursor(cur.Handle)
    End Sub
    Sub detection()
        If Dir("C:\Steam\steamapps\common\Scrap Mechanic\Release\ScrapMechanic.exe", vbDirectory) = "" Then

        Else
            RepJeux = ("C:\Steam\steamapps\common\Scrap Mechanic\Data\Scripts\game")
            BoutonModif.Enabled = True
            LabelRepertoir.Text = ("Path: C:\Steam\steamapps\common\Scrap Mechanic")
            Exit Sub
        End If

        If Dir("D:\Steam\steamapps\common\Scrap Mechanic\Release\ScrapMechanic.exe", vbDirectory) = "" Then

        Else
            RepJeux = ("D:\Steam\steamapps\common\Scrap Mechanic\Data\Scripts\game")
            BoutonModif.Enabled = True
            LabelRepertoir.Text = ("Path: D:\Steam\steamapps\common\Scrap Mechanic")
            Exit Sub
        End If
        MsgBox("ScrapMechanic.exe NOT FOUND. Please Select Scrap Mechanic Folder. Examples of Path : X:\Steam\steamapps\common\Scrap Mechanic", vbInformation, "ERROR")
    End Sub

    Private Sub BoutonModif_Click(sender As Object, e As EventArgs) Handles BoutonModif.Click
        IO.File.WriteAllBytes(RepJeux & "\CreativeGame.lua", My.Resources.CreativeGameM)
    End Sub

    Private Sub BoutonBase_Click(sender As Object, e As EventArgs) Handles BoutonBase.Click
        IO.File.WriteAllBytes(RepJeux & "\CreativeGame.lua", My.Resources.CreativeGameB)
    End Sub

    Private Sub Repertoir_Click(sender As Object, e As EventArgs) Handles Repertoir.Click
        FolderBrowserDialog1.Description = "Select Directory"
        With FolderBrowserDialog1
            If .ShowDialog() = DialogResult.OK Then

                If Dir(.SelectedPath + "\Release\ScrapMechanic.exe", vbDirectory) = "" Then
                    MsgBox("ScrapMechanic.exe NOT FOUND. Please Select Scrap Mechanic Folder. Examples of Path : X:\Steam\steamapps\common\Scrap Mechanic", vbCritical, "ERROR")
                    LabelRepertoir.Text = (.SelectedPath)
                Else
                    RepJeux = .SelectedPath + ("\Data\Scripts\game")
                    LabelRepertoir.Text = ("Path: " & .SelectedPath)
                    BoutonModif.Enabled = True
                End If

            End If
        End With
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.Y -= (Y)
            NewPoint.X -= (X)
            Me.Location = NewPoint
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Close()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.Y -= (Y)
            NewPoint.X -= (X)
            Me.Location = NewPoint
        End If
    End Sub
End Class
