<!DOCTYPE html>
<html>
    <head>
        <title>Рабочая нагрузка</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
    </head>
    <body>
        <?php require_once 'processworkload.php'; ?>
        
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
                        <a class="nav-link" href="teachers.php#">Преподаватели</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="workload.php#">Рабочая нагрузка</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="hardquery.php#">Сложные запросы</a>
                    </li>
                </ul>
                    <p></p>
                    <blockquote class="blockquote text-right">
                        <p class="mb-0">Ничто так не изнуряет как нерешительность, и ничто так не бесполезно.</p>
                        <footer class="blockquote-footer">Бертран Рассел<cite title="Source Title">Source Title</cite></footer>
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
            $result = $mysqli->query("SELECT * FROM workload ORDER BY code_teacher ASC") or die($mysqli->error);
            $search_teacher_result = $mysqli->query("SELECT * FROM teachers ORDER BY code_teacher ASC") or die($mysqli->error);
            $search_group_result = $mysqli->query("SELECT * FROM groups ORDER BY code_group ASC") or die($mysqli->error);
        ?>
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
                        <th colspan="2">Действия</th>
                    </tr>
                </thead>
        <?php 
            while ($row = $result->fetch_assoc()): ?>
                <tr>
                    <td><?php echo $row['code_teacher']; ?></td>
                    <td><?php echo $row['code_group']; ?></td>
                    <td><?php echo $row['amounthours']; ?></td>
                    <td><?php echo $row['lesson']; ?></td>
                    <td><?php echo $row['lessontype']; ?></td>
                    <td><?php echo $row['pay']; ?></td>
                    <td>
                        <a href="workload.php?edit=<?php echo $row['id']; ?>"
                           class="btn btn-info">Изменить</a>
                        <a href="processworkload.php?delete=<?php echo $row['id']; ?>"
                           class="btn btn-danger">Удалить</a>   
                    </td>
                </tr>
            <?php endwhile; ?>
            </table>
        </div>
        
        <div class="row justify-content-center">
            <form action="processworkload.php" method="POST">
                <div class="d-none">
            <input type="text" name="id" class="form-" 
                   value="<?php echo $id; ?>">
            </div>
            <div class="form-group">
                <label>Выберите преподавателя</label>
                <select class="form-control" id="exampleFormControlSelect1" name = code_teacher>
                  <?php while ($row = $search_teacher_result->fetch_assoc()): ?>
                      <?php if ($code_teacher == $row['code_teacher']): ?>
                          <option selected><?php echo $row['code_teacher'];?></option>
                      <?php else: ?>
                          <option><?php echo $row['code_teacher']; ?></option>
                      <?php endif; ?>
                  <?php endwhile; ?>
                </select>
            </div>
            <div class="form-group">
                <label>Выберите группу</label>
                <select class="form-control" id="exampleFormControlSelect1" name = code_group>
                  <?php while ($row = $search_group_result->fetch_assoc()): ?>
                      <?php if ($code_group == $row['code_group']): ?>
                          <option selected><?php echo $row['code_group'];?></option>
                      <?php else: ?>
                          <option><?php echo $row['code_group']; ?></option>
                      <?php endif; ?>
                  <?php endwhile; ?>
                </select>
            </div>
            <div class="form-group">
            <label>Количество часов</label>
            <input type="text" name="amounthours" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $amounthours; ?>" placeholder="Введите количество часов" required>
            </div>
            <div class="form-group">
            <label>Предмет</label>
            <input type="text" name="lesson" class="form-control" pattern="[A-Za-zА-Яа-я, ,+-]{1,}$"
                   value="<?php echo $lesson; ?>" placeholder="Введите название предмета" required>
            </div>
            <div class="form-group">
            <label>Тип занятия</label>
            <input type="text" name="lessontype" class="form-control" pattern="[A-Za-zА-Яа-я, ,]{1,}$"
                   value="<?php echo $lessontype; ?>" placeholder="Введите тип занятия" required>
            </div>
            <div class="form-group">
            <label>Оплата</label>
            <input type="text" name="pay" class="form-control" pattern="[0-9]{1,}$"
                   value="<?php echo $pay; ?>" placeholder="Введите оплату за час" required>
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