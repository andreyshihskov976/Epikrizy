-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.3.16-MariaDB - mariadb.org binary distribution
-- Операционная система:         Win64
-- HeidiSQL Версия:              11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Дамп структуры базы данных vypisnie_epikrizy
CREATE DATABASE IF NOT EXISTS `vypisnie_epikrizy` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `vypisnie_epikrizy`;

-- Дамп структуры для таблица vypisnie_epikrizy.dannye_instr_issled
CREATE TABLE IF NOT EXISTS `dannye_instr_issled` (
  `id_dannyh_instr_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_proved_instr_issled` int(11) NOT NULL,
  `id_pokazat_instr_issled` int(11) NOT NULL,
  `znachenie` varchar(30) NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  PRIMARY KEY (`id_dannyh_instr_issled`),
  KEY `id_pacienta` (`id_proved_instr_issled`),
  KEY `id_pokazat_instr_issled` (`id_pokazat_instr_issled`),
  CONSTRAINT `dannye_instr_issled_ibfk_2` FOREIGN KEY (`id_pokazat_instr_issled`) REFERENCES `pokazat_instr_issled` (`id_pokazat_instr_issled`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dannye_instr_issled_ibfk_3` FOREIGN KEY (`id_proved_instr_issled`) REFERENCES `proved_instr_issled` (`id_proved_instr_issled`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COMMENT='Данные показателей инструментальных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.dannye_instr_issled: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `dannye_instr_issled` DISABLE KEYS */;
INSERT INTO `dannye_instr_issled` (`id_dannyh_instr_issled`, `id_proved_instr_issled`, `id_pokazat_instr_issled`, `znachenie`, `commentariy`) VALUES
	(10, 6, 1, 'Синусовый', ''),
	(11, 6, 2, '85', ''),
	(12, 6, 3, 'Вертикальная', ''),
	(13, 7, 1, 'Синусовый', ''),
	(14, 7, 2, '85', ''),
	(15, 7, 3, 'Вертикальная', ''),
	(16, 8, 4, '5,6*5,3*7,2 см (объем 112 см3)', 'Структура неоднородная. В миометрии задней стенки межмышечный субмукозный узел (тип 1-2) диаметром 1,4 см. М-эхо - 5 мм. Эндоцервикс не расширен.'),
	(17, 8, 5, '', 'Анэхогенное образование с гладкой капсулой и однородным содержимым диаметром 4,5 см.'),
	(18, 8, 6, '2,0*1,5*1,6 см (объем 2,7 см3)', ''),
	(19, 9, 7, 'Воспаление аппендикса 1 ст.', ''),
	(20, 10, 1, 'Синусовый', ''),
	(21, 10, 2, '87', ''),
	(22, 10, 3, 'Вертикальная', ''),
	(23, 11, 7, 'Подозрение на воспаление аппен', '');
/*!40000 ALTER TABLE `dannye_instr_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.dannye_lab_issled
CREATE TABLE IF NOT EXISTS `dannye_lab_issled` (
  `id_dannyh_lab_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_proved_lab_issled` int(11) NOT NULL,
  `id_pokazat_lab_issled` int(11) NOT NULL,
  `znachenie` varchar(30) NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  PRIMARY KEY (`id_dannyh_lab_issled`),
  KEY `id_pacienta` (`id_proved_lab_issled`),
  KEY `id_pokazat_lab_issled` (`id_pokazat_lab_issled`),
  CONSTRAINT `dannye_lab_issled_ibfk_2` FOREIGN KEY (`id_pokazat_lab_issled`) REFERENCES `pokazat_lab_issled` (`id_pokazat_lab_issled`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dannye_lab_issled_ibfk_3` FOREIGN KEY (`id_proved_lab_issled`) REFERENCES `proved_lab_issled` (`id_proved_lab_issled`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8 COMMENT='Данные показателей лабораторных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.dannye_lab_issled: ~10 rows (приблизительно)
/*!40000 ALTER TABLE `dannye_lab_issled` DISABLE KEYS */;
INSERT INTO `dannye_lab_issled` (`id_dannyh_lab_issled`, `id_proved_lab_issled`, `id_pokazat_lab_issled`, `znachenie`, `commentariy`) VALUES
	(19, 4, 15, 'II', ''),
	(20, 4, 16, '+', ''),
	(21, 5, 15, 'II', ''),
	(22, 5, 16, '+', ''),
	(25, 8, 15, 'II', ''),
	(26, 8, 16, '+', ''),
	(29, 10, 21, '5,46', ''),
	(30, 10, 22, '159', ''),
	(31, 10, 23, '8,29', ''),
	(32, 10, 24, '0,88', ''),
	(33, 10, 25, '', ''),
	(34, 10, 26, '1', ''),
	(35, 10, 27, '0', ''),
	(36, 10, 28, '1', ''),
	(37, 10, 29, '60', ''),
	(38, 10, 30, '32', ''),
	(39, 10, 31, '6', ''),
	(40, 10, 32, '2', ''),
	(41, 11, 33, '37', ''),
	(42, 11, 34, '5,4', ''),
	(43, 11, 35, '67', ''),
	(44, 11, 36, '22', ''),
	(45, 11, 37, '14', ''),
	(46, 11, 38, '4,8', ''),
	(47, 11, 39, '50', ''),
	(48, 11, 40, '4,3', ''),
	(49, 11, 41, '140', ''),
	(50, 11, 42, '109', ''),
	(56, 13, 15, 'А(II)', ''),
	(57, 13, 16, 'Положительный', ''),
	(61, 15, 21, '5,87', ''),
	(62, 15, 22, '146', ''),
	(63, 15, 23, '8,33', ''),
	(64, 15, 24, '0,79', ''),
	(65, 15, 25, '3,10', ''),
	(66, 15, 26, '1', ''),
	(67, 15, 27, '0', ''),
	(68, 15, 28, '1', ''),
	(69, 15, 29, '59', ''),
	(70, 15, 30, '32', ''),
	(71, 15, 31, '6', ''),
	(72, 15, 32, '2', ''),
	(73, 16, 15, 'III', ''),
	(74, 16, 16, '-', ''),
	(75, 17, 21, '5.13', ''),
	(76, 17, 22, '146', ''),
	(77, 17, 23, '7.89', ''),
	(78, 17, 24, '0.99', ''),
	(79, 17, 25, '', ''),
	(80, 17, 26, '1', ''),
	(81, 17, 27, '0', ''),
	(82, 17, 28, '1', ''),
	(83, 17, 29, '57', ''),
	(84, 17, 30, '36', ''),
	(85, 17, 31, '6', ''),
	(86, 17, 32, '2', ''),
	(87, 18, 33, '36', ''),
	(88, 18, 34, '5.8', ''),
	(89, 18, 35, '58', ''),
	(90, 18, 36, '26', ''),
	(91, 18, 37, '13', ''),
	(92, 18, 38, '4.9', ''),
	(93, 18, 39, '44', ''),
	(94, 18, 40, '4.8', ''),
	(95, 18, 41, '120', ''),
	(96, 18, 42, '110', '');
/*!40000 ALTER TABLE `dannye_lab_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.diagnozy
CREATE TABLE IF NOT EXISTS `diagnozy` (
  `id_diagnoza` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL,
  PRIMARY KEY (`id_diagnoza`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник диагнозов';

-- Дамп данных таблицы vypisnie_epikrizy.diagnozy: ~7 rows (приблизительно)
/*!40000 ALTER TABLE `diagnozy` DISABLE KEYS */;
INSERT INTO `diagnozy` (`id_diagnoza`, `naimenovanie`) VALUES
	(1, 'Аппендицит'),
	(2, 'Язва желудка'),
	(5, 'Гастрит'),
	(7, 'Аномальное маточное кровотечение'),
	(8, 'Субмукозная миома матки'),
	(9, 'Киста левого ячника'),
	(10, 'ИБС'),
	(11, 'Артериальная гипертензия');
/*!40000 ALTER TABLE `diagnozy` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.diagnozy_pacienta
CREATE TABLE IF NOT EXISTS `diagnozy_pacienta` (
  `id_diagnoza_pacienta` int(11) NOT NULL AUTO_INCREMENT,
  `id_epikriza` int(11) NOT NULL,
  `id_diagnoza` int(11) NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  `zaklucheniye` varchar(3) NOT NULL,
  PRIMARY KEY (`id_diagnoza_pacienta`),
  KEY `id_pacienta` (`id_epikriza`),
  KEY `id_diagnoza` (`id_diagnoza`),
  CONSTRAINT `diagnozy_pacienta_ibfk_2` FOREIGN KEY (`id_diagnoza`) REFERENCES `diagnozy` (`id_diagnoza`) ON UPDATE CASCADE,
  CONSTRAINT `diagnozy_pacienta_ibfk_3` FOREIGN KEY (`id_epikriza`) REFERENCES `epikrizy` (`id_epikriza`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COMMENT='Перечень диагнозов, поставленных пациенту';

-- Дамп данных таблицы vypisnie_epikrizy.diagnozy_pacienta: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `diagnozy_pacienta` DISABLE KEYS */;
INSERT INTO `diagnozy_pacienta` (`id_diagnoza_pacienta`, `id_epikriza`, `id_diagnoza`, `commentariy`, `zaklucheniye`) VALUES
	(2, 3, 1, '', 'Да'),
	(8, 4, 2, '', 'Да'),
	(9, 5, 5, 'Поверхностный гастрит 1 степени.', 'Да'),
	(10, 6, 7, '', 'Нет'),
	(11, 6, 8, '', 'Да'),
	(12, 6, 9, '', 'Да'),
	(13, 6, 10, 'Атеросклеротический и постинфарктный кардиосклероз. Артериальная гипертензия II ст. Риск 4. HIA', 'Нет'),
	(14, 5, 1, 'Воспаление аппендикса', 'Да'),
	(16, 5, 11, 'I ст. Риск 3. HIA', 'Нет'),
	(17, 4, 1, 'Воспаление аппендикса 3 ст.', 'Да'),
	(18, 4, 5, 'Поверхностный эррозивный гастрит 2 ст.', 'Да'),
	(19, 7, 10, 'атеросклеротический и постинфарктный кардиосклероз', 'Да'),
	(20, 7, 11, 'II ст. Риск 4. HIA', 'Нет'),
	(21, 7, 8, '', 'Да'),
	(22, 7, 9, '', 'Да'),
	(23, 7, 1, '', 'Да');
/*!40000 ALTER TABLE `diagnozy_pacienta` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.doljnosti
CREATE TABLE IF NOT EXISTS `doljnosti` (
  `id_doljnosti` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(150) NOT NULL,
  PRIMARY KEY (`id_doljnosti`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник должностей';

-- Дамп данных таблицы vypisnie_epikrizy.doljnosti: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `doljnosti` DISABLE KEYS */;
INSERT INTO `doljnosti` (`id_doljnosti`, `naimenovanie`) VALUES
	(1, 'Хирург'),
	(4, 'Невропатолог'),
	(5, 'Заведущий отделением'),
	(6, 'Гастороэтеролог'),
	(7, 'Терапевт'),
	(8, 'Ортопед'),
	(9, 'Офтальмолог'),
	(10, 'Гинеколог'),
	(11, 'Кардиохирург');
/*!40000 ALTER TABLE `doljnosti` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.dop_sved
CREATE TABLE IF NOT EXISTS `dop_sved` (
  `id_dop_sved` int(11) NOT NULL AUTO_INCREMENT,
  `id_epikriza` int(11) NOT NULL,
  `ad` varchar(300) DEFAULT NULL,
  `gen_anam` varchar(300) DEFAULT NULL,
  `smoking` varchar(3) DEFAULT NULL,
  `alco` varchar(3) DEFAULT NULL,
  `imt` varchar(300) DEFAULT NULL,
  `cholesterin` varchar(300) DEFAULT NULL,
  `blood` varchar(300) DEFAULT NULL,
  `urina` varchar(300) DEFAULT NULL,
  `ekg` varchar(300) DEFAULT NULL,
  `skore` varchar(300) DEFAULT NULL,
  `vgd` varchar(300) DEFAULT NULL,
  `predstat` varchar(300) DEFAULT NULL,
  `mol` varchar(300) DEFAULT NULL,
  `flura` varchar(300) DEFAULT NULL,
  `glukoza` varchar(300) DEFAULT NULL,
  `suicide` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_dop_sved`),
  KEY `id_epikriza` (`id_epikriza`),
  CONSTRAINT `dop_sved_ibfk_1` FOREIGN KEY (`id_epikriza`) REFERENCES `epikrizy` (`id_epikriza`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Дополнительные сведения эпикриза';

-- Дамп данных таблицы vypisnie_epikrizy.dop_sved: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `dop_sved` DISABLE KEYS */;
INSERT INTO `dop_sved` (`id_dop_sved`, `id_epikriza`, `ad`, `gen_anam`, `smoking`, `alco`, `imt`, `cholesterin`, `blood`, `urina`, `ekg`, `skore`, `vgd`, `predstat`, `mol`, `flura`, `glukoza`, `suicide`) VALUES
	(2, 3, '2', '3', 'Да', 'Да', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17'),
	(4, 4, '110*70', '', 'Нет', 'Нет', '', '', '', '', '', '', '', '', '', '', '', ''),
	(5, 6, '130/90 мм рт. ст.', '', 'Нет', 'Нет', '', '1,5 балла', '', '', '', '', '', '', '', '', '', '1,5 балла'),
	(6, 5, '120/68 мм рт. ст.', '', 'Да', 'Нет', '', '', '', '', '', '', '', '', '', '', '', '1,0 балла'),
	(7, 7, '120/80 мм рт. ст.', '', 'Нет', 'Нет', '', '1,8 балла', '', '', '', '', '', '', '', '', '', '1,8 балла');
/*!40000 ALTER TABLE `dop_sved` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.epikrizy
CREATE TABLE IF NOT EXISTS `epikrizy` (
  `id_epikriza` int(11) NOT NULL AUTO_INCREMENT,
  `id_pacienta` int(11) NOT NULL,
  `date_n` date NOT NULL,
  `date_k` date NOT NULL,
  `id_otdeleniya` int(11) NOT NULL,
  `sost_vypiski` varchar(300) NOT NULL,
  `lvn_n` date NOT NULL,
  `lvn_k` date NOT NULL,
  `recomendacii` varchar(300) NOT NULL,
  `lech_vrach` varchar(150) NOT NULL,
  PRIMARY KEY (`id_epikriza`),
  KEY `id_pacienta` (`id_pacienta`),
  KEY `id_otdeleniya` (`id_otdeleniya`),
  CONSTRAINT `epikrizy_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`),
  CONSTRAINT `epikrizy_ibfk_2` FOREIGN KEY (`id_otdeleniya`) REFERENCES `otdeleniya` (`id_otdeleniya`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Выписные эпикризы';

-- Дамп данных таблицы vypisnie_epikrizy.epikrizy: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `epikrizy` DISABLE KEYS */;
INSERT INTO `epikrizy` (`id_epikriza`, `id_pacienta`, `date_n`, `date_k`, `id_otdeleniya`, `sost_vypiski`, `lvn_n`, `lvn_k`, `recomendacii`, `lech_vrach`) VALUES
	(3, 1, '2020-05-27', '2020-05-28', 2, 'yuio', '2020-05-29', '2020-05-30', 'etrh', 'Синенок Ангелина Олеговна'),
	(4, 2, '2020-05-27', '2020-05-30', 4, 'rdf', '2020-05-31', '2020-06-01', 'rsdf', 'Шишков Андрей Алексеевич'),
	(5, 2, '2020-06-01', '2020-06-05', 4, 'Удовлетворительном состоянии', '2020-06-06', '2020-06-07', 'Пройти повторное обследование через 12 месяцев. Принимать Омепразол раз в день в течении 2 месяцев.', 'Шишков Андрей Алексеевич'),
	(6, 8, '2020-06-25', '2020-06-30', 10, 'Удовлетворительном', '2020-07-25', '2020-07-30', 'Явка за гистологическим ответом через 14 дней', 'Зубов Иван Федорович'),
	(7, 10, '2020-04-25', '2020-04-30', 10, 'Удовлетворительном', '2020-05-01', '2020-05-06', 'Нет рекомендаций', 'Павленко Павел Андреевич');
/*!40000 ALTER TABLE `epikrizy` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.gcgp
CREATE TABLE IF NOT EXISTS `gcgp` (
  `id_gcgp` int(11) NOT NULL AUTO_INCREMENT,
  `nom_filiala` varchar(12) NOT NULL DEFAULT '',
  `adress` varchar(150) NOT NULL,
  PRIMARY KEY (`id_gcgp`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Справочник ГЦГП';

-- Дамп данных таблицы vypisnie_epikrizy.gcgp: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `gcgp` DISABLE KEYS */;
INSERT INTO `gcgp` (`id_gcgp`, `nom_filiala`, `adress`) VALUES
	(1, 'Филиал № 9  ', 'ул. Клермон-Ферран, 4'),
	(4, 'Филиал № 1 ', 'ул. Гагарина, 13'),
	(5, 'Филиал № 8  ', 'ул. Советская 4'),
	(6, 'Филиал № 7  ', 'ул. Партизанская 14'),
	(7, 'Филиал № 6  ', 'ул. Мазурова 34'),
	(8, 'Филиал № 5  ', 'ул. Головацского 76'),
	(9, 'Филиал № 4  ', 'ул. Интернациолнальная 10'),
	(10, 'Филиал № 3  ', 'ул. Притыцкого 14'),
	(11, 'Филиал № 2  ', 'ул. Гомельская 28');
/*!40000 ALTER TABLE `gcgp` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.instr_issledovaniya
CREATE TABLE IF NOT EXISTS `instr_issledovaniya` (
  `id_instr_issledovaniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_instr_issledovaniya`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник инструментальных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.instr_issledovaniya: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `instr_issledovaniya` DISABLE KEYS */;
INSERT INTO `instr_issledovaniya` (`id_instr_issledovaniya`, `naimenovanie`) VALUES
	(1, 'ЭКГ'),
	(3, 'Эхоскопия малого таза'),
	(4, 'Узи брюшной области');
/*!40000 ALTER TABLE `instr_issledovaniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.instr_otdeleniya
CREATE TABLE IF NOT EXISTS `instr_otdeleniya` (
  `id_instr_otdeleniya` int(11) NOT NULL AUTO_INCREMENT,
  `id_otdeleniya` int(11) NOT NULL,
  `id_instr_issledovaniya` int(11) NOT NULL,
  PRIMARY KEY (`id_instr_otdeleniya`),
  KEY `id_otdeleniya` (`id_otdeleniya`),
  KEY `id_instr_issledovaniya` (`id_instr_issledovaniya`),
  CONSTRAINT `instr_otdeleniya_ibfk_1` FOREIGN KEY (`id_instr_issledovaniya`) REFERENCES `instr_issledovaniya` (`id_instr_issledovaniya`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `instr_otdeleniya_ibfk_2` FOREIGN KEY (`id_otdeleniya`) REFERENCES `otdeleniya` (`id_otdeleniya`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='Перечень инстр-ных исследований, проводимых отделением';

-- Дамп данных таблицы vypisnie_epikrizy.instr_otdeleniya: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `instr_otdeleniya` DISABLE KEYS */;
INSERT INTO `instr_otdeleniya` (`id_instr_otdeleniya`, `id_otdeleniya`, `id_instr_issledovaniya`) VALUES
	(1, 2, 1),
	(2, 4, 1),
	(3, 10, 1),
	(4, 11, 1),
	(5, 12, 1),
	(6, 13, 1),
	(7, 10, 3),
	(8, 2, 4),
	(9, 4, 4),
	(10, 13, 4);
/*!40000 ALTER TABLE `instr_otdeleniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.lab_issledovaniya
CREATE TABLE IF NOT EXISTS `lab_issledovaniya` (
  `id_lab_issledovaniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL,
  PRIMARY KEY (`id_lab_issledovaniya`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 COMMENT='Справочник лабораторных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.lab_issledovaniya: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `lab_issledovaniya` DISABLE KEYS */;
INSERT INTO `lab_issledovaniya` (`id_lab_issledovaniya`, `naimenovanie`) VALUES
	(18, 'Группа крови'),
	(21, 'ОАК'),
	(22, 'БАК');
/*!40000 ALTER TABLE `lab_issledovaniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.lab_otdeleniya
CREATE TABLE IF NOT EXISTS `lab_otdeleniya` (
  `id_lab_otdeleniya` int(11) NOT NULL AUTO_INCREMENT,
  `id_otdeleniya` int(11) NOT NULL,
  `id_lab_issledovaniya` int(11) NOT NULL,
  PRIMARY KEY (`id_lab_otdeleniya`),
  KEY `id_otdeleniya` (`id_otdeleniya`),
  KEY `id_lab_issledovaniya` (`id_lab_issledovaniya`),
  CONSTRAINT `lab_otdeleniya_ibfk_1` FOREIGN KEY (`id_lab_issledovaniya`) REFERENCES `lab_issledovaniya` (`id_lab_issledovaniya`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `lab_otdeleniya_ibfk_2` FOREIGN KEY (`id_otdeleniya`) REFERENCES `otdeleniya` (`id_otdeleniya`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8 COMMENT='Перечень лабораторных исследований, проводимых отделением';

-- Дамп данных таблицы vypisnie_epikrizy.lab_otdeleniya: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `lab_otdeleniya` DISABLE KEYS */;
INSERT INTO `lab_otdeleniya` (`id_lab_otdeleniya`, `id_otdeleniya`, `id_lab_issledovaniya`) VALUES
	(18, 2, 18),
	(19, 4, 18),
	(22, 10, 18),
	(23, 11, 18),
	(24, 12, 18),
	(25, 13, 18),
	(26, 4, 21),
	(27, 13, 21),
	(28, 10, 21),
	(29, 2, 22),
	(30, 4, 22),
	(31, 10, 22),
	(32, 11, 22),
	(33, 12, 22),
	(34, 13, 22);
/*!40000 ALTER TABLE `lab_otdeleniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.lechenie
CREATE TABLE IF NOT EXISTS `lechenie` (
  `id_lecheniya` int(11) NOT NULL AUTO_INCREMENT,
  `id_diagnoza` int(11) NOT NULL,
  `id_preparata` int(11) NOT NULL,
  PRIMARY KEY (`id_lecheniya`),
  KEY `id_diagnoza` (`id_diagnoza`),
  KEY `id_preparata` (`id_preparata`),
  CONSTRAINT `lechenie_ibfk_1` FOREIGN KEY (`id_diagnoza`) REFERENCES `diagnozy` (`id_diagnoza`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `lechenie_ibfk_2` FOREIGN KEY (`id_preparata`) REFERENCES `preparaty` (`id_preparata`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COMMENT='Перечень препаратор для лечения диагноза';

-- Дамп данных таблицы vypisnie_epikrizy.lechenie: ~9 rows (приблизительно)
/*!40000 ALTER TABLE `lechenie` DISABLE KEYS */;
INSERT INTO `lechenie` (`id_lecheniya`, `id_diagnoza`, `id_preparata`) VALUES
	(10, 5, 3),
	(12, 7, 6),
	(13, 7, 8),
	(14, 7, 7),
	(15, 8, 12),
	(16, 8, 9),
	(17, 9, 9),
	(18, 9, 10),
	(19, 9, 7),
	(20, 10, 11),
	(21, 11, 11);
/*!40000 ALTER TABLE `lechenie` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.otdeleniya
CREATE TABLE IF NOT EXISTS `otdeleniya` (
  `id_otdeleniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(150) NOT NULL,
  PRIMARY KEY (`id_otdeleniya`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COMMENT='Справочник отделений';

-- Дамп данных таблицы vypisnie_epikrizy.otdeleniya: ~6 rows (приблизительно)
/*!40000 ALTER TABLE `otdeleniya` DISABLE KEYS */;
INSERT INTO `otdeleniya` (`id_otdeleniya`, `naimenovanie`) VALUES
	(2, 'Хирургия'),
	(4, 'Терапевтическое'),
	(10, 'Гинекология'),
	(11, 'Кардиология'),
	(12, 'Неврология'),
	(13, 'Реанимация');
/*!40000 ALTER TABLE `otdeleniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.pacienty
CREATE TABLE IF NOT EXISTS `pacienty` (
  `id_pacienta` int(11) NOT NULL AUTO_INCREMENT,
  `familiya` varchar(30) NOT NULL,
  `imya` varchar(30) NOT NULL,
  `otchestvo` varchar(30) NOT NULL,
  `data_rojdeniya` date NOT NULL,
  `pol` varchar(1) NOT NULL,
  `adress_projivaniya` varchar(150) NOT NULL,
  `id_gcgp` int(11) NOT NULL,
  PRIMARY KEY (`id_pacienta`),
  KEY `id_gcgp` (`id_gcgp`),
  CONSTRAINT `pacienty_ibfk_1` FOREIGN KEY (`id_gcgp`) REFERENCES `gcgp` (`id_gcgp`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='Справочник пациентов';

-- Дамп данных таблицы vypisnie_epikrizy.pacienty: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `pacienty` DISABLE KEYS */;
INSERT INTO `pacienty` (`id_pacienta`, `familiya`, `imya`, `otchestvo`, `data_rojdeniya`, `pol`, `adress_projivaniya`, `id_gcgp`) VALUES
	(1, 'Кракодеев', 'Евгений', 'Александрович', '2000-07-07', 'М', 'г. Добруш, ул. Пролетарская, д.13', 5),
	(2, 'Сидорова', 'Тамара', 'Леонидовна', '1976-02-13', 'Ж', 'г. Гомель, пр-т Речицкий, 4ж 35', 1),
	(5, 'Логвин', 'Александр', 'Александрович', '1993-05-10', 'М', 'г. Гомель, ул. Интернациональная 6, 46', 6),
	(6, 'Денисенко', 'Петр', 'Анатольевич', '1983-01-16', 'М', 'г. Гомель, ул. Партизанская 16', 9),
	(7, 'Самойлов', 'Алексей', 'Федорович', '1951-07-10', 'М', 'г. Гомель, ул. Героев подпольщиков 193', 10),
	(8, 'Симонова', 'Антонина', 'Павловна', '1945-08-27', 'Ж', 'г. Гомель, пр. Победы 37, 50', 11),
	(9, 'Зуборева', 'Алена', 'Ивановна', '1975-10-23', 'Ж', 'г. Гомель, ул. 60 лет БССР 10', 8),
	(10, 'Липа', 'Светлана', 'Алексеевна', '1993-04-01', 'Ж', 'г. Гомель, ул. Клермон-Ферран 16, 89', 1);
/*!40000 ALTER TABLE `pacienty` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.perenesennye_operacii
CREATE TABLE IF NOT EXISTS `perenesennye_operacii` (
  `id_operacii` int(11) NOT NULL AUTO_INCREMENT,
  `id_epikriza` int(11) NOT NULL,
  `date_provedeniya` date NOT NULL,
  `provedeno` varchar(300) NOT NULL,
  `commentariy` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_operacii`),
  KEY `id_pacienta` (`id_epikriza`),
  CONSTRAINT `perenesennye_operacii_ibfk_1` FOREIGN KEY (`id_epikriza`) REFERENCES `epikrizy` (`id_epikriza`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='Перенесенные операции пациентов';

-- Дамп данных таблицы vypisnie_epikrizy.perenesennye_operacii: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `perenesennye_operacii` DISABLE KEYS */;
INSERT INTO `perenesennye_operacii` (`id_operacii`, `id_epikriza`, `date_provedeniya`, `provedeno`, `commentariy`) VALUES
	(2, 4, '2020-05-28', 'Удаление воспаленного аппендикса', 'Приемлемый'),
	(3, 5, '2020-06-02', 'Гастроскопия желудка с пробой слизистой оболочки', 'Без особенностей'),
	(4, 6, '2020-06-25', 'Раздельное диагностическое выскабливание цервикального канала и полости матки', 'Протекал без особенностей'),
	(5, 5, '2020-06-03', 'Удаление воспаленного аппендикса хирургическим путем', 'Удовлетворительный'),
	(6, 4, '2020-05-27', 'Гастероскопия желудка с пробой слизистой оболочки', 'Приемлемый'),
	(7, 7, '2020-04-25', 'Раздельно диагностическое выскабливание цервикального канала и полости матки', 'Без особенностей'),
	(8, 7, '2020-04-28', 'Удаление воспаленного аппендикса', 'Без особенностей'),
	(9, 3, '2020-05-27', 'Удаление аппендикса', 'Без особенностей');
/*!40000 ALTER TABLE `perenesennye_operacii` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.personal
CREATE TABLE IF NOT EXISTS `personal` (
  `id_personala` int(11) NOT NULL AUTO_INCREMENT,
  `familiya` varchar(30) NOT NULL,
  `imya` varchar(30) NOT NULL,
  `otchestvo` varchar(30) NOT NULL,
  `id_otdeleniya` int(11) NOT NULL,
  `id_doljnosti` int(11) NOT NULL,
  PRIMARY KEY (`id_personala`),
  KEY `id_otdeleniya` (`id_otdeleniya`),
  KEY `id_doljnosti` (`id_doljnosti`),
  CONSTRAINT `personal_ibfk_1` FOREIGN KEY (`id_otdeleniya`) REFERENCES `otdeleniya` (`id_otdeleniya`),
  CONSTRAINT `personal_ibfk_2` FOREIGN KEY (`id_doljnosti`) REFERENCES `doljnosti` (`id_doljnosti`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='Справочник персонала';

-- Дамп данных таблицы vypisnie_epikrizy.personal: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` (`id_personala`, `familiya`, `imya`, `otchestvo`, `id_otdeleniya`, `id_doljnosti`) VALUES
	(1, 'Шварцберг', 'Антонина', 'Эдуардовна', 2, 1),
	(2, 'Шишков', 'Андрей', 'Алексеевич', 4, 4),
	(5, 'Павленко', 'Павел', 'Андреевич', 10, 10),
	(6, 'Вермухт', 'Всеволод', 'Владиславович', 2, 5),
	(7, 'Петренко', 'Юрий', 'Владимирович', 13, 7),
	(8, 'Зубов', 'Иван', 'Федорович', 10, 5),
	(9, 'Потапова', 'Тамара', 'Евгеньевна', 11, 5),
	(10, 'Пушкова', 'Светлана', 'Юрьевна', 11, 11);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.pokazat_instr_issled
CREATE TABLE IF NOT EXISTS `pokazat_instr_issled` (
  `id_pokazat_instr_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_instr_issledovaniya` int(11) NOT NULL,
  `naimenovanie` varchar(150) NOT NULL DEFAULT '',
  `ed_izm` varchar(30) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_pokazat_instr_issled`),
  KEY `id_instr_issledovaniya` (`id_instr_issledovaniya`),
  CONSTRAINT `pokazat_instr_issled_ibfk_1` FOREIGN KEY (`id_instr_issledovaniya`) REFERENCES `instr_issledovaniya` (`id_instr_issledovaniya`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='Показатели инструментального исследования';

-- Дамп данных таблицы vypisnie_epikrizy.pokazat_instr_issled: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `pokazat_instr_issled` DISABLE KEYS */;
INSERT INTO `pokazat_instr_issled` (`id_pokazat_instr_issled`, `id_instr_issledovaniya`, `naimenovanie`, `ed_izm`) VALUES
	(1, 1, 'Ритм', ''),
	(2, 1, 'ЧСС', 'уд/мин'),
	(3, 1, 'ЭОС', ''),
	(4, 3, 'Матка в антефлексио', ''),
	(5, 3, 'Левый яичник', ''),
	(6, 3, 'Правый яичник', ''),
	(7, 4, 'Заключение', '');
/*!40000 ALTER TABLE `pokazat_instr_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.pokazat_lab_issled
CREATE TABLE IF NOT EXISTS `pokazat_lab_issled` (
  `id_pokazat_lab_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_lab_issledovaniya` int(11) NOT NULL,
  `naimenovanie` varchar(100) NOT NULL DEFAULT '',
  `ed_izm` varchar(30) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_pokazat_lab_issled`),
  KEY `id_lab_issledovaniya` (`id_lab_issledovaniya`),
  CONSTRAINT `pokazat_lab_issled_ibfk_1` FOREIGN KEY (`id_lab_issledovaniya`) REFERENCES `lab_issledovaniya` (`id_lab_issledovaniya`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8 COMMENT='Показатели лабораторного исследовани';

-- Дамп данных таблицы vypisnie_epikrizy.pokazat_lab_issled: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `pokazat_lab_issled` DISABLE KEYS */;
INSERT INTO `pokazat_lab_issled` (`id_pokazat_lab_issled`, `id_lab_issledovaniya`, `naimenovanie`, `ed_izm`) VALUES
	(15, 18, 'Группа крови', ''),
	(16, 18, 'Резус-фактор', ''),
	(21, 21, 'Er.', '* 10^12/л'),
	(22, 21, 'НВ', 'г/л'),
	(23, 21, 'L', '* 10^9/л'),
	(24, 21, 'ЦП', ''),
	(25, 21, 'Т', '* 10^9/л'),
	(26, 21, 'П', ''),
	(27, 21, 'Э', ''),
	(28, 21, 'Б', ''),
	(29, 21, 'С', ''),
	(30, 21, 'Л', ''),
	(31, 21, 'М', ''),
	(32, 21, 'СОЭ', 'мм/ч'),
	(33, 22, 'Билирубин общий', 'мкмоль/л'),
	(34, 22, 'Мочевина', 'ммоль/л'),
	(35, 22, 'Общий белок', 'г/л'),
	(36, 22, 'АСТ', 'ед./л'),
	(37, 22, 'АЛТ', 'ед./л'),
	(38, 22, 'Глюкоза', 'ммоль/л'),
	(39, 22, 'Креатинин', 'мкмоль/л'),
	(40, 22, 'К', 'ммоль/л'),
	(41, 22, 'Na', 'ммоль/л'),
	(42, 22, 'Cl', 'ммоль/л');
/*!40000 ALTER TABLE `pokazat_lab_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.preparaty
CREATE TABLE IF NOT EXISTS `preparaty` (
  `id_preparata` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL DEFAULT '',
  `farm_svoistva` varchar(200) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_preparata`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COMMENT='Справочник препаратов и назначенных лечений лечений';

-- Дамп данных таблицы vypisnie_epikrizy.preparaty: ~9 rows (приблизительно)
/*!40000 ALTER TABLE `preparaty` DISABLE KEYS */;
INSERT INTO `preparaty` (`id_preparata`, `naimenovanie`, `farm_svoistva`) VALUES
	(3, 'Омепразол', 'Применяется при заболеваниях желудка, а также при болях в ЖКТ'),
	(5, 'Викасол', 'Н/А'),
	(6, 'Атропин', 'Н/А'),
	(7, 'Димедрол', 'Н/А'),
	(8, 'Гемостат', 'Н/А'),
	(9, 'Ренгер', 'Н/А'),
	(10, 'Амплодипин', 'Н/А'),
	(11, 'Аспикард', 'Н/А'),
	(12, 'Индапамид', 'Н/А'),
	(13, 'Аторвастин', 'Н/А');
/*!40000 ALTER TABLE `preparaty` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.proved_instr_issled
CREATE TABLE IF NOT EXISTS `proved_instr_issled` (
  `id_proved_instr_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_epikriza` int(11) NOT NULL,
  `id_instr_issledovaniya` int(11) NOT NULL,
  `date_proved` date NOT NULL,
  PRIMARY KEY (`id_proved_instr_issled`),
  KEY `id_epikriza` (`id_epikriza`),
  KEY `id_instr_issledovaniya` (`id_instr_issledovaniya`),
  CONSTRAINT `proved_instr_issled_ibfk_1` FOREIGN KEY (`id_instr_issledovaniya`) REFERENCES `instr_issledovaniya` (`id_instr_issledovaniya`) ON DELETE CASCADE,
  CONSTRAINT `proved_instr_issled_ibfk_2` FOREIGN KEY (`id_epikriza`) REFERENCES `epikrizy` (`id_epikriza`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='Проведенные инстр. исследования';

-- Дамп данных таблицы vypisnie_epikrizy.proved_instr_issled: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `proved_instr_issled` DISABLE KEYS */;
INSERT INTO `proved_instr_issled` (`id_proved_instr_issled`, `id_epikriza`, `id_instr_issledovaniya`, `date_proved`) VALUES
	(6, 5, 1, '2020-06-02'),
	(7, 6, 1, '2020-06-25'),
	(8, 6, 3, '2020-06-25'),
	(9, 4, 4, '2020-05-27'),
	(10, 7, 1, '2020-04-27'),
	(11, 7, 4, '2020-04-27');
/*!40000 ALTER TABLE `proved_instr_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.proved_lab_issled
CREATE TABLE IF NOT EXISTS `proved_lab_issled` (
  `id_proved_lab_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_epikriza` int(11) NOT NULL,
  `id_lab_issledovaniya` int(11) NOT NULL,
  `date_proved` date NOT NULL,
  PRIMARY KEY (`id_proved_lab_issled`),
  KEY `id_epikriza` (`id_epikriza`),
  KEY `id_lab_issledovaniya` (`id_lab_issledovaniya`),
  CONSTRAINT `proved_lab_issled_ibfk_1` FOREIGN KEY (`id_lab_issledovaniya`) REFERENCES `lab_issledovaniya` (`id_lab_issledovaniya`) ON DELETE CASCADE,
  CONSTRAINT `proved_lab_issled_ibfk_2` FOREIGN KEY (`id_epikriza`) REFERENCES `epikrizy` (`id_epikriza`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COMMENT='Проведенные лаб. исследования';

-- Дамп данных таблицы vypisnie_epikrizy.proved_lab_issled: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `proved_lab_issled` DISABLE KEYS */;
INSERT INTO `proved_lab_issled` (`id_proved_lab_issled`, `id_epikriza`, `id_lab_issledovaniya`, `date_proved`) VALUES
	(4, 3, 18, '2020-05-28'),
	(5, 4, 18, '2020-05-27'),
	(8, 5, 18, '2020-06-02'),
	(10, 6, 21, '2020-06-26'),
	(11, 6, 22, '2020-06-26'),
	(13, 6, 18, '2020-06-26'),
	(15, 5, 21, '2020-06-02'),
	(16, 7, 18, '2020-04-25'),
	(17, 7, 21, '2020-04-25'),
	(18, 7, 22, '2020-04-25');
/*!40000 ALTER TABLE `proved_lab_issled` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
