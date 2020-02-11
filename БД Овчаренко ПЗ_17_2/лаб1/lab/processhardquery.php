<?php

session_start();

$mysqli = new mysqli('localhost', 'root', '', 'ordersbd') or die(mysqli_error($mysqli));