<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));

$update = false;
$id = '';
$customer_code = '';
$name = '';
$address = '';
$phone_number = '';
$person = '';

if (isset($_POST['save'])){
    $customer_code = $_POST['customer_code'];
    $name = $_POST['name'];
    $address = $_POST['address'];
    $phone_number = $_POST['phone_number'];
    $person = $_POST['person'];
    
    $mysqli->query("INSERT INTO customers(customer_code, name, address, phone_number, person) VALUES('$customer_code', '$name', '$address', '$phone_number', '$person')") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно добавлена";
    $_SESSION['msg_type'] = "success";
    
    header("location: customers.php");
}

if (isset($_GET['delete'])){
    $id = $_GET['delete'];
    
    $mysqli->query("DELETE FROM customers WHERE id=$id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: customers.php");
}

if (isset($_GET['edit'])){
    $id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM customers WHERE id=$id") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $customer_code = $row['customer_code'];
        $name = $row['name'];
        $address = $row['address'];
        $phone_number = $row['phone_number'];
        $person = $row['person'];
    }
}

if (isset($_POST['update'])){
    $id = $_POST['id'];
    $customer_code = $_POST['customer_code'];
    $name = $_POST['name'];
    $address = $_POST['address'];
    $phone_number = $_POST['phone_number'];
    $person = $_POST['person'];
      
    $mysqli->query("UPDATE customers SET customer_code='$customer_code', name='$name', address='$address', phone_number='$phone_number', person='$person'  WHERE id=$id") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно обновлена";
    $_SESSION['msg_type'] = "warning";
    
    header("location: customers.php");
}