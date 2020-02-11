<?php

session_start();
setcookie("id", '', time()-60*60*24*30);
setcookie("hash", '', time()-60*60*24*30,null,null,null,true); // httponly !!!
session_unset();

session_destroy();

header("location:index.php");

exit();

?>

