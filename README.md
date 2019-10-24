![Capture](./Pics/Capture.gif)



# Scripting of Online Changeable Modules

With the new build of 4024 TwinCAT, the ability to change TcCom modules 'on the fly' was introduced. This can be automated outside TwinCAT to some extent, by directly sending an ADS command with the LibrayID parameter for the new version. The one chore that needs completion before changing the modules is the distribution of the Repository files, and the appropriate x64/x86 tmx file, to the targets boot folder. However, the Repository distribution is relatively easy via XAE; apply the new TcCOM version at least once, and it'll deploy the correct files to the target.

In the sample within this repo, I've included a simple WinForms C# application for controlling five pre-build modules. Each module has its own signal output, and it's on unique settings, to provide a different signal within each version.

The modules themselves are not included in this repo, as to avoid the certificate distribution process. Running the application is possible, but you will want to change the LibraryID string that is sent over ADS. To get a similar TcCOM to the one used for the demo, see my Fourier Series TwinCAT CPP project. 

Located here: https://gitlab.com/0w8States/cpp-fourier-series-online-changeable

## Prerequisites

* The engineering system running the WinForms application needs a full (or trial) TE1300 Scope Professional license generated
* The target system will need a TF3300 Scope View, and TC1300 C++ trial license or Simulink trial

## Running the App

1. Start new TwinCAT XAE project and build your TcCOM Modules
2. Read the Edits section below, and modify the specified values in the Form1.cs for the WinForms Application
3. Start WinForms project and connect to the target

## Edits to Form1.cs

The main edit will be the string for the LibraryID version that is transmitted over ADS. For this demo, the full string looked similar to this:
```CSharp
"C++ Module Vendor|CPPVP1|0.0.0.1"
```

* tcCOM_indexGroup

This is the Index for the TcCOM object you will be controlling inside TwinCAT    

* tcCOM_indexOffset

This is the Offset for the TcCOM object you will be controlling inside TwinCAT

* task_indexGroup

This is the Index for the ADS symbol you would like displayed on Scope, needs to be an LREAL

* task_indexOffset

This is the Offset for the ADS symbol you would like displayed on Scope, needs to be an LREAL

* tmcVendorInfo_Name

Vendor Name located inside the TMC file for the TcCOM

* tmcVersionedClassfactory_Name

Vendor Class Factory located inside the TMC file for the TcCOM

* TcComVersion

This string needs to be replaced for the method _writeTcComModuleVersion for the various button presses, based on your version numbers