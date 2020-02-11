<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'qualification') or die(mysqli_error($mysqli));

$update = false;
$id = '';
$code_teacher = '';
$code_group = '';
$amounthours ='';
$lesson = '';
$lessontype = '';
$pay = '';

if (isset($_POST['save'])){
    $code_teacher = $_POST['code_teacher'];
    $code_group = $_POST['code_group'];
    $amounthours = $_POST['amounthours'];
    $lesson = $_POST['lesson'];
    $lessontype = $_POST['lessontype'];
    $pay = $_POST['pay'];

    $mysqli->query("INSERT INTO workload(code_teacher, code_group, amounthours, lesson, lessontype, pay) VALUES('$code_teacher', '$code_group', '$amounthours', '$lesson', '$lessontype', '$pay')") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно добавлена";
    $_SESSION['msg_type'] = "success";

    header("location: workload.php");
}

if (isset($_GET['delete'])){
    $id = $_GET['delete'];

    $mysqli->query("DELETE FROM workload WHERE id=$id") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";

    header("location: workload.php");
}

if (isset($_GET['edit'])){
    $id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM workload WHERE id=$id") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $code_teacher = $row['code_teacher'];
        $code_group = $row['code_group'];
        $amounthours = $row['amounthours'];
        $lesson = $row['lesson'];
        $lessontype = $row['lessontype'];
        $pay = $row['pay'];
    }
}

if (isset($_POST['update'])){
    $id = $_POST['id'];
    $code_teacher = $_POST['code_teacher'];
    $code_group = $_POST['code_group'];
    $amounthours = $_POST['amounthours'];
    $lesson = $_POST['lesson'];
    $lessontype = $_POST['lessontype'];
    $pay = $_POST['pay'];

    $mysqli->query("UPDATE workload SET code_teacher='$code_teacher', code_group='$code_group', amounthours='$amounthours', lesson='$lesson', lessontype='$lessontype', pay='$pay'  WHERE id=$id") or die($mysqli->error);

    $_SESSION['message'] = "Запись была успешно обновлена";
    $_SESSION['msg_type'] = "warning";
    
    header("location: workload.php");
}