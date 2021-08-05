Imports System.Data.OleDb
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
    Private Sub FrmDatabaseKontak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()
        da = New OleDbDataAdapter("Select * from Kontak", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "Kontak")
        DataGridView1.DataSource = (ds.Tables("Kontak"))
    End Sub
End Class