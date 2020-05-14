-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.4.11-MariaDB - mariadb.org binary distribution
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
  `id_pacienta` int(11) NOT NULL,
  `id_pokazat_instr_issled` int(11) NOT NULL,
  `date_proved` date NOT NULL,
  `znachenie` varchar(30) NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  PRIMARY KEY (`id_dannyh_instr_issled`),
  KEY `id_pacienta` (`id_pacienta`),
  KEY `id_pokazat_instr_issled` (`id_pokazat_instr_issled`),
  CONSTRAINT `dannye_instr_issled_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dannye_instr_issled_ibfk_2` FOREIGN KEY (`id_pokazat_instr_issled`) REFERENCES `pokazat_instr_issled` (`id_pokazat_instr_issled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Данные показателей инструментальных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.dannye_instr_issled: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `dannye_instr_issled` DISABLE KEYS */;
/*!40000 ALTER TABLE `dannye_instr_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.dannye_lab_issled
CREATE TABLE IF NOT EXISTS `dannye_lab_issled` (
  `id_dannyh_lab_issled` int(11) NOT NULL AUTO_INCREMENT,
  `id_pacienta` int(11) NOT NULL,
  `id_pokazat_lab_issled` int(11) NOT NULL,
  `date_proved` date NOT NULL,
  `znachenie` varchar(30) NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  PRIMARY KEY (`id_dannyh_lab_issled`),
  KEY `id_pacienta` (`id_pacienta`),
  KEY `id_pokazat_lab_issled` (`id_pokazat_lab_issled`),
  CONSTRAINT `dannye_lab_issled_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `dannye_lab_issled_ibfk_2` FOREIGN KEY (`id_pokazat_lab_issled`) REFERENCES `pokazat_lab_issled` (`id_pokazat_lab_issled`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Данные показателей лабораторных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.dannye_lab_issled: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `dannye_lab_issled` DISABLE KEYS */;
/*!40000 ALTER TABLE `dannye_lab_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.diagnozy
CREATE TABLE IF NOT EXISTS `diagnozy` (
  `id_diagnoza` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL,
  PRIMARY KEY (`id_diagnoza`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник диагнозов';

-- Дамп данных таблицы vypisnie_epikrizy.diagnozy: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `diagnozy` DISABLE KEYS */;
INSERT IGNORE INTO `diagnozy` (`id_diagnoza`, `naimenovanie`) VALUES
	(1, 'Взрыв жопы'),
	(2, 'Жопа горит сильно');
/*!40000 ALTER TABLE `diagnozy` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.diagnozy_pacienta
CREATE TABLE IF NOT EXISTS `diagnozy_pacienta` (
  `id_pacienta` int(11) NOT NULL,
  `id_diagnoza` int(11) NOT NULL,
  `date_vyiavleniya` date NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  `zaklucheniye` varchar(3) NOT NULL,
  KEY `id_pacienta` (`id_pacienta`),
  KEY `id_diagnoza` (`id_diagnoza`),
  CONSTRAINT `diagnozy_pacienta_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `diagnozy_pacienta_ibfk_2` FOREIGN KEY (`id_diagnoza`) REFERENCES `diagnozy` (`id_diagnoza`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Перечень диагнозов, поставленных пациенту';

-- Дамп данных таблицы vypisnie_epikrizy.diagnozy_pacienta: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `diagnozy_pacienta` DISABLE KEYS */;
/*!40000 ALTER TABLE `diagnozy_pacienta` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.doljnosti
CREATE TABLE IF NOT EXISTS `doljnosti` (
  `id_doljnosti` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(150) NOT NULL,
  PRIMARY KEY (`id_doljnosti`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник должностей';

-- Дамп данных таблицы vypisnie_epikrizy.doljnosti: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `doljnosti` DISABLE KEYS */;
INSERT IGNORE INTO `doljnosti` (`id_doljnosti`, `naimenovanie`) VALUES
	(1, 'Хирург'),
	(4, 'Невропатолог');
/*!40000 ALTER TABLE `doljnosti` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.epkrizy
CREATE TABLE IF NOT EXISTS `epkrizy` (
  `id_epikriza` int(11) NOT NULL AUTO_INCREMENT,
  `id_pacienta` int(11) NOT NULL,
  `date_n` date NOT NULL,
  `date_k` date NOT NULL,
  `id_otdeleniya` int(11) NOT NULL,
  `sost_vypiski` varchar(300) NOT NULL,
  `lvn_n` date NOT NULL,
  `lvn_k` date NOT NULL,
  `recomendacii` varchar(300) NOT NULL,
  `ad` varchar(150) NOT NULL,
  `anam` varchar(150) NOT NULL,
  `kurenie` varchar(150) NOT NULL,
  `alcogol` varchar(150) NOT NULL,
  `imt` varchar(150) NOT NULL,
  `holesterin` varchar(150) NOT NULL,
  `ob_krovi` varchar(150) NOT NULL,
  `ob_mochi` varchar(150) NOT NULL,
  `ekg` varchar(150) NOT NULL,
  `skore` varchar(150) NOT NULL,
  `vgd` varchar(150) NOT NULL,
  `predstat` varchar(150) NOT NULL,
  `moloch_jel` varchar(150) NOT NULL,
  `fluorografia` varchar(150) NOT NULL,
  `glukoza` varchar(150) NOT NULL,
  `risk_suicida` varchar(150) NOT NULL,
  `zav_otdeleniya` varchar(150) NOT NULL,
  `lech_vrach` varchar(150) NOT NULL,
  PRIMARY KEY (`id_epikriza`),
  KEY `id_pacienta` (`id_pacienta`),
  KEY `id_otdeleniya` (`id_otdeleniya`),
  CONSTRAINT `epkrizy_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`),
  CONSTRAINT `epkrizy_ibfk_2` FOREIGN KEY (`id_otdeleniya`) REFERENCES `otdeleniya` (`id_otdeleniya`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Выписные эпикризы';

-- Дамп данных таблицы vypisnie_epikrizy.epkrizy: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `epkrizy` DISABLE KEYS */;
/*!40000 ALTER TABLE `epkrizy` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.gcgp
CREATE TABLE IF NOT EXISTS `gcgp` (
  `id_gcgp` int(11) NOT NULL AUTO_INCREMENT,
  `nom_filiala` varchar(12) NOT NULL DEFAULT '',
  `adress` varchar(150) NOT NULL,
  PRIMARY KEY (`id_gcgp`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник ГЦГП';

-- Дамп данных таблицы vypisnie_epikrizy.gcgp: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `gcgp` DISABLE KEYS */;
INSERT IGNORE INTO `gcgp` (`id_gcgp`, `nom_filiala`, `adress`) VALUES
	(1, 'Филиал № 9  ', 'ул. Клермон-Ферран, 4'),
	(4, 'Филиал № 1 ', 'ул. Гагарина, 13');
/*!40000 ALTER TABLE `gcgp` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.instr_issledovaniya
CREATE TABLE IF NOT EXISTS `instr_issledovaniya` (
  `id_instr_issledovaniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_instr_issledovaniya`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='Справочник инструментальных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.instr_issledovaniya: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `instr_issledovaniya` DISABLE KEYS */;
INSERT IGNORE INTO `instr_issledovaniya` (`id_instr_issledovaniya`, `naimenovanie`) VALUES
	(1, 'ЭКГ');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='Перечень инстр-ных исследований, проводимых отделением';

-- Дамп данных таблицы vypisnie_epikrizy.instr_otdeleniya: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `instr_otdeleniya` DISABLE KEYS */;
INSERT IGNORE INTO `instr_otdeleniya` (`id_instr_otdeleniya`, `id_otdeleniya`, `id_instr_issledovaniya`) VALUES
	(1, 2, 1),
	(2, 4, 1);
/*!40000 ALTER TABLE `instr_otdeleniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.lab_issledovaniya
CREATE TABLE IF NOT EXISTS `lab_issledovaniya` (
  `id_lab_issledovaniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL,
  PRIMARY KEY (`id_lab_issledovaniya`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COMMENT='Справочник лабораторных исследований';

-- Дамп данных таблицы vypisnie_epikrizy.lab_issledovaniya: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `lab_issledovaniya` DISABLE KEYS */;
INSERT IGNORE INTO `lab_issledovaniya` (`id_lab_issledovaniya`, `naimenovanie`) VALUES
	(18, 'Анализ крови');
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COMMENT='Перечень лабораторных исследований, проводимых отделением';

-- Дамп данных таблицы vypisnie_epikrizy.lab_otdeleniya: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `lab_otdeleniya` DISABLE KEYS */;
INSERT IGNORE INTO `lab_otdeleniya` (`id_lab_otdeleniya`, `id_otdeleniya`, `id_lab_issledovaniya`) VALUES
	(18, 2, 18),
	(19, 4, 18);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='Перечень препаратор для лечения диагноза';

-- Дамп данных таблицы vypisnie_epikrizy.lechenie: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `lechenie` DISABLE KEYS */;
INSERT IGNORE INTO `lechenie` (`id_lecheniya`, `id_diagnoza`, `id_preparata`) VALUES
	(1, 1, 1),
	(3, 2, 1);
/*!40000 ALTER TABLE `lechenie` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.otdeleniya
CREATE TABLE IF NOT EXISTS `otdeleniya` (
  `id_otdeleniya` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(150) NOT NULL,
  PRIMARY KEY (`id_otdeleniya`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='Справочник отделений';

-- Дамп данных таблицы vypisnie_epikrizy.otdeleniya: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `otdeleniya` DISABLE KEYS */;
INSERT IGNORE INTO `otdeleniya` (`id_otdeleniya`, `naimenovanie`) VALUES
	(2, 'Хирургия'),
	(4, 'Терапевтическое');
/*!40000 ALTER TABLE `otdeleniya` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.pacienty
CREATE TABLE IF NOT EXISTS `pacienty` (
  `id_pacienta` int(11) NOT NULL AUTO_INCREMENT,
  `familiya` varchar(30) NOT NULL,
  `imya` varchar(30) NOT NULL,
  `otchestvo` varchar(30) NOT NULL,
  `data_rojdeniya` date NOT NULL,
  `adress_projivaniya` varchar(150) NOT NULL,
  `id_gcgp` int(11) NOT NULL,
  PRIMARY KEY (`id_pacienta`),
  KEY `id_gcgp` (`id_gcgp`),
  CONSTRAINT `pacienty_ibfk_1` FOREIGN KEY (`id_gcgp`) REFERENCES `gcgp` (`id_gcgp`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник пациентов';

-- Дамп данных таблицы vypisnie_epikrizy.pacienty: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `pacienty` DISABLE KEYS */;
INSERT IGNORE INTO `pacienty` (`id_pacienta`, `familiya`, `imya`, `otchestvo`, `data_rojdeniya`, `adress_projivaniya`, `id_gcgp`) VALUES
	(1, 'Кракодеев', 'Евгений', 'Александрович', '2000-07-07', 'г. Добруш, ул. Пролетарская, д.13', 1),
	(2, 'Шишкова', 'Наталья', 'Леонидовна', '1977-02-13', 'г. Гомель, пр-т Речицкий, 4д 53', 1);
/*!40000 ALTER TABLE `pacienty` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.perenesennye_operacii
CREATE TABLE IF NOT EXISTS `perenesennye_operacii` (
  `id_operacii` int(11) NOT NULL AUTO_INCREMENT,
  `id_pacienta` int(11) NOT NULL,
  `date_provedeniya` date NOT NULL,
  `commentariy` varchar(300) NOT NULL,
  PRIMARY KEY (`id_operacii`),
  KEY `id_pacienta` (`id_pacienta`),
  CONSTRAINT `perenesennye_operacii_ibfk_1` FOREIGN KEY (`id_pacienta`) REFERENCES `pacienty` (`id_pacienta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Перенесенные операции пациентов';

-- Дамп данных таблицы vypisnie_epikrizy.perenesennye_operacii: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `perenesennye_operacii` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Справочник персонала';

-- Дамп данных таблицы vypisnie_epikrizy.personal: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT IGNORE INTO `personal` (`id_personala`, `familiya`, `imya`, `otchestvo`, `id_otdeleniya`, `id_doljnosti`) VALUES
	(1, 'Синенок', 'Ангелина', 'Олеговна', 2, 1),
	(2, 'Шишков', 'Андрей', 'Алексеевич', 4, 4);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Показатели инструментального исследования';

-- Дамп данных таблицы vypisnie_epikrizy.pokazat_instr_issled: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `pokazat_instr_issled` DISABLE KEYS */;
INSERT IGNORE INTO `pokazat_instr_issled` (`id_pokazat_instr_issled`, `id_instr_issledovaniya`, `naimenovanie`, `ed_izm`) VALUES
	(1, 1, 'Ритм', ''),
	(2, 1, 'ЧСС', 'уд/мин'),
	(3, 1, 'ЭОС', '');
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COMMENT='Показатели лабораторного исследовани';

-- Дамп данных таблицы vypisnie_epikrizy.pokazat_lab_issled: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `pokazat_lab_issled` DISABLE KEYS */;
INSERT IGNORE INTO `pokazat_lab_issled` (`id_pokazat_lab_issled`, `id_lab_issledovaniya`, `naimenovanie`, `ed_izm`) VALUES
	(15, 18, 'Группа крови', ''),
	(16, 18, 'Резус-фактор', '');
/*!40000 ALTER TABLE `pokazat_lab_issled` ENABLE KEYS */;

-- Дамп структуры для таблица vypisnie_epikrizy.preparaty
CREATE TABLE IF NOT EXISTS `preparaty` (
  `id_preparata` int(11) NOT NULL AUTO_INCREMENT,
  `naimenovanie` varchar(50) NOT NULL DEFAULT '',
  `farm_svoistva` varchar(200) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_preparata`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='Справочник препаратов и назначенных лечений лечений';

-- Дамп данных таблицы vypisnie_epikrizy.preparaty: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `preparaty` DISABLE KEYS */;
INSERT IGNORE INTO `preparaty` (`id_preparata`, `naimenovanie`, `farm_svoistva`) VALUES
	(1, 'Аспирин', 'Болит живот, рука, ноги, голова?! Выпей АСПИРИН - точно пройдет. Разорвало живот, оторвало руку, ногу, голову ?! Выпей АСПИРИН - отрастет всё снова!'),
	(2, 'Вазелин', '"Охлади своё трахание, Углепластик"');
/*!40000 ALTER TABLE `preparaty` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
