<%@ Page Language="VB"  %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Microsoft.Ink" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<script language="vb" runat="server">
	
	Protected Sub Page_Load() 
		Dim oImage As String, NotificationID As String = Request.QueryString("img")
		
		' get from database
		If NotificationID <> "" Then
			Dim mySelectQuery As String = "SELECT notification_signature FROM op_signature WHERE notification_id = '" & NotificationID & "'"
            Dim myConnection As New SqlConnection("Persist Security Info=False;Data Source=192.168.5.185;Initial Catalog=swordfish_v2_20120517;user id=sa;password=jjsea7698")
			Dim myCommand As New SqlCommand(mySelectQuery, myConnection)
			myConnection.Open()
			Dim myReader As SqlDataReader = myCommand.ExecuteReader()
			Try
				If myReader.Read()
					oImage = myReader.GetString(0)
				End If
			Finally
				' always call Close when done reading.
				myReader.Close()
				' always call Close when done reading.
				myConnection.Close()
			End Try		
		Else
			Return
		End If
	
		' generate image
		Try 
					
			If oImage Is Nothing Or Convert.IsDBNull(oImage) Then 			
				'ShowNA() ' Signature not found 				
				Return 
			
			End If 				
		
			Dim sImage As String = oImage ' Set signature if it is not null 			
			Dim mstream As New System.IO.MemoryStream 
		
			
			Try 			
                Base64toImage(sImage).Save(mstream, System.Drawing.Imaging.ImageFormat.Gif)
			
			Catch ex As Exception 
			
			' MessageBox.Show("Signature_Edit.PaintSignature - " & ex.Message) 
			
			End Try 
		
			'Saving bitmap to memory 		
		
			Response.ClearContent() 		
            Response.ContentType = "image/gif"
		
			'Drawing image 		
			Response.BinaryWrite(mstream.ToArray()) 		
			Response.End() 
				
		Catch ex As Exception 		
			'OpenAlert("ShowImage: There is an error occurred, while drawing image.") 
		
		End Try 
	
	End Sub
	

    Function Base64toImage(ByVal Base64 As String) As System.Drawing.Image
        Dim utf8 As UTF8Encoding = New UTF8Encoding()
        Dim imgSig As System.Drawing.Image
        Dim tmploadedInk As Ink = New Ink()
        Dim strGIF As String
        Dim imageBytes() As Byte
        Dim MS As MemoryStream
        'Load the Base64 String in Format(PersistenceFormat = Base64InkSerializedFormat) as ink
        tmploadedInk.Load(utf8.GetBytes(Base64))
        'Convert the ink to Base64 String in format 
        '(PersistenceFormat.Gif, CompressionMode.Maximum)
        strGIF = Convert.ToBase64String(tmploadedInk.Save(PersistenceFormat.Gif, CompressionMode.Maximum))
        'Convert Base64 String to Byte Array
        imageBytes = Convert.FromBase64String(strGIF)
        MS = New MemoryStream(imageBytes, 0, imageBytes.Length)
        ' Convert byte[] to Image
        MS.Write(imageBytes, 0, imageBytes.Length)
        imgSig = System.Drawing.Image.FromStream(MS, True)


        Return imgSig
    End Function
</script>
