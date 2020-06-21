<%--
  Created by IntelliJ IDEA.
  User: Dmitry
  Date: 11.05.2020
  Time: 17:39
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>register</title>
</head>
<body>
    <p style="color: red;">${reg}</p><br>
    <H1>registration</H1>
    <form action = "register" method="post">
        <input type="text" name="login" placeholder="enter login"><br>
        <input type="text" name="pass" placeholder="enter password"><br>
        <input type="submit" value="register">
    </form>
</body>
</html>
