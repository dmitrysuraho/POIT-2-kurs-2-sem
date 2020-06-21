<%--
  Created by IntelliJ IDEA.
  User: Dmitry
  Date: 05.05.2020
  Time: 7:54
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Task6</title>
</head>
<body>
    <form action="FirstServlet" method="get">
        <input type="submit" value="идем на первый сервлет GET-запросом"/>
    </form>
    <form action="FirstServlet" method="post">
        <input type="submit" value="идем на первый сервлет POST-запросом"/>
    </form>
    <form action="FirstServlet" method="get">
        <input type="submit" value="двойное переопределение GET-запроса"/>
    </form>
    <form action="FirstServlet" method="get">
        <input type="submit" value="двойное переопределение GET-запроса с переадресацией"/>
    </form>
</body>
</html>
