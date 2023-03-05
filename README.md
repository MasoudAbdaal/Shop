<br/>

<p align="center">
  <a href="https://github.com/MasoudAbdaal/Shop">
  <p align="center">
    <img src="https://png2.cleanpng.com/dy/5bac0bc4427bd5e7c3e9a1d085874823/L0KzQYq3WcExN6N3kZH9cnHxg8HokvVvfF5yh9DydHB1PbrqjB4ubZR0hd9ucnPoPbrqjB4ud59xgdDuLYPrf8G0ifNwdl46fKkCYUe5c4i3VPZlO183TaoCM0i1RIK8VsgyOmM8S6Q9Nj7zfri=/transparent-monitor-icon-ecommerce-icon-online-shop-icon-5d77a76c704fd3.25873824156812273246.png" alt="Logo" width="80" height="80">
    </p>
  </a>

  <h3 align="center">Online Shop</h3>

  <p align="center">
    Ready to deploy your shop.
    <br/>
    <br/>
  </p>
</p>

## Table Of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)

## Getting Started

### Prerequisites

.Net 6

SQL Server

### Installation

1. [Download](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us) And [install SQL Server 2022](https://docs.hexagonppm.com/r/en-US/Intergraph-Smart-Interop-Publisher-Installation-and-Setup/Version-2019-R1/775713) with named instance Shop
   1-2. Install [SSMS](https://aka.ms/ssmsfullsetup)
   1-3. Create **dev** user with **admin123** password [(Guide)](https://vaishaligoilkar3322.medium.com/sql-server-create-login-user-role-and-assign-permission-7ab78cb61e1a)

1-4. Grant **dbcreator** role to **dev** user.

2. Install [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.406-windows-x64-installer)

3. Install Ef Core Tools

```ps
dotnet tool install --global dotnet-ef
```

4. Clone project

```ps
git clone https://github.com/MasoudAbdaal/Shop.git
```

5. Create a migration

```ps
 dotnet ef migrations add InitialMigration
```

6. Apply migration to database

```ps
 dotnet ef database update
```

7. Run Project

```ps
dotnet run
```

8. Change `appsettings.Development.json` **Issuer** And **Audience** for your host url
