## _Auto-Repair _
#### By _**Russ Vetsper**_




## Description

The Auto-Repair app lets mechanic keep track of clients , user can add , delete and match mechanics to clients.

** To run this app you will need to clone this repository. On your computers, in PowerShell run "DNU restore" , Enter "DNX Kestrel" , then  Navigate in your browser to "LocalHost:5004" to enter the app.

** Creat database and tables:
* CREATE DATABASE auto_repair;
* GO
* USE auto_repair;
* GO
* CREATE TABLE mechanic (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));
* GO

## Specs

| Behavior     | Input  |Output Example  |
| ------------- |:-----:|:----------: |
| check for empty database | none | true |
| User adds a mechanic| name of mechanic: Joe |mechanic Joe is on list for mechanics  |
| User edits a mechanic | edit mechanic Joe for mechanic Mike | mechanic name updated to Mike|
| User deletes mechanic | Delete Mike  | mechanic Mike deleted |
| User adds a client to a mechanic | new client Russ added to mechanic Frank| Russ is added to mechanic Frank |
| User edits a client | edit client Russ to client Jim |clients name updated to Jim
|User deletes client| delete client Jim| Jim deleted ,no name in mechanic list|



## Known Bugs


None

## Technologies Used
 C#, Nancy, Razor, html

### License
Copyright (c) 2016 _**Russ Vetsper **_
