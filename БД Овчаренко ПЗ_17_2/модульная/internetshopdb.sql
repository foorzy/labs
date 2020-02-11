-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Май 28 2019 г., 01:25
-- Версия сервера: 10.1.38-MariaDB
-- Версия PHP: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `internetshopdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `employees`
--

CREATE TABLE `employees` (
  `ID` int(11) NOT NULL,
  `FName` varchar(20) NOT NULL,
  `MName` varchar(20) DEFAULT NULL,
  `LName` varchar(20) NOT NULL,
  `Post` varchar(25) NOT NULL,
  `Salary` int(11) NOT NULL,
  `PriorSalary` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employees`
--

INSERT INTO `employees` (`ID`, `FName`, `MName`, `LName`, `Post`, `Salary`, `PriorSalary`) VALUES
(4, 'Ð‘Ð°Ð³Ð°Ñ‚Ñ‹Ñ€', 'ÐÐ½Ð´Ñ€ÐµÐ¹', 'Ð‘Ð¾Ð³Ð´Ð°Ð½Ð¾Ð²Ð¸Ñ‡', 'ÐŸÑ€Ð¾Ð´Ð°Ð²ÐµÑ†', 4000, 400),
(5, 'Ð”ÑƒÐ½Ð°Ð¹Ñ‡ÑƒÐº', 'ÐœÐ°Ñ€Ðº', 'ÐžÐ»ÐµÐ³Ð¾Ð²Ð¸Ñ‡', 'ÐŸÑ€Ð¾Ð´Ð°Ð²ÐµÑ†', 5000, 499),
(6, 'ÐŸÐµÑ‚Ñ€Ð¾Ð²', 'ÐŸÐµÑ‚Ñ€', 'ÐŸÐµÑ‚Ñ€Ð¾Ð²Ð¸Ñ‡', 'ÐœÐµÐ½ÐµÐ´Ð¶ÐµÑ€', 6000, 800);

-- --------------------------------------------------------

--
-- Структура таблицы `employeesinfo`
--

CREATE TABLE `employeesinfo` (
  `ID` int(11) NOT NULL,
  `MaritalStatus` varchar(20) NOT NULL,
  `BirthDate` date NOT NULL,
  `Address` varchar(50) NOT NULL,
  `Phone` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `employeesinfo`
--

INSERT INTO `employeesinfo` (`ID`, `MaritalStatus`, `BirthDate`, `Address`, `Phone`) VALUES
(4, 'ÐÐµ Ð¶ÐµÐ½Ð°Ñ‚', '1999-01-13', 'ÐœÐµÑ‚Ð°Ð»ÑƒÑ€Ð³Ð¾Ð²', '858723'),
(5, 'Ð–ÐµÐ½Ð°Ñ‚', '2000-04-04', 'ÐšÐ²Ð°Ñ€Ñ‚Ð°Ð»', '7658492'),
(6, 'ÐÐµ Ð¶ÐµÐ½Ð°Ñ‚', '2000-06-09', 'ÐšÐ¾ÑÐ¸Ð¾Ñ€Ð°', '8382893355');

-- --------------------------------------------------------

--
-- Структура таблицы `levels`
--

CREATE TABLE `levels` (
  `level_id` int(10) NOT NULL,
  `level` int(10) NOT NULL,
  `levelname` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `levels`
--

INSERT INTO `levels` (`level_id`, `level`, `levelname`) VALUES
(2, 0, 'user'),
(3, 1, 'manager'),
(4, 2, 'admin');

-- --------------------------------------------------------

--
-- Структура таблицы `orderdetails`
--

CREATE TABLE `orderdetails` (
  `OrderID` int(11) NOT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `Qty` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `TotalPrice` int(11) AS (Qty*Price) VIRTUAL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `orderdetails`
--

INSERT INTO `orderdetails` (`OrderID`, `ProductID`, `Qty`, `Price`) VALUES
(14, 3, 3, 15000),
(15, 4, 5, 10000),
(16, 3, 223, 15000),
(17, 6, 213, 10000);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `ID` int(11) NOT NULL,
  `CustomerID` int(11) DEFAULT NULL,
  `EmployeeID` int(11) DEFAULT NULL,
  `OrderDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`ID`, `CustomerID`, `EmployeeID`, `OrderDate`) VALUES
(14, 26, 5, '2019-05-22 00:00:00'),
(15, 26, 4, '2019-05-23 00:00:00'),
(16, 26, 6, '2019-05-08 00:00:00'),
(17, 30, 5, '2019-05-03 00:00:00'),
(18, 29, 6, '2019-05-01 00:00:00');

-- --------------------------------------------------------

--
-- Структура таблицы `productdetails`
--

CREATE TABLE `productdetails` (
  `ID` int(11) NOT NULL,
  `Color` char(20) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `productdetails`
--

INSERT INTO `productdetails` (`ID`, `Color`, `Description`) VALUES
(2, 'White', 'Samiy tverdiy'),
(4, 'Serebro', 'Kachestvennie'),
(6, 'Belie', 'Ochen\' prochnie');

-- --------------------------------------------------------

--
-- Структура таблицы `products`
--

CREATE TABLE `products` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `products`
--

INSERT INTO `products` (`ID`, `Name`) VALUES
(2, 'Cement'),
(3, 'Doski'),
(4, 'Wurupi'),
(5, 'Webenka'),
(6, 'Perchatki');

-- --------------------------------------------------------

--
-- Структура таблицы `stocks`
--

CREATE TABLE `stocks` (
  `ProductID` int(11) NOT NULL,
  `Qty` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `stocks`
--

INSERT INTO `stocks` (`ProductID`, `Qty`) VALUES
(2, 10),
(3, 489),
(5, 5),
(6, 523);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `user_id` int(10) NOT NULL,
  `user_login` varchar(30) NOT NULL,
  `user_password` varchar(32) NOT NULL,
  `user_hash` varchar(32) NOT NULL DEFAULT '',
  `user_level` int(10) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`user_id`, `user_login`, `user_password`, `user_hash`, `user_level`) VALUES
(23, 'manager', 'd1d16c28c7674cfc5e269dbe1209f552', 'f81b4833f6129f42e8f2f7b2deb7c59b', 1),
(24, 'admin', '2f7b52aacfbf6f44e13d27656ecb1f59', '895b10f09bd93ae867c136f48e12665a', 2),
(26, 'user', '4e3da2ae832730d1abbf10611df36ea6', 'ddb96605c137062ef1eeb56efe6b5543', 0),
(29, 'check', 'ec6a6536ca304edf844d1d248a4f08dc', 'eddf9d8c3e22ba592cbeebe0be50a125', 0),
(30, 'sawa', 'ec6a6536ca304edf844d1d248a4f08dc', 'a89bdebc2bf3fbb307670682104c06be', 0),
(31, 'towa', 'ec6a6536ca304edf844d1d248a4f08dc', '08c32dfea57245dcafec987ee3e90889', 0),
(32, 'manager1', 'ec6a6536ca304edf844d1d248a4f08dc', '', 0),
(33, 'jeka', 'ec6a6536ca304edf844d1d248a4f08dc', '258d8f88100bc91625aa4a89b797d7ab', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `usersinfo`
--

CREATE TABLE `usersinfo` (
  `user_id` int(10) NOT NULL,
  `FName` varchar(20) DEFAULT NULL,
  `MName` varchar(20) DEFAULT NULL,
  `LName` varchar(20) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `Phone` char(12) DEFAULT NULL,
  `DateInSystem` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `usersinfo`
--

INSERT INTO `usersinfo` (`user_id`, `FName`, `MName`, `LName`, `Address`, `City`, `Phone`, `DateInSystem`) VALUES
(23, 'ÐŸÐµÑ€ÐµÐ¿ÐµÐ»Ð¸Ñ†Ð°', 'Ð‘Ñ€Ð°Ð´ÐµÐ½Ð±ÑƒÑ€Ð³', 'Ð®Ñ€ÑŒÐµÐ²Ð¸Ñ‡', 'Ð¢Ð¾Ð¿Ð¾Ð»ÑŒ', 'Ð”Ð½ÐµÐ¿Ñ€', '753932932', '2019-05-02 00:00:00'),
(24, 'Ð‘Ð¾Ð½Ð´Ð°Ñ€ÐµÐ½ÐºÐ¾', 'Ð‘Ð¾Ð³Ð´Ð°Ð½', 'Ð Ð¾Ð¼Ð°Ð½Ð¾Ð²Ð¸Ñ‡', 'ÐšÐ¾ÑÐ¸Ð¾Ñ€Ð°', 'Ð”Ð½ÐµÐ¿Ñ€', '675630268', '2018-11-30 00:00:00'),
(26, 'Ñ†Ñ„Ð²', 'Ñ„Ñ†Ð²', 'Ñ„Ñ†Ð²', 'Ñ„Ñ†Ð²', 'Ñ„Ñ†Ð²', '123123', '2019-05-28 00:00:00');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `employeesinfo`
--
ALTER TABLE `employeesinfo`
  ADD UNIQUE KEY `ID` (`ID`);

--
-- Индексы таблицы `levels`
--
ALTER TABLE `levels`
  ADD PRIMARY KEY (`level_id`),
  ADD KEY `level` (`level`);

--
-- Индексы таблицы `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD KEY `OrderID` (`OrderID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `orders_ibfk_2` (`EmployeeID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- Индексы таблицы `productdetails`
--
ALTER TABLE `productdetails`
  ADD UNIQUE KEY `ID` (`ID`);

--
-- Индексы таблицы `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `stocks`
--
ALTER TABLE `stocks`
  ADD UNIQUE KEY `ProductID` (`ProductID`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `user_login` (`user_login`),
  ADD KEY `user_level` (`user_level`);

--
-- Индексы таблицы `usersinfo`
--
ALTER TABLE `usersinfo`
  ADD UNIQUE KEY `user_id_2` (`user_id`),
  ADD KEY `user_id` (`user_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `employees`
--
ALTER TABLE `employees`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `levels`
--
ALTER TABLE `levels`
  MODIFY `level_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT для таблицы `products`
--
ALTER TABLE `products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `employeesinfo`
--
ALTER TABLE `employeesinfo`
  ADD CONSTRAINT `employeesinfo_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `employees` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `orderdetails_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `orderdetails_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`CustomerID`) REFERENCES `users` (`user_id`);

--
-- Ограничения внешнего ключа таблицы `productdetails`
--
ALTER TABLE `productdetails`
  ADD CONSTRAINT `productdetails_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `products` (`ID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `stocks`
--
ALTER TABLE `stocks`
  ADD CONSTRAINT `stocks_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`user_level`) REFERENCES `levels` (`level`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `usersinfo`
--
ALTER TABLE `usersinfo`
  ADD CONSTRAINT `usersinfo_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
