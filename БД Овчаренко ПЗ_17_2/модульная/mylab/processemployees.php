<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));

$update = false;
$FName = '';
$MName = '';
$LName = '';
$Post = '';
$Salary = '';
$PriorSalary = '';

if (isset($_POST['save'])){
    $ID = $_POST['ID'];
    $FName = $_POST['FName'];
    $MName = $_POST['MName'];
    $LName = $_POST['LName'];
    $Post = $_POST['Post'];
    $Salary = $_POST['Salary'];
    $PriorSalary = $_POST['PriorSalary'];

    $result = $mysqli->query("SELECT * FROM employees WHERE ID=$ID ORDER BY ID ASC");
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Продавец с таким именем уже существует в базе данных, введите ваши значения вновь";
        $_SESSION['msg_type'] = "danger";
        header("location: employees.php");
    }
    else {
        $mysqli->query("INSERT INTO employees(FName, MName, LName, Post, Salary, PriorSalary) VALUES('$FName', '$MName', '$LName', '$Post', '$Salary', '$PriorSalary')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: employees.php");
    }
}

if (isset($_GET['delete'])){
    $ID = $_GET['delete'];

    $mysqli->query("DELETE FROM employees WHERE ID=$ID") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: employees.php");
}

if (isset($_GET['edit'])){
    $ID = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM employees WHERE ID=$ID ORDER BY ID ASC") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
		$FName = $row['FName'];
		$MName = $row['MName'];
		$LName = $row['LName'];
		$Post = $row['Post'];
		$Salary = $row['Salary'];
		$PriorSalary = $row['PriorSalary'];
    }
}

if (isset($_POST['update'])){
		$ID = $_POST['ID'];
		$FName = $_POST['FName'];
		$MName = $_POST['MName'];
		$LName = $_POST['LName'];
		$Post = $_POST['Post'];
		$Salary = $_POST['Salary'];
		$PriorSalary = $_POST['PriorSalary'];
        $mysqli->query("UPDATE employees SET ID='$ID', FName = '$FName', MName = '$MName', LName = '$LName', Post = '$Post', Salary = '$Salary', PriorSalary = '$PriorSalary' WHERE ID=$ID");

    if ($mysqli->error) {
        $_SESSION['message'] = "Ошибка";
        $_SESSION['msg_type'] = "danger";

    }
    else {
        $_SESSION['message'] = "Запись была успешно обновлена";
        $_SESSION['msg_type'] = "success";

    }
    header("location: employees.php");
}