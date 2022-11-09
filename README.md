# CanBusProtocol
C# Classes For Connecting To Can ECUs To Send And Receive Data Commands
-----------------------------------------------------------------------
Connection class:
To get response from any kind of ECU(CAN or KWP)
-----------------------------------------------------------------------
CanECUs class:
Contains methods to connect to CAN ECUs, send data command requests towards them
and get data command responses from them.
It converts the commands received from ECU into standard CAN format.
-----------------------------------------------------------------------
DataBaseConnection class:
The required data to work with is stored in a MS Access Database and
this class connects to the database and reads the data from it.

** You can use this class if you're attempting to use MS Access Database
in a C# Project and modify it as your requirements **
-----------------------------------------------------------------------
DumpConnection class:
To send data commands of ECU Downloading procedure, first we need to
read the data commands from a .bin(Dump) file and return in into the
code. This class does so.
