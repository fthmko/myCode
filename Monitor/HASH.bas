Attribute VB_Name = "HASH"
Private Declare Function CryptAcquireContext _
                Lib "advapi32.dll" _
                Alias "CryptAcquireContextA" (ByRef phProv As Long, _
                                              ByVal pszContainer As String, _
                                              ByVal pszProvider As String, _
                                              ByVal dwProvType As Long, _
                                              ByVal dwFlags As Long) As Long

Private Declare Function CryptReleaseContext _
                Lib "advapi32.dll" (ByVal hProv As Long, _
                                    ByVal dwFlags As Long) As Long

Private Declare Function CryptCreateHash _
                Lib "advapi32.dll" (ByVal hProv As Long, _
                                    ByVal Algid As Long, _
                                    ByVal hKey As Long, _
                                    ByVal dwFlags As Long, _
                                    ByRef phHash As Long) As Long

Private Declare Function CryptDestroyHash Lib "advapi32.dll" (ByVal hHash As Long) As Long

Private Declare Function CryptHashData _
                Lib "advapi32.dll" (ByVal hHash As Long, _
                                    pbData As Byte, _
                                    ByVal dwDataLen As Long, _
                                    ByVal dwFlags As Long) As Long

Private Declare Function CryptGetHashParam _
                Lib "advapi32.dll" (ByVal hHash As Long, _
                                    ByVal dwParam As Long, _
                                    pbData As Any, _
                                    pdwDataLen As Long, _
                                    ByVal dwFlags As Long) As Long

Private Const PROV_RSA_FULL = 1

Private Const CRYPT_NEWKEYSET = &H8

Private Const ALG_CLASS_HASH = 32768

Private Const ALG_TYPE_ANY = 0

Private Const ALG_SID_MD2 = 1
Private Const ALG_SID_MD4 = 2
Private Const ALG_SID_MD5 = 3
Private Const ALG_SID_SHA1 = 4

Enum HashAlgorithm
    MD2 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD2
    MD4 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD4
    MD5 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD5
    SHA1 = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_SHA1
End Enum

Private Const HP_HASHVAL = 2
Private Const HP_HASHSIZE = 4

Function HashFile(ByVal Filename As String, _
                  Optional ByVal Algorithm As HashAlgorithm = MD5) As String
    Dim hCtx     As Long
    Dim hHash    As Long
    Dim lFile    As Long
    Dim lRes     As Long
    Dim lLen     As Long
    Dim lIdx     As Long
    Dim abHash() As Byte

    ' Check if the file exists (not the best method BTW!)
    If Len(Dir$(Filename)) = 0 Then Err.Raise 53
   
    ' Get default provider context handle
    lRes = CryptAcquireContext(hCtx, vbNullString, vbNullString, PROV_RSA_FULL, 0)
 
    If lRes = 0 And Err.LastDllError = &H80090016 Then
   
        ' There's no default keyset container!!!
        ' Get the provider context and create
        ' a default keyset container
        lRes = CryptAcquireContext(hCtx, vbNullString, vbNullString, PROV_RSA_FULL, CRYPT_NEWKEYSET)
    End If
   
    If lRes <> 0 Then

        ' Create the hash
        lRes = CryptCreateHash(hCtx, Algorithm, 0, 0, hHash)

        If lRes <> 0 Then

            ' Get a file handle
            lFile = FreeFile
         
            ' Open the file
            Open Filename For Binary As lFile
         
            If Err.Number = 0 Then
         
                Const BLOCK_SIZE As Long = 32 * 1024& ' 32K
                ReDim abBlock(1 To BLOCK_SIZE) As Byte
                Dim lCount     As Long
                Dim lBlocks    As Long
                Dim lLastBlock As Long
            
                ' Calculate how many full blocks
                ' the file contains
                lBlocks = LOF(lFile) \ BLOCK_SIZE
            
                ' Calculate the remaining data length
                lLastBlock = LOF(lFile) - lBlocks * BLOCK_SIZE
            
                ' Hash the blocks
                For lCount = 1 To lBlocks
            
                    Get lFile, , abBlock
         
                    ' Add the chunk to the hash
                    lRes = CryptHashData(hHash, abBlock(1), BLOCK_SIZE, 0)
            
                    ' Stop the loop if CryptHashData fails
                    If lRes = 0 Then Exit For
               
                Next

                ' Is there more data?
                If lLastBlock > 0 And lRes <> 0 Then
            
                    ' Get the last block
                    ReDim abBlock(1 To lLastBlock) As Byte
                    Get lFile, , abBlock
               
                    ' Hash the last block
                    lRes = CryptHashData(hHash, abBlock(1), lLastBlock, 0)
               
                End If
            
                ' Close the file
                Close lFile
         
            End If

            If lRes <> 0 Then
            
                ' Get the hash lenght
                lRes = CryptGetHashParam(hHash, HP_HASHSIZE, lLen, 4, 0)

                If lRes <> 0 Then

                    ' Initialize the buffer
                    ReDim abHash(0 To lLen - 1)

                    ' Get the hash value
                    lRes = CryptGetHashParam(hHash, HP_HASHVAL, abHash(0), lLen, 0)

                    If lRes <> 0 Then

                        ' Convert value to hex string
                        For lIdx = 0 To UBound(abHash)
                            HashFile = HashFile & Right$("0" & Hex$(abHash(lIdx)), 2)
                        Next

                    End If

                End If

            End If

            ' Release the hash handle
            CryptDestroyHash hHash

        End If
      
    End If

    ' Release the provider context
    CryptReleaseContext hCtx, 0

    ' Raise an error if lRes = 0
    If lRes = 0 Then Err.Raise Err.LastDllError

End Function

