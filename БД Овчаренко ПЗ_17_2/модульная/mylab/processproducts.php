<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$ID = '';
$Name = '';

if (isset($_POST['save'])){
    $ID = $_POST['ID'];
    $Name = $_POST['Name'];

    $result = $mysqli->query("SELECT * FROM products WHERE ID=$ID ORDER BY ID ASC");
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Ошибка при добавлении продукта в базу";
        $_SESSION['msg_type'] = "danger";
        header("location: products.php");
    }
    else {
        $mysqli->query("INSERT INTO products(Name) VALUES('$Name')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: products.php");
    }
}

if (isset($_GET['delete'])){
    $ID = $_GET['delete'];

    $mysqli->query("DELETE FROM products WHERE ID=$ID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: products.php");
}

if (isset($_GET['edit'])){
    $ID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM products WHERE ID=$ID ORDER BY ID ASC") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $ID = $row['ID'];
        $Name = $row['Name'];
    }
}

if (isset($_POST['update'])){
    $ID = $_POST['ID'];
    $Name = $_POST['Name'];


        $mysqli->query("UPDATE products SET ID='$ID', Name='$Name' WHERE ID=$ID");

    if ($mysqli->error) {
        $_SESSION['message'] = "Нельзя изменить код продукта, на уже существующий, проверьте правильность ввода данных";
        $_SESSION['msg_type'] = "danger";

    }
    else {
        $_SESSION['message'] = "Запись была успешно обновлена";
        $_SESSION['msg_type'] = "success";

    }
    header("location: products.php");
}