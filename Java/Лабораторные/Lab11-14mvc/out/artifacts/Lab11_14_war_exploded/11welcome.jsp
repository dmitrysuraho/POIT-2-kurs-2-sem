<%--
  Created by IntelliJ IDEA.
  User: npats
  Date: 01.03.2019
  Time: 11:10
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title> Title</title>

    <link media="screen"   type= "text/css"
          rel="stylesheet" href="resources/css/style.css?<?php echo time(); ?>">
    <link href="https://s3-us-west-2.amazonaws.com/s.cdpn.io/67239/animate.min.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">

</head>
<body>

<nav role="navigation" class="navbar navbar-default">

    <%--<div class="">--%>
       <%--<img src = "https://www.kv.by/sites/default/files/user7743/logo_iba_group.jpg" width="50" height="50">--%>
    <%--</div>--%>

    <div >
     <nav class="menu" >
        <ul >
            <li><a href="${pageContext.request.contextPath}/controller?command=login_page">Login</a></li>
            <li><a href="${pageContext.servletContext.contextPath}/controller?command=sign_out">Logout</a></li>
            <li style="float:right;">
        </ul>
     </nav>
    </div>




<div class="container">
    <span /><h4>Welcome,  ${username}</h4>


    <div  class = "layer1">
        <H1>   <caption>Contact list</caption> </H1>
        <table class ="container" border="2">

            <tr>
                <th><h1>Name</h1></th>
                <th><h1>Phone</h1></th>
                <th><h1>Email</h1></th>
            </tr>

            <c:forEach items="${group}" var="person">
            <tr><td>${person.name}</td>
                <td>${person.phone}</td>
                <td>${person.email}</td>
            </tr>
            </c:forEach>
        </table>
    </div>
    <div class = "layer2">
        <p><font color="red">${errorMessage}</font></p>
        <form class="login-form" method="POST" action="${pageContext.servletContext.contextPath}/controller?command=add_new_person">
          Add new contact:
            <p>  Enter name <input name="nname" type="text" /> </p>
            <p>   Enter phone <input name="nphone" type="text" /> </p>
            <p>  Enter email <input name="nemail" type="text" /> </p>
            <input class ="button-main-page" value="Add" type="submit" />
        </form>
    </div>
</div>
<p> ${lastdate}</p>
<script src="webjars/jquery/3.3.1/jquery.min.js"></script>
<script src="webjars/bootstrap/4.3.1/js/bootstrap.min.js"></script>
      <script  src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</body>
</html>
