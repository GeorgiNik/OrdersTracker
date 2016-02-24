# OrdersTracker
Application for tracking orders and managing small shops
##Features:
* Adding Clients
* Creating Orders
* Managing Orders
* Income details
* Tracking and updating orders
* Admin area

#Requirements fullfiled:
### General Requirements
* Use **ASP.NET MVC** and **Visual Studio 2015** 
* Have at least **15 controllers**
* Have at least **40 actions**
* You should use **Razor** template engine for generating the UI
	* You may use any JavaScript library of your choice
		* For example Kendo UI widgets (with the ASP.NET MVC Wrappers), Chart.js for charts, etc.
	* ASP.NET WebForms is not allowed
	* Use at least **3 sections** and at least **10 partial views**
	* Use at least **10 editor or display templates**
* Use **MS SQL Server** as database back-end
	* Use **Entity Framework 6** to access your database
	* Using **repositories and/or service layer** is a must
* Use at least **2 areas** in your project (e.g. for administration)
* Create **tables with data** with **server-side paging and sorting** for every model entity
	* You can use Kendo UI grid, jqGrid, any other library or generate your own HTML tables
* Create **beautiful and responsive UI**
	* You may use **Bootstrap** or **Materialize**
	* You may change the standard theme and modify it to apply own web design and visual styles
* Use the standard **ASP.NET Identity System** for managing users and roles
	* Your registered users should have at least one of the two roles: **user** and **administrator**
* Use **AJAX form and/or SignalR** communication in some parts of your application
* Use **caching** of data where it makes sense (e.g. starting page)
* Use **Ninject** (or any other dependency container) and **Automapper**
* Apply **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side)
* Prevent yourself from **security** holes (XSS, XSRF, Parameter Tampering, etc.)
	* Handle correctly the **special HTML characters** and tags like `<script>`, `<br />`, etc.
* Use GitHub and take advantage of the **branches** for writing your features.
* **Documentation** of the project and project architecture (as `.md` file, including screenshots)

### Optional Requirements (bonus points)

* Originality of the idea (uniqueness)
* Host your application in Azure (or any other public hosting provider)


#Sreenshots:
###HomePage
![Screenshot1](http://i.imgur.com/yBEaJSn.png)
###Orders Creation
![Screenshot2](http://i.imgur.com/K0voVwh.png)
###Administration area
![Screenshot2](http://i.imgur.com/fnbx2B5.png)
