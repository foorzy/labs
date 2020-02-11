<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'qualification') or die(mysqli_error($mysqli));