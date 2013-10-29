AngularSignalrTutorial
======================

This project shows how to use SignalR, Angular and SignalR with Angular.
Currently it consists of three tutorials.  The first tutorial uses only signalr to communicate with a back end database (a SQL Server MDF file).
The second tutorial uses angular and the $http service to pull data from the database.  The third tutorial uses signalr with angular to pull the data bac from the database.


Tutorial 4 is coming soon and will show how to use Delegates in signalr to fire multiple client events from a single call to the server.
This is really helpful when you want the server to stream data to the client, or when you need to send more than 1 chunk of data to the client from the server from one server call.  Think paging...  You could send back the number of pages to the client and then the appropriate page, all from a single server call.  The server will then call to the client when it has the data ready.
