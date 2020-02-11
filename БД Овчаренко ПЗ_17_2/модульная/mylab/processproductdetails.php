<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$ID = '';
$Color = '';
$Description = '';

if (isset($_POST['save'])){
    $ID = $_POST['ID'];
    $Color = $_POST['Color'];
    $Description = $_POST['Description'];

    $result = $mysqli->query("SELECT ID FROM productdetails WHERE ID=$ID"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка при добавлении информации по продукту в базу";
        $_SESSION['msg_type'] = "danger";
        header("location: productdetails.php");
    }
    else {
        $mysqli->query("INSERT INTO productdetails(ID, Color, Description)VALUES('$ID', '$Color', '$Description')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: productdetails.php");
    }
}

if (isset($_GET['delete'])){
    $ID = $_GET['delete'];

    $mysqli->query("DELETE FROM productdetails WHERE ID=$ID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: productdetails.php");
}

if (isset($_GET['edit'])){
    $ID = $_GET['edit'];
	
    $update = true;
    $result = $mysqli->query("SELECT * FROM productdetails WHERE ID=$ID") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $ID = $row['ID'];
        $Color = $row['Color'];
		$Description = $row['Description'];
    }
}

if (isset($_POST['update'])){
    $ID = $_POST['ID'];
    $Color = $_POST['Color'];
	$Description = $_POST['Description'];

        $mysqli->query("UPDATE productdetails SET ID='$ID', Color='$Color', Description='$Description' WHERE ID=$ID");

        if ($mysqli->error) {
            $_SESSION['message'] = "Ошибка при изменении инфы продукта в базу";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: productdetails.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['ID'])){
        $where = $where.'ID='.$_POST['ID'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $Color = $_POST['Color'];



    $mysqli->query("SELECT * FROM productdetails ".$where);
    var_dump($mysqli->fetch_assoc());die();
}