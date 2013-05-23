rem @ECHO OFF
SET MSNETFRM="c:\WINDOWS\Microsoft.NET\Framework\v4.0.30319"
SET EnableNuGetPackageRestore=true
%MSNETFRM%\msbuild.exe /m LegacyApp.sln
PAUSE
