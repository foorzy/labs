<!DOCTYPE html>
<html>
    <head>
        <title>Общий вывод</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processoutput.php'; ?>
        
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
                    <div class="light" style="background-color: #e3f2fd;">
                        <ul class="nav nav-pills nav-fill">
                            <li class="nav-item">
                                <a class="nav-link active" href="index.php#">Главная</a>
                            </li>
                        </ul>
                    </div>
                    <div class="light p-5" style="background-color: #e3f2fd;">
                    <ul class="nav nav-pills nav-fill">
                        <li class="nav-item">
                            <a class="nav-link" href="output.php#">Общий вывод</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="customers.php#">Продукты</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="products.php#">Клиенты</a>
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
                        <p class="mb-0">Мы можем выбрать, что делать. Мы свободны в своем выборе. Но нужно помнить: последствия этого выбора уже не будут от нас зависеть.</p>
                        <footer class="blockquote-footer">Стивен Р. Кови<cite title="Source Title"></cite></footer>
                    </blockquote>
                </div>
            </div>
            <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </nav>
        </div>
        <?php
        $mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));
        $resultcustomers = $mysqli->query("SELECT * FROM customers ORDER BY customer_code ASC") or die($mysqli->error);
        $resultproducts = $mysqli->query("SELECT * FROM products ORDER BY product_code ASC") or die($mysqli->error);
        $resultdeals = $mysqli->query("SELECT * FROM deals ORDER BY customer_code ASC") or die($mysqli->error);
        ?>
        <div class="row justify-content-center">
        <h1>Welcome to the main page!</h1>
        </div>
    </div>
    </body>
</html>