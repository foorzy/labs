<!DOCTYPE html>
<html>
    <head>
        <title>Клиенты</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processcustomers.php'; ?>
        
        <?php 
        
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
        <div class="light" style="background-color: #CCFFFF;">
            <ul class="nav nav-pills nav-fill">
                <li class="nav-item">
                    <a class="nav-link" href="index.php#">Главная</a>
                </li>
            </ul>
        </div>
        <div class="light p-5" style="background-color: #CCFFFF;">
            <ul class="nav nav-pills nav-fill">
                <li class="nav-item">
                    <a class="nav-link" href="output.php#">Общий вывод</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="customers.php#">Клиенты</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="products.php#">Продукты</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="deals.php#">Заказы</a>
                </li>
				<li class="nav-item">
                            <a class="nav-link" href="hardquery.php#">Сложные запросы</a>
                        </li>
            </ul>
            <p></p>
            <blockquote class="blockquote text-right">
                <p class="mb-0">Никогда не ищи сложных путей там, где есть простая дорога.</p>
                <footer class="blockquote-footer">Эрих Мария Ремарк<cite title="Source Title"></cite></footer>
            </blockquote>
        </div>
    </div>
    <nav class="navbar navbar-light" style="background-color: #CCFFFF;">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </nav>
</div>
        <div class="container">
		
        <?php 
            $mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));
            $result = $mysqli->query("SELECT * FROM customers") or die($mysqli->error);
        ?>
        <div class="row justify-content-center">
            <table class="table">
                <thead>
                    <tr>
                        <th>Код клиента</th>
                        <th>Название</th>
                        <th>Адрес</th>
                        <th>Телефон</th>
                        <th>Контактное лицо</th>
                        <th colspan="2">Действия</th>
                    </tr>
                </thead>
        <?php 
            while ($row = $result->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['customer_code']; ?></td>
                    <td><?php echo $row['name']; ?></td>
                    <td><?php echo $row['address']; ?></td>
                    <td><?php echo $row['phone_number']; ?></td>
                    <td><?php echo $row['person']; ?></td>
                    <td>
                        <a href="customers.php?edit=<?php echo $row['id']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processcustomers.php?delete=<?php echo $row['id']; ?>"
                           class="btn btn-danger">Удалить</a>   
                    </td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
        
        <div class="row justify-content-center">
            <form action="processcustomers.php" method="POST">
            <div class="d-none">
            <input type="text" name="id" class="form-" 
                   value="<?php echo $id; ?>" >
            </div>
            <div class="form-group">
            <label>Код клиента</label>
            <input type="text" name="customer_code" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $customer_code; ?>" placeholder="Введите номер клиента"required>
            </div>
            <div class="form-group">
            <label>Название</label>
            <input type="text" name="name" class="form-control" pattern="[A-Za-zА-Яа-я, ,0-9]{1,}$"
                   value="<?php echo $name; ?>" placeholder="Введите название"required>
            </div>
            <div class="form-group">
            <label>Адрес</label>
            <input type="text" name="address" class="form-control" pattern="[A-Za-zА-Яа-я+-, ,0-9]{1,}$"
                   value="<?php echo $address; ?>" placeholder="Введите адрес"required>
            </div>
            <div class="form-group">
            <label>Телефон</label>
            <input type="text" name="phone_number" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $phone_number; ?>" placeholder="Введите номер телефона"required>
            </div>
            <div class="form-group">
            <label>Контактное лицо</label>
            <input type="text" name="person" class="form-control" pattern="[A-Za-zА-Яа-я, ]{1,}$"
                   value="<?php echo $person; ?>" placeholder="Введите контактное лицо"required>
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
    </div>
    </body>
</html>