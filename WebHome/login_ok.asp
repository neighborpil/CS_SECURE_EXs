<!DOCTYPE html>
<%
    If request("userid") = "" Then
%>
<script>
    location.href = "login.html";
</script>
<%
    End if
    If request("userid") <> "feel" or request("userpw") <> "1234" Then
%>
<script>
    location.href = "login_fail.asp";
</script>
<%
    End if
    loginId = request("userid")
    loginPwd = request("userpw")
%>
<html>
<head>
    <title>인증화면</title>
	<meta charset="utf-8" />
</head>
<body>
    입력한 ID : <%= loginId %><p />
    입력한 PWD : <%=loginPwd %><p />
</body>
</html>
