echo on
cls

@echo TEST 0

C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 /?
@pause
cls

@echo TEST 1
@echo Start program without parameters

C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1

@if %errorLevel% == 160 (
	echo Error code: %errorLevel%
	echo Test is OK
) else (
	echo Exit code: %errorLevel% - Test is not OK
)
@pause
cls

@echo TEST 2
@echo Start program with nonexistent path

C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 D:\Users\Anton\archcomp1\tests\test1 E:\Users\repos\archcomp1\tests\test2

@if %errorLevel% == 3 (
  echo Eror code: %errorLevel%
  echo Test is OK
) else (
  echo Exit code: %errorLevel% - Test is not OK
)

@pause
cls
@echo TEST 3
@echo Start program with bad key



C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 /H D:\Tests\tomerge1 D:\Tests\tomerge2

@if %errorLevel% == 186 (
  echo Eror code: %errorLevel% 
  echo Test is OK
) else (
  echo Exit code: %errorLevel% - Test is not OK
)
@pause
cls

@echo TEST 4
@echo Start program with bad attribute

C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 C:\Users\Anton\source\repos\archcomp1\tests\test1 C:\Users\Anton\source\repos\archcomp1\tests\test2 /A F

@if %errorLevel% == 186 (
  echo Eror code: %errorLevel% 
  echo Test is OK
) else (
  echo Exit code: %errorLevel% - Test is not OK
)

@pause
cls

@echo TEST 5
@echo Start program with attribute but without start paths


C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 /A R H

@if %errorLevel% == 2 (
  echo Eror code: %errorLevel% 
  echo Test is OK
) else (
  echo Exit code: %errorLevel% - Test is not OK
)

@pause
cls

@pause
cls

@echo TEST 7
@echo Test program to move all files
@echo inside test1:
dir C:\Users\Anton\source\repos\archcomp1\tests\test1
@pause

@echo inside test2:
dir C:\Users\Anton\source\repos\archcomp1\tests\test2
@pause
@press enter to start program
@pause

C:\Users\Anton\source\repos\archcomp1\archcomp1\bin\Debug\archcomp1 C:\Users\Anton\source\repos\archcomp1\tests\test1 C:\Users\Anton\source\repos\archcomp1\tests\test2

@echo inside test1:
dir C:\Users\Anton\source\repos\archcomp1\tests\test1
@pause

@echo inside test2:
dir C:\Users\Anton\source\repos\archcomp1\tests\test2
@pause