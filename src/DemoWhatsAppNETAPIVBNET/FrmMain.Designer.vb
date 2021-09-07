<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblState = New System.Windows.Forms.Label()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnDatabase = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtPesan = New System.Windows.Forms.TextBox()
        Me.flowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnKirim = New System.Windows.Forms.Button()
        Me.flowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkKirimPesanDgGambar = New System.Windows.Forms.CheckBox()
        Me.txtFileGambar = New System.Windows.Forms.TextBox()
        Me.btnCariGambar = New System.Windows.Forms.Button()
        Me.flowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkKirimFileAja = New System.Windows.Forms.CheckBox()
        Me.txtFileDokumen = New System.Windows.Forms.TextBox()
        Me.btnCariDokumen = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkKirimGambarDariUrl = New System.Windows.Forms.CheckBox()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLokasiPenyimpananFileAtauGambar = New System.Windows.Forms.Button()
        Me.btnLokasiWAAutomateNodejs = New System.Windows.Forms.Button()
        Me.txtLokasiPenyimpananFileAtauGambar = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtLokasiWhatsAppNETAPINodeJs = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.flowLayoutPanel2.SuspendLayout()
        Me.flowLayoutPanel4.SuspendLayout()
        Me.flowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.lblState, 0, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox1, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox2, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.CheckedListBox1, 0, 3)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 5
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 362.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(1284, 702)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblState.Location = New System.Drawing.Point(4, 664)
        Me.lblState.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(1276, 38)
        Me.lblState.TabIndex = 5
        Me.lblState.Text = "State:"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Controls.Add(Me.btnStart)
        Me.flowLayoutPanel1.Controls.Add(Me.btnStop)
        Me.flowLayoutPanel1.Controls.Add(Me.btnDatabase)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(4, 120)
        Me.flowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(1276, 45)
        Me.flowLayoutPanel1.TabIndex = 0
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(124, 5)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(112, 35)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnDatabase
        '
        Me.btnDatabase.Enabled = False
        Me.btnDatabase.Location = New System.Drawing.Point(244, 5)
        Me.btnDatabase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDatabase.Name = "btnDatabase"
        Me.btnDatabase.Size = New System.Drawing.Size(152, 35)
        Me.btnDatabase.TabIndex = 6
        Me.btnDatabase.Text = "Kontak"
        Me.btnDatabase.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Label6)
        Me.groupBox1.Controls.Add(Me.tableLayoutPanel2)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(4, 175)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox1.Size = New System.Drawing.Size(1276, 352)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = " [ Kirim Pesan ] "
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 351)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Label6"
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 2
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.label3, 0, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.txtPesan, 1, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.flowLayoutPanel2, 1, 5)
        Me.tableLayoutPanel2.Controls.Add(Me.flowLayoutPanel4, 1, 2)
        Me.tableLayoutPanel2.Controls.Add(Me.flowLayoutPanel5, 1, 4)
        Me.tableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel6, 1, 3)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(4, 24)
        Me.tableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 6
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(1268, 323)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label3.Location = New System.Drawing.Point(4, 38)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(54, 98)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Pesan"
        '
        'txtPesan
        '
        Me.txtPesan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPesan.Location = New System.Drawing.Point(66, 43)
        Me.txtPesan.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPesan.Multiline = True
        Me.txtPesan.Name = "txtPesan"
        Me.txtPesan.Size = New System.Drawing.Size(1198, 88)
        Me.txtPesan.TabIndex = 1
        '
        'flowLayoutPanel2
        '
        Me.flowLayoutPanel2.Controls.Add(Me.btnKirim)
        Me.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowLayoutPanel2.Location = New System.Drawing.Point(66, 279)
        Me.flowLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.flowLayoutPanel2.Name = "flowLayoutPanel2"
        Me.flowLayoutPanel2.Size = New System.Drawing.Size(1198, 39)
        Me.flowLayoutPanel2.TabIndex = 2
        '
        'btnKirim
        '
        Me.btnKirim.Enabled = False
        Me.btnKirim.Location = New System.Drawing.Point(1082, 5)
        Me.btnKirim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnKirim.Name = "btnKirim"
        Me.btnKirim.Size = New System.Drawing.Size(112, 35)
        Me.btnKirim.TabIndex = 2
        Me.btnKirim.Text = "Kirim"
        Me.btnKirim.UseVisualStyleBackColor = True
        '
        'flowLayoutPanel4
        '
        Me.flowLayoutPanel4.Controls.Add(Me.chkKirimPesanDgGambar)
        Me.flowLayoutPanel4.Controls.Add(Me.txtFileGambar)
        Me.flowLayoutPanel4.Controls.Add(Me.btnCariGambar)
        Me.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel4.Location = New System.Drawing.Point(62, 136)
        Me.flowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.flowLayoutPanel4.Name = "flowLayoutPanel4"
        Me.flowLayoutPanel4.Size = New System.Drawing.Size(1206, 46)
        Me.flowLayoutPanel4.TabIndex = 3
        '
        'chkKirimPesanDgGambar
        '
        Me.chkKirimPesanDgGambar.AutoSize = True
        Me.chkKirimPesanDgGambar.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkKirimPesanDgGambar.Location = New System.Drawing.Point(4, 5)
        Me.chkKirimPesanDgGambar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkKirimPesanDgGambar.Name = "chkKirimPesanDgGambar"
        Me.chkKirimPesanDgGambar.Size = New System.Drawing.Size(197, 35)
        Me.chkKirimPesanDgGambar.TabIndex = 0
        Me.chkKirimPesanDgGambar.Text = "Kirim pesan dg gambar"
        Me.chkKirimPesanDgGambar.UseVisualStyleBackColor = True
        '
        'txtFileGambar
        '
        Me.txtFileGambar.Location = New System.Drawing.Point(209, 5)
        Me.txtFileGambar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFileGambar.Name = "txtFileGambar"
        Me.txtFileGambar.ReadOnly = True
        Me.txtFileGambar.Size = New System.Drawing.Size(787, 26)
        Me.txtFileGambar.TabIndex = 1
        '
        'btnCariGambar
        '
        Me.btnCariGambar.Enabled = False
        Me.btnCariGambar.Location = New System.Drawing.Point(1004, 5)
        Me.btnCariGambar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCariGambar.Name = "btnCariGambar"
        Me.btnCariGambar.Size = New System.Drawing.Size(51, 35)
        Me.btnCariGambar.TabIndex = 2
        Me.btnCariGambar.Text = "..."
        Me.btnCariGambar.UseVisualStyleBackColor = True
        '
        'flowLayoutPanel5
        '
        Me.flowLayoutPanel5.Controls.Add(Me.chkKirimFileAja)
        Me.flowLayoutPanel5.Controls.Add(Me.txtFileDokumen)
        Me.flowLayoutPanel5.Controls.Add(Me.btnCariDokumen)
        Me.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel5.Location = New System.Drawing.Point(62, 228)
        Me.flowLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.flowLayoutPanel5.Name = "flowLayoutPanel5"
        Me.flowLayoutPanel5.Size = New System.Drawing.Size(1206, 46)
        Me.flowLayoutPanel5.TabIndex = 3
        '
        'chkKirimFileAja
        '
        Me.chkKirimFileAja.AutoSize = True
        Me.chkKirimFileAja.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkKirimFileAja.Location = New System.Drawing.Point(4, 5)
        Me.chkKirimFileAja.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkKirimFileAja.Name = "chkKirimFileAja"
        Me.chkKirimFileAja.Size = New System.Drawing.Size(93, 35)
        Me.chkKirimFileAja.TabIndex = 0
        Me.chkKirimFileAja.Text = "Kirim file"
        Me.chkKirimFileAja.UseVisualStyleBackColor = True
        '
        'txtFileDokumen
        '
        Me.txtFileDokumen.Location = New System.Drawing.Point(105, 5)
        Me.txtFileDokumen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFileDokumen.Name = "txtFileDokumen"
        Me.txtFileDokumen.ReadOnly = True
        Me.txtFileDokumen.Size = New System.Drawing.Size(890, 26)
        Me.txtFileDokumen.TabIndex = 1
        '
        'btnCariDokumen
        '
        Me.btnCariDokumen.Enabled = False
        Me.btnCariDokumen.Location = New System.Drawing.Point(1003, 5)
        Me.btnCariDokumen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCariDokumen.Name = "btnCariDokumen"
        Me.btnCariDokumen.Size = New System.Drawing.Size(51, 35)
        Me.btnCariDokumen.TabIndex = 2
        Me.btnCariDokumen.Text = "..."
        Me.btnCariDokumen.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.chkKirimGambarDariUrl)
        Me.FlowLayoutPanel6.Controls.Add(Me.txtUrl)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(62, 182)
        Me.FlowLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(1206, 46)
        Me.FlowLayoutPanel6.TabIndex = 3
        '
        'chkKirimGambarDariUrl
        '
        Me.chkKirimGambarDariUrl.AutoSize = True
        Me.chkKirimGambarDariUrl.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkKirimGambarDariUrl.Location = New System.Drawing.Point(4, 5)
        Me.chkKirimGambarDariUrl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkKirimGambarDariUrl.Name = "chkKirimGambarDariUrl"
        Me.chkKirimGambarDariUrl.Size = New System.Drawing.Size(228, 26)
        Me.chkKirimGambarDariUrl.TabIndex = 0
        Me.chkKirimGambarDariUrl.Text = "Kirim pesan dg gambar (url)"
        Me.chkKirimGambarDariUrl.UseVisualStyleBackColor = True
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(240, 5)
        Me.txtUrl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(787, 26)
        Me.txtUrl.TabIndex = 1
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btnLokasiPenyimpananFileAtauGambar)
        Me.groupBox2.Controls.Add(Me.btnLokasiWAAutomateNodejs)
        Me.groupBox2.Controls.Add(Me.txtLokasiPenyimpananFileAtauGambar)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.txtLokasiWhatsAppNETAPINodeJs)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(4, 5)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBox2.Size = New System.Drawing.Size(1276, 105)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = " [ Konfigurasi ] "
        '
        'btnLokasiPenyimpananFileAtauGambar
        '
        Me.btnLokasiPenyimpananFileAtauGambar.Location = New System.Drawing.Point(1086, 63)
        Me.btnLokasiPenyimpananFileAtauGambar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLokasiPenyimpananFileAtauGambar.Name = "btnLokasiPenyimpananFileAtauGambar"
        Me.btnLokasiPenyimpananFileAtauGambar.Size = New System.Drawing.Size(51, 35)
        Me.btnLokasiPenyimpananFileAtauGambar.TabIndex = 2
        Me.btnLokasiPenyimpananFileAtauGambar.Text = "..."
        Me.btnLokasiPenyimpananFileAtauGambar.UseVisualStyleBackColor = True
        '
        'btnLokasiWAAutomateNodejs
        '
        Me.btnLokasiWAAutomateNodejs.Location = New System.Drawing.Point(1086, 23)
        Me.btnLokasiWAAutomateNodejs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLokasiWAAutomateNodejs.Name = "btnLokasiWAAutomateNodejs"
        Me.btnLokasiWAAutomateNodejs.Size = New System.Drawing.Size(51, 35)
        Me.btnLokasiWAAutomateNodejs.TabIndex = 2
        Me.btnLokasiWAAutomateNodejs.Text = "..."
        Me.btnLokasiWAAutomateNodejs.UseVisualStyleBackColor = True
        '
        'txtLokasiPenyimpananFileAtauGambar
        '
        Me.txtLokasiPenyimpananFileAtauGambar.Location = New System.Drawing.Point(404, 66)
        Me.txtLokasiPenyimpananFileAtauGambar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLokasiPenyimpananFileAtauGambar.Name = "txtLokasiPenyimpananFileAtauGambar"
        Me.txtLokasiPenyimpananFileAtauGambar.ReadOnly = True
        Me.txtLokasiPenyimpananFileAtauGambar.Size = New System.Drawing.Size(672, 26)
        Me.txtLokasiPenyimpananFileAtauGambar.TabIndex = 1
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(14, 71)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(381, 20)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Lokasi penyimpanan file atau gambar (pesan masuk)"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLokasiWhatsAppNETAPINodeJs
        '
        Me.txtLokasiWhatsAppNETAPINodeJs.Location = New System.Drawing.Point(404, 26)
        Me.txtLokasiWhatsAppNETAPINodeJs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLokasiWhatsAppNETAPINodeJs.Name = "txtLokasiWhatsAppNETAPINodeJs"
        Me.txtLokasiWhatsAppNETAPINodeJs.ReadOnly = True
        Me.txtLokasiWhatsAppNETAPINodeJs.Size = New System.Drawing.Size(672, 26)
        Me.txtLokasiWhatsAppNETAPINodeJs.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 31)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(257, 20)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Lokasi WhatsApp NET API NodeJs"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(4, 537)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(247, 119)
        Me.CheckedListBox1.TabIndex = 6
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(4, 5)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(112, 35)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 702)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo WhatsAppAPI untuk .NET Developer (VB.NET)"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.tableLayoutPanel2.PerformLayout()
        Me.flowLayoutPanel2.ResumeLayout(False)
        Me.flowLayoutPanel4.ResumeLayout(False)
        Me.flowLayoutPanel4.PerformLayout()
        Me.flowLayoutPanel5.ResumeLayout(False)
        Me.flowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tableLayoutPanel1 As TableLayoutPanel
    Private WithEvents flowLayoutPanel1 As FlowLayoutPanel
    Private WithEvents btnStop As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents tableLayoutPanel2 As TableLayoutPanel
    Private WithEvents label3 As Label
    Private WithEvents txtPesan As TextBox
    Private WithEvents flowLayoutPanel2 As FlowLayoutPanel
    Private WithEvents btnKirim As Button
    Private WithEvents flowLayoutPanel4 As FlowLayoutPanel
    Private WithEvents chkKirimPesanDgGambar As CheckBox
    Private WithEvents txtFileGambar As TextBox
    Private WithEvents btnCariGambar As Button
    Private WithEvents flowLayoutPanel5 As FlowLayoutPanel
    Private WithEvents chkKirimFileAja As CheckBox
    Private WithEvents txtFileDokumen As TextBox
    Private WithEvents btnCariDokumen As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents btnLokasiPenyimpananFileAtauGambar As Button
    Private WithEvents btnLokasiWAAutomateNodejs As Button
    Private WithEvents txtLokasiPenyimpananFileAtauGambar As TextBox
    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents txtLokasiWhatsAppNETAPINodeJs As TextBox
    Private WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Private WithEvents chkKirimGambarDariUrl As CheckBox
    Private WithEvents txtUrl As TextBox
    Private WithEvents lblState As Label
    Friend WithEvents btnDatabase As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Label6 As Label
    Private WithEvents btnStart As Button
End Class
