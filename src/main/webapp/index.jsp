<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@taglib uri = "http://www.springframework.org/tags/form" prefix = "form"%>

<t:_layout>
	<jsp:attribute name="header">
	  <title>Grocery Samurai Login</title>
	</jsp:attribute>
    <jsp:attribute name="footer">
      <p id="copyright">&copy; 2017, Magic Hamster Ent.</p>
    </jsp:attribute>
    <jsp:body>
      <h1>Welcome</h1>
      <hr />
      <form:form method = "POST" action = "/login.html">
         <div class="form-horizontal">
            <div class="form-group">
               <form:label path = "userId" class="control-label col-md-2">Username:</form:label>
               <div class="col-md-10">
                 <form:input path = "userId" class="control"></form:input>
               </div>
            </div>
            <div class="form-group">
               <form:label path = "password" class="control-label col-md-2">Password:</form:label>
               <div class="col-md-10">
                 <form:input path = "password" type="password" class="control"></form:input>
               </div>
            </div>
            <div class="form-group">
               <div class="col-md-offset-2 col-md-10">
                  <input type = "submit" value = "Login" class="btn btn-default"/>
               </div>
            </div>
         </div>  
      </form:form>
    </jsp:body>
</t:_layout>
