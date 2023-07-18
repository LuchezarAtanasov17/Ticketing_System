# Ticketing System
## Introduction

Ticketing System is a web application for managing tickets. 

## Features

- 3 different roles: Administrator, Support and User.
- The first registered user will acquire Administrator privileges.
- The administrator can change all user roles.
- Users can register but cannot use their accounts until Administrator approves them.
- Users can login in if account is already approved.
- Listing, creating, updating and deleting projects and tickets.
- Sending messages in scope of ticket.

## Base Requirements

- .NET SDK 5.0.100 or newer
- SQL Server 2017 or newer

## Build and run

- Navigate to the `TicketingSystem.Web` directory and run: `dotnet build`
- After build succeeds, run: `dotnet run`
- Application shall be hosted in Production environment on address: `https://localhost:7220/`

## Creator
Luchezar Atanasov, lachezaratanasov1705@gmail.com