<?php
// Скрипт проверки

// Соединямся с БД
$link=mysqli_connect("localhost", "root", "", "internetshopdb");

if (isset($_COOKIE['id']) and isset($_COOKIE['hash']))
{
    $query = mysqli_query($link, "SELECT * FROM users WHERE user_id = '".intval($_COOKIE['id'])."' LIMIT 1");
    $userdata = mysqli_fetch_assoc($query);

    if(($userdata['user_hash'] !== $_COOKIE['hash']) or ($userdata['user_id'] !== $_COOKIE['id']))
    {
        setcookie("id", "", time() - 3600*24*30*12, "/");
        setcookie("hash", "", time() - 3600*24*30*12, "/");
        print "Хм, что-то не получилось";
    }
    else
    {
        print "Привет, ".$userdata['user_login'].". Всё работает!";
    }
	if(($userdata['user_level'] == 2))
    {
        print "Ты админ!";
    }
	else if(($userdata['user_level'] == 1))
    {
        print "Ты менеджер!";
    }
    else
    {
        print "Ты юзер!";
    }
}
else
{
    print "Включите куки";
}
?>