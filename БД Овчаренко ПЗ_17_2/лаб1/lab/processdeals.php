
<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));

$update = false;
$id = '';
$deal_code = '';
$customer_code = '';
$product_code = '';
$quantity ='';
$date = '';

if (isset($_POST['save'])){
    $deal_code = $_POST['deal_code'];
    $customer_code = $_POST['customer_code'];
	$product_code = $_POST['product_code'];
    $quantity = $_POST['quantity'];
    $date = $_POST['date'];
    
    $mysqli->query("INSERT INTO deals(deal_code, customer_code , product_code, quantity, date) VALUES('$deal_code', '$customer_code', '$product_code', '$quantity', '$date')") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно добавлена";
    $_SESSION['msg_type'] = "success";
    
    header("location: deals.php");
}

if (isset($_GET['delete'])){
    $id = $_GET['delete'];
    
    $mysqli->query("DELETE FROM deals WHERE id=$id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: deals.php");
}

if (isset($_GET['edit'])){
    $id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM deals WHERE id=$id") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
		$deal_code = $row['deal_code'];
        $customer_code = $row['customer_code'];
		$product_code = $row['product_code'];
        $quantity = $row['quantity'];
        $date = $row['date'];
    }
}

if (isset($_POST['update'])){
    $id = $_POST['id'];
    $deal_code = $_POST['deal_code'];
    $customer_code = $_POST['customer_code'];
	$product_code = $_POST['product_code'];
    $quantity = $_POST['quantity'];
    $date = $_POST['date'];
    
    $mysqli->query("UPDATE deals SET deal_code='$deal_code', customer_code='$customer_code', product_code='$product_code', quantity='$quantity', date='$date'  WHERE id=$id") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно обновлена";
    $_SESSION['msg_type'] = "warning";
    
    header("location: deals.php");
}