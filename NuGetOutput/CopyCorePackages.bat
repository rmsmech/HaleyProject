@echo off

if exist ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.nupkg (
xcopy ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.nupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.nupkg 
)

if exist ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.snupkg (
xcopy ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.snupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyMVVMCore\bin\Release\*.snupkg 
)

if exist ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.nupkg (
xcopy ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.nupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.nupkg 
)

if exist ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.snupkg (
xcopy ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.snupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyHelpers\bin\Release\*.snupkg 
)

if exist ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.nupkg (
xcopy ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.nupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.nupkg 
)

if exist ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.snupkg (
xcopy ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.snupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyLog\bin\Release\*.snupkg 
)

if exist ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.nupkg (
xcopy ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.nupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.nupkg 
)

if exist ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.snupkg (
xcopy ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.snupkg .\ /i /y
del /f ..\_CORE_PROJECTS\HaleyRuleEngine\bin\Release\*.snupkg 
)

PAUSE