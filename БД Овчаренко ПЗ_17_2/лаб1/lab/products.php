<!DOCTYPE html>
<html>
    <head>
        <title>Credit</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processproducts.php'; ?>
        
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
        <div class="light" style="background-color: #CCFFCC;">
            <ul class="nav nav-pills nav-fill">
                <li class="nav-item">
                    <a class="nav-link" href="index.php#">Главная</a>
                </li>
            </ul>
        </div>
        <div class="light p-5" style="background-color: #CCFFCC;">
            <ul class="nav nav-pills nav-fill">
                <li class="nav-item">
                    <a class="nav-link" href="output.php#">Общий вывод</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="customers.php#">Клиенты</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="products.php#">Продукты</a>
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
    <nav class="navbar navbar-light" style="background-color: CCFFCC;">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </nav>
</div>
        <div class="container">
        <?php 
            $mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));
            $result = $mysqli->query("SELECT * FROM products") or die($mysqli->error);
        ?>
        <div class="row justify-content-center">
            <table class="table">
                <thead>
                    <tr>
                        <th>Код товара</th>
                        <th>Цена</th>
                        <th>Доставка</th>
                        <th>Описание</th>
                        <th colspan="2">Действия</th>
                    </tr>
                </thead>
        <?php 
            while ($row = $result->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['product_code']; ?></td>
                    <td><?php echo $row['price']; ?></td>
                    <td><?php echo $row['delivery']; ?></td>
                    <td><?php echo $row['info']; ?></td>
                    <td>
                        <a href="products.php?edit=<?php echo $row['id']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processproducts.php?delete=<?php echo $row['id']; ?>"
                           class="btn btn-danger">Удалить</a>   
                    </td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
        
        <div class="row justify-content-center">
            <form action="processproducts.php" method="POST">
                 <div class="d-none">
            <input type="text" name="id" class="form-" 
                   value="<?php echo $id; ?>" placeholder="Введите Код товара">
            </div>
            <div class="form-group">
            <label>Код товара</label>
            <input type="text" name="product_code" class="form-control" pattern="[0-9]{1,}$" 
                   value="<?php echo $product_code; ?>" placeholder="Введите Код товара"required> 
            </div>
            <div class="form-group">
            <label>Цена</label>
            <input type="text" name="price" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $price; ?>" placeholder="Введите цену"required>
            </div>
            <div class="form-group">
            <label>Доставка</label>
            <input type="text" name="delivery" class="form-control" pattern="[A-Za-zА-Яа-я]{1,}$"
                   value="<?php echo $delivery; ?>" placeholder="Введите да или нет"required>
            </div>
            <div class="form-group">
            <label>Описание</label>
            <input type="text" name="info" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                   value="<?php echo $info; ?>" placeholder="Введите описание"required>
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