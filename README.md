# city-api-puzzle
Simple web app that makes an API call to http://alltheclouds.com.au/ to retrieve and display the product list. <br>
Coded in ASP.NET MVC as that was the framework listed in the job description.

# Details
Code written to fulfil the acceptance criteria as listed in the assignment: <br>
1) User is prompted to select user type (Customer).
2) Upon selection, API call is made to http://alltheclouds.com.au/ and product list is loaded and displayed.
3) Price displayed in the table is not the original price but the marked-up price.

# Additional NuGet add-ons
The following addons were installed using Visual Studio's NuGet Package Manager:<br>
* jQuery 3.7.0 - For JavaScript functionality.
* Microsoft.AspNet.WebApi.Client - For HttpClient which is used to make the API calls.

# Possible improvements
* Table used to display products should have proper grid lines.
* API call is not async, and could be converted to run asynchronously to prevent blocking of UI thread.
* The way the table is loaded is probably not the most efficient, and could be improved if I had more time to look into it.
