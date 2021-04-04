Imports System.Threading

Public Class Form1
    Dim hilo As Thread
    Dim hilo_inicio As New ThreadStart(AddressOf label_animation1)
    Dim num_random As New Random
    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        Arrastre = False
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If Arrastre Then
            Location = PointToScreen(New Point(MousePosition.X - Location.X - ex, MousePosition.Y - Location.Y - ey))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        Panel5.BackColor = Color.LightSkyBlue

        Dim ubicaion = New Point(8, 42)

        If (Label1.Location = ubicaion And TextBox1.ForeColor = Color.DimGray) Then
            Try
                Label1.Visible = True

                hilo_inicio = New ThreadStart(AddressOf label_animation1)
                hilo = New Thread(hilo_inicio)
                hilo.IsBackground = True
                hilo.Start()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Panel5.BackColor = Color.SteelBlue

        Dim ubicaion = New Point(8, 22)

        If (Label1.Location = ubicaion And TextBox1.Text.Equals("")) Then
            Try

                'hilo_inicio = New ThreadStart(AddressOf label_animation2)
                'hilo = New Thread(hilo_inicio)
                'hilo.IsBackground = True
                'hilo.Start()

                Label1.ForeColor = Color.DimGray
                Label1.Location = New Point(8, 42)
                Label1.Font = New Font(Label1.Font.Name, 12)
                Label1.Visible = False
                TextBox1.ForeColor = Color.DimGray
                TextBox1.Text = "Repeticiones"
                TextBox1.Enabled = False
                TextBox1.Enabled = True

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub label_animation1()
        Try
            Form1.CheckForIllegalCrossThreadCalls = False

            Label1.ForeColor = Color.White
            TextBox1.ForeColor = Color.White
            TextBox1.Text = ""

            For i As Integer = 0 To 3

                Label1.Location = New Point(Label1.Location.X, Label1.Location.Y - 5)

                If (Label1.Location.Y = 32 Or Label1.Location.Y = 22) Then
                    Label1.Font = New Font(Label1.Font.Name, Label1.Font.SizeInPoints - 1)
                End If

                Thread.Sleep(25)
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Private Sub label_animation2()
    '    Try
    '        Form1.CheckForIllegalCrossThreadCalls = False

    '        For i As Integer = 0 To 3

    '            If (Label1.Location.Y = 32 Or Label1.Location.Y = 22) Then
    '                Label1.Font = New Font(Label1.Font.Name, Label1.Font.SizeInPoints + 1)
    '            End If

    '            Label1.Location = New Point(Label1.Location.X, Label1.Location.Y + 5)

    '            Thread.Sleep(25)
    '        Next

    '        Label1.ForeColor = Color.DimGray
    '        Label1.Location = New Point(8, 42)
    '        Label1.Font = New Font(Label1.Font.Name, 12)
    '        Label1.Visible = False
    '        TextBox1.ForeColor = Color.DimGray
    '        TextBox1.Text = "Repeticiones"

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub

    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long)
    'LEFT BUTTON DOWN = &H2
    'LEFT BUTTON UP = &H4
    'RIGHT BUTTON DOWN = &H8
    'RIGHT BUTTON UP = &H10
    'MIDDLE BUTTON DOWN = &H20
    'MIDDLE BUTTON UP = &H40

    Private Sub solo_numeros(e As KeyPressEventArgs)
        If (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        solo_numeros(e)
    End Sub

    Private Sub cast_alchemy(replays)
        Try
            If (Char.IsNumber(TextBox1.Text)) Then
                replays = TextBox1.Text

                WindowState = FormWindowState.Minimized

                Dim mouse = New Point(num_random.Next(1277, 1284), num_random.Next(527, 536))

                For i As Integer = 1 To replays

                    If (Cursor.Position <> mouse) Then
                        Cursor.Position = New Point(mouse)
                    End If

                    If (CheckBox1.Checked) Then

                        mouse_event(&H2)
                        mouse_event(&H4)
                        Thread.Sleep(num_random.Next(300, 400))

                        If (Cursor.Position <> mouse) Then
                            Cursor.Position = New Point(mouse)
                        End If

                        mouse_event(&H2)
                        mouse_event(&H4)
                        Thread.Sleep(num_random.Next(1600, 1700))

                        My.Computer.Keyboard.SendKeys(" ")
                        Thread.Sleep(num_random.Next(1400, 1500))

                        My.Computer.Keyboard.SendKeys("1")

                    Else

                        mouse_event(&H2)
                        mouse_event(&H4)

                        Thread.Sleep(num_random.Next(350, 480))

                        If (Cursor.Position <> mouse) Then
                            Cursor.Position = New Point(mouse)
                        End If

                        mouse_event(&H2)
                        mouse_event(&H4)

                    End If

                    Thread.Sleep(num_random.Next(3000, 4000))

                    If (i = replays) Then
                        WindowState = FormWindowState.Normal
                        MsgBox("Listo perro😎")
                    End If
                Next

                TextBox1.Text = "Repeticiones"
                TextBox1.ForeColor = Color.DimGray
                Label1.ForeColor = Color.DimGray
                Label1.Location = New Point(8, 42)
                Label1.Font = New Font(Label1.Font.Name, 12)
                Label1.Visible = False
                CheckBox1.Checked = False
                CheckBox1.Focus()
                WindowState = FormWindowState.Minimized
            Else
                MsgBox("Debe ingresar el número de items para hacer alchemy")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cast_alchemy(TextBox1.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        AcceptButton = Button1
    End Sub
End Class
