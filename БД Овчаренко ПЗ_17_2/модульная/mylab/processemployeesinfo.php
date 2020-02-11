<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$MaritalStatus = '';
$BirthDate = '';
$Address = '';
$Phone = '';

if (isset($_POST['save'])){
    $ID = $_POST['ID'];
    $MaritalStatus = $_POST['MaritalStatus'];
    $BirthDate = $_POST['BirthDate'];
    $Address = $_POST['Address'];
    $Phone = $_POST['Phone'];

    $result = $mysqli->query("SELECT ID FROM employeesinfo WHERE ID=$ID"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка при добавлении инфы о продавцах";
        $_SESSION['msg_type'] = "danger";
        header("location: employeesinfo.php");
    }
    else {
        $mysqli->query("INSERT INTO employeesinfo(ID, MaritalStatus, BirthDate, Address, Phone)VALUES('$ID', '$MaritalStatus', '$BirthDate', '$Address', '$Phone')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: employeesinfo.php");
    }
}

if (isset($_GET['delete'])){
    $ID = $_GET['delete'];

    $mysqli->query("DELETE FROM employeesinfo WHERE ID=$ID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: employeesinfo.php");
}

if (isset($_GET['edit'])){
    $ID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM employeesinfo WHERE ID=$ID") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $ID = $row['ID'];
		$MaritalStatus = $row['MaritalStatus'];
		$BirthDate = $row['BirthDate'];
		$Address = $row['Address'];
		$Phone = $row['Phone'];
    }
}

if (isset($_POST['update'])){
    $ID = $_POST['ID'];
    $MaritalStatus = $_POST['MaritalStatus'];
    $BirthDate = $_POST['BirthDate'];
    $Address = $_POST['Address'];
    $Phone = $_POST['Phone'];

        $mysqli->query("UPDATE employeesinfo SET ID='$ID', MaritalStatus='$MaritalStatus', BirthDate='$BirthDate', Address='$Address', Phone='$Phone' WHERE ID=$ID");

        if ($mysqli->error) {
            $_SESSION['message'] = "Ошибка при изменении инфы о продавцах";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: employeesinfo.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['ID'])){
        $where = $where.'ID='.$_POST['ID'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $MaritalStatus = $_POST['MaritalStatus'];



    $mysqli->query("SELECT * FROM employeesinfo ".$where);
    var_dump($mysqli->fetch_assoc());die();
}