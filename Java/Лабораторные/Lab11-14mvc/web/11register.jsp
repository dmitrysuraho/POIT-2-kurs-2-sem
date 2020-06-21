<%--
  Created by IntelliJ IDEA.
  User: npats
  Date: 24.03.2019
  Time: 1:15
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>


    <link media="screen"   type= "text/css"
          rel="stylesheet" href="resources/css/style.css?<?php echo time(); ?>">
    <link href="https://s3-us-west-2.amazonaws.com/s.cdpn.io/67239/animate.min.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">

</head>
<body>
<div class="login-container">
    <section class="login" id="login">
        <header>
            <h2>Contact list</h2>
            <h4></h4>
        </header>

        <div class="form">
<p><font color="red">${errorRegister}</font></p>

<form class="login-form" action="${pageContext.servletContext.contextPath}/controller?command=register_new_user" method="POST">
    <p> <h4>Register new user</h4></p>
    <p>   <input  name="newLoginName" placeholder="Enter new login" type="text" />
    </p>
    <p>    <input name="newPassword" placeholder="Enter new password"  type="password" />
    </p>
    <input class ="button-main-page" type="submit"  value="Register"/>

</form>
        </div>
    </section>
</div>
</body>
</html>
