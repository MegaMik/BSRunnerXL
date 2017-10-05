Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Org.BouncyCastle.X509
Imports Org.BouncyCastle.Asn1
Imports System.IO
Imports Org.BouncyCastle.Asn1.X509
Imports System.Collections

Namespace ReisJr.BouncyCastle.Utils
    Public Class CertificateUtils
        Public Shared Function LoadCertificate(filename As String) As X509Certificate
            Dim certParser As New X509CertificateParser()
            Dim fs As New FileStream(filename, FileMode.Open)
            Dim cert As X509Certificate = certParser.ReadCertificate(fs)
            fs.Close()

            Return cert
        End Function

        Public Shared Function GetAuthorityInformationAccessOcspUrl(cert As X509Certificate) As List(Of String)
            Dim ocspUrls As New List(Of String)()

            Try
                Dim obj As Asn1Object = GetExtensionValue(cert, X509Extensions.AuthorityInfoAccess.Id)

                If obj Is Nothing Then
                    Return Nothing
                End If

                ' For a strange reason I cannot acess the aia.AccessDescription[].
                ' Hope it will be fixed in the next version (1.5).
                ' AuthorityInformationAccess aia = AuthorityInformationAccess.GetInstance(obj);

                ' Switched to manual parse
                Dim s As Asn1Sequence = CType(obj, Asn1Sequence)
                Dim elements As IEnumerator = s.GetEnumerator()

                While elements.MoveNext()
                    Dim element As Asn1Sequence = CType(elements.Current, Asn1Sequence)
                    Dim oid As DerObjectIdentifier = CType(element(0), DerObjectIdentifier)

                    If oid.Id.Equals("1.3.6.1.5.5.7.48.1") Then
                        ' Is Ocsp?
                        Dim taggedObject As Asn1TaggedObject = CType(element(1), Asn1TaggedObject)
                        Dim gn As GeneralName = CType(GeneralName.GetInstance(taggedObject), GeneralName)
                        ocspUrls.Add((CType(DerIA5String.GetInstance(gn.Name), DerIA5String)).GetString())
                    End If
                End While
            Catch e As Exception
                Throw New Exception("Error parsing AIA.", e)
            End Try

            Return ocspUrls
        End Function



        Protected Shared Function GetExtensionValue(cert As X509Certificate, oid As String) As Asn1Object
            If cert Is Nothing Then
                Return Nothing
            End If

            Dim bytes As Byte() = cert.GetExtensionValue(New DerObjectIdentifier(oid)).GetOctets()

            If bytes Is Nothing Then
                Return Nothing
            End If

            Dim aIn As New Asn1InputStream(bytes)

            Return aIn.ReadObject()
        End Function



    End Class
End Namespace