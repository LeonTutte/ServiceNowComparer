# ServiceNow Comparer
_Quickly and easily compare table data_

![latest build](https://github.com/LeonTutte/ServiceNowComparer/actions/workflows/dotnet.yml/badge.svg)
![security](https://github.com/LeonTutte/ServiceNowComparer/actions/workflows/codeql.yml/badge.svg)
---

This application enables the import and viewing of tables from multiple ServiceNow Instances.

The application offers the following features:

* SFD (Single File Database) with encryption according to [AES](https://www.litedb.org/docs/encryption/) standard
* Create ServiceNow instances
* SN credentials per instance
* Retrieve table data and store locally.
* Evaluate and compare table data

## Feature roadmap:

| 0.1.0               | 0.2.0                             | 0.3.0                 |
| ------------------- | --------------------------------- | --------------------- |
| connect to instance | persistent local storage          | table data evaluation |
| SFD                 | storage cleanup and housekeeping  | advanced comparison`s |
| Table download      | storage search via LINQ interface |                       |
|                     | table comparison                  |                       |

### Possible features for future versions outside the roadmap

* table backup and restore

---

## Installation and usage:

### Prerequisites:
* At least [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) must be installed on the target system.
* A terminal emulator is expected

### Installation:
The application ist portable, so just download the latest release archive and extract the files within to a folder where you have write access.

Before first start:
In the  application folder you can find a `settings.ini` file there you can give it an absolute path to the database file.

Here a the default settings:

```
[Database]
Filename=data.storage
```

To start using the application, you can but dont need to change the storage path. Upon first start you need the set a master passwort for the given storage, then the full storage will be AES encrypted. You can leave the password empty wich will result in no encryption.

---

### Instructions to begin:
1. Open the application
2. Add a ServiceNow Instance
3. Add a user with rest access to the instance for authetication
4. search for a table and download its data

#### Table comparision:
1. Repeat step 2 to 4 for both instances
2. Use the compare action in the menu
   1. select the first instance
   2. select the second instance
   3. select from the available tables

_To make a table available you must have the table downloaded for both instances, the programm will only show tables wich are already in storage for the given instances_
