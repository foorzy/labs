<!DOCTYPE html>
<html>
    <head>
        <title>Преподаватели</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processteachers.php'; ?>
        
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
                            <a class="nav-link active" href="teachers.php#">Преподаватели</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="workload.php#">Рабочая нагрузка</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="hardquery.php#">Сложные запросы</a>
                        </li>
                    </ul>
                    <p></p>
                    <blockquote class="blockquote text-right">
                        <p class="mb-0">Ни один человек не выбирает зло, потому что это зло, он лишь ошибочно принимает его за счастье и добро, к которому он стремится.</p>
                        <footer class="blockquote-footer">Мэри Уолстонкрафт Шелли</footer>
                    </blockquote>
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
            $mysqli = new mysqli('localhost', 'root', '', 'qualification') or die(mysqli_error($mysqli));
            $result = $mysqli->query("SELECT * FROM teachers ORDER BY code_teacher ASC") or die($mysqli->error);
        ?>
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
                        <th colspan="2">Действия</th>
                    </tr>
                </thead>
        <?php
            while ($row = $result->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['code_teacher']; ?></td>
                    <td><?php echo $row['surname']; ?></td>
                    <td><?php echo $row['name']; ?></td>
                    <td><?php echo $row['patronymic']; ?></td>
                    <td><?php echo $row['phone']; ?></td>
                    <td><?php echo $row['experience']; ?></td>
                    <td>
                        <a href="teachers.php?edit=<?php echo $row['id']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processteachers.php?delete=<?php echo $row['id']; ?>"
                           class="btn btn-danger">Удалить</a>   
                    </td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>

        <div class="row justify-content-center">
            <form action="processteachers.php" method="POST">
            <div class="d-none">
            <input type="text" name="id" class="form-" 
                   value="<?php echo $id; ?>" >
            </div>
            <div class="form-group">
            <label>Номер преподавателя</label>
            <input type="text" name="code_teacher" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $code_teacher; ?>" placeholder="Введите номер преподавателя" required>
            </div>
            <div class="form-group">
            <label>Фамилия</label>
            <input type="text" name="surname" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                   value="<?php echo $surname; ?>" placeholder="Введите фамилию" required>
            </div>
            <div class="form-group">
            <label>Имя</label>
            <input type="text" name="name" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                   value="<?php echo $name; ?>" placeholder="Введите имя" required>
            </div>
            <div class="form-group">
            <label>Отчество</label>
            <input type="text" name="patronymic" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                   value="<?php echo $patronymic; ?>" placeholder="Введите отчество" required>
            </div>
            <div class="form-group">
            <label>Телефон</label>
            <input type="tel" name="phone" class="form-control" pattern="[0-9]{6,}$"
                   value="<?php echo $phone; ?>" placeholder="Введите телефон" required>
                <small id="name" class="form-text text-muted">Например: 0996663355</small>
            </div>
            <div class="form-group">
            <label>Опыт работы</label>
            <input type="text" name="experience" class="form-control" pattern="[0-9]{1,2}$"
                   value="<?php echo $experience; ?>" placeholder="Введите стаж работы" required>
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