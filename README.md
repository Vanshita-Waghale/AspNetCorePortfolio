# AspNetCorePortfolio
This is the repository for my personal portfolio project built using **ASP.NET Core**, **Razor Views**, **Entity Framework Core**, and **Bootstrap**. The project demonstrates my skills, with features such as a contact form that supports **CRUD operations** and **admin access**.

## Features

- **Contact Form Management:** Users can submit, edit, and delete contact information.
- **Admin Access:** Admins can manage the contact form submissions and view submitted data.
- **Responsive Design:** The portfolio is mobile-friendly, built using **Bootstrap** to ensure a smooth user experience across devices.
- **CRUD Operations:** Implemented for managing contact data via **Entity Framework Core**.

## Tech Stack

- **Frontend:**
  - **ASP.NET Core MVC**
  - **Razor Views**
  - **Bootstrap 4/5**

- **Backend:**
  - **ASP.NET Core MVC**
  - **Entity Framework Core 5/6**
  - **SQL Server** (or any relational database)

- **Version Control:**
  - **Git** and **GitHub** for version control and collaboration.

## Prerequisites

To run this project locally, you'll need to have the following installed on your system:

### 1. Software Requirements:
- **.NET SDK 5.0 or higher:** [Download .NET](https://dotnet.microsoft.com/download)
- **SQL Server (or any relational database)**: [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Visual Studio 2019 or higher** (Optional for better development experience): [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- **Git** for version control: [Download Git](https://git-scm.com/downloads)

### 2. Versions Worked On:
- **.NET Core SDK Version:** 5.0/6.0
- **Entity Framework Core Version:** 5.x or 6.x
- **SQL Server Version:** 2017 or newer (other databases are supported with minor adjustments)
- **Bootstrap Version:** 4.x or 5.x

## How to Download the ZIP

1. Go to the GitHub repository page: [VicStarDevPortfolio](https://github.com/Vanshita-Waghale/AspNetCorePortfolio)
2. Click the green **Code** button.
3. Select **Download ZIP** from the dropdown menu.
4. Save the ZIP file to your local machine and extract it to a folder.

## Steps to Run Locally

### 1. Clone the Repository (Optional)
   If you'd prefer to clone the repository instead of downloading the ZIP, you can run the following command:

   ```bash
   git clone https://github.com/Vanshita-Waghale/AspNetCorePortfolio.git
````

### 2. Set Up the Project Locally

#### Step 1: Open the Project in Visual Studio

* Open **Visual Studio** 2019 or higher.
* Click on **File** -> **Open** -> **Project/Solution** and navigate to the folder where you saved or cloned the repository.
* Open the solution file (`VicStarDevPortfolio.sln`).

#### Step 2: Restore Dependencies

* Open the **Package Manager Console** in Visual Studio by clicking on **Tools** -> **NuGet Package Manager** -> **Package Manager Console**.
* Run the following command to restore the project dependencies:

  ```bash
  dotnet restore
  ```

This will download the required NuGet packages and dependencies for the project.

#### Step 3: Configure the Database

* Update the **connection string** in the `appsettings.json` file to match your local database credentials. For example:

  ```json
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=VicStarDevPortfolioDb;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }
  ```

  If you're using **SQL Server**, make sure SQL Server is installed and running on your machine. For other databases, update the connection string accordingly.

#### Step 4: Apply Database Migrations (if using Entity Framework)

* If you're using **Entity Framework Core** to manage your database schema, you need to apply migrations to create the necessary tables.
* Run the following commands in the **Package Manager Console** or via **dotnet CLI** to apply migrations:

  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

  This will create the necessary tables in your database.

#### Step 5: Run the Application

* After configuring the database and restoring dependencies, you can now run the project locally.
* Click on **Run** (or press `F5`) in Visual Studio to start the application.
* Visit `http://localhost:5000` (or `https://localhost:5001` for HTTPS) in your browser to view the portfolio.

### 3. Admin Access

* Admin credentials are required to access the **admin dashboard** for managing the contact form.
* You can modify the **user credentials** in the database to enable admin access or create an admin user during initial setup.

## Folder Structure

Here’s an overview of the folder structure in this repository:

```
VicStarDevPortfolio/
├── Controllers/               # Contains controllers to handle requests
├── Models/                    # Contains model classes (e.g., Contact)
├── Views/                     # Razor views for UI rendering
├── Data/                      # Entity Framework context and migrations
├── appsettings.json           # Configuration file (connection strings, etc.)
├── wwwroot/                   # Static files (CSS, JavaScript, images)
└── Startup.cs                 # Application startup and configuration
```

## Contributing

If you want to contribute to this project:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -am 'Add feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.


### Additional Notes

* **.NET Version:** Ensure that you are using the correct version of .NET SDK (either 5.0 or higher) to build and run this application.
* **Database:** The database is configured via **Entity Framework Core**. You can switch to any other relational database by modifying the connection string and adjusting the context class.
* **Admin Access:** Make sure the correct credentials are set for the admin user to access the admin dashboard and manage contact forms.
* **Security:** This project does not contain advanced security mechanisms such as password hashing for admin users. Please consider implementing additional security features in a real-world deployment.

