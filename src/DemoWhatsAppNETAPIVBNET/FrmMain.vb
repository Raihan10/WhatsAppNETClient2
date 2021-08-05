﻿'*********************************************************************************************************
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

Public Class FrmMain

    Private _wa As IWhatsAppNETAPI

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _wa = New WhatsAppNETAPI.WhatsAppNETAPI()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
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
        AddHandler _wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
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
        btnGrabContacts.Enabled = False
        btnGrabGroupAndMembers.Enabled = False
        btnUnreadMessages.Enabled = False
        btnArchiveChat.Enabled = False
        btnDeleteChat.Enabled = False
        btnKirim.Enabled = False

        txtFileDokumen.Clear()
        txtFileGambar.Clear()

        chkSubscribe.Checked = False
        chkSubscribe.Enabled = False

        chkMessageSentSubscribe.Checked = False
        chkMessageSentSubscribe.Enabled = False

        chkAutoReplay.Checked = False
        chkAutoReplay.Enabled = False

        lstPesanMasuk.Items.Clear()

        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))
            ' unsubscribe event
            RemoveHandler _wa.OnStartup, AddressOf OnStartupHandler
            RemoveHandler _wa.OnChangeState, AddressOf OnChangeStateHandler
            RemoveHandler _wa.OnScanMe, AddressOf OnScanMeHandler
            RemoveHandler _wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler
            RemoveHandler _wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
            RemoveHandler _wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler
            RemoveHandler _wa.OnClientConnected, AddressOf OnClientConnectedHandler

            _wa.Disconnect()

        End Using
    End Sub

    Private Sub btnKirim_Click(sender As Object, e As EventArgs) Handles btnKirim.Click

        Dim msgArgs As MsgArgs
        Dim jumlahPesan = Int32.Parse(txtJumlahPesan.Text)

        If (jumlahPesan > 1) Then ' broadcast

            Dim list As New List(Of MsgArgs)
            Dim index As Integer

            For index = 1 To jumlahPesan

                If chkKirimPesanDgGambar.Checked Then
                    msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Image, txtFileGambar.Text)
                ElseIf chkKirimGambarDariUrl.Checked Then
                    msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Url, txtUrl.Text)
                ElseIf chkKirimFileAja.Checked Then
                    msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.File, txtFileDokumen.Text)
                Else
                    msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Text)
                End If

                list.Add(msgArgs)

            Next

            _wa.BroadcastMessage(list)
        Else

            If chkKirimPesanDgGambar.Checked Then
                msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Image, txtFileGambar.Text)
            ElseIf chkKirimGambarDariUrl.Checked Then
                msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Url, txtUrl.Text)
            ElseIf chkKirimFileAja.Checked Then
                msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.File, txtFileDokumen.Text)
            Else
                msgArgs = New MsgArgs(txtKontak.Text, txtPesan.Text, MsgArgsType.Text)
            End If

            _wa.SendMessage(msgArgs)
        End If
    End Sub

    Private Sub chkSubscribe_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubscribe.CheckedChanged
        If (chkSubscribe.Checked) Then
            AddHandler _wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler ' subscribe event
        Else
            RemoveHandler _wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler ' unsubscribe event
            lstPesanMasuk.Items.Clear()
        End If

        chkAutoReplay.Enabled = chkSubscribe.Checked
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

    Private Sub btnGrabContacts_Click(sender As Object, e As EventArgs) Handles btnGrabContacts.Click
        Using frm As New FrmContactOrGroup("Contacts")

            AddHandler _wa.OnReceiveContacts, AddressOf frm.OnReceiveContactsHandler ' subscribe event
            _wa.GetContacts()

            frm.ShowDialog()
            RemoveHandler _wa.OnReceiveContacts, AddressOf frm.OnReceiveContactsHandler ' unsubscribe event

        End Using
    End Sub

    Private Sub chkMessageSentSubscribe_CheckedChanged(sender As Object, e As EventArgs) Handles chkMessageSentSubscribe.CheckedChanged

        If chkMessageSentSubscribe.Checked Then
            AddHandler _wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler ' subscribe event
        Else
            RemoveHandler _wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler ' unsubscribe event

            lstPesanKeluar.Items.Clear()
        End If
    End Sub

    Private Sub btnDeleteChat_Click(sender As Object, e As EventArgs) Handles btnDeleteChat.Click
        Dim msg = "Fungsi ini akan MENGHAPUS semua pesan." + Environment.NewLine +
                  "Apakah ingin dilanjutkan"
        If MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _wa.DeleteChat()
        End If
    End Sub

    Private Sub btnArchiveChat_Click(sender As Object, e As EventArgs) Handles btnArchiveChat.Click
        Dim msg = "Fungsi ini akan MENGARSIPKAN semua pesan." + Environment.NewLine +
                  "Apakah ingin dilanjutkan"
        If MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _wa.ArchiveChat()
        End If
    End Sub

    Private Sub btnUnreadMessages_Click(sender As Object, e As EventArgs) Handles btnUnreadMessages.Click
        _wa.GetUnreadMessage()
    End Sub

#Region "Event handler"

    Private Sub OnStartupHandler(ByVal message As String)

        ' koneksi ke WA berhasil
        If message.IndexOf("Ready") >= 0 Then

            btnStart.Invoke(Sub() btnStart.Enabled = False)
            btnStop.Invoke(Sub() btnStop.Enabled = True)
            btnGrabContacts.Invoke(Sub() btnGrabContacts.Enabled = True)
            btnGrabGroupAndMembers.Invoke(Sub() btnGrabGroupAndMembers.Enabled = True)
            btnUnreadMessages.Invoke(Sub() btnUnreadMessages.Enabled = True)
            btnArchiveChat.Invoke(Sub() btnArchiveChat.Enabled = True)
            btnDeleteChat.Invoke(Sub() btnDeleteChat.Enabled = True)
            btnKirim.Invoke(Sub() btnKirim.Enabled = True)
            btnDatabase.Invoke(Sub() btnDatabase.Enabled = True)
            chkSubscribe.Invoke(Sub() chkSubscribe.Enabled = True)
            chkMessageSentSubscribe.Invoke(Sub() chkMessageSentSubscribe.Enabled = True)

            Me.UseWaitCursor = False

        End If

        ' koneksi ke WA GAGAL, bisa dicoba lagi
        If message.IndexOf("Failure") >= 0 OrElse message.IndexOf("Timeout") >= 0 _
            OrElse message.IndexOf("ERR_NAME") >= 0 Then

            ' unsubscribe event
            RemoveHandler _wa.OnStartup, AddressOf OnStartupHandler
            RemoveHandler _wa.OnScanMe, AddressOf OnScanMeHandler
            RemoveHandler _wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler
            RemoveHandler _wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
            RemoveHandler _wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler
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

    Private Sub OnReceiveMessageHandler(ByVal message As WhatsAppNETAPI.Message)

        System.Diagnostics.Debug.Print(message.type)

        Dim msg = message.content
        Dim pengirim = IIf(String.IsNullOrEmpty(message.sender.name), message.from, message.sender.name)
        Dim fileName = message.filename

        Dim data = String.Empty

        If String.IsNullOrEmpty(fileName) Then
            data = String.Format("[{0}] Pengirim: {1}, Pesan teks: {2}",
                    message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg)
        Else
            data = String.Format("[{0}] Pengirim: {1}, Pesan gambar/dokumen: {2}, nama file: {3}",
                    message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg, fileName)
        End If

        ' update UI dari thread yang berbeda
        lstPesanMasuk.Invoke(
            Sub()
                lstPesanMasuk.Items.Add(data)

                If message.type = MessageType.Location Then

                    Dim location = message.location

                    Dim dataLocation = String.Format("--> latitude: {0}, longitude: {1}, description: {2}",
                        location.latitude, location.longitude, location.description)

                    lstPesanMasuk.Items.Add(dataLocation)

                ElseIf message.type = MessageType.VCard OrElse message.type = MessageType.MultiVCard Then
                    Dim vcards = message.vcards
                    Dim vcardFilenames = message.vcardFilenames

                    Dim index = 0
                    For Each vcard As VCard In vcards

                        Dim dataVCard = String.Format("--> N: {0}, FN: {1}, WA Id: {2}, fileName: {3}",
                            vcard.n, vcard.fn, vcard.waId, vcardFilenames(index))

                        lstPesanMasuk.Items.Add(dataVCard)

                        index = index + 1
                    Next
                End If

                lstPesanMasuk.SelectedIndex = lstPesanMasuk.Items.Count - 1
            End Sub
        )

        If chkAutoReplay.Checked Then

            Dim msgReplay = String.Format("Bpk/Ibu *{0}*, pesan *{1}* sudah kami terima. Silahkan ditunggu.",
                pengirim, msg)

            _wa.ReplyMessage(New ReplyMsgArgs(message.from, msgReplay, message.id))
        End If
    End Sub

    Private Sub OnReceiveMessagesHandler(messages As IList(Of Message))

        For Each message As Message In messages

            Dim msg = message.content
            Dim pengirim = IIf(String.IsNullOrEmpty(message.sender.name), message.from, message.sender.name)

            Dim data = String.Format("[{0}] Pengirim: {1}, Isi pesan: {2}",
            message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg)

            ' update UI dari thread yang berbeda
            lstPesanMasuk.Invoke(
                Sub()
                    lstPesanMasuk.Items.Add(data)
                    lstPesanMasuk.SelectedIndex = lstPesanMasuk.Items.Count - 1
                End Sub
            )

            If chkAutoReplay.Checked Then

                Dim senderName = IIf(String.IsNullOrEmpty(message.sender.name), message.from, message.sender.name)

                Dim msgReplay = String.Format("Bpk/Ibu *{0}*, pesan *{1}* sudah kami terima. Silahkan ditunggu.",
                    senderName, msg)

                _wa.ReplyMessage(New ReplyMsgArgs(message.from, msgReplay, message.id))
            End If
        Next

    End Sub

    Private Sub OnReceiveMessageStatusHandler(ByVal msgStatus As WhatsAppNETAPI.MessageStatus)

        Dim status = IIf(msgStatus.status = "true", "BERHASIL", "GAGAL")

        Dim msg = String.Format("Status pengiriman pesan ke {0}, {1}",
            msgStatus.send_to, status)

        ' update UI dari thread yang berbeda
        lstPesanMasuk.Invoke(
            Sub()
                lstPesanKeluar.Items.Add(msg)
                lstPesanKeluar.SelectedIndex = lstPesanKeluar.Items.Count - 1
            End Sub
        )

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

    Private Sub btnGrabGroupAndMembers_Click(sender As Object, e As EventArgs) Handles btnGrabGroupAndMembers.Click
        Using frm As New FrmContactOrGroup("Groups and Members")

            AddHandler _wa.OnReceiveGroups, AddressOf frm.OnReceiveGroupsHandler ' subscribe event
            _wa.GetGroups()

            frm.ShowDialog()
            RemoveHandler _wa.OnReceiveGroups, AddressOf frm.OnReceiveGroupsHandler ' unsubscribe event

        End Using
    End Sub

    Private Sub btnDatabase_Click(sender As Object, e As EventArgs) Handles btnDatabase.Click
        Using frm As New FrmDatabaseKontak("Kontak")
            frm.ShowDialog()
        End Using
    End Sub

#End Region

End Class