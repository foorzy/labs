echo on
cls

@echo TEST 0

merge /?
@pause
cls

@echo TEST 1
@echo Start program without parameters

merge

@if %errorLevel% == 160 (
	echo Error code: %errorLevel%
	echo Test is OK
) else (
	echo Exit code: %errorLevel% - Test is not OK
)
@pause
cls

@echo TEST 2
@echo Start program with bad path directory parameter

merge D:\NOEXIST1 E:\NOEXIST

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



merge /H D:\Tests\tomerge1 D:\Tests\tomerge2

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

merge /A:G D:\Tests\tomerge1 D:\Tests\tomerge2

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


merge /A:R

@if %errorLevel% == 160 (
  echo Eror code: %errorLevel% 
  echo Test is OK
) else (
  echo Exit code: %errorLevel% - Test is not OK
)

@pause
cls

@echo TEST 7
@echo Test program to copy all files

merge /C /S D:\Tests\tomerge1 D:\Tests\tomerge2 D:\Tests\tomerge3 D:\Tests\result
dir /B D:\Tests\result\*.* /A:-D /S > D:\Tests\result.txt

@del /Q /S D:\Tests\result\ /A:R > nul
@del /Q /S D:\Tests\result\ >nul
@del /Q /S D:\Tests\result\ /A:H >nul

Comp <no.txt ForTest1.txt result.txt /N=6 /C 
@IF Errorlevel 1 goto NotOk 
@Echo -
@Echo %errorlevel% ===== TestOk =====
@goto Test2
:NotOk
@Echo ===== TestNotOk =====
:Test2
pause
cls
@echo TEST 8
@echo Test program to copy all files with attributes ReadOnly and Archive!

merge /C /S /A:AR D:\Tests\tomerge1 D:\Tests\tomerge2 D:\Tests\tomerge3 D:\Tests\result
dir /B D:\Tests\result\*.* /A:-D /S > D:\Tests\result.txt

Comp <no.txt ForTest2.txt result.txt /N=1 /C 
@IF Errorlevel 1 goto NotOk 
@Echo -
@Echo %errorlevel% ===== TestOk =====
@goto End
:NotOk
@Echo ===== TestNotOk =====
:End
@del /Q /S D:\Tests\result\ /A:R > nul
@del /Q /S D:\Tests\result\ > nul
pause