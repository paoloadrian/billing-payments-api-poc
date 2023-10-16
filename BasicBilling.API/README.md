# BasicBilling API POC

Please, follow all the instructions insie this BasicBilling.API directory.
Please notice that this project has been implemented using .Net 7, you may need to install it before using this app.

## SetUp
If it is the first time you are running this app, please execute:
    dotnet ef database update

Then build the project running:
    dotnet build

## Run
Run the project using port 5000 using command:
    dotnet run

## Swagger
Please go to http://localhost:5000/swagger/index.html to use swagger to:
- Understand how the API works
- Create new Clients
- Create new Bills. Send optional parameter "clientId" (with value different from 0) if you want to create it just for one client, otherwise it gets created for all customer)
- Or execute any other action

