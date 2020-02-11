<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$ID = '';
$CustomerID = '';
$EmployeeID = '';
$OrderDate = '';

if (isset($_POST['save'])){
    $ID = $_POST['ID'];
    $CustomerID = $_POST['CustomerID'];
    $EmployeeID = $_POST['EmployeeID'];
    $OrderDate = $_POST['OrderDate'];

    $result = $mysqli->query("SELECT ID FROM orders WHERE ID=$ID"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка при добавлении заказа в базу";
        $_SESSION['msg_type'] = "danger";
        header("location: orders.php");
    }
    else {
        $mysqli->query("INSERT INTO orders(ID, CustomerID, EmployeeID, OrderDate)VALUES('$ID', '$CustomerID', '$EmployeeID', '$OrderDate')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: orders.php");
    }
}

if (isset($_GET['delete'])){
    $ID = $_GET['delete'];

    $mysqli->query("DELETE FROM orders WHERE ID=$ID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: orders.php");
}

if (isset($_GET['edit'])){
    $ID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM orders WHERE ID=$ID") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $ID = $row['ID'];
        $CustomerID = $row['CustomerID'];
        $EmployeeID = $row['EmployeeID'];
		$OrderDate = $row['OrderDate'];
    }
}

if (isset($_POST['update'])){
    $ID = $_POST['ID'];
    $CustomerID = $_POST['CustomerID'];
	$EmployeeID = $_POST['EmployeeID'];
    $OrderDate = $_POST['OrderDate'];

        $mysqli->query("UPDATE orders SET ID='$ID', CustomerID='$CustomerID', EmployeeID='$EmployeeID', OrderDate='$OrderDate' WHERE ID=$ID");

        if ($mysqli->error) {
            $_SESSION['message'] = "Ошибка при изменении заказа в базе";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: orders.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['ID'])){
        $where = $where.'ID='.$_POST['ID'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $CustomerID = $_POST['CustomerID'];



    $mysqli->query("SELECT * FROM orders ".$where);
    var_dump($mysqli->fetch_assoc());die();
}