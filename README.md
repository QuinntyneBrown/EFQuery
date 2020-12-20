# EF Query

Creating an EF query (using the Query syntax) to display the customers who have a recent order and an EF query for customers with orders (without using navigation properties).

## How to run locally

1. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download)
    * If you don't have `localdb` available on your system, [Download and install SQL Server Express](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
2. Open a terminal such as **PowerShell**, **Command Prompt**, or **bash** and navigate to the `src/EFQuery.Api` folder
3. Run the following `dotnet` commands:
```sh
dotnet build
dotnet run
```
3. Open your browser to: `https://localhost:5001`.

## To Run the Integration tests
1. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download)
    * If you don't have `localdb` available on your system, [Download and install SQL Server Express](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
2. Open a terminal such as **PowerShell**, **Command Prompt**, or **bash** and run the following command:
`dotnet test`
