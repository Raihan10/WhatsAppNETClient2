Imports System.Data.OleDb
Imports WhatsAppNETAPI
Public Class FrmDatabaseKontak
    Public Conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String

    Private iWhatsApp As IWhatsAppNETAPI
    Public Sub New(ByVal title As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = title

        ' Cretae object
        iWhatsApp = New WhatsAppNETAPI.WhatsAppNETAPI()
    End Sub
    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kontakDB.accdb"
        Conn = New OleDbConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    Sub LoadDataKontak()
        'Koneksi()
        'Data Table
        Dim dtCustomerCategory As New DataTable
        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "Customer ID"
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Name = "Nama"
        DataGridView1.Columns(2).Name = "Handphone"

        Dim daSelectAllCustomer As OleDbDataAdapter
        Dim daSelectAllCategory As OleDbDataAdapter
        Dim daSelectCustomerCategory As OleDbDataAdapter


        'Isi dataset untuk tabel relasi
        daSelectAllCustomer = New OleDbDataAdapter("SELECT * FROM customer ORDER BY [customer_name]", Conn)
        daSelectAllCategory = New OleDbDataAdapter("SELECT * FROM category", Conn)
        daSelectCustomerCategory = New OleDbDataAdapter("SELECT * FROM customer_category", Conn)

        'Isi dataset untuk customer
        Dim dsAllCustomer As DataSet
        dsAllCustomer = New DataSet
        dsAllCustomer.Clear()
        daSelectAllCustomer.Fill(dsAllCustomer, "customer")

        'Isi dataset untuk category
        Dim dsAllCategory As DataSet
        dsAllCategory = New DataSet
        dsAllCategory.Clear()
        daSelectAllCategory.Fill(dsAllCategory, "category")

        'Isi dataset untuk customer_category
        Dim dsAllRelation As New DataSet
        dsAllRelation = New DataSet
        dsAllRelation.Clear()
        daSelectCustomerCategory.Fill(dsAllRelation, "customer_category")

        'Bikin kolom untuk tiap kategori
        Dim i As Integer
        Dim countCategoryRows = dsAllCategory.Tables("category").Rows.Count - 1
        For i = 0 To countCategoryRows
            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridView1.Columns.Add(chk)
            chk.HeaderText = dsAllCategory.Tables("category").Rows(i).Item(2).ToString
            chk.Name = dsAllCategory.Tables("category").Rows(i).Item(0).ToString
        Next

        'Add Row
        Dim countCustomerRows = dsAllCustomer.Tables("customer").Rows.Count - 1
        For i = 0 To countCustomerRows
            Dim customer_id As String = dsAllCustomer.Tables("customer").Rows(i).Item(0).ToString
            Dim handphone As String = dsAllCustomer.Tables("customer").Rows(i).Item(1).ToString
            Dim customer_name As String = dsAllCustomer.Tables("customer").Rows(i).Item(2).ToString
            Dim rowCustomer As String() = New String() {customer_id, customer_name, handphone}
            Dim rowIndex As Integer = DataGridView1.Rows.Add(rowCustomer)

            'If Conn.State = ConnectionState.Closed Then Koneksi()
            Dim j As Integer
            For j = 0 To countCategoryRows
                Dim columnIndex As Integer = dsAllCustomer.Tables("customer").Columns.Count + j
                'Get Category ID
                Dim category_id As String = DataGridView1.Columns(columnIndex).Name

                'Loop in dataset customer_category
                'Isi DataSet untuk tabel relasi
                'Koneksi()
                Dim daSelectOneRelation As OleDbDataAdapter
                daSelectOneRelation = New OleDbDataAdapter("SELECT * FROM customer_category WHERE [customer_id]=" & customer_id & " AND [category_id]=" & category_id & "", Conn)

                'Isi dataset untuk customer
                Dim dsOneRelation As DataSet
                dsOneRelation = New DataSet
                dsOneRelation.Clear()
                daSelectOneRelation.Fill(dsOneRelation, "customer_category")

                If (dsOneRelation.Tables("customer_category").Rows.Count = 0) Then
                    DataGridView1.Rows(rowIndex).Cells(columnIndex).Value = False
                Else
                    DataGridView1.Rows(rowIndex).Cells(columnIndex).Value = True
                End If
                'Dim countRelationRows As Integer = dsAllRelation.Tables("customer_category").Rows.Count - 1
                'MessageBox.Show(countRelationRows)
                'Dim k As Integer
                'For k = 0 To countRelationRows
                '    If (dsAllRelation.Tables("customer_category").Rows(k).Item(1).ToString = customer_id And dsAllRelation.Tables("customer_category").Rows(k).Item(2).ToString = category_id) Then
                '        DataGridView1.Rows(rowIndex).Cells(columnIndex).Value = True
                '    Else
                '        DataGridView1.Rows(rowIndex).Cells(columnIndex).Value = False
                '    End If
                'Next
            Next
        Next
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
        'Conn.Close()
    End Sub
    Sub AddKontakToDB(contacts As IList(Of Contact))
        'Koneksi()
        Dim queryString As String
        queryString = "Insert into customer([customer_name],[handphone]) Values(?, ?)"
        For Each contact As Contact In contacts
            If Not (contact.id = "status@broadcast") Then
                Dim daSelectOne As OleDbDataAdapter
                Dim dsSelectOne As DataSet
                daSelectOne = New OleDbDataAdapter("Select * from customer Where [handphone] = '" & contact.id & "'", Conn)
                dsSelectOne = New DataSet
                'dsSelectOne.Clear()
                daSelectOne.Fill(dsSelectOne, "customer")

                If dsSelectOne.Tables("customer").Rows.Count = 0 Then
                    Dim cmd As OleDbCommand = New OleDbCommand(queryString, Conn)
                    cmd.Parameters.Add(New OleDbParameter("customer_name", contact.name))
                    cmd.Parameters.Add(New OleDbParameter("handphone", contact.id))

                    Try
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    'If (contact.id.Equals("6287747965139")) Then
                    '    MessageBox.Show(dsSelectOne.Tables("customer").Rows.Count)
                    '    MessageBox.Show(contact.id)
                    '    MessageBox.Show(contact.name)
                    'End If

                    'MessageBox.Show(dsSelectOne.Tables("customer").Rows.Count)
                    'MessageBox.Show(contact.id)
                    'MessageBox.Show(contact.name)
                    Dim queryUpdateString As String
                    queryUpdateString = "UPDATE customer SET [customer_name] = '" & contact.name & "' WHERE [handphone] = '" & contact.id & "'"
                    Dim cmd As OleDbCommand = New OleDbCommand(queryUpdateString, Conn)

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
        'Conn.Close()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim customerIdString As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        Dim categoryIdString As String = DataGridView1.Columns(e.ColumnIndex).Name
        Dim customerId As Integer = Convert.ToInt32(customerIdString)
        Dim categoryId As Integer = Convert.ToInt32(categoryIdString)
        Dim queryString As String
        Koneksi()
        If (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False) Then
            queryString = "Insert into customer_category([customer_id],[category_id]) Values(?,?)"
            Dim cmd As OleDbCommand = New OleDbCommand(queryString, Conn)
            cmd.Parameters.Add(New OleDbParameter("customer_id", customerId))
            cmd.Parameters.Add(New OleDbParameter("category_id", categoryId))

            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                'DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            queryString = "Delete from customer_category where [customer_id] = " & customerIdString & " And [category_id] = " & categoryIdString & ""
            Dim cmd As OleDbCommand = New OleDbCommand(queryString, Conn)

            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                'DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        'Conn.Close()
    End Sub
    Public Event SynchronizeEvent()
    Public Event BroadcastEvent()
    Private Sub btnSynchronize_Click(sender As Object, e As EventArgs) Handles btnSynchronize.Click
        RaiseEvent SynchronizeEvent()
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        RaiseEvent BroadcastEvent()
    End Sub
    Public Sub getAllRelations()
        Dim daSelectAllRelations As OleDbDataAdapter
        daSelectAllRelations = New OleDbDataAdapter("SELECT * FROM customer_category", Conn)
        Dim dsAllRelations As DataSet
        dsAllRelations = New DataSet
        dsAllRelations.Clear()
        daSelectAllRelations.Fill(dsAllRelations, "category")
    End Sub
End Class