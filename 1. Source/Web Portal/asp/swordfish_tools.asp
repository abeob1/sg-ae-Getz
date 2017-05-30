<%
	Function FormatDateToDDMMYYYY (origin_date) 
		Dim valid: valid = True
		Dim result: result = ""
		If origin_date = "" Then valid = False
		If Not IsDate(origin_date) Then valid = False
		
		If valid Then
			Dim DateTimeArray, CurrentDate
			DateTimeArray = Split(origin_date, " ", -1, 1)
			CurrentDate = Split(DateTimeArray(0), "/", -1, 1)
			
			result = CurrentDate(1) & "/" & CurrentDate(0) & "/" & CurrentDate(2)			
			If UBound(DateTimeArray) > 0 Then result = result & " " & DateTimeArray(1)
			
		End If

		FormatDateToDDMMYYYY = result
	End Function
	
%>