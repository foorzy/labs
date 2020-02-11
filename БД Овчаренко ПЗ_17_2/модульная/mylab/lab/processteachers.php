<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'qualification') or die(mysqli_error($mysqli));

$update = false;
$id = '';
$code_teacher = '';
$surname = '';
$name = '';
$patronymic = '';
$phone = '';
$experience = '';

if (isset($_POST['save'])){
    $code_teacher = $_POST['code_teacher'];
    $surname = $_POST['surname'];
    $name = $_POST['name'];
    $patronymic = $_POST['patronymic'];
    $phone = $_POST['phone'];
    $experience = $_POST['experience'];

    $result = $mysqli->query("SELECT * FROM teachers WHERE code_teacher=$code_teacher ORDER BY code_teacher ASC");
    $row_cnt = $result->num_rows;
    if($row_cnt > 0) {
        $_SESSION['message'] = "Преподаватель с таким именем уже существует в базе данных, введите ваши значения вновь";
        $_SESSION['msg_type'] = "danger";
        header("location: teachers.php");
    }
    else {
        $mysqli->query("INSERT INTO teachers(code_teacher, surname, name, patronymic, phone, experience) VALUES('$code_teacher', '$surname', '$name', '$patronymic', '$phone', '$experience')") or die($mysqli->error);

        $_SESSION['message'] = "Запись была успешно добавлена";
        $_SESSION['msg_type'] = "success";

        header("location: teachers.php");
    }
}

if (isset($_GET['delete'])){
    $id = $_GET['delete'];

    $mysqli->query("DELETE FROM teachers WHERE id=$id") or die($mysqli->error);
    
    $_SESSION['message'] = "Запись была успешно удалена";
    $_SESSION['msg_type'] = "danger";
    
    header("location: teachers.php");
}

if (isset($_GET['edit'])){
    $id = $_GET['edit'];
    $update = true;
    $result = $mysqli->query("SELECT * FROM teachers WHERE id=$id ORDER BY code_teacher ASC") or die($mysqli->error);
    if(count(array($result))==1){
        $row = $result->fetch_array();
        $code_teacher = $row['code_teacher'];
        $surname = $row['surname'];
        $name = $row['name'];
        $patronymic = $row['patronymic'];
        $phone = $row['phone'];
        $experience = $row['experience'];
    }
}

if (isset($_POST['update'])){
    $id = $_POST['id'];
    $code_teacher = $_POST['code_teacher'];
    $surname = $_POST['surname'];
    $name = $_POST['name'];
    $patronymic = $_POST['patronymic'];
    $phone = $_POST['phone'];
    $experience = $_POST['experience'];


        $mysqli->query("UPDATE teachers SET code_teacher='$code_teacher', surname='$surname', name='$name', patronymic='$patronymic', phone='$phone', experience='$experience'  WHERE id=$id");

    if ($mysqli->error) {
        $_SESSION['message'] = "Нельзя изменить код преподавателя, на уже существующий, проверьте правильность ввода данных";
        $_SESSION['msg_type'] = "danger";

    }
    else {
        $_SESSION['message'] = "Запись была успешно обновлена";
        $_SESSION['msg_type'] = "success";

    }
    header("location: teachers.php");
}