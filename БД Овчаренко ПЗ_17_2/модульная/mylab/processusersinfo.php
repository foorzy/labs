<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$FName = '';
$MName = '';
$LName = '';
$Address = '';
$City = '';
$Phone = '';
$DateInSystem = '';

if (isset($_POST['save'])){
    $user_id = $_POST['user_id'];
    $FName = $_POST['FName'];
    $MName = $_POST['MName'];
    $LName = $_POST['LName'];
    $Address = $_POST['Address'];
    $City = $_POST['City'];
    $Phone = $_POST['Phone'];
    $DateInSystem = $_POST['DateInSystem'];

    $result = $mysqli->query("SELECT user_id FROM usersinfo WHERE user_id=$user_id"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка добавления информации о пользователе";
        $_SESSION['msg_type'] = "danger";
        header("location: usersinfo.php");
    }
    else {
        $mysqli->query("INSERT INTO usersinfo(user_id, FName, MName, LName, Address, City, Phone, DateInSystem)VALUES('$user_id', '$FName', '$MName', '$LName', '$Address', '$City', '$Phone', '$DateInSystem')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: usersinfo.php");
    }
}

if (isset($_GET['delete'])){
    $user_id = $_GET['delete'];

    $mysqli->query("DELETE FROM usersinfo WHERE user_id=$user_id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: usersinfo.php");
}

if (isset($_GET['edit'])){
    $user_id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM usersinfo WHERE user_id=$user_id") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $user_id = $row['user_id'];
		$FName = $row['FName'];
		$MName = $row['MName'];
		$LName = $row['LName'];
		$Address = $row['Address'];
		$City = $row['City'];
		$Phone = $row['Phone'];
		$DateInSystem = $row['DateInSystem'];
    }
}

if (isset($_POST['update'])){
    $user_id = $_POST['user_id'];
    $FName = $_POST['FName'];
    $MName = $_POST['MName'];
    $LName = $_POST['LName'];
    $Address = $_POST['Address'];
    $City = $_POST['City'];
    $Phone = $_POST['Phone'];
    $DateInSystem = $_POST['DateInSystem'];

        $mysqli->query("UPDATE usersinfo SET user_id='$user_id', FName='$FName', MName='$MName', LName='$LName', Address='$Address', City='$City', Phone='$Phone', DateInSystem='$DateInSystem' WHERE user_id=$user_id");

        if ($mysqli->error) {
            $_SESSION['message'] = "Ошибка изменения информации о пользователе";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: usersinfo.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['user_id'])){
        $where = $where.'user_id='.$_POST['user_id'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $FName = $_POST['FName'];



    $mysqli->query("SELECT * FROM usersinfo ".$where);
    var_dump($mysqli->fetch_assoc());die();
}