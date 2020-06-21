<%@ page import="java.sql.Connection" %>
<%@ page import="DataBase.ConnectionDB" %>
<%@ page import="java.sql.Statement" %>
<%@ page import="java.sql.ResultSet" %><%--
  Created by IntelliJ IDEA.
  User: Dmitry
  Date: 11.05.2020
  Time: 17:38
  To change this template use File | Settings | File Templates.
--%>

<%--<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/sql" prefix="sql" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/xml" prefix="x" %>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>

<%@ taglib prefix="label" uri="sda"%>
<html>
<head>
    <title>welcome</title>
</head>
<body>
    <jsp:include page="header.jsp"/>
    <h1>Welcome</h1>
    <label:sdaTable list="${coll}"/>
    <form action="addItem" method="post">
        <input type="text" name="item" placeholder="item"><br>
        <input type="text" name="price" placeholder="price"><br>
        <input type="text" name="quantity" placeholder="quantity"><br>
        <input type="submit" value="add"/>
    </form>
    <form action="deleteItem" method="post">
        <input type="text" name="item" placeholder="item"><br>
        <input type="submit" value="delete"/>
    </form>
    <c:out value="JSTL HELLO"/><br>
    <h1>------------Core-------------</h1>
    <c:set var="user" value="guest" scope="page"/>
    <c:out value="${user}"/><br>
    <c:if test="${ user == 'guest' }">
        <c:out value ="Its guest"/>
    </c:if><br>
    <c:set var="str" value="1, 2 - 3 : 4 . 5" />
    <c:forTokens var="token" items="${ str }" delims=".,-:)">
        <c:out value="${ token }" /><br/>
    </c:forTokens>

    <h1>------------Formatting-------------</h1>
    <jsp:useBean id="now" class="java.util.Date" />
    <fmt:setLocale value="en-EN"/>
    format English<br/>
    Today: <fmt:formatDate value="${now}" /><br/>
    <fmt:setLocale value="ru-RU"/>
    format Russian<br/>
    Todat: <fmt:formatDate value="${now}" /><br/>
    TimeStyle:
    (short): <fmt:formatDate value="${now}"
                             type="time" timeStyle="short" /><br/>
    (medium):<fmt:formatDate value="${now}"
                             type="time" timeStyle="medium" /><br/>
    (long): <fmt:formatDate value="${now}"
                            type="time" timeStyle="long" /><br/>

    <h1>------------Functions-------------</h1>
    <c:set var="str1" value="Java Guides" />
    <c:set var="str2" value="Guides" />
    <c:if test="${fn:contains(str1, str2)}">
        <c:out value="'Guides' substring present in 'Java Guides' string" />
    </c:if><br/>
    <c:set var="msg" value="This is an example of JSTL function" />
    <c:set var="arrayofmsg" value="${fn:split(msg,' ')}" />
    <c:forEach var="i" begin="0" end="6">
        arrayofmsg[${i}]: ${arrayofmsg[i]}<br>
    </c:forEach><br>
    <c:set var="str" value="Java Guides" />
    Length of str is: ${fn:length(str)}
    <br>
    <jsp:include page="footer.jsp"/>
</body>
</html>
