# Worklog API

## Overview

This repository contains the source code for the Worklog API, a web API built using ASP.NET 5.0. It provides endpoints for managing worklogs, projects, and related data.

## Getting Started

## Prerequisites:

Visual Studio 2022 or later with the ASP.NET and web development workload installed.
.NET 5.0 or later SDK.
MySQL database server.
Clone the repository:

```bash
git clone https://github.com/darrel26/worklog-demo.git
```

Restore NuGet packages:

```bash
dotnet restore
```

### Configure appsettings.json:

- Update the connection string to your MySQL database.
- Provide your Sentry DSN if using Sentry for error logging.

Run the application:

Bash
dotnet run
Use code with caution. Learn more

## NuGet Packages

The following NuGet packages are used in this project:

| Package Name                                  | Url                                                                                |
| --------------------------------------------- | ---------------------------------------------------------------------------------- |
| Serilog.AspNetCore **_v6.10.0_**              | https://www.nuget.org/packages/Serilog                                             |
| Entity Framework Core **_v5.0.17_**           | https://www.nuget.org/packages/Microsoft.EntityFrameworkCore                       |
| MySql.Data **_v8.3.0_**                       | https://www.nuget.org/packages/MySql.Data                                          |
| Pomelo.EntityFrameworkCore.MySql **_v5.0.4_** | https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql                    |
| Sentry.AspNetCore **_3.41.4_**                | https://www.nuget.org/packages/Sentry                                              |
| Sentry.Serilog **_v3.41.4_**                  | https://www.nuget.org/packages/Sentry.Serilog/                                     |
| AutoMapper Dependency Injection **_v12.0.1_** | https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection |

## API Documentation

Swagger Api Documentation for [Worklog Demo Application](https://app.swaggerhub.com/apis/DIONISIUSGUNADI/worklog-demo/v1 "Redirect to SwaggerHub").
