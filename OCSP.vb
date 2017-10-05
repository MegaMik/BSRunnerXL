Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Text

Imports Org.BouncyCastle.Asn1
Imports Org.BouncyCastle.Asn1.Ocsp
Imports Org.BouncyCastle.Asn1.X509
Imports Org.BouncyCastle.Math
Imports Org.BouncyCastle.Ocsp
Imports Org.BouncyCastle.X509
Imports BayshoreBrowser.ReisJr.BouncyCastle.Utils

Namespace ReisJr.BouncyCastle.Examples
    Public Class OcspClient
        Public Enum CertificateStatus
            Good
            Revoked
            Unknown
        End Enum

        Private ReadOnly MaxClockSkew As Integer = 36000000

        Public Function Query(eeCert As Org.BouncyCastle.X509.X509Certificate, issuerCert As Org.BouncyCastle.X509.X509Certificate) As CertificateStatus
            ' Query the first Ocsp Url found in certificate
            Dim urls As List(Of String) = CertificateUtils.GetAuthorityInformationAccessOcspUrl(eeCert)

            If urls.Count = 0 Then
                Throw New Exception("No OCSP url found in ee certificate.")
            End If

            Dim url As String = urls(0)

            Console.WriteLine("Querying '" + url + "'...")

            Dim req As OcspReq = GenerateOcspRequest(issuerCert, eeCert.SerialNumber)

            Dim binaryResp As Byte() = IoUtils.PostData(url, req.GetEncoded(), "application/ocsp-request", "application/ocsp-response")

            Return ProcessOcspResponse(eeCert, issuerCert, binaryResp)
        End Function



        Private Function ProcessOcspResponse(eeCert As Org.BouncyCastle.X509.X509Certificate, issuerCert As Org.BouncyCastle.X509.X509Certificate, binaryResp As Byte()) As CertificateStatus
            Dim r As New OcspResp(binaryResp)
            Dim cStatus As CertificateStatus = CertificateStatus.Unknown

            Select Case r.Status
                Case OcspRespStatus.Successful
                    Dim [or] As BasicOcspResp = CType(r.GetResponseObject(), BasicOcspResp)

                    ValidateResponse([or], issuerCert)

                    If [or].Responses.Length = 1 Then
                        Dim resp As SingleResp = [or].Responses(0)

                        ValidateCertificateId(issuerCert, eeCert, resp.GetCertID())
                        ValidateThisUpdate(resp)
                        ValidateNextUpdate(resp)

                        Dim certificateStatus As [Object] = resp.GetCertStatus()

                        If certificateStatus Is Org.BouncyCastle.Ocsp.CertificateStatus.Good Then
                            cStatus = certificateStatus.Good
                        ElseIf TypeOf certificateStatus Is Org.BouncyCastle.Ocsp.RevokedStatus Then
                            cStatus = certificateStatus.Revoked
                        ElseIf TypeOf certificateStatus Is Org.BouncyCastle.Ocsp.UnknownStatus Then
                            cStatus = certificateStatus.Unknown
                        End If
                    End If
                    Exit Select
                Case Else
                    Throw New Exception("Unknow status '" + r.Status + "'.")
            End Select

            Return cStatus
        End Function



        Private Sub ValidateResponse([or] As BasicOcspResp, issuerCert As Org.BouncyCastle.X509.X509Certificate)
            ValidateResponseSignature([or], issuerCert.GetPublicKey())
            ValidateSignerAuthorization(issuerCert, [or].GetCerts()(0))
        End Sub



        '3. The identity of the signer matches the intended recipient of the
        'request.
        '4. The signer is currently authorized to sign the response.
        Private Sub ValidateSignerAuthorization(issuerCert As Org.BouncyCastle.X509.X509Certificate, signerCert As Org.BouncyCastle.X509.X509Certificate)
            ' This code just check if the signer certificate is the same that issued the ee certificate
            ' See RFC 2560 for more information
            If Not (issuerCert.IssuerDN.Equivalent(signerCert.IssuerDN) AndAlso issuerCert.SerialNumber.Equals(signerCert.SerialNumber)) Then
                Throw New Exception("Invalid OCSP signer")
            End If
        End Sub



        '2. The signature on the response is valid;
        Private Sub ValidateResponseSignature([or] As BasicOcspResp, asymmetricKeyParameter As Org.BouncyCastle.Crypto.AsymmetricKeyParameter)
            If Not [or].Verify(asymmetricKeyParameter) Then
                Throw New Exception("Invalid OCSP signature")
            End If
        End Sub



        '6. When available, the time at or before which newer information will
        'be available about the status of the certificate (nextUpdate) is
        'greater than the current time.
        Private Sub ValidateNextUpdate(resp As SingleResp)
            If resp.NextUpdate IsNot Nothing AndAlso Not resp.NextUpdate.Value = Nothing AndAlso resp.NextUpdate.Value.Ticks <= DateTime.Now.Ticks Then
                Throw New Exception("Invalid next update.")
            End If
        End Sub



        '5. The time at which the status being indicated is known to be
        'correct (thisUpdate) is sufficiently recent.
        Private Sub ValidateThisUpdate(resp As SingleResp)
            If Math.Abs(resp.ThisUpdate.Ticks - DateTime.Now.Ticks) > MaxClockSkew Then
                Throw New Exception("Max clock skew reached.")
            End If
        End Sub



        '1. The certificate identified in a received response corresponds to
        'that which was identified in the corresponding request;
        Private Sub ValidateCertificateId(issuerCert As Org.BouncyCastle.X509.X509Certificate, eeCert As Org.BouncyCastle.X509.X509Certificate, certificateId As CertificateID)
            Dim expectedId As New CertificateID(certificateId.HashSha1, issuerCert, eeCert.SerialNumber)

            If Not expectedId.SerialNumber.Equals(certificateId.SerialNumber) Then
                Throw New Exception("Invalid certificate ID in response")
            End If

            If Not Org.BouncyCastle.Utilities.Arrays.AreEqual(expectedId.GetIssuerNameHash(), certificateId.GetIssuerNameHash()) Then
                Throw New Exception("Invalid certificate Issuer in response")
            End If

        End Sub



        Private Function GenerateOcspRequest(issuerCert As Org.BouncyCastle.X509.X509Certificate, serialNumber As BigInteger) As OcspReq
            Dim id As New CertificateID(CertificateID.HashSha1, issuerCert, serialNumber)
            Return GenerateOcspRequest(id)
        End Function



        Private Function GenerateOcspRequest(id As CertificateID) As OcspReq
            Dim ocspRequestGenerator As New OcspReqGenerator()

            ocspRequestGenerator.AddRequest(id)

            Dim nonce As BigInteger = BigInteger.ValueOf(New DateTime().Ticks)

            Dim oids As New ArrayList()
            Dim values As New Hashtable()

            oids.Add(OcspObjectIdentifiers.PkixOcsp)

            Dim asn1 As Asn1OctetString = New DerOctetString(New DerOctetString(New Byte() {1, 3, 6, 1, 5, 5, _
             7, 48, 1, 1}))

            values.Add(OcspObjectIdentifiers.PkixOcsp, New X509Extension(False, asn1))
            ocspRequestGenerator.SetRequestExtensions(New X509Extensions(oids, values))

            Return ocspRequestGenerator.Generate()
        End Function




    End Class
End Namespace