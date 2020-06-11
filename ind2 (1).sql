-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Июн 11 2020 г., 12:56
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `ind2`
--

-- --------------------------------------------------------

--
-- Структура таблицы `group`
--

CREATE TABLE IF NOT EXISTS `group` (
  `idgr` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `numgr` varchar(10) NOT NULL,
  `numstud` int(4) NOT NULL,
  `headman` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idgr`,`headman`),
  UNIQUE KEY `id` (`idgr`),
  KEY `id_2` (`idgr`),
  KEY `headman` (`headman`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Дамп данных таблицы `group`
--

INSERT INTO `group` (`idgr`, `numgr`, `numstud`, `headman`) VALUES
(6, '19', 19, 10),
(7, '18', 18, 9),
(8, '22', 22, 8);

-- --------------------------------------------------------

--
-- Структура таблицы `numpar`
--

CREATE TABLE IF NOT EXISTS `numpar` (
  `numpar` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `начало` varchar(10) NOT NULL,
  `конец` varchar(10) NOT NULL,
  PRIMARY KEY (`numpar`),
  UNIQUE KEY `numpar` (`numpar`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Дамп данных таблицы `numpar`
--

INSERT INTO `numpar` (`numpar`, `начало`, `конец`) VALUES
(1, '8.00', '9.30'),
(2, '9.40', '11.10'),
(3, '11.30', '13.00'),
(4, '13.10', '14.40'),
(5, '15.00', '16.30'),
(6, '16.40', '18.10');

-- --------------------------------------------------------

--
-- Структура таблицы `person`
--

CREATE TABLE IF NOT EXISTS `person` (
  `idperson` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `fio` varchar(50) NOT NULL,
  PRIMARY KEY (`idperson`),
  UNIQUE KEY `idperson` (`idperson`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=18 ;

--
-- Дамп данных таблицы `person`
--

INSERT INTO `person` (`idperson`, `fio`) VALUES
(10, 'Иванов Иван Иванович'),
(11, 'Петров Петр Петрович'),
(12, 'Алексеев Алексей Алексеевич'),
(13, 'Барановский Артем Феликсович'),
(14, 'Касатый Осип Еремеевич'),
(15, 'Клоков Владилен Капитонович'),
(16, 'Голубов Евдоким Капитонович'),
(17, 'Лавров Юлиан Сидорович');

-- --------------------------------------------------------

--
-- Структура таблицы `schedule`
--

CREATE TABLE IF NOT EXISTS `schedule` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `idrg` int(11) unsigned NOT NULL,
  `idteach` int(11) unsigned NOT NULL,
  `idsubject` int(11) unsigned NOT NULL,
  `iday` int(11) unsigned NOT NULL,
  `numpar` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `iday` (`iday`),
  KEY `idteach` (`idteach`),
  KEY `idrg` (`idrg`),
  KEY `idsubject` (`idsubject`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=18 ;

--
-- Дамп данных таблицы `schedule`
--

INSERT INTO `schedule` (`id`, `idrg`, `idteach`, `idsubject`, `iday`, `numpar`) VALUES
(11, 6, 5, 3, 1, 3),
(12, 6, 5, 3, 4, 4),
(13, 6, 6, 1, 3, 2),
(14, 6, 7, 2, 1, 5),
(15, 7, 5, 3, 2, 2),
(16, 7, 5, 3, 5, 2),
(17, 7, 7, 2, 4, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `student`
--

CREATE TABLE IF NOT EXISTS `student` (
  `idstudent` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `idperson` int(11) unsigned NOT NULL,
  `idgroup` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idstudent`),
  UNIQUE KEY `idstudent` (`idstudent`),
  KEY `idperson` (`idperson`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 AUTO_INCREMENT=11 ;

--
-- Дамп данных таблицы `student`
--

INSERT INTO `student` (`idstudent`, `idperson`, `idgroup`) VALUES
(6, 13, 7),
(7, 14, 8),
(8, 15, 8),
(9, 16, 7),
(10, 17, 6);

-- --------------------------------------------------------

--
-- Структура таблицы `subject`
--

CREATE TABLE IF NOT EXISTS `subject` (
  `idsubject` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `subj` varchar(50) NOT NULL,
  PRIMARY KEY (`idsubject`),
  UNIQUE KEY `id` (`idsubject`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Дамп данных таблицы `subject`
--

INSERT INTO `subject` (`idsubject`, `subj`) VALUES
(1, 'Програмирование'),
(2, 'История'),
(3, 'Физ-ра'),
(4, 'Конcтруирование ');

-- --------------------------------------------------------

--
-- Структура таблицы `teacher`
--

CREATE TABLE IF NOT EXISTS `teacher` (
  `idteach` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `department` text NOT NULL,
  `position` text NOT NULL,
  `idperson` int(11) unsigned NOT NULL,
  PRIMARY KEY (`idteach`,`idperson`),
  UNIQUE KEY `id` (`idteach`),
  KEY `idperson` (`idperson`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Дамп данных таблицы `teacher`
--

INSERT INTO `teacher` (`idteach`, `department`, `position`, `idperson`) VALUES
(5, 'СКЛКН', 'Чувак', 10),
(6, 'СКЛКН', 'Чувак', 11),
(7, 'СКЛКН', 'Чувак', 12);

-- --------------------------------------------------------

--
-- Структура таблицы `week`
--

CREATE TABLE IF NOT EXISTS `week` (
  `iday` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `day` varchar(13) NOT NULL,
  PRIMARY KEY (`iday`),
  UNIQUE KEY `id` (`iday`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Дамп данных таблицы `week`
--

INSERT INTO `week` (`iday`, `day`) VALUES
(1, 'Понедельник'),
(2, 'Вторник'),
(3, 'Среда'),
(4, 'Четверг'),
(5, 'Пятница'),
(6, 'Суббота');

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `group`
--
ALTER TABLE `group`
  ADD CONSTRAINT `group_ibfk_1` FOREIGN KEY (`headman`) REFERENCES `student` (`idstudent`);

--
-- Ограничения внешнего ключа таблицы `schedule`
--
ALTER TABLE `schedule`
  ADD CONSTRAINT `schedule_ibfk_4` FOREIGN KEY (`iday`) REFERENCES `week` (`iday`),
  ADD CONSTRAINT `schedule_ibfk_6` FOREIGN KEY (`idteach`) REFERENCES `teacher` (`idteach`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `schedule_ibfk_7` FOREIGN KEY (`idrg`) REFERENCES `group` (`idgr`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `schedule_ibfk_8` FOREIGN KEY (`idsubject`) REFERENCES `subject` (`idsubject`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`idperson`) REFERENCES `person` (`idperson`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `teacher`
--
ALTER TABLE `teacher`
  ADD CONSTRAINT `teacher_ibfk_1` FOREIGN KEY (`idperson`) REFERENCES `person` (`idperson`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
