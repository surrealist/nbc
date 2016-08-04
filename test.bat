@REM install-package xunit.runner.console 

@echo off
Packages\xunit.runner.console.2.1.0\tools\xunit.console ^
	NBC.Facts\bin\Debug\NBC.Facts.dll ^
	-parallel all ^
	-html Result.html 
@echo on