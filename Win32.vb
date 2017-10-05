Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.ComponentModel

Public Class Win32

    <DllImport("crypt32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function CertCreateCertificateContext(dwCertEncodingType As UInteger, pbCertEncoded As Byte(), cbCertEncoded As UInteger) As IntPtr
    End Function

    <DllImport("crypt32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function CertOpenSystemStore(hCryptProv As IntPtr, storename As String) As IntPtr
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CertCloseStore(hCertStore As IntPtr, dwFlags As UInteger) As Boolean
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CertFindCertificateInStore(hCertStore As IntPtr, dwCertEncodingType As UInteger, dwFindFlags As UInteger, dwFindType As UInteger, <[In](), MarshalAs(UnmanagedType.LPWStr)> pszFindString As [String], pPrevCertCntxt As IntPtr) As IntPtr
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CertFindCertificateInStore(hCertStore As IntPtr, dwCertEncodingType As UInteger, dwFindFlags As UInteger, dwFindType As UInteger, pCertNameBlob As IntPtr, pPrevCertCntxt As IntPtr) As IntPtr
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CertFreeCertificateContext(hCertStore As IntPtr) As Boolean
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CertGetPublicKeyLength(dwCertEncodingType As UInteger, pPublicKeyInfo As IntPtr) As Integer
    End Function





    ' binary DER cert data
    <DllImport("crypt32.dll", SetLastError:=True)> _
    Public Shared Function CryptVerifyCertificateSignature(hCryptProv As IntPtr, dwCertEncodingType As UInteger, pbEncoded As Byte(), cbEncoded As UInteger, pPublicKey As IntPtr) As Boolean
    End Function


    'PCERT_PUBLIC_KEY_INFO 
End Class



'--------  Win32 structs prototypes ---------------

<StructLayout(LayoutKind.Sequential)> _
Public Structure CERT_CONTEXT
    Public dwCertEncodingType As UInteger
    Public pbCertEncoded As IntPtr
    Public cbCertEncoded As Integer
    Public pCertInfo As IntPtr
    Public hCertStore As IntPtr
End Structure



Public Class VerifyCertSigner
    Const MY As String = "my"
    Const ROOT As String = "root"
    Const SUBCA As String = "ca"
    'Intermediate Certificate Authorities
    Const OTHERS As String = "addressbook"

    Const PKCS_7_ASN_ENCODING As UInteger = &H10000
    Const X509_ASN_ENCODING As UInteger = &H1
    Const CERT_FIND_SUBJECT_STR As UInteger = &H80007
    Const CERT_FIND_SUBJECT_NAME As UInteger = &H20007
    Const CERT_FIND_ISSUER_NAME As UInteger = &H20004

    Shared MY_ENCODING_TYPE As UInteger = PKCS_7_ASN_ENCODING Or X509_ASN_ENCODING
    Shared searchStores As New ArrayList()



    Public Shared Function CertMain(args As String()) As String
        Dim hSysStore As IntPtr = IntPtr.Zero
        Dim hCertCntxt As IntPtr = IntPtr.Zero
        Dim hIssuerCertCntxt As IntPtr = IntPtr.Zero

        searchStores.Add(ROOT)
        searchStores.Add(SUBCA)
        searchStores.Add(OTHERS)
        searchStores.Add(MY)

        If args.Length < 2 Then
            'Console.WriteLine("Usage:  VerifyCertSigner  [certfile]  [certificate_store]")
            Return "Usage:  VerifyCertSigner  [certfile]  [certificate_store]"
        End If
        Dim fname As [String] = args(0)
        If Not File.Exists(fname) Then
            'Console.WriteLine(vbLf & "File '" + fname + "' not found ")
            Return vbLf & "File '" + fname + "' not found "
        End If

        Dim searchStore As [String] = args(1).ToLower()
        If Not searchStores.Contains(searchStore) Then
            'check for alias certstore names
            If searchStore.Equals("personal") Then
                searchStore = "my"
            ElseIf searchStore.Equals("others") OrElse searchStore.Equals("other people") Then
                searchStore = "addressbook"
            Else
                'Console.WriteLine("Store  '{0}' not known", searchStore)
                Return "Store not known " & searchStore

            End If
        End If

        Dim pcert As Byte() = getCert(fname)
        'binary DER encoded cert. data
        If pcert Is Nothing Then
            Return ""
        End If

        hCertCntxt = Win32.CertCreateCertificateContext(MY_ENCODING_TYPE, pcert, CType(pcert.Length, UInteger))
        If hCertCntxt = IntPtr.Zero Then
            'Console.WriteLine("Couldn't create certificate context")
            Return "Couldn't create certificate context"
        End If


        'Console.WriteLine(vbLf & "Created certificate context from file {0}", fname)

        Dim certcntxt As CERT_CONTEXT = CType(Marshal.PtrToStructure(hCertCntxt, GetType(CERT_CONTEXT)), CERT_CONTEXT)

        Dim certinfo As IntPtr = certcntxt.pCertInfo
        '---- Console.WriteLine("pCertInfo:\t0x{0:X}", certinfo);
        '---  Walk IntPtr offset in CERT_INFO to CERT_NAME_BLOB Issuer  (3 ints, 3 IntPtrs)
        Dim pIssuerName As IntPtr = CType((3 * 4 + 3 * IntPtr.Size + CType(certinfo, Integer)), IntPtr)
        'Console.WriteLine("Got IssuerName for certificate" & vbLf)

        '-----  Now search for issuer in searchStore with matching SubjectName  --------
        '----- The SubjectName of this issuer cert should match the IssuerName of hCertCntxt ---
        hSysStore = Win32.CertOpenSystemStore(IntPtr.Zero, searchStore)
        Console.WriteLine("Got handle for '{0}' store", searchStore)

        If hSysStore <> IntPtr.Zero Then
            hIssuerCertCntxt = Win32.CertFindCertificateInStore(hSysStore, MY_ENCODING_TYPE, 0, CERT_FIND_SUBJECT_NAME, pIssuerName, IntPtr.Zero)

            If hIssuerCertCntxt <> IntPtr.Zero Then
                Dim foundcert As New X509Certificate(hIssuerCertCntxt)
                Console.WriteLine("Found matching issuer certificate in '{0}' store", searchStore)
                Console.WriteLine("Issuer SubjectName:" & vbTab & "{0}", foundcert.Subject())
                Console.WriteLine("Issuer Serial No:" & vbTab & "{0}", foundcert.GetSerialNumberString())
                Dim issuerCntxt As CERT_CONTEXT = CType(Marshal.PtrToStructure(hIssuerCertCntxt, GetType(CERT_CONTEXT)), CERT_CONTEXT)

                Dim issuercertinfo As IntPtr = issuerCntxt.pCertInfo
                '--- walk IntPtr offset in CERT_INFO to SubjectPublicKeyInfo structure (5 ints, 2 longs, 5 IntPtrs)
                Dim pPublicKeyinfo As IntPtr = CType((9 * 4 + 5 * IntPtr.Size + CType(issuercertinfo, Integer)), IntPtr)
                'Console.WriteLine("Issuer Public key size: {0}", Win32.CertGetPublicKeyLength(MY_ENCODING_TYPE, pPublicKeyinfo)) ;

                Console.WriteLine(vbLf & "Verifying Issuer signature on certificate ...")

                If Win32.CryptVerifyCertificateSignature(IntPtr.Zero, MY_ENCODING_TYPE, pcert, CType(pcert.Length, UInteger), pPublicKeyinfo) Then
                    Console.WriteLine("******  Verified signature on certificate  *********")
                Else
                    Console.WriteLine("!!!!!!   FAILED to verify signature on certificate !!!!!!")
                End If
            Else
                Console.WriteLine("Could not find issuer cert in '{0}' store matching  IssuerName in cert '{1}'", searchStore, fname)
            End If
        End If

        '-------  Clean Up  -----------
        If hCertCntxt <> IntPtr.Zero Then
            Win32.CertFreeCertificateContext(hCertCntxt)
        End If
        If hIssuerCertCntxt <> IntPtr.Zero Then
            Win32.CertFreeCertificateContext(hIssuerCertCntxt)
        End If
        If hSysStore <> IntPtr.Zero Then
            Win32.CertCloseStore(hSysStore, 0)
        End If
        Return ""
    End Function





    Private Shared Function getCert(filename As [String]) As Byte()
        If Not File.Exists(filename) Then
            Return Nothing
        End If
        Dim stream As Stream = New FileStream(filename, FileMode.Open)
        Dim datalen As Integer = CType(stream.Length, Integer)
        Dim buffer As Byte() = New Byte(datalen) {}
        stream.Seek(0, SeekOrigin.Begin)
        stream.Read(buffer, 0, datalen)
        stream.Close()
        Return buffer
    End Function




End Class

