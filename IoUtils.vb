
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Net

Namespace ReisJr.BouncyCastle.Utils
    Public Class IoUtils
        Public Shared ReadOnly BufferSize As Integer = 4096 * 8

        Public Shared Function PostData(url As String, data As Byte(), contentType As String, accept As String) As Byte()
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = contentType
            request.ContentLength = data.Length
            request.Accept = accept
            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim respStream As Stream = response.GetResponseStream()
            Dim resp As Byte() = ToByteArray(respStream)
            respStream.Close()

            Return resp
        End Function



        Public Shared Function ToByteArray(stream As Stream) As Byte()
            Dim buffer As Byte() = New Byte(BufferSize) {}
            Dim ms As New MemoryStream()

            Dim read As Integer = 0

            While (read = stream.Read(buffer, 0, buffer.Length)) > 0
                ms.Write(buffer, 0, read)
            End While

            Return ms.ToArray()
        End Function


    End Class
End Namespace

