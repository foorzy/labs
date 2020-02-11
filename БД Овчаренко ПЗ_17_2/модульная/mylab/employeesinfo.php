<!DOCTYPE html>
<html>
<head>
    <title>Инфа о рабочих</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
</head>
<body>
<?php require_once 'processemployeesinfo.php'; ?>

<?php
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
                    <a class="nav-link" href="hardquery.php#">Сложные запросы</a>
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
                    <a class="nav-link active" href="employeesinfo.php#">Инфа о рабочих</a>
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
	$search_employees_result = $mysqli->query("SELECT * FROM employees ORDER BY ID ASC") or die($mysqli->error);
    $result = $mysqli->query("SELECT * FROM employeesinfo ORDER BY ID ASC") or die($mysqli->error);
    ?>
    <div class="row justify-content-center">
        <table class="table">
            <thead>
            <tr>
                <th>Id работника</th>
                <th>Семейный статус</th>
				<th>Дата рождения</th>
				<th>Адрес</th>
                <th>Телефон</th>
				<?php 
					if(($userdata['user_level'] == 2))
					{
				?>
                <th colspan="2">Действия</th>
				<?php
					}
					else if(($userdata['user_level'] == 1))
					{
				?>
                <th colspan="1">Изменения</th>
				<?php
					}
				?>
            </tr>
            </thead>
            <?php
            while ($row = $result->fetch_assoc()): ?>
                <tr>
					<td><?php echo $row['ID']; ?></td>
                    <td><?php echo $row['MaritalStatus']; ?></td>
                    <td><?php echo $row['BirthDate']; ?></td>
                    <td><?php echo $row['Address']; ?></td>
                    <td><?php echo $row['Phone']; ?></td>
					<?php 
					if(($userdata['user_level'] == 2))
					{
					?>
                    <td>
                        <a href="employeesinfo.php?edit=<?php echo $row['ID']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processemployeesinfo.php?delete=<?php echo $row['ID']; ?>"
                           class="btn btn-danger">Удалить</a>
                    </td>
					<?php
					}
					else if(($userdata['user_level'] == 1))
					{
					?>
					<td>
                        <a href="employeesinfo.php?edit=<?php echo $row['ID']; ?>"
                           class="btn btn-info">Изменить</a>
                    </td>
					<?php
					}
					?>
                </tr>
            <?php endwhile; ?>
        </table>
    </div>
					<?php 
					if(($userdata['user_level'] > 0))
					{
					?>
    <div class="row justify-content-center">
        <form action="processemployeesinfo.php" method="POST">
            <div class="form-group">
                <label>Выберите id рабочего</label>
                <select class="form-control" id="exampleFormControlSelect1" name=ID>
                  <?php while ($row = $search_employees_result->fetch_assoc()): ?>
                      <?php if ($ID == $row['ID']): ?>
                          <option selected><?php echo $row['ID'],' - ',$row['FName'];;?></option>
                      <?php else: ?>
                          <option><?php echo $row['ID'],' - ',$row['FName']; ?></option>
                      <?php endif; ?>
                  <?php endwhile; ?>
                </select>
            </div>
            <div class="form-group">
                <label>Семейный статус</label>
                <input type="text" name="MaritalStatus" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $MaritalStatus; ?>" placeholder="Введите семейный статус" required>
            </div>
			<div class="form-group">
                <label>Дата рождения</label>
                <input type="date" name="BirthDate" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $BirthDate; ?>" placeholder="Введите дату рождения" required>
            </div>
			<div class="form-group">
                <label>Адрес</label>
                <input type="text" name="Address" class="form-control" pattern="[A-Za-zА-Яа-я, ,0-9]{1,}$"
                       value="<?php echo $Address; ?>" placeholder="Введите адрес" required>
            </div>
			<div class="form-group">
                <label>Телефон</label>
                <input type="text" name="Phone" class="form-control" pattern="[0-9]{1,}$"
                       value="<?php echo $Phone; ?>" placeholder="Введите телефон" required>
            </div>
            <div class="form-group">
                <?php
                if($update == true):
                    ?>
                    <button type="submit" class="btn btn-info" name="update">Обновить</button>
                <?php else: ?>
                    <button type="submit" class="btn btn-primary" name="save">Добавить</button>
                <?php endif; ?>
            </div>
        </form>
    </div>
	<?php
					}
	?>
</div>
</body>
</html>