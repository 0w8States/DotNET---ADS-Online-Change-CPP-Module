![Capture](./Pics/Capture.gif)



# Scripting of Online Changeable Modules

With the new build of 4024 TwinCAT, the ability to change TcCom modules 'on the fly' was introduced. This can be automated outside TwinCAT to some extent, by directly sending an ADS command with the LibrayID parameter for the new version. The one chore that needs completion before changing the modules is the distribution of the Repository files, and the appropriate x64/x86 tmx file, to the targets boot folder.

In the sample within this repo, I've included a simple WinForms C# application for controlling five pre-build modules. Each module has its own signal output, and it's on unique settings, to provide a different signal within each version.

The modules themselves are not included, as to avoid the certificate distribution process. Running the application is possible, but you will want to change the LibraryID string that is sent over ADS.

## Prerequisites

Below I two systems are listed; the engineering and target. These can be the same system, but the target will be whatever system is running TwinCAT XAR, and the engineering is whatever system is running the WinForms application + XAE environment.

* The engineering system running the WinForms application needs a full (or trial) TE1300 Scope Professional license generated
* The target system will need a TF3300 Scope View and TC1300 C++ trial license

## Running the App

1. Start new TwinCAT XAE project and build your TcCOM Modules
2. Find the LibraryID string from the TcCOM module for each version
4. Replace the ADS write string command in the WinForms application to push your LibraryID
5. Start WinForms project and connect to the target
