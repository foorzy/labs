<!DOCTYPE html>
<html>
<head>
    <title>Сложные запросы</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
</head>
<body>
<?php require_once 'processstocks.php'; ?>

<?php
$row_cnt='';
	$counter = '';
	$link=mysqli_connect("localhost", "root", "", "internetshopdb");

	if (isset($_COOKIE['id']) and isset($_COOKIE['hash']))
	{
		$query = mysqli_query($link, "SELECT * FROM users WHERE user_id = '".intval($_COOKIE['id'])."' LIMIT 1");
		$userdata = mysqli_fetch_assoc($query);

	}
	else
	{
		print "Включите куки";
	}
if (isset($_SESSION['message'])): ?>
    <div class="alert alert-<?=$_SESSION['msg_type']?>">

        <?php
        echo $_SESSION['message'];
        unset($_SESSION['message']);
        ?>

    </div>
<?php endif ?>
<div class="pos-f-t">
    <div class="collapse" id="navbarToggleExternalContent">
        <div class="light" style="background-color: #e3f2fd;">
            <ul class="nav nav-pills nav-fill">
			<li class="list-group-item list-group-item-primary">
                    Main page
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="index.php#">Главная</a>
                </li>
            </ul>
        </div>
        <div class="light p-3" style="background-color: #e3f2fd;">
            <ul class="nav nav-pills nav-fill">
			<li class="list-group-item list-group-item-primary">
                    Register
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="register.php#">Регистрация</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="login.php#">Логин</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="check.php#">Чек</a>
                </li>
            </ul>
		</div>
		<div class="light p-3" style="background-color: #e3f2fd;">
			<ul class="nav nav-pills nav-fill">
				<li class="list-group-item list-group-item-primary">
                    User
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="stocks.php#">Склад</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="products.php#">Продукты</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="productdetails.php#">Инфо о продуктах</a>
                </li>
				<li class="nav-item">
                    <a class="nav-link active" href="hardquery.php#">Сложные запросы</a>
                </li>
            </ul>
		</div>
		<div class="light p-6" style="background-color: #e3f2fd;">
			<ul class="nav nav-pills nav-fill">
			<?php if(($userdata['user_level'] > 0)) 
					{ ?>
				<li class="list-group-item list-group-item-primary">
                    Admin
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="users.php#">Пользователи</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="usersinfo.php#">Инфа о пользователях</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="employees.php#">Рабочие</a>
                </li>
				<li class="nav-item">
                    <a class="nav-link" href="employeesinfo.php#">Инфа о рабочих</a>
                </li>
				<li class="nav-item">
                    <a class="nav-link" href="orders.php#">Заказы</a>
                </li>
				<li class="nav-item">
                    <a class="nav-link" href="orderdetails.php#">Инфа о заказах</a>
                </li>
					<?php }?>
            </ul>
		</div>
    </div>
    <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </nav>
</div>
<div class="container">
    <?php
    $mysqli = new mysqli('localhost', 'root', '', 'internetshopdb') or die(mysqli_error($mysqli));
	$search_products_result = $mysqli->query("SELECT * FROM products ORDER BY ID ASC") or die($mysqli->error);
    $resultstocks = $mysqli->query("SELECT * FROM stocks WHERE Qty>400 ORDER BY ProductID ASC") or die($mysqli->error);
	$resultusers = $mysqli->query("SELECT * FROM users WHERE user_level>0 ORDER BY user_id ASC") or die($mysqli->error);
    $resultemployees = $mysqli->query("SELECT * FROM employees WHERE Salary>1000 ORDER BY ID ASC") or die($mysqli->error);
	$resultproducts = $mysqli->query("SELECT * FROM products WHERE ID>1 AND ID<6 ORDER BY ID ASC") or die($mysqli->error);
	$resultproductsinner = $mysqli->query("SELECT * FROM Products INNER JOIN ProductDetails ON Products.ID = ProductDetails.ID ORDER BY Products.ID ASC") or die($mysqli->error);
	if ($_POST) {
            $Qty = $_POST['Qty'];
                $resultsearch = $mysqli->query("SELECT * FROM stocks WHERE Qty>'$Qty' ORDER BY ProductID ASC") or die($mysqli->error);
				$row_cnt = $resultsearch->num_rows;
				
        }
        else{
            $resultsearch = $mysqli->query("SELECT * FROM stocks ORDER BY ProductID ASC") or die($mysqli->error);
        }
	$resultproductleft = $mysqli->query("SELECT * FROM Products LEFT OUTER JOIN ProductDetails ON Products.ID = ProductDetails.ID") or die($mysqli->error);
    ?>
	<?php
		if(($userdata['user_level'] > 0))
					{
		?>
		<div class="row justify-content-center">
            <h1>Админы, менеджеры сайта</h1>
        </div>
		<div class="row justify-content-center">
            <table class="table">
                <thead>
                    <tr>
                        <th>Код пользователя</th>
                        <th>Логин</th>
						<th>Пасс</th>
						<th>Хэш</th>
						<th>Уровень доступа</th>
                    </tr>
                </thead>
        <?php
            while ($row = $resultusers->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['user_id']; ?></td>
                    <td><?php echo $row['user_login']; ?></td>
                    <td><?php echo $row['user_password']; ?></td>
                    <td><?php echo $row['user_hash']; ?></td>
                    <td><?php echo $row['user_level']; ?></td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
		<div class="row justify-content-center">
            <h1>Рабочие, зарплата которых, больше 1000</h1>
        </div>
    <div class="row justify-content-center">
            <table class="table">
                <thead>
                    <tr>
                        <th>Код рабочего</th>
                        <th>Фамилия</th>
						<th>Имя</th>
						<th>Отчество</th>
						<th>Должность</th>
						<th>Зарплата</th>
						<th>Премия</th>
                    </tr>
                </thead>
        <?php
            while ($row = $resultemployees->fetch_assoc()):
					?>
                <tr>
                    <td><?php echo $row['ID']; ?></td>
                    <td><?php echo $row['FName']; ?></td>
                    <td><?php echo $row['MName']; ?></td>
                    <td><?php echo $row['LName']; ?></td>
                    <td><?php echo $row['Post']; ?></td>
                    <td><?php echo $row['Salary']; ?></td>
					  <td><?php echo $row['PriorSalary']; ?></td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
					<?php }?>
					<h1>Запрос с параметром</h1>
	<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                Фильтр по количеству на складе
            </button>
            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Введите данные для выполнения запроса</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <form action="hardquery.php" method="POST" name="formsearch">
                                Продукты, которых на складе больше чем
                                <input type="text" name="Qty" class="form-control" pattern="[0-9]{1,}$"
                                placeholder="" required>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="submit" class="btn btn-primary" name="search">Search</button>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
			<div class="row justify-content-center">
			<?php if ($row_cnt > 0) 
			{?>
        <table class="table">
            <thead>
            <tr>
                <th>Номер продукта</th>
                <th>Количество</th>
            </tr>
            </thead>
            <?php
			
            while ($row = $resultsearch->fetch_assoc()):?>
                <tr>
                    <td><?php echo $row['ProductID']; ?></td>
                    <td><?php echo $row['Qty']; ?></td>
                </tr>
            <?php endwhile; ?>
			
        </table>
			<?php } 
					else 
					{?>
				<h1><font size="10" color="red" face="Arial">Нет товаров, с таким количеством</font></h1>
					<?php } ?>
    </div>
	<div class="row justify-content-center">
            <h1>Продукты, которых больше чем 500 единиц на складе</h1>
        </div>
    <div class="row justify-content-center">
        <table class="table">
            <thead>
            <tr>
                <th>Номер продукта</th>
                <th>Количество</th>
            </tr>
            </thead>
            <?php
            while ($row = $resultstocks->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['ProductID']; ?></td>
                    <td><?php echo $row['Qty']; ?></td>
                </tr>
            <?php endwhile; ?>
        </table>
    </div>
	<h1>Продукты, ID которых, больше 1-го, но меньше 6-ти</h1>
	<div class="row justify-content-center">
            <table class="table">
                <thead>
                    <tr>
                        <th>Код продукта</th>
                        <th>Название</th>
                    </tr>
                </thead>
        <?php
            while ($row = $resultproducts->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['ID']; ?></td>
                    <td><?php echo $row['Name']; ?></td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
	<div class="row justify-content-center">
            <h1>Продукты, с описанием</h1>
        </div>
	<div class="row justify-content-center">
        <table class="table">
            <thead>
            <tr>
                <th>Наименвание</th>
                <th>Цвет</th>
                <th>Описание</th>
            </tr>
            </thead>
            <?php
            while ($row = $resultproductsinner->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['Name']; ?></td>
                    <td><?php echo $row['Color']; ?></td>
                    <td><?php echo $row['Description']; ?></td>
                </tr>
            <?php endwhile; ?>
        </table>
    </div>
	<div class="row justify-content-center">
            <h1>Все продукты, даже без описания</h1>
        </div>
	<div class="row justify-content-center">
        <table class="table">
            <thead>
            <tr>
                <th>Наименвание</th>
                <th>Цвет</th>
                <th>Описание</th>
            </tr>
            </thead>
            <?php
            while ($row = $resultproductleft->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['Name']; ?></td>
                    <td><?php echo $row['Color']; ?></td>
                    <td><?php echo $row['Description']; ?></td>
                </tr>
            <?php endwhile; ?>
        </table>
    </div>
</div>
</body>
</html>