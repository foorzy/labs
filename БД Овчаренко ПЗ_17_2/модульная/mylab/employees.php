<!DOCTYPE html>
<html>
    <head>
        <title>Продавцы</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processemployees.php'; ?>
        
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
                    <a class="nav-link active" href="employees.php#">Рабочие</a>
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
			$search_levels_result = $mysqli->query("SELECT * FROM levels ORDER BY level_id ASC") or die($mysqli->error);
			$result = $mysqli->query("SELECT * FROM employees ORDER BY ID ASC") or die($mysqli->error);
        ?>
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
					
					<?php
						}
					?>
                    </tr>
                </thead>
        <?php
            while ($row = $result->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['ID']; ?></td>
                    <td><?php echo $row['FName']; ?></td>
                    <td><?php echo $row['MName']; ?></td>
                    <td><?php echo $row['LName']; ?></td>
                    <td><?php echo $row['Post']; ?></td>
                    <td><?php echo $row['Salary']; ?></td>
					  <td><?php echo $row['PriorSalary']; ?></td>
					<?php 
					if(($userdata['user_level'] == 2))
					{
					?>
                    <td>
                        <a href="employees.php?edit=<?php echo $row['ID']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processemployees.php?delete=<?php echo $row['ID']; ?>"
                           class="btn btn-danger">Удалить</a>   
                    </td>
					<?php
					}
					else if(($userdata['user_level'] == 1))
					{
					?>
					<?php
					}
					?>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
		<?php 
					if(($userdata['user_level'] == 2))
					{
					?>
        <div class="row justify-content-center">
            <form action="processemployees.php" method="POST">
            <div class="d-none">
            <input type="text" name="ID" class="form-" 
                   value="<?php echo $ID; ?>" >
            </div>
            <div class="form-group">
                <label>Фамилия</label>
                <input type="text" name="FName" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $FName; ?>" placeholder="Введите фамилию" required>
            </div>
			<div class="form-group">
                <label>Имя</label>
                <input type="text" name="MName" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $MName; ?>" placeholder="Введите имя" required>
            </div>
			<div class="form-group">
                <label>Отчество</label>
                <input type="text" name="LName" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $LName; ?>" placeholder="Введите отчество" required>
            </div>
			<div class="form-group">
                <label>Должность</label>
                <input type="text" name="Post" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                       value="<?php echo $Post; ?>" placeholder="Введите Должность" required>
            </div>
			<div class="form-group">
                <label>Зарплата</label>
                <input type="text" name="Salary" class="form-control" pattern="[0-9]{1,}$"
                       value="<?php echo $Salary; ?>" placeholder="Введите зарплату" required>
            </div>
			<div class="form-group">
                <label>Премия</label>
                <input type="text" name="PriorSalary" class="form-control" pattern="[0-9]{1,}$"
                       value="<?php echo $PriorSalary; ?>" placeholder="Введите премию" required>
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