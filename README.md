# BitDefenderDeploy
Utility for MSPs to deploy Bit Defender silently

This utility can be used to deploy Bit Defender to an end point via a RMM Agent. 
The application takes a single argument that is the URL for the Bit Defender package you are seeking to deploy. 

   BitDefenderDeploy.exe https://cloud.gravityzone.bitdefender.com/Packages/BSTWIN/0/setupdownloader_[aHR.....4tVVM=].exe

The end user will not be bothered with a popup. 

A staging directory will be created called 
c:\bddeploy

The Bit Defender package will be downloaded to this directory and executed. 

At the end of the installation the app attempts (and fails) to remove the staging directory. 
At this point an exception occurs and the staging directory is not removed. I haven't had time to solve this problem. 

To Do
----
1. Fix exception and failure to remove the staging directory
2. Error handling
3. Logging into the Windows Event Log
4. Porting to .NET Core leading to cross platform support for Linux. 

I would welcome any contributions to resolve these To Dos. 

License
-------
MIT License
