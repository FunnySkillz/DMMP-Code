# Pflichtenheft
**Author:** Bogdan Sebastijan
**Version:** 2.6.1
**Date:** 2022-09-22

## Current state

### User

- Old ways of keeping up with the changes done to his property.
- Job definition between client and contractor hard to keep track of on multiple properties.
- Old ways of making a request for a different job.
- Keeping track of when a particular object is due.

### Contractor

- Hard to keep track of properties due to maintain.
- Hard to keep track of contracts made with a certain client.
- Hard to keep track of all clients.
- Hard to keep track of all jobs and addresses due today.
- Hard to keep track of todos.

## Problem definition

- At this point in time, we have to use different methods (applications, to-do lists, papers, etc.) to keep track of many simple tasks. The process is exhausting, and organizing consumes too much time.

## Assignment

- Create a web application that will keep topics such as organizing and tracking to a minimum and provide a simple user interface with zero to minimal time consumption.

### Nonfunctional Demands

- Security
- Efficiency
- Usability
- Portability
- Robustness
- Usability

### Functional Demands / Use-cases

#### User

- Can add a new contract to the existing list by filling out a form.
- Can see the latest updates to his property on the homepage.
- Can see the upcoming/due maintenance in the DatePicker.
- Date picker: Clicks on a date, and the maintenance due for that day will be shown in a list.
- NFC - Scan an object, and the following information will be shown:
  - Last time it was maintained.
  - Next due maintenance.
  - (Who maintained it -- under strong consideration)
  - Object information - which floor is the object, under which job it's connected to, other available data in a string or notes for the object.

#### Contractor

- Can see the to-do list for today on the homepage.
- Can insert how many Floors and how many Items are on each floor.
- Can assign tasks to a certain worker.
- Can display a PDF (Houseplan, Contract, etc.).

#### Use-Case Diagram

![DMMP Use-case Diagram](path/to/image.png)

### System Architecture - "How do I do it?"

![DMMP System Architecture](path/to/image.png)

- The backend communicates with the database using an ORM, and the frontend communicates with the backend via a REST API.
- Authorization is handled by Keycloak, and the entire system is containerized using Docker.

## Goal

- User can manage his properties and be assured his facilities are well-maintained.
- Contractor can manage facilities and keep track of his todos.
- Easier to scale up and help assign tasks to workers.

## Framework

- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/de/vs/)
- Programming Language: [.NET C#](https://en.wikipedia.org/wiki/C_Sharp_(programming_language))
- Frontend: [.NET MAUI](https://learn.microsoft.com/de-de/dotnet/maui/what-is-maui?view=net-maui-7.0)
- Backend: [.NET C#](https://dotnet.microsoft.com/en-us/languages/csharp)
- Authorization: [Keycloak](https://www.keycloak.org/)
- Docker: [Docker](https://www.docker.com/)
- Database: [MySQL-DB](https://www.mysql.com/)
- VCS: [GitHub](https://github.com/FunnySkillz/DMMP-Code)

## More about the application

- [GUI Documentation](https://underconstruction.at): Application GUI documentation.
- [More About](https://underconstruction.at): Company information.

