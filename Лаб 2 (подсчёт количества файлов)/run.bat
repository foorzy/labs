@ECHO OFF

ECHO Test #0:
Count.py -h
PAUSE
CLS

ECHO Test #1:
FOR /f %%i IN ('DIR "Test1" /a-d /b^| FIND /c /v ""') DO SET l=%%i
ECHO %l%
Count.py -D .\Test1\
IF %ErrorLevel% == %l% ECHO Test Ok
IF NOT %ErrorLevel% == %l% ECHO Test Wrong :(
PAUSE
CLS

ECHO Test #2:
FOR /f %%i IN ('DIR "Test2" /a-d /b /s^| FIND /c /v ""') DO SET l=%%i
ECHO %l%
Count.py -D .\Test2\ -R
IF %ErrorLevel% == %l% ECHO Test Ok
IF NOT %ErrorLevel% == %l% ECHO Test Wrong :(
PAUSE
CLS

ECHO Test #3:
FOR /f %%i IN ('DIR "Test3" /a-d /b^| FIND /c ".pdb"') DO SET l=%%i
ECHO %l%
Count.py -D .\Test3\ .pdb
IF %ErrorLevel% == %l% ECHO Test Ok
IF NOT %ErrorLevel% == %l% ECHO Test Wrong :(
PAUSE
CLS

ECHO Test #4:
FOR /f %%i IN ('DIR "Test3" /a-d /b /s^| FIND /c ".jpg"') DO SET p1=%%i
FOR /f %%i IN ('DIR "Test3" /a-d /b /s^| FIND /c ".exe"') DO SET p2=%%i
SET /a p = p1 + p2
ECHO %p%
Count.py -D .\Test3\ .jpg .exe -R
IF %ErrorLevel% == %p% ECHO Test Ok
IF NOT %ErrorLevel% == %p% ECHO Test Wrong :(
PAUSE
CLS

ECHO Test #5:
FOR /f %%i IN ('DIR /a-d /b^| FIND /c /v ""') DO SET l=%%i
ECHO %l%
Count.py
IF %ErrorLevel% == %l% ECHO Test Ok
IF NOT %ErrorLevel% == %l% ECHO Test Wrong :(
PAUSE
CLS

ECHO Test #6:
FOR /f %%i IN ('DIR "Test" /a-d /b^| FIND /c /v ""') DO SET l=%%i
ECHO %l%
Count.py Test
IF %ErrorLevel% == %l% ECHO Test Ok
IF NOT %ErrorLevel% == %l% ECHO Test Wrong :(
PAUSE
CLS