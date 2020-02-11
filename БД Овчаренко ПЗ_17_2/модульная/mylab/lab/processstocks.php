<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$ProductID = '';
$Qty = '';

if (isset($_POST['save'])){
    $ProductID = $_POST['ProductID'];
    $Qty = $_POST['Qty'];

    $result = $mysqli->query("SELECT ProductID FROM stocks WHERE ProductID=$ProductID"  );
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Товар с таким номером уже существует в базе данных, введите ваши значения вновь";
        $_SESSION['msg_type'] = "danger";
        header("location: stocks.php");
    }
    else {
        $mysqli->query("INSERT INTO stocks(ProductID, Qty)VALUES('$ProductID', '$Qty')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: stocks.php");
    }
}

if (isset($_GET['delete'])){
    $ProductID = $_GET['delete'];

    $mysqli->query("DELETE FROM stocks WHERE ProductID=$ProductID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: stocks.php");
}

if (isset($_GET['edit'])){
    $ProductID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM stocks WHERE ProductID=$ProductID") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $ProductID = $row['ProductID'];
        $Qty = $row['Qty'];
    }
}

if (isset($_POST['update'])){
    $ProductID = $_POST['ProductID'];
    $Qty = $_POST['Qty'];

        $mysqli->query("UPDATE stocks SET ProductID='$ProductID', Qty='$Qty' WHERE ProductID=$ProductID");

        if ($mysqli->error) {
            $_SESSION['message'] = "Нельзя изменить код группы, на уже существующий, проверьте правильность ввода данных";
            $_SESSION['msg_type'] = "danger";

        }
        else {
            $_SESSION['message'] = "Запись была успешно обновлена";
            $_SESSION['msg_type'] = "success";

        }
    header("location: stocks.php");
}

if (isset($_POST['filter'])) {
    $where = "WHERE ";
    if(isset($_POST['ProductID'])){
        $where = $where.'ProductID='.$_POST['ProductID'];
    };
    $specialty = $_POST['specialty'];
    $department = $_POST['department'];
    $moreorless = $_POST['moreorless'];
    $Qty = $_POST['Qty'];



    $mysqli->query("SELECT * FROM stocks ".$where);
    var_dump($mysqli->fetch_assoc());die();
}