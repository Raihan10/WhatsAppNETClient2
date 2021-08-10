Imports System.Data.OleDb
Imports WhatsAppNETAPI
Public Class FrmDatabaseKontak
    Dim Conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String
    Public Sub New(ByVal title As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = title
    End Sub
    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kontakDB.accdb"
        Conn = New OleDbConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    Sub LoadDataKontak()
        Koneksi()
        da = New OleDbDataAdapter("Select [Nama],[NomorHP],[Kategori01],[Kategori02],[Kategori03],[Kategori04],[Kategori05],[Kategori06],[Kategori07],[Kategori08],[Kategori09] from Kontak Order By Nama", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Kontak")
        DataGridView1.DataSource = (ds.Tables("Kontak"))
    End Sub
    Sub DeleteAllData()
        Koneksi()
        'Delete All Data
        Dim queryStringDelete As String
        queryStringDelete = "Delete from Kontak"
        Dim cmdDeleteAll As OleDbCommand = New OleDbCommand(queryStringDelete, Conn)

        Try
            cmdDeleteAll.ExecuteNonQuery()
            cmdDeleteAll.Dispose()
            'Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmDatabaseKontak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DeleteAllData()
        LoadDataKontak()
    End Sub
    Private Sub FrmDatabaseKontak_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        'DeleteAllData()
    End Sub
    Sub AddKontakToDB(contacts As IList(Of Contact))
        Koneksi()
        Dim queryString As String
        queryString = "Insert into Kontak([Nama],[NomorHP]) Values(?, ?)"
        For Each contact As Contact In contacts
            If Not (contact.id = "status@broadcast") Then
                Dim daSelectOne As OleDbDataAdapter
                Dim dsSelectOne As DataSet
                daSelectOne = New OleDbDataAdapter("Select * from Kontak Where [NomorHP] = '" & contact.id & "'", Conn)
                dsSelectOne = New DataSet
                dsSelectOne.Clear()
                daSelectOne.Fill(dsSelectOne, "Kontak")

                If dsSelectOne.Tables("Kontak").Rows.Count = 0 Then
                    Dim cmd As OleDbCommand = New OleDbCommand(queryString, Conn)
                    cmd.Parameters.Add(New OleDbParameter("Nama", contact.name))
                    cmd.Parameters.Add(New OleDbParameter("NomorHP", contact.id))

                    Try
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
            End If
        Next
        Conn.Close()
    End Sub
End Class