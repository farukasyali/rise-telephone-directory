# rise-telephone-directory
Back-End Assignment for Rise Technology, Consulting 

## Microservices
Three microservices were created in the project. Configured to run on Kestrel server.
* Person Service  
* Report Service 
* ReportPublisher Service 

## Database
Postgresql is used as database.
Migration configurations were made for Person Service and Report Service.
The appsettings.json file of the projects should be edited for the local server.

## Message Broker
RabbitMq was used as the message broker. Also used MassTransit framework.
RabbitMq Default Port : Assumed to run as 5672.
RabbitMq server address can be set in appsettings.json file.

Necessary adjustments should be made in the PhoneBook.Services.Report.Api and PhoneBook.Services.ReportPublisher.Api projects

## SignalR
In the ReportPublisher Service project, in the appsettings.json file
SignalRHub address can be set.

This setting needs to be fixed if the port of the PhoneBook.Web project changes.
