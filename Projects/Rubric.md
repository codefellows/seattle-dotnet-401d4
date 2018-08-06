# Final E-Commerce Rubric 
 

### Home Page - 5pts
Introduction to the product. Able to easily tell what product is being sold. 
The layout is clean, professional. The Homepage consists of a Register/Login button, 
and basket link, as well as a personalized greeting for the user logged in.
 

### Login Page - 10pts
Login page has a username and a password field., with both required. 
Password is masked. At least 2 OAUTH options for 3rd party service providers for 
login and are functioning as expected. OAUTH logins capture user's email if they are not 
present in the system. The login page for a new user redirects to the home page and the login 
for an admin redirects to an admin panel.
 

### Registration Page  - 10pts
Separate page that looks and feels clean/professional/easy to navigate. 
Registration Page is accessible by anonymous users. Collects minimum data required for 
a user to register for the site. All required fields throw an error when not filled out. 
An account gets successfully created upon registration and redirected back to home page. 
Claims are being captured and saved by the application upon successful registration. 
User is being added to a member role upon registration. 
Potentially a special case for admin registration. Email is sent to user upon new registration.
 
### Admin Dashboard  - 10pts
CSS looks clean and professional. Page is only accessible by Admin users. Links are present to see last 20 submitted orders by all users, and ability to manage (CRUD) of products.

 
### Shopping Page - 10pts 
The site contains a page where all products in the inventory are visible for users to browse. CSS/HTML of page is clean and easy to navigate. Each product that displays links to a product landing page. Price of product is visible and each product has an image associated with it.
 
### Product Landing Page - 10pts
Each product has it's own product landing page. The product landing page has clean and readable CSS. Able to easily see the product's details and image. Able to easily add the product to your personal cart.

 
### Basket Page - 10pts 
Page has clean and professional looking CSS. Basket Page contains all of the items the user has added to their basket. Able to easily "proceed" to a checkout page. User is able to remove items from their basket. Page consists of an order total of all items in the cart so far. View component is also present on more than one page that shows all of the current logged in users items in their cart. The cart will update as new items are added.

 
### Checkout Page - 10pts
CSS/Design of page is professional and clean. Only accessible by logged in/authorized users. No personal identifiable information is captured. Only a fake credit card is being captured (dropdown menu...no open text field).

 
### Receipt/Order Confirmation Page - 5pts
Order Confirmation page has clean and professional looking CSS. Only accessible by logged in/authorized users. Contains a summary, by line item, of items purchased by the user, including order total. Receipt is emailed to user of summary of order. Text of email is profressional

 
### Personal Profile Page - 5pts
Page consists of clean/professional CSS and Design. User is able to access their last 5 orders that were placed. Profile contains user's information for visibility. User has the ability to change basic information (not email) from profile page. New information successfully saves back to database and updates the user information appropriately. Personal Profile page is using the razor pages and is located in the "Pages" directory.

 
### Vulnerability Report - 4pts
Repo consists of a vulnerability report that outlines at least 4 potential vulnerabilities. Vulnerabilities are formatted within the provided template and each section contains relevant and appropriate information.

 
### Overall Design and Experience - 30pts
Overall look and feel of the site looks clean and fits the theme of the product. Color Scheme is appropriate and overall navigation has a nice flow. Users are able to easily navigate through the site with very little issues

 
### Readme - 10pts 
Readme is present in repo and contains 1. Intro to the site 2. product that is being sold 3. claims that are being captured 4, policies being enforced 5. OAUTH providers being used 6. DB Schema present with explanation 7. Link to Deployed site 8. Link and reference to Vulnerability report. 9. Name of contributors.

 
### Code Quality - 10pts
Quality of code is up to industry standard. Summary comments are present above each method and action. Comments are present when more explanation is needed. Variables are named appropriately, and there isnt' any unnecessary code classes or blocks that are not being used.

 
### Email Sender - 1pt
Email sender uses SendGrid and implements the IEmailSender Interface

 
### Site Skeleton - 2pts
Site uses MVC architectural pattern(Model, View, Controller folders) as well as Razor pages (pages directory). Site utilizes .NET Core's Identity Framework for authentication and authorization.

 
### Policies - 3pts
Site has and enforces a 1. Custom Claims based policy (with a separate handler and requirement, as well as registered in startup), 2. Role based policy (i.e. Admin only), Claims are being enforced on at least one page each, and are registered in the Startup.cs file

 
### Site Functionality - 5pts
Site does not contain broken links or uncompleted pages. Site does not throw 500 errors during basic functionality and usages. Site contains a custom 400 error page to mask errors. (not required) , No developer errors are present to user.

#### Total Points: 150.0 
