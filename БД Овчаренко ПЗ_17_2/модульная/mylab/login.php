<!DOCTYPE html>
<html>
<head>
    <title>Авторизация</title>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<style>
/* Demo Background */
body{background:url(/images/bg/bg-6.png)}

/* Form Style */
.form-horizontal{
 background: #fff;
 padding-bottom: 40px;
 border-radius: 15px;
 text-align: center;
}
.form-horizontal .heading{
 display: block;
 font-size: 35px;
 font-weight: 700;
 padding: 35px 0;
 border-bottom: 1px solid #f0f0f0;
 margin-bottom: 30px;
}
.form-horizontal .form-group{
 padding: 0 40px;
 margin: 0 0 25px 0;
 position: relative;
}
.form-horizontal .form-control{
 background: #f0f0f0;
 border: none;
 border-radius: 20px;
 box-shadow: none;
 padding: 0 20px 0 45px;
 height: 40px;
 transition: all 0.3s ease 0s;
}
.form-horizontal .form-control:focus{
 background: #e0e0e0;
 box-shadow: none;
 outline: 0 none;
}
.form-horizontal .form-group i{
 position: absolute;
 top: 12px;
 left: 60px;
 font-size: 17px;
 color: #c8c8c8;
 transition : all 0.5s ease 0s;
}
.form-horizontal .form-control:focus + i{
 color: #00b4ef;
}
.form-horizontal .fa-question-circle{
 display: inline-block;
 position: absolute;
 top: 12px;
 right: 60px;
 font-size: 20px;
 color: #808080;
 transition: all 0.5s ease 0s;
}
.form-horizontal .fa-question-circle:hover{
 color: #000;
}
.form-horizontal .main-checkbox{
 float: left;
 width: 20px;
 height: 20px;
 background: #11a3fc;
 border-radius: 50%;
 position: relative;
 margin: 5px 0 0 5px;
 border: 1px solid #11a3fc;
}
.form-horizontal .main-checkbox label{
 width: 20px;
 height: 20px;
 position: absolute;
 top: 0;
 left: 0;
 cursor: pointer;
}
.form-horizontal .main-checkbox label:after{
 content: "";
 width: 10px;
 height: 5px;
 position: absolute;
 top: 5px;
 left: 4px;
 border: 3px solid #fff;
 border-top: none;
 border-right: none;
 background: transparent;
 opacity: 0;
 -webkit-transform: rotate(-45deg);
 transform: rotate(-45deg);
}
.form-horizontal .main-checkbox input[type=checkbox]{
 visibility: hidden;
}
.form-horizontal .main-checkbox input[type=checkbox]:checked + label:after{
 opacity: 1;
}
.form-horizontal .text{
 float: left;
 margin-left: 7px;
 line-height: 20px;
 padding-top: 5px;
 text-transform: capitalize;
}
.form-horizontal .btn{
 float: right;
 font-size: 14px;
 color: #fff;
 background: #00b4ef;
 border-radius: 30px;
 padding: 10px 25px;
 border: none;
 text-transform: capitalize;
 transition: all 0.5s ease 0s;
}
@media only screen and (max-width: 479px){
 .form-horizontal .form-group{
 padding: 0 25px;
 }
 .form-horizontal .form-group i{
 left: 45px;
 }
 .form-horizontal .btn{
 padding: 10px 20px;
 }
}

</style>
<body>
<?php
session_start();
if (isset($_SESSION['message'])): ?>
    <div class="alert alert-<?=$_SESSION['msg_type']?>">

        <?php
        echo $_SESSION['message'];
        unset($_SESSION['message']);
        ?>

    </div>
<?php endif ?>
<?php
// Страница авторизации

// Функция для генерации случайной строки
function generateCode($length=6) {
    $chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHI JKLMNOPRQSTUVWXYZ0123456789";
    $code = "";
    $clen = strlen($chars) - 1;
    while (strlen($code) < $length) {
            $code .= $chars[mt_rand(0,$clen)];
    }
    return $code;
}

// Соединямся с БД
$link=mysqli_connect("localhost", "root", "", "internetshopdb");

if (isset($_COOKIE['id']) and isset($_COOKIE['hash']))
{
    $query = mysqli_query($link, "SELECT * FROM users WHERE user_id = '".intval($_COOKIE['id'])."' LIMIT 1");
    $userdata = mysqli_fetch_assoc($query);
}
else
{
    print "";
}

if(isset($_POST['submit']))
{
    // Вытаскиваем из БД запись, у которой логин равняеться введенному
    $query = mysqli_query($link,"SELECT user_id, user_password FROM users WHERE user_login='".mysqli_real_escape_string($link,$_POST['login'])."' LIMIT 1");
    $data = mysqli_fetch_assoc($query);

    // Сравниваем пароли
    if($data['user_password'] === md5(md5($_POST['password'])))
    {
        // Генерируем случайное число и шифруем его
        $hash = md5(generateCode(10));

        if(!empty($_POST['not_attach_ip']))
        {
            // Если пользователя выбрал привязку к IP
            // Переводим IP в строку
            $insip = ", user_ip=INET_ATON('".$_SERVER['REMOTE_ADDR']."')";
        }

        // Записываем в БД новый хеш авторизации и IP
        mysqli_query($link, "UPDATE users SET user_hash='".$hash."' ".$insip." WHERE user_id='".$data['user_id']."'");

        // Ставим куки
        setcookie("id", $data['user_id'], time()+60*60*24*30);
        setcookie("hash", $hash, time()+60*60*24*30,null,null,null,true); // httponly !!!

        // Переадресовываем браузер на страницу проверки нашего скрипта
		$_SESSION['message'] = "Авторизация прошла успешно, здравствуйте! "/*.$userdata['user_login']*/;
        $_SESSION['msg_type'] = "success";
        header("Location: index.php");
    }
    else
    {
        $_SESSION['message'] = "Ошибка при введении логина/пароля, попробуйте снова!";
        $_SESSION['msg_type'] = "danger";
        header("location: login.php");
    }
}
?>
<div class="container">
 <div class="row">
 <div class="col-md-offset-3 col-md-6">
 <form class="form-horizontal" method="POST">
 <span class="heading">АВТОРИЗАЦИЯ</span>
 <div class="form-group">
 <input type="text" class="form-control" placeholder="Login" name="login" required>
 <i class="fa fa-user"></i>
 </div>
 <div class="form-group">
 <input type="password" class="form-control" placeholder="Password" name="password" required>
 <i class="fa fa-lock"></i>
 </div>
 <div class="form-group">
 <table>
 <tr>
 <th>
 <button name="submit" type="submit" class="btn btn-default">Войти в аккаунт</button>
 </th>
 <th>
 <h1>ИЛИ<span class="badge badge-secondary">ЖЕ</span></h1>
 </th>
 <th>
 <a class="btn btn-primary" href="register.php" role="button">Обратно к регистрации</a>
 </th>
 </tr>
 </table>
 </div>
 </form>
 </div>
 </div><!-- /.row -->
</div><!-- /.container -->
</body>
</html>