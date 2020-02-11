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
        <?php require_once 'processindex.php'; ?>
        
        <?php
        $experience1='';
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
                    <div class="light p-2" style="background-color: #e3f2fd;">
                        <ul class="nav nav-pills nav-fill">
                            <li class="nav-item">
                                <a class="nav-link" href="index.php#">Главная</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="document.html">Документация</a>
                            </li>
                        </ul>
                    </div>
                    <div class="light p-5" style="background-color: #e3f2fd;">
                    <ul class="nav nav-pills nav-fill">
                        <li class="nav-item">
                            <a class="nav-link" href="output.php#">Общий вывод</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="groups.php#">Группы</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="teachers.php#">Преподаватели</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="workload.php#">Рабочая нагрузка</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="hardquery.php#">Сложные запросы</a>
                        </li>
                    </ul>
                        <p></p>
                    <blockquote class="blockquote text-right">
                        <p class="mb-0">Только наш выбор способен показать, что мы не ограничены только лишь нашими способностями.</p>
                        <footer class="blockquote-footer">Джоан Кэтлин Роулинг</footer>
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
        $mysqli = new mysqli('localhost', 'root', '', 'qualification') or die(mysqli_error($mysqli));
        $resultgroups = $mysqli->query("SELECT * FROM groups WHERE code_group>100 AND quantity<50 ORDER BY code_group ASC") or die($mysqli->error);
        $resultteachers = $mysqli->query("SELECT * FROM teachers WHERE surname LIKE 'Еф%' AND experience>13 AND experience<48 ORDER BY code_teacher ASC") or die($mysqli->error);
        $resultworkload = $mysqli->query("SELECT * FROM workload WHERE code_group=123 AND amounthours>30 ORDER BY code_teacher ASC") or die($mysqli->error);
        if ($_POST) {
            $experience1 = $_POST['experience'];
                $resultsearch = $mysqli->query("SELECT * FROM teachers WHERE experience>'$experience1' ORDER BY code_teacher ASC") or die($mysqli->error);
        }
        else{
            $resultsearch = $mysqli->query("SELECT * FROM teachers ORDER BY code_teacher ASC") or die($mysqli->error);
        }

        ?>
        
        <div class="container">
            <div class="row justify-content-center">
			<div class="row justify-content-center">
            <h1>Таблица групп, код которых больше 100, а количество учеников меньше 50-ти</h1>
        </div>
                <table class="table">
                    <thead>
                    <tr>
                        <th>Номер группы</th>
                        <th>Специальность</th>
                        <th>Отделение</th>
                        <th>Количество учащихся</th>
                    </tr>
                    </thead>
                    <?php
                    while ($row = $resultgroups->fetch_assoc()): ?>
                        <tr>
                            <td><?php echo $row['code_group']; ?></td>
                            <td><?php echo $row['specialty']; ?></td>
                            <td><?php echo $row['department']; ?></td>
                            <td><?php echo $row['quantity']; ?></td>
                        </tr>
                    <?php endwhile; ?>
                </table>
            </div>
        </div>
        
        <div class="container">
            <div class="row justify-content-center">
			<div class="row justify-content-center">
            <h1>Таблица преподавателей, фамилия которых начинается на ЕФ, 13<стаж работы<48 </h1>
        </div>
                <table class="table">
                    <thead>
                    <tr>
                        <th>Код преподавателя</th>
                        <th>Фамилия</th>
                        <th>Имя</th>
                        <th>Отчество</th>
                        <th>Телефон</th>
                        <th>Опыт работы</th>
                    </tr>
                    </thead>
                    <?php
                    while ($row = $resultteachers->fetch_assoc()): ?>
                        <tr>
                            <td><?php echo $row['code_teacher']; ?></td>
                            <td><?php echo $row['surname']; ?></td>
                            <td><?php echo $row['name']; ?></td>
                            <td><?php echo $row['patronymic']; ?></td>
                            <td><?php echo $row['phone']; ?></td>
                            <td><?php echo $row['experience']; ?></td>
                        </tr>
                    <?php endwhile; ?>
                </table>
            </div>
        </div>
        <div class="row justify-content-center">
            <h1>Таблица рабочей нагрузки группы с кодом 123, часов > 30</h1>
        </div>
        <div class="container">
            <div class="row justify-content-center">
                <table class="table">
                    <thead>
                    <tr>
                        <th>Код преподавателя</th>
                        <th>Код группы</th>
                        <th>Количество часов</th>
                        <th>Предмет</th>
                        <th>Тип занятия</th>
                        <th>Оплата</th>
                    </tr>
                    </thead>
                    <?php
                    while ($row = $resultworkload->fetch_assoc()): ?>
                        <tr>
                            <td><?php echo $row['code_teacher']; ?></td>
                            <td><?php echo $row['code_group']; ?></td>
                            <td><?php echo $row['amounthours']; ?></td>
                            <td><?php echo $row['lesson']; ?></td>
                            <td><?php echo $row['lessontype']; ?></td>
                            <td><?php echo $row['pay']; ?></td>
                        </tr>
                    <?php endwhile; ?>
                </table>
            </div>
        </div>
        <div class="container">
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                Фильтр по опыту работы
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
                                Таблица преподавателей, опыт которых больше чем
                                <input type="text" name="experience" class="form-control" pattern="[0-9]{1,2}$"
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
            <table class="table">
                <thead>
                <tr>
                    <th>Код преподавателя</th>
                    <th>Фамилия</th>
                    <th>Имя</th>
                    <th>Отчество</th>
                    <th>Телефон</th>
                    <th>Опыт работы</th>
                </tr>
                </thead>
                <?php
                while ($row = $resultsearch->fetch_assoc()): ?>
                    <tr>
                        <td><?php echo $row['code_teacher']; ?></td>
                        <td><?php echo $row['surname']; ?></td>
                        <td><?php echo $row['name']; ?></td>
                        <td><?php echo $row['patronymic']; ?></td>
                        <td><?php echo $row['phone']; ?></td>
                        <td><?php echo $row['experience']; ?></td>
                    </tr>
                <?php endwhile; ?>
            </table>
        </div>
    </body>
</html>