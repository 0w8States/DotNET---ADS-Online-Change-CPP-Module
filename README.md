
![Capture](./Pics/Capture.gif)



# Scripting of Online Changeable Modules

With the new build of 4024 TwinCAT, the ability to change TcCom modules 'on the fly' was introduced. This can be automated outside TwinCAT to some extent, by simply sending an ADS command with the LibrayID parameter for the new version. The one task that needs to be completed prior to change the modules on the fly, is the distribution of the Repository files, and the appropriate x64/x86 tmx file, to the targets boot folder.  

In the sample within this repo, I've included a simple WinForms C# application for controlling 5 pre-build modules. Each module has it's own signal output, and it's on unique settings, to provide a different signal within each version.



## Prerequisites

Below I two systems are listed; engineering, and target. These can be the same system, but the target will be whatever system is running TwinCAT XAR, and the engineering is whatever system is running the WinForms application + XAE environment.

* The engineering system running the WinForms application needs a full (or trial) TE1300 Scope Professional license generated
* The target system will need a TF3300 Scope View and TC1300 C++ trial license
* The target system will need to be setup in Test Signing Mode for the TcCom drivers to start properly
* The target system will need the contents of the XAR folder from this repository copied to C:\TwinCAT\3.1\Boot\Repository
* The engineering system will need the contents of the XAE folder from this repository copied to C:\TwinCAT\3.1\Repository



It's important to note that the XAR deployment files were built for x64, so this may not work with all systems. In this case, you can manually generate these files by 'Applying' each version of the module manually to the target after Step 4 below.



## Running the App

1. Start new TwinCAT XAE project

2. Right-click TcCom objects, and select reload TMC

3. Right-click TcCom objects, Add New, select the SignalsDemo module v0.0.0.1

4. Activate Configuration on the target

5. Start WinForms project and connect to the target

   (You can also change the modules via XAE from TcCom Objects -> Online Changables tab -> Right-click and Apply Version)

