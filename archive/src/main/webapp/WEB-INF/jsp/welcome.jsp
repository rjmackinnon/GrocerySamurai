<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@taglib uri = "http://www.springframework.org/tags/form" prefix = "form"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<t:_layout>
	<jsp:attribute name="header">
	  <title>Grocery Samurai</title>
	</jsp:attribute>
    <jsp:attribute name="footer">
      <p id="copyright">&copy; 2017, Magic Hamster Ent.</p>
    </jsp:attribute>
    <jsp:body>
   	  <div class="col-md-9">
   	  	<table id="tblItems">
   	  	  <thead>
   	  	  	<tr>
   	  	  	  <th>
   	  	  	    Items
   	  	  	  </th>
   	  	  	</tr>
   	  	  </thead>
   	  	  <tbody>
            <c:forEach var="listValue" items="${items}">
		        <tr>
		            <td>
		                <c:out value="${listValue.getName()}"/>
		            </td>
		        </tr>
            </c:forEach>
   	  	  </tbody>
   	  	</table>
   	  	# Items: <c:out value="${itemCount}" />
   	  </div>
    </jsp:body>
</t:_layout>
<%=request.getAttribute("dummy") %>
