Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebServicePrueba
    Inherits System.Web.Services.WebService

    Dim data As DataTable = New DataTable
    Dim formato = 0

    <WebMethod()>
    Public Function GetConversion(ByVal car As String, ByVal FormatoDestino As String) As String
        'cargarInfo()
        Return data.Rows(car).Item(FormatoDestino).ToString
    End Function

    <WebMethod()>
    Public Function Translate(ByVal cadena As String, ByVal FormatoOrigen As String, ByVal FormatoDestino As String) As String
        cargarInfo()
        Dim letrasBinMor() As String
        Select Case FormatoOrigen
            Case "TEXT"
                For i = 0 To cadena.Length
                    cadena += GetConversion(cadena.Substring(i, i + 1), formato)
                Next
            Case "MORSE"
                letrasBinMor = cadena.Split(" ")
                For count = 0 To letrasBinMor.Length - 1
                    cadena += GetConversion(letrasBinMor(count), formato)
                Next
            Case "BINARY"
                letrasBinMor = cadena.Split(" ")
                For count = 0 To letrasBinMor.Length - 1
                    cadena += GetConversion(letrasBinMor(count), formato)
                Next
            Case Else
                'For i = 0 To cadena.Length
                '    GetConversion(cadena.Substring(0, i), formato)
                'Next
        End Select
        Return cadena
    End Function

    <WebMethod()>
    Public Function DefinirFormato(ByVal FormatoDestino As String) As String
        Select Case FormatoDestino
            Case "TEXT"
                formato = 0
            Case "MORSE"
                formato = 1
            Case "BINARY"
                formato = 2
            Case Else
                formato = 3
        End Select
    End Function


    <WebMethod()>
    Public Function cargarInfo() As String

        data.Columns.Add("TEXT")
        data.Columns.Add("MORSE")
        data.Columns.Add("BINARY")
        'data.Columns.Add("Otro")
        data.Rows.Add("A", ".", "10011")
        data.Rows.Add("B", ".-", "11111")
        data.Rows.Add("C", "..", "10011")
        data.Rows.Add("D", ".-", "11011")
        data.Rows.Add("E", "--", "10011")
        data.Rows.Add("F", "...", "10101")
        data.Rows.Add("G", "..-", "10001")
        data.Rows.Add("H", ".--", "10010")
        data.Rows.Add("I", "-.-", "01001")
        data.Rows.Add("J", "--.", "10001")
        data.Rows.Add("K", "...-", "10011")
        data.Rows.Add("L", "..--", "100001")
        data.Rows.Add("M", ".---", "111101")
        data.Rows.Add("N", "----", "111001")
        data.Rows.Add("O", "..-", "010101")
        data.Rows.Add("P", "..-", "010101")
        data.Rows.Add("Q", "..-", "111001")
        data.Rows.Add("R", "..-", "101101")
        data.Rows.Add("S", "..-", "100111")
        data.Rows.Add("T", "..-", "010000")
        data.Rows.Add("U", "..-", "010010")
        data.Rows.Add("V", "..-", "100100")
        data.Rows.Add("W", "..-", "010010")
        data.Rows.Add("X", "..-", "100001")
        data.Rows.Add("Y", "..-", "101011")
        data.Rows.Add("Z", "..-", "101101")
        Return JsonConvert.SerializeObject(data)
    End Function

End Class