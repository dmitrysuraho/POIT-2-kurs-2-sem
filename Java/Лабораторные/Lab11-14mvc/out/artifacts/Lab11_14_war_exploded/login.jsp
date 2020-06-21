<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/sql" prefix="sql" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/xml" prefix="x" %>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>

<%@ taglib prefix="label" uri="sda"%>
<html>
<head>
    <title>login</title>
</head>
<body>
<p style="color: red;">${res}</p><br>
<H1>Login</H1>
<form action = "login" method="post">
    <label:sdaLabledTextField label="Login" name="login"/>
    <label:sdaLabledTextField label="Password" name="pass"/>
    <label:sdaSubmit/>
</form>
</body>
</html>