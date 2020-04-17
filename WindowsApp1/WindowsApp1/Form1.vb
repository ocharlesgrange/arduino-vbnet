Imports System.Threading
Imports System.IO
Imports System.IO.Ports

Public Class Form1
    Shared _continue As Boolean
    Shared _serialPort As SerialPort
    Dim comport = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Button1.Text = "Acender") Then
            Button1.Text = "Desligar"
        Else
            Button1.Text = "Acender"
        End If
        SerialPort1.Open()
        SerialPort1.Write("1")
        SerialPort1.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Button2.Text = "Acender") Then
            Button2.Text = "Desligar"
        Else
            Button2.Text = "Acender"
        End If
        SerialPort1.Open()
        SerialPort1.Write("2")
        SerialPort1.Close()
    End Sub

    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Button3.Text = "Acender") Then
            Button3.Text = "Desligar"
        Else
            Button3.Text = "Acender"
        End If
        SerialPort1.Open()
        SerialPort1.Write("3")
        SerialPort1.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        comport = ComboBox1.SelectedItem
        If (Button4.Text = "Conectar") Then
            If (comport = "") Then
                MsgBox("Por favor, selecione uma COMX!")
            Else
                SerialPort1.Close()
                SerialPort1.PortName = comport
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default
                Button1.Enabled = True
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Text = "Desconectar"
                Button4.FlatAppearance.BorderColor = Color.Red
                Button4.FlatAppearance.MouseOverBackColor = Color.Red
            End If
        Else
            Button4.Text = "Desconectar"
            Button4.FlatAppearance.BorderColor = Color.Red
            Button4.FlatAppearance.MouseOverBackColor = Color.Red
            SerialPort1.Close()
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Conectar"
            Button4.FlatAppearance.BorderColor = Color.Green
            Button4.FlatAppearance.MouseOverBackColor = Color.Green
        End If

    End Sub
End Class
