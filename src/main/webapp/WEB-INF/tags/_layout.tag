<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<%@tag description="Overall Page template" pageEncoding="UTF-8"%>
		<%@attribute name="header" fragment="true" %>
		<%@attribute name="footer" fragment="true" %>
		<link rel="stylesheet" href="css/site.css">         
		<script src="js/bootstrap.min.js"></script>
		<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
		<%@taglib uri = "http://www.springframework.org/tags/form" prefix = "form"%>
	</head>
  <body>
  	<div class="navbar navbar-inverse navbar-fixed-top">
	 	<div class="container">
	 		<div class="navbar-header">
	 			<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
	 				<span class="icon-bar"></span>
	 				<span class="icon-bar"></span>
	 				<span class="icon-bar"></span>
	 			</button>
	 			<a href="welcome.html" class="navbar-brand">Grocery Samurai</a>
	 		</div>
	 		<div class="navbar-collapse collapse">
	 			<ul class="nav navbar-nav">
	 				<li><a href="welcome.html">Home</a>
	 				<li><a href="about.html">About</a>
	 			</ul>
	 			<p class="nav navbar-text navbar-right">Hello, Guest!</p>
	 		</div>
	 	</div>
    </div>
 	<div class="container body-content">
 		<div class="row">
		    <div id="pageheader">
		      <jsp:invoke fragment="header"/>
		    </div>
		    <div id="body">
		      <jsp:doBody/>
		    </div>
	    </div>
	    <hr />
	    <footer>
		    <div id="pagefooter">
		      <jsp:invoke fragment="footer"/>
		    </div>
	    </footer>
    </div>
  </body>
</html>