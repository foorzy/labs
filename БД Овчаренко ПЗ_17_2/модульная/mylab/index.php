<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Главная страница</title>

  <!-- Bootstrap core CSS -->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

  <!-- Custom fonts for this template -->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet">
  <link href="vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template -->
  <link href="css/landing-page.min.css" rel="stylesheet">

</head>

<body>
 <?php require_once 'processindex.php'; 
	

		ob_start(); ?>

        <?php

        if (isset($_SESSION['message'])): ?>
        <div class="alert alert-<?=$_SESSION['msg_type']?>">

            <?php
                echo $_SESSION['message'];
                unset($_SESSION['message']);
            ?>
        </div>
        <?php endif ?>
  <!-- Navigation -->
  <nav class="navbar navbar-light bg-light static-top">
    <div class="container">
      <a class="navbar-brand" href="index.php">Главная</a>
<?php
// Скрипт проверки
if(isset($_GET['exit'])) {
session_destroy(); 
#redirect
header('Location: index.php');
exit;
}
// Соединямся с БД
$link=mysqli_connect("localhost", "root", "", "internetshopdb");

if (isset($_COOKIE['id']) and isset($_COOKIE['hash']))
{
    $query = mysqli_query($link, "SELECT * FROM users WHERE user_id = '".intval($_COOKIE['id'])."' LIMIT 1");
    $userdata = mysqli_fetch_assoc($query);

	?>
	<a class="btn btn-danger" href="logout.php">Выход</a>
	<?php
	}
	else
	{
	?>
	<a class="btn btn-success" href="register.php">Регистрация/Логин</a>
	<?php 
	} 
	?>
    </div>
  </nav>

  <!-- Masthead -->
  <header class="masthead text-white text-center">
    <div class="overlay"></div>
    <div class="container">
      <div class="row">
        <div class="col-xl-9 mx-auto">
          <h1 class="mb-5">Перейдите к покупкам прямо сейчас!</h1>
        </div>
		<?php
		if (isset($_COOKIE['id']) and isset($_COOKIE['hash']))
		{		if(($userdata['user_level'] > 0))
					{
		?>
		<div class="col-md-10 col-lg-8 col-xl-7 mx-auto">
		<div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-success">Админка</a>
        </div>
          <form>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="users.php">Пользователи</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="usersinfo.php">Информация о пользователях</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="employees.php#">Рабочие</a>
              </div>
            </div>
          </form>
        </div>
		<div class="col-md-10 col-lg-8 col-xl-7 mx-auto">
          <form>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="employeesinfo.php">Информация о рабочих</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="orders.php">Заказы</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="orderdetails.php#">Инфорация о заказах</a>
              </div>
            </div>
          </form>
		  <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-success">Пользователю</a>
        </div>
        </div>
		
					<?php }?>
        <div class="col-md-10 col-lg-8 col-xl-7 mx-auto">
          <form>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="products.php">Продукты</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="productdetails.php">Информация о продуктах</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="stocks.php#">Склад</a>
              </div>
            </div>
			<div class="form-row">
              <div class="col-12 col-md-12">
                <a class="btn btn-block btn-lg btn-warning" href="hardquery.php#">Сложные запросы</a>
              </div>
            </div>
          </form>
        </div>
		<?php }
		else
		{ ?>
		<div class="col-md-10 col-lg-8 col-xl-7 mx-auto">
          <form>
			<div class="form-row">
              <div class="col-12 col-lg-12">
                <a class="btn btn-block btn-lg btn-warning" href="register.php">Залогинься или зарегистрируйся для доступа!</a>
              </div>
            </div>
          </form>
        </div>
		<?php } ?>
      </div>
    </div>
  </header>


  <!-- Image Showcases -->
  <section class="showcase">
    <div class="container-fluid p-0">
      <div class="row no-gutters">

        <div class="col-lg-6 order-lg-2 text-white showcase-img" style="background-image: url('img/bg-showcase-1.jpg');"></div>
        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
          <h2>Огромный и разнообразный ассортимент</h2>
          <p class="lead mb-0">В нашем магазине, вы без проблем найдете то что вы ищете! Наш магазин является сертифицированным дилером многих известных торговых марок торговых марок, поэтому мы можем предложить высококачественные строительные материалы по выгодным ценам.</p>
        </div>
      </div>
      <div class="row no-gutters">
        <div class="col-lg-6 text-white showcase-img" style="background-image: url('img/bg-showcase-2.jpg');"></div>
        <div class="col-lg-6 my-auto showcase-text">
          <h2>Доставка и разгрузкак</h2>
          <p class="lead mb-0">Заказы доставляются нашей службой логистики. При необходимости разгрузки и подъема на этаж вы можете заказать услуги грузчиков.</p>
        </div>
      </div>
      <div class="row no-gutters">
        <div class="col-lg-6 order-lg-2 text-white showcase-img" style="background-image: url('img/bg-showcase-3.jpg');"></div>
        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
          <h2>Аксессуары</h2>
          <p class="lead mb-0">Помимо торговли стройматериалами оптом и в розницу наша компания занимается продажей всевозможных товаров, которые могут пригодиться вам во время ремонта.</p>
        </div>
      </div>
    </div>
  </section>

  <!-- Testimonials -->


  <!-- Call to Action -->
  <section class="call-to-action text-white text-center">
    <div class="overlay"></div>
    <div class="container">
      <div class="row">
        <div class="col-xl-9 mx-auto">
          <h2 class="mb-4">Спасибо за внимание!</h2>
        </div>
      </div>
    </div>
  </section>

  <!-- Footer -->
  

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>

</html>
