<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$OrderID = '';
$ProductID = '';
$Qty = '';
$Price = '';

if (isset($_POST['save'])){
    $OrderID = $_POST['OrderID'];
    $ProductID = $_POST['ProductID'];
    $Qty = $_POST['Qty'];
    $Price = $_POST['Price'];

    $result = $mysqli->query("SELECT OrderID FROM orderdetails WHERE OrderID=$OrderID"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка при добавлении инфы заказа в базу";
        $_SESSION['msg_type'] = "danger";
        header("location: orderdetails.php");
    }
    else {
        $mysqli->query("INSERT INTO orderdetails(OrderID, ProductID, Qty, Price)VALUES('$OrderID', '$ProductID', '$Qty', '$Price')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: orderdetails.php");
    }
}

if (isset($_GET['delete'])){
    $OrderID = $_GET['delete'];

    $mysqli->query("DELETE FROM orderdetails WHERE OrderID=$OrderID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: orderdetails.php");
}

if (isset($_GET['edit'])){
    $OrderID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM orderdetails WHERE OrderID=$OrderID") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $OrderID = $row['OrderID'];
        $ProductID = $row['ProductID'];
        $Qty = $row['Qty'];
		$Price = $row['Price'];
    }
}

if (isset($_POST['update'])){
    $OrderID = $_POST['OrderID'];
    $ProductID = $_POST['ProductID'];
	$Qty = $_POST['Qty'];
    $Price = $_POST['Price'];

        $mysqli->query("UPDATE orderdetails SET OrderID='$OrderID', ProductID='$ProductID', Qty='$Qty', Price='$Price' WHERE OrderID=$OrderID");

        if ($mysqli->error) {
            $_SESSION['message'] = "Ошибка при изменении инфы заказа";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: orderdetails.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['OrderID'])){
        $where = $where.'OrderID='.$_POST['OrderID'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $ProductID = $_POST['ProductID'];



    $mysqli->query("SELECT * FROM orderdetails ".$where);
    var_dump($mysqli->fetch_assoc());die();
}