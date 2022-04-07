# <b>cautious-rotary-phone</b> : A Paylocity Coding Challenge



## Business Need:
One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits
packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please
demonstrate how you would code the following scenario:

 - The cost of benefits is $1000/year for each employee
 - Each dependent (children and possibly spouses) incurs a cost of $500/year
 - Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent


We’d like to see this calculation used in a web application where employers input employees and their
dependents, and get a preview of the costs. This is of course a contrived example. We want to know how you
would implement the application structure and calculations and get a brief preview of how you work.
Please implement a web application based on these assumptions:
 - All employees are paid $2000 per paycheck before deductions
 - There are 26 paychecks in a year



## Technology Decisions

- OOB templating for speed of development
- Simplified CQRS for ease of movement to SPA/API structure
- Migrations are written as straight sql
- .net 6.0 
- Nlog : For a logging provider. 
- Automapper : For easy object mapping
- FluentValidation : For easy to read server side validations 
- Entity Framework: For easier movement between various db's 
- AdminLTE:  For a more beautiful experience
- Flyway: For applying migrations in their own deployment step
- SQLite: For guaranteed cross platform data storage
 

