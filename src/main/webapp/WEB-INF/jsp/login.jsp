<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@taglib uri = "http://www.springframework.org/tags/form" prefix = "form"%>

<t:_layout>
	<jsp:attribute name="header">
	  <title>Grocery Samurai</title>
	</jsp:attribute>
    <jsp:attribute name="footer">
      <p id="copyright">&copy; 2017, Magic Hamster Ent.</p>
    </jsp:attribute>
    <jsp:body>
      <h1>Welcome</h1>
      <hr />
      <p>You are now logged in.</p>
    </jsp:body>
</t:_layout>
