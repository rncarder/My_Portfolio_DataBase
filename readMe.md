# My\_Portfolio\_DataBase

Full-stack C# solution for AHS database management, including schema migrations and data entry tools.



\# 🏥 AHS Database Management Suite

A comprehensive .NET solution for managing health service data, featuring automated migrations, secure data entry, and advanced querying capabilities.



\## 🌟 Key Features

\- \*\*Centralized Data Management\*\*: A robust Class Library (`AHSDb`) that handles all core data logic and Entity Framework configurations.

\- \*\*Interactive Data Entry\*\*: A dedicated application (`AHSDataEntry`) for secure and efficient input of health service records.

\- \*\*Advanced Querying\*\*: A search-focused tool (`AHSQuery`) designed for fast retrieval and filtering of database entries.

\- \*\*Automated Schema Sync\*\*: Uses Entity Framework Core Migrations to ensure your local database always matches the latest code structure.



\## 📸 Screenshots

| Data Entry Interface | Query Results |

!\[App Preview](./screenshots\_AHSDatabase/screen\_shot\_1.png)

!\[App Preview](./screenshots\_AHSDatabase/screen\_shot\_2.png)

!\[App Preview](./screenshots\_AHSDatabase/screen\_shot\_3.png)

!\[App Preview](./screenshots\_AHSDatabase/screen\_shot\_4.png)

!\[App Preview](./screenshots\_AHSDatabase/screen\_shot\_5.png)



\## 📝 Development Documentation

you can see my day by day progression in my devlog:



\[Read the Project Devlog](./AHS\_DB\_Devlog.md)





\*\*Process Overview\*\*: The Data Entry app populates the \[SQL Server LocalDB](https://learn.microsoft.com), which is then accessed by the Query app for real-time data retrieval.



\## 🛠️ Tech Stack

\- \*\*Framework\*\*: \[.NET 8](https://dotnet.microsoft.com/)

\- \*\*ORM\*\*: \[Entity Framework Core](https://learn.microsoft.com)

\- \*\*Database\*\*: SQL Server (LocalDB)

\- \*\*Language\*\*: C#



\## ⚙️ Getting Started



\### 1. Clone \& Restore

&nbsp;in a folder f your choice##make sure its not a onedrive folder as this can causes environmental issues open a open a powershell and run

```powershell

git clone https://github.com/rncarder/My\_Portfolio\_DataBase

cd My\_PortfolioProject\_AHSDatabase

dotnet restore

dotnet ef database update --project AHSDb

```

\## its easier to run The AHSDataEntry App and the AHSQuery app through visual studio by hitting f5 or clicking build. in each .sln

or alternatively



`dotnet run --project AHSDataEntry

`dotnet run --project AHSQuery



\##credintials to sign into the AHSDataEntry app

username: editor

password: admin





