'*********************************************************************************************************
' Copyright (C) 2021 Kamarudin (http://wa-net.coding4ever.net/)
'
' Licensed under the Apache License, Version 2.0 (the "License"); you may not
' use this file except in compliance with the License. You may obtain a copy of
' the License at
'
' http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
' WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
' License for the specific language governing permissions and limitations under
' the License.
'
' The latest version of this file can be found at https://github.com/WhatsAppNETClient/WhatsAppNETClient2
'*********************************************************************************************************

Imports WhatsAppNETAPI
Imports ConceptCave.WaitCursor
Imports System.Data.OleDb

Public Class FrmMain

    Private _wa As IWhatsAppNETAPI
    'Public frmDatabaseKontak As New FrmDatabaseKontak("Kontak")
    Dim WithEvents frmDbKontakClass As New FrmDatabaseKontak("DBKontak")

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _wa = New WhatsAppNETAPI.WhatsAppNETAPI()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'txtLokasiWhatsAppNETAPINodeJs.Text = "D:\Documents\Kuliah\PKL\Percobaan\wanetlibraryfork\WhatsAppNETAPINodeJs"
        If (String.IsNullOrEmpty(txtLokasiWhatsAppNETAPINodeJs.Text)) Then
            MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs'  belum di set", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtLokasiWhatsAppNETAPINodeJs.Focus()

            Return
        End If

        _wa.WaNetApiNodeJsPath = txtLokasiWhatsAppNETAPINodeJs.Text

        ' TODO: aktifkan kode ini agar bisa mengirimkan file dalam format video
        ' _wa.ChromePath = "C:/Program Files (x86)/Google/Chrome/Application/chrome.exe"

        If (Not _wa.IsWaNetApiNodeJsPathExists) Then

            MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs' tidak ditemukan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtLokasiWhatsAppNETAPINodeJs.Focus()

            Return
        End If

        Connect()

        frmDbKontakClass.Koneksi()
        'Isi checklistbox category
        Dim daSelectCategory As OleDbDataAdapter


        'Isi dataset untuk tabel relasi
        daSelectCategory = New OleDbDataAdapter("SELECT * FROM category", frmDbKontakClass.Conn)

        'Isi dataset untuk category
        Dim dsCategory As DataSet
        dsCategory = New DataSet
        dsCategory.Clear()
        daSelectCategory.Fill(dsCategory, "category")

        'Isi checklistbox
        CheckedListBox1.Items.Clear()
        Dim index As Integer
        For index = 0 To dsCategory.Tables("category").Rows.Count - 1
            Dim categoryName = dsCategory.Tables("category").Rows(index).Item(2).ToString
            CheckedListBox1.Items.Add(categoryName, CheckState.Unchecked)
        Next
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Disconnect()
    End Sub

    Private Sub Connect()
        Me.UseWaitCursor = True

        _wa.ImageAndDocumentPath = txtLokasiPenyimpananFileAtauGambar.Text

        ' subscribe event
        AddHandler _wa.OnStartup, AddressOf OnStartupHandler
        AddHandler _wa.OnChangeState, AddressOf OnChangeStateHandler
        AddHandler _wa.OnClientConnected, AddressOf OnClientConnectedHandler

        _wa.Connect()

        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))

            Using frm As New FrmStartUp

                ' subscribe event
                AddHandler _wa.OnStartup, AddressOf frm.OnStartupHandler
                AddHandler _wa.OnScanMe, AddressOf frm.OnScanMeHandler

                frm.UseWaitCursor = True
                frm.ShowDialog()

                ' unsubscribe event
                RemoveHandler _wa.OnStartup, AddressOf frm.OnStartupHandler
                RemoveHandler _wa.OnScanMe, AddressOf frm.OnScanMeHandler

            End Using

        End Using
    End Sub

    Private Sub Disconnect()

        btnStart.Enabled = True
        btnStop.Enabled = False
        btnKirim.Enabled = False
        btnDatabase.Enabled = False

        txtFileDokumen.Clear()
        txtFileGambar.Clear()

        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))
            ' unsubscribe event
            RemoveHandler _wa.OnStartup, AddressOf OnStartupHandler
            RemoveHandler _wa.OnChangeState, AddressOf OnChangeStateHandler
            RemoveHandler _wa.OnScanMe, AddressOf OnScanMeHandler
            RemoveHandler _wa.OnClientConnected, AddressOf OnClientConnectedHandler

            _wa.Disconnect()

        End Using
    End Sub

    Private Sub btnKirim_Click(sender As Object, e As EventArgs) Handles btnKirim.Click

        Dim msg = "Apakah Anda yakin untuk broadcast pesan ? Pesan akan dikirimkan berdasarkan pemetaan kategori."
        If MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'Get All Customer
            Dim daSelectAllCustomer As OleDbDataAdapter
            daSelectAllCustomer = New OleDbDataAdapter("SELECT * FROM customer", frmDbKontakClass.Conn)
            Dim dsAllCustomer As DataSet
            dsAllCustomer = New DataSet
            dsAllCustomer.Clear()
            daSelectAllCustomer.Fill(dsAllCustomer, "customer")

            'Untuk tiap customer, cek ke tabel relasi
            Dim i As Integer
            For i = 0 To dsAllCustomer.Tables("customer").Rows.Count - 1
                Dim customerId = dsAllCustomer.Tables("customer").Rows(i).Item(0).ToString()

                'Cek di tabel relasi
                Dim daSelectOneRelation As OleDbDataAdapter
                daSelectOneRelation = New OleDbDataAdapter("SELECT * FROM customer_category WHERE customer_id = " & customerId & " ORDER BY category_id", frmDbKontakClass.Conn)
                Dim dsOneRelation As DataSet
                dsOneRelation = New DataSet
                dsOneRelation.Clear()
                daSelectOneRelation.Fill(dsOneRelation, "relation")

                If dsOneRelation.Tables("relation").Rows.Count <> 0 Then
                    'Cek apakah customer cocok dengan pilihan category
                    Dim isBroadcastReceiver As Boolean
                    isBroadcastReceiver = False

                    'Loop di dataset one relation
                    Dim j As Integer
                    Dim listCategory As New List(Of String)
                    For j = 0 To dsOneRelation.Tables("relation").Rows.Count - 1
                        'Get data category
                        Dim categoryId = dsOneRelation.Tables("relation").Rows(j).Item(2).ToString()
                        Dim daSelectOneCategory As OleDbDataAdapter
                        daSelectOneCategory = New OleDbDataAdapter("SELECT category_name FROM category WHERE category_id = " & categoryId & "", frmDbKontakClass.Conn)
                        Dim dsOneCategory As DataSet
                        dsOneCategory = New DataSet
                        dsOneCategory.Clear()
                        daSelectOneCategory.Fill(dsOneCategory, "one_category")

                        'Loop di checkboxlist pilihan category
                        Dim index As Integer
                        For index = 0 To CheckedListBox1.Items.Count - 1
                            If (CheckedListBox1.GetItemCheckState(index) = 1) Then
                                If (CheckedListBox1.Items(index).ToString.Equals(dsOneCategory.Tables("one_category").Rows(0).Item(0).ToString())) Then
                                    isBroadcastReceiver = True
                                    Exit For
                                End If
                            End If
                        Next

                        If (isBroadcastReceiver) Then
                            Exit For
                        End If
                    Next

                    If (isBroadcastReceiver) Then
                        'Create Message
                        Dim broadcastMessage As String
                        Dim receiverNumber As String
                        Dim messageArguments As MsgArgs
                        receiverNumber = dsAllCustomer.Tables("customer").Rows(i).Item(1).ToString()
                        broadcastMessage = String.Format("Yth. Bapak/Ibu Customer *{0}*,{1}{1}{2}", receiverNumber, vbCrLf, txtPesan.Text)

                        'Cek tipe message
                        If chkKirimPesanDgGambar.Checked Then
                            messageArguments = New MsgArgs(receiverNumber, broadcastMessage, MsgArgsType.Image, txtFileGambar.Text)
                        ElseIf chkKirimGambarDariUrl.Checked Then
                            messageArguments = New MsgArgs(receiverNumber, broadcastMessage, MsgArgsType.Url, txtUrl.Text)
                        ElseIf chkKirimFileAja.Checked Then
                            messageArguments = New MsgArgs(receiverNumber, broadcastMessage, MsgArgsType.File, txtFileDokumen.Text)
                            _wa.SendMessage(messageArguments)
                            messageArguments = New MsgArgs(receiverNumber, broadcastMessage, MsgArgsType.Text)
                        Else
                            messageArguments = New MsgArgs(receiverNumber, broadcastMessage, MsgArgsType.Text)
                        End If

                        _wa.SendMessage(messageArguments)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btnCariGambar_Click(sender As Object, e As EventArgs) Handles btnCariGambar.Click
        Dim fileName = ShowDialogOpen("Lokasi file gambar", True)

        If Not String.IsNullOrEmpty(fileName) Then txtFileGambar.Text = fileName
    End Sub

    Private Sub btnCariDokumen_Click(sender As Object, e As EventArgs) Handles btnCariDokumen.Click
        Dim fileName = ShowDialogOpen("Lokasi file dokumen")

        If Not String.IsNullOrEmpty(fileName) Then txtFileDokumen.Text = fileName
    End Sub

    Private Function ShowDialogOpen(ByVal title As String, Optional ByVal fileImageOnly As Boolean = False) As String

        Dim fileName As String = String.Empty

        Using dlgOpen As New OpenFileDialog

            If fileImageOnly Then
                dlgOpen.Filter = "File gambar (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png"
            Else
                dlgOpen.Filter = "File dokumen (*.*)|*.*"
            End If

            dlgOpen.Title = title

            Dim result = dlgOpen.ShowDialog()
            If (result = DialogResult.OK) Then fileName = dlgOpen.FileName

        End Using

        Return fileName
    End Function

    Private Function ShowDialogOpenFolder() As String

        Dim folderName As String = String.Empty

        Using dlgOpen As New FolderBrowserDialog

            Dim result = dlgOpen.ShowDialog()

            If result = DialogResult.OK AndAlso (Not String.IsNullOrWhiteSpace(dlgOpen.SelectedPath)) Then
                folderName = dlgOpen.SelectedPath
            End If
        End Using

        Return folderName

    End Function

    Private Sub chkKirimPesanDgGambar_CheckedChanged(sender As Object, e As EventArgs) Handles chkKirimPesanDgGambar.CheckedChanged

        btnCariGambar.Enabled = chkKirimPesanDgGambar.Checked

        If chkKirimPesanDgGambar.Checked Then
            chkKirimFileAja.Checked = False
            chkKirimGambarDariUrl.Checked = False
            txtFileDokumen.Clear()
        Else
            txtFileGambar.Clear()
        End If
    End Sub

    Private Sub chkKirimGambarDariUrl_CheckedChanged(sender As Object, e As EventArgs) Handles chkKirimGambarDariUrl.CheckedChanged
        If chkKirimGambarDariUrl.Checked Then
            chkKirimPesanDgGambar.Checked = False
            chkKirimFileAja.Checked = False
            txtFileGambar.Clear()
            txtFileDokumen.Clear()
        End If
    End Sub

    Private Sub chkKirimFileAja_CheckedChanged(sender As Object, e As EventArgs) Handles chkKirimFileAja.CheckedChanged

        btnCariDokumen.Enabled = chkKirimFileAja.Checked

        If chkKirimFileAja.Checked Then
            chkKirimPesanDgGambar.Checked = False
            chkKirimGambarDariUrl.Checked = False
            txtFileGambar.Clear()
        Else
            txtFileDokumen.Clear()
        End If

    End Sub

#Region "Event handler"

    Private Sub OnStartupHandler(ByVal message As String)

        ' koneksi ke WA berhasil
        If message.IndexOf("Ready") >= 0 Then

            btnStart.Invoke(Sub() btnStart.Enabled = False)
            btnStop.Invoke(Sub() btnStop.Enabled = True)
            btnKirim.Invoke(Sub() btnKirim.Enabled = True)
            btnDatabase.Invoke(Sub() btnDatabase.Enabled = True)

            Me.UseWaitCursor = False

        End If

        ' koneksi ke WA GAGAL, bisa dicoba lagi
        If message.IndexOf("Failure") >= 0 OrElse message.IndexOf("Timeout") >= 0 _
            OrElse message.IndexOf("ERR_NAME") >= 0 Then

            ' unsubscribe event
            RemoveHandler _wa.OnStartup, AddressOf OnStartupHandler
            RemoveHandler _wa.OnScanMe, AddressOf OnScanMeHandler
            RemoveHandler _wa.OnClientConnected, AddressOf OnClientConnectedHandler

            _wa.Disconnect()

            Me.UseWaitCursor = False

            Dim msg = message + Environment.NewLine + Environment.NewLine +
                      "Koneksi ke WA gagal, silahkan cek koneksi internet Anda"

            MessageBox.Show(msg, "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub OnChangeStateHandler(ByVal state As WhatsAppNETAPI.WAState)
        lblState.Invoke(Sub() lblState.Text = String.Format("State: {0}", state.ToString()))
    End Sub

    Private Sub OnScanMeHandler(ByVal qrcodePath As String)

    End Sub

    Private Sub OnClientConnectedHandler()
        System.Diagnostics.Debug.Print("ClientConnected on {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now)
    End Sub

    Private Sub btnLokasiWAAutomateNodejs_Click(sender As Object, e As EventArgs) Handles btnLokasiWAAutomateNodejs.Click
        Dim folderName = ShowDialogOpenFolder()

        If (Not String.IsNullOrEmpty(folderName)) Then txtLokasiWhatsAppNETAPINodeJs.Text = folderName
    End Sub

    Private Sub btnLokasiPenyimpananFileAtauGambar_Click(sender As Object, e As EventArgs) Handles btnLokasiPenyimpananFileAtauGambar.Click
        Dim folderName = ShowDialogOpenFolder()

        If (Not String.IsNullOrEmpty(folderName)) Then txtLokasiPenyimpananFileAtauGambar.Text = folderName
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Disconnect()
    End Sub

    Private Sub btnGrabGroupAndMembers_Click(sender As Object, e As EventArgs)
        Using frm As New FrmContactOrGroup("Groups and Members")

            AddHandler _wa.OnReceiveGroups, AddressOf frm.OnReceiveGroupsHandler ' subscribe event
            _wa.GetGroups()

            frm.ShowDialog()
            RemoveHandler _wa.OnReceiveGroups, AddressOf frm.OnReceiveGroupsHandler ' unsubscribe event

        End Using
    End Sub
    Public Sub synchronizeDatabase() Handles frmDbKontakClass.SynchronizeEvent
        frmDbKontakClass.DataGridView1.Rows.Clear()
        frmDbKontakClass.DataGridView1.Columns.Clear()
        AddHandler _wa.OnReceiveContacts, AddressOf frmDbKontakClass.AddKontakToDB ' subscribe event
        _wa.GetContacts()

        frmDbKontakClass.LoadDataKontak()
        RemoveHandler _wa.OnReceiveContacts, AddressOf frmDbKontakClass.AddKontakToDB ' unsubscribe event
    End Sub
    Private Sub btnDatabase_Click(sender As Object, e As EventArgs) Handles btnDatabase.Click
        AddHandler _wa.OnReceiveContacts, AddressOf frmDbKontakClass.AddKontakToDB ' subscribe event
        _wa.GetContacts()

        frmDbKontakClass.ShowDialog()
        RemoveHandler _wa.OnReceiveContacts, AddressOf frmDbKontakClass.AddKontakToDB ' unsubscribe event
    End Sub
#End Region

End Class