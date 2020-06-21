<%--
  Created by IntelliJ IDEA.
  User: Dmitry
  Date: 20.06.2020
  Time: 9:50
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>next</title>
</head>
<body>
    <form action="servlet" method="post">
        <input type="submit" value="Next"/>
    </form>
    ${list.name} ${list.email} ${list.phone}
</body>
</html>
