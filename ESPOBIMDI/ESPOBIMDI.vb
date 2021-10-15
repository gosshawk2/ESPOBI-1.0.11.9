Public Class ESPOBIMDI
    Dim GlobalParms As ESPOBIParms.BIParms
    Dim GlobalSession As ESPOParms.Session
    Dim p As System.Security.Principal.WindowsPrincipal = CType(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    Dim userid As String = p.Identity.Name


    Private Sub ESPOBIMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim myDAL = New SQLBuilder.SQLBuilderDAL

        GlobalSession = New ESPOParms.Session
        GlobalParms = New ESPOBIParms.BIParms
        GlobalSession.CurrentUser = userid
        GlobalSession.CurrentUserShort = GlobalSession.CurrentUser.Split("\")(1)


        Dim strStartupArguments() As String
        strStartupArguments = System.Environment.GetCommandLineArgs
        Me.WindowState = FormWindowState.Maximized
        Try
            If strStartupArguments(1).ToString = "123456" Then
                GlobalSession.CurrentMode = strStartupArguments(2).ToString
                GlobalSession.CurrentServer = strStartupArguments(3).ToString
            Else
                MsgBox("Invalid application key passed",, "Error Loading Frameworks")
            End If
        Catch ex As Exception

            If GlobalSession.CurrentUserShort = "agl015" Or GlobalSession.CurrentUserShort = "ddg407" Or GlobalSession.CurrentUserShort = "PC" Then
                'Dim MS As ModeSelect
                'GlobalSession.CurrentMode = MS.GetParms()
                ModeSelect.ShowDialog()
                GlobalSession.CurrentMode = ModeSelect.GetMode()
                GlobalSession.CurrentServer = "PARAGON"
            Else
                MsgBox("This application needs to be run from the ESPO Application Launcher",, "Error Loading Frameworks Application")
                End
            End If

        End Try
        Dim espoConnect As New ESPOCommon.ESPOConnect
        GlobalSession.ConnectString = espoConnect.GetConnectString(GlobalSession.CurrentMode, GlobalSession.CurrentServer)
        GlobalSession.MDIParentHandle = Me.Handle
        GlobalParms.IBMConnectionString = GlobalSession.ConnectString
        GlobalParms.MySQLConnectionString = myDAL.GetMYSQLConnection()
        stsFW100Label2.Spring = True
        stsFW100Label3.Text = "    User: " & GlobalSession.CurrentUserShort & "   "
        stsFW100Label4.Text = "    Server: " & GlobalSession.CurrentServer & "   "
        stsFW100Label5.Text = "    Environment: " & GlobalSession.CurrentMode & "   "
        stsFW100Label6.Text = String.Format("    Version {0}", My.Application.Info.Version.ToString) & "   "
        NormalToolStripMenuItem.Checked = True
        DarkToolStripMenuItem.Checked = False
        MYSQLToolStripMenuItem.Checked = False
        'IBMToolStripMenuItem.Checked = True
        'DBToolStripMenuItem.Text = "IBM"
        'SQLBuilder.DataSetHeaderList.DBVersion = "IBM"
        SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL"
        DBToolStripMenuItem.Text = "MYSQL"
        IBMToolStripMenuItem.Checked = False
        MYSQLToolStripMenuItem.Checked = True
        ShowHeaderForm()

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next
        'SQLBuilderToolStripMenuItem.PerformClick()
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub ArrangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrangeToolStripMenuItem.Click
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub RestoreAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.WindowState = FormWindowState.Normal
        Next
    End Sub
    Private Sub MinimiseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimiseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.WindowState = FormWindowState.Minimized
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Label24.Text = String.Format("Clicked ""{0}"" with the {1} mouse button.", sender.name, e.Button.ToString.ToLower)
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Sub ShowHeaderForm()
        Cursor = Cursors.Default
        stsFW100Label1.Text = "Loading List......"
        Cursor = Cursors.WaitCursor
        Refresh()
        Dim App As New SQLBuilder.DataSetHeaderList

        App.Visible = False
        App.GetParms(GlobalSession, GlobalParms)
        'App.PopulateForm()
        App.Show()
        stsFW100Label1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SQLBuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLBuilderToolStripMenuItem.Click
        ShowHeaderForm()

    End Sub

    'Private Sub ImportFromCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFromCSVToolStripMenuItem.Click
    'Tools-> import from csv form:
    '   Cursor = Cursors.Default
    '  stsFW100Label1.Text = "Loading List......"
    ' Cursor = Cursors.WaitCursor
    'Refresh()
    'Dim App As New SQLBuilder.ImportfromCSV

    '   App.Visible = False
    'App.GetParms(GlobalSession, GlobalParms)
    'App.PopulateForm()
    '  App.Show()
    ' stsFW100Label1.Text = ""
    'Cursor = Cursors.Default
    'End Sub

    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        ColumnAttributes.ColumnAttributes.ThemeSelection = 0
        DarkToolStripMenuItem.Checked = False
    End Sub

    Private Sub DarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkToolStripMenuItem.Click
        ColumnAttributes.ColumnAttributes.ThemeSelection = 1
        NormalToolStripMenuItem.Checked = False
    End Sub

    Private Sub IBMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IBMToolStripMenuItem.Click
        SQLBuilder.DataSetHeaderList.DBVersion = "IBM"
        DBToolStripMenuItem.Text = "IBM"
        MYSQLToolStripMenuItem.Checked = False
    End Sub

    Private Sub MYSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MYSQLToolStripMenuItem.Click
        SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL"
        DBToolStripMenuItem.Text = "MYSQL"
        IBMToolStripMenuItem.Checked = False
    End Sub

    Private Sub ImportFromCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFromCSVToolStripMenuItem.Click
        Cursor = Cursors.Default
        stsFW100Label1.Text = "Loading List......"
        Cursor = Cursors.WaitCursor
        Refresh()
        If SQLBuilder.DataSetHeaderList.DBVersion = "IBM" Then
            Dim App As New ImportTable.ImportTableDetail
            App.Visible = False
            App.GetParms(GlobalSession, GlobalParms)
            'App.PopulateForm()
            App.Show()
        ElseIf SQLBuilder.DataSetHeaderList.DBVersion = "MYSQL" Then
            Dim App As New ImportTable.DataSetColumns

            App.Visible = False
            App.GetParms(GlobalSession, GlobalParms)
            App.Show()

        End If


        stsFW100Label1.Text = ""
        Cursor = Cursors.Default
    End Sub
End Class