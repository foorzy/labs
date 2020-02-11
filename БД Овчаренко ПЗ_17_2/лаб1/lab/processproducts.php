<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));

$update = false;
$id = '';
$product_code ='';
$price = '';
$delivery = '';
$info = '';

if (isset($_POST['save'])){
    $product_code = $_POST['product_code'];
    $price = $_POST['price'];
    $delivery = $_POST['delivery'];
    $info = $_POST['info'];
        
    $mysqli->query("INSERT INTO products(product_code, price, delivery, info) VALUES('$product_code', '$price', '$delivery', '$info')") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно добавлена";
    $_SESSION['msg_type'] = "success";
    
    header("location: products.php");
}

if (isset($_GET['delete'])){
    $id = $_GET['delete'];
    
    $mysqli->query("DELETE FROM products WHERE id=$id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: products.php");
}

if (isset($_GET['edit'])){
    $id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM products WHERE id=$id") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $product_code = $row['product_code'];
        $price = $row['price'];
        $delivery = $row['delivery'];
        $info = $row['info'];
    }
}

if (isset($_POST['update'])){
    $id = $_POST['id'];
    $product_code = $_POST['product_code'];
    $price = $_POST['price'];
    $delivery = $_POST['delivery'];
    $info = $_POST['info'];

    $mysqli->query("UPDATE products SET product_code='$product_code', price='$price', delivery='$delivery', info='$info' WHERE id=$id") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно обновлена";
    $_SESSION['msg_type'] = "warning";
    
    header("location: products.php");
}