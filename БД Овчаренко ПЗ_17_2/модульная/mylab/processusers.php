<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$user_level = '';

if (isset($_GET['delete'])){
    $user_id = $_GET['delete'];

    $mysqli->query("DELETE FROM users WHERE user_id=$user_id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: users.php");
}

if (isset($_GET['edit'])){
    $user_id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM users WHERE user_id=$user_id ORDER BY user_id ASC") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $user_level = $row['user_level'];
    }
}

if (isset($_POST['update'])){
    $user_id = $_POST['user_id'];
	$user_level = $_POST['user_level'];

        $mysqli->query("UPDATE users SET user_level='$user_level' WHERE user_id=$user_id");

    if ($mysqli->error) {
        $_SESSION['message'] = "Ошибка";
        $_SESSION['msg_type'] = "danger";

    }
    else {
        $_SESSION['message'] = "Запись была успешно обновлена";
        $_SESSION['msg_type'] = "success";

    }
    header("location: users.php");
}