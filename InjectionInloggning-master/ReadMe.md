# ℹ️ SQL Injection 
To start the Program you need to follow the steps below:
```bash
1. Change the server variable to your server name.
2. Change database variable to the name of the database you have.
3. Change dbUser the user name.
4. Change dbPass to your password you have on MySQL.  
```
______________________________________________________________________________________________________________
# ⚠️ The Project Weakness:
> **Project Weeknes** was sql injection because it was useing the user input in the query that was sent to the database. to se that you need to 
uncomment the code in line 42 and do comment the code in the line below it (43). use the following sql injection 
```bash
omar' or 1=1-- 
```
_______________________________________________________________________________________________________________________
# 🛠️ Solution for the Project Weeknes:
> **Parametrized queries** that what we chosed to use to fix the problem in the project. you can se that i the code in line 43 weher we chosed to 
**slugName** and **slugpass**, and then change them be using the .Parameters.AddWithValue() function to send the input of the user to search the database.
