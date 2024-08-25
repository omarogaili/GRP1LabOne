ℹ️ SQL Injection

To start the Program you need to follow the steps below:

1. Change the `server` variable to your server name.
2. Change the `database` variable to the name of your database.
3. Change the `dbUser` variable to your MySQL username.
4. Change the `dbPass` variable to your MySQL password. .  

⚠️ The Project Weakness:

    Project Weakness The project was vulnerable to SQL injection because it used user input directly in the query sent to the database. To see this, you need to uncomment the code on line 42 and comment out the code on the line below it (43). You can use the following SQL injection. 
```bash
omar' or 1=1--
``` 

# 🛠️  Solution for the Project Weakness:
   ## Solution One:
    Parameterized queries This is the solution we chose to address the problem in this project. You can see this in the code on line 43, where we used slugName and slugPass. These are then modified by using the .ygbParameters.AddWithValue() function to pass the actual user input values to search the database.
    
    ## Solution Two: 
    we have added also an validation methods that validate if the user have entered an email address or a telephone number to sign in.  
