@ECHO OFF

ECHO Help:
numandsize.py -h
PAUSE
CLS


ECHO Test nomer 1:
ECHO Wrong directory
numandsize.py -h Test
IF %ErrorLevel% == %0% ECHO Test not OK
IF NOT %ErrorLevel% == %0%  ECHO Test OK
PAUSE
CLS

ECHO Test nomer 2:
ECHO Without recursion for foulder test 2
numandsize.py -h -D .\Test2\
IF %ErrorLevel% == -1 ECHO Test not OK
IF NOT %ErrorLevel% == -1 ECHO Test OK 
PAUSE
CLS

ECHO Test nomer 3:
ECHO With recursion for foulder test 3
numandsize.py -h -D .\Test3\ -R 
IF %ErrorLevel% == %-1% ECHO Test not OK
IF NOT %ErrorLevel% == %-1% ECHO ECHO Test OK
PAUSE
CLS

ECHO Test nomer 4:
ECHO With recursion for foulder test 4 only for .txt
numandsize.py -h -h -D .\Test4\ -R .txt 
IF %ErrorLevel% == %-1% ECHO Test not OK
IF NOT %ErrorLevel% == %-1% ECHO ECHO ECHO Test OK
PAUSE
CLS

ECHO Test nomer 5:
ECHO Withot recursion for foulder test 5 only for .jpg
numandsize.py -h -D .\Test5\ .jpg
IF %ErrorLevel% == %-1% ECHO Test not OK
IF NOT %ErrorLevel% == %-1% ECHO ECHO ECHO Test OK
PAUSE
CLS

ECHO Test nomer 6:
ECHO With recursion for foulder test 6 for .jpg i .txt
numandsize.py -h-D .\Test6\ -R .jpg .txt
IF %ErrorLevel% == %-1% ECHO Test not OK
IF NOT %ErrorLevel% == %-1% ECHO ECHO ECHO Test OK
PAUSE
CLS