﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epikrizy
{
    public class MySqlQueries
    {
        //Exists
        public string Exists_LabIssl = $@"SELECT EXISTS(SELECT * FROM lab_issledovaniya WHERE naimenovanie = @Value1);";

        public string Exists_Diagnozy = $@"SELECT EXISTS(SELECT * FROM diagnozy WHERE naimenovanie = @Value1);";

        public string Exists_InstrIssl = $@"SELECT EXISTS(SELECT * FROM instr_issledovaniya WHERE naimenovanie = @Value1);";

        public string Exists_Doljnosti = $@"SELECT EXISTS(SELECT * FROM doljnosti WHERE naimenovanie = @Value1);";

        public string Exists_Preparaty = $@"SELECT EXISTS(SELECT * FROM preparaty WHERE naimenovanie = @Value1 AND farm_svoistva = @Value2);";

        public string Exists_Otdeleniya = $@"SELECT EXISTS(SELECT * FROM otdeleniya WHERE naimenovanie = @Value1);";

        public string Exists_Gcgp = $@"SELECT EXISTS(SELECT * FROM gcgp WHERE nom_filiala = @Value1 OR adress = @Value2);";

        public string Exists_Otdeleniya_LabIssl = $@"SELECT EXISTS(SELECT * FROM lab_otdeleniya WHERE id_lab_issledovaniya = @Value1 AND id_otdeleniya = @Value2);";

        public string Exists_Pokazat_LabIssl = $@"SELECT EXISTS(SELECT * FROM pokazat_lab_issled WHERE id_lab_issledovaniya = @Value1 AND naimenovanie = @Value2 AND ed_izm = @Value3);";

        public string Exists_Otdeleniya_InstrIssl = $@"SELECT EXISTS(SELECT * FROM instr_otdeleniya WHERE id_instr_issledovaniya = @Value1 AND id_otdeleniya = @Value2);";

        public string Exists_Pokazat_InstrIssl = $@"SELECT EXISTS(SELECT * FROM pokazat_instr_issled WHERE id_instr_issledovaniya = @Value1 AND naimenovanie = @Value2 AND ed_izm = @Value3);";

        public string Exists_Lechenie = $@"SELECT EXISTS(SELECT * FROM lechenie WHERE id_diagnoza = @Value1 AND id_preparata = @Value2);";
        //Exists

        //Select
        public string Select_Last_ID = $@"SELECT LAST_INSERT_ID();";

        public string Select_Otdeleniya = $@"SELECT id_otdeleniya, naimenovanie AS 'Наименование отделения' FROM otdeleniya;";

        public string Select_Otdeleniya_ComboBox = $@"SELECT naimenovanie FROM otdeleniya";

        public string Select_ID_Otdeleniya_ComboBox = $@"SELECT id_otdeleniya FROM otdeleniya WHERE naimenovanie = @Value1";

        public string Select_Doljnosti = $@"SELECT id_doljnosti, naimenovanie AS 'Наименование должности' FROM doljnosti;";

        public string Select_Doljnosti_ComboBox = $@"SELECT naimenovanie FROM doljnosti;";

        public string Select_ID_Doljnosti_ComboBox = $@"SELECT id_doljnosti FROM doljnosti WHERE naimenovanie = @Value1;";

        public string Select_Preparaty = $@"SELECT id_preparata, naimenovanie AS 'Наименование препарата', farm_svoistva AS 'Фармакологические свойства' FROM preparaty;";

        public string Select_Preparaty_ComboBox = $@"SELECT naimenovanie FROM preparaty;";

        public string Select_ID_Preparaty_ComboBox = $@"SELECT id_preparata FROM preparaty WHERE naimenovanie = @Value1;";

        public string Select_Personal = $@"SELECT personal.id_personala, CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo) AS 'Ф.И.О. Сотрудника', 
otdeleniya.naimenovanie AS 'Наименование отделения', doljnosti.naimenovanie AS 'Наименование должности'
FROM personal INNER JOIN otdeleniya ON personal.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN doljnosti ON personal.id_doljnosti = doljnosti.id_doljnosti;";

        public string Select_Pacienty = $@"SET lc_time_names = 'ru_RU';
SELECT pacienty.id_pacienta, CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', 
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y') AS 'Дата рождения', pacienty.adress_projivaniya AS 'Адрес проживания', gcgp.nom_filiala AS 'Филиал ГЦГП'
FROM pacienty INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp;";

        public string Select_Gcgp = $@"SELECT id_gcgp, nom_filiala AS 'Номер филиала', adress AS 'Адрес' FROM gcgp;";

        public string Select_Gcgp_ComboBox = $@"SELECT nom_filiala FROM gcgp;";

        public string Select_ID_Gcgp_ComboBox = $@"SELECT id_gcgp FROM gcgp WHERE nom_filiala = @Value1;";

        public string Select_Pokazat_LabIssl = $@"SELECT pokazat_lab_issled.id_pokazat_lab_issled, pokazat_lab_issled.naimenovanie AS 'Наименование', pokazat_lab_issled.ed_izm AS 'Ед. Изм.' 
FROM pokazat_lab_issled INNER JOIN lab_issledovaniya ON pokazat_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_Otdeleniya_LabIssl = $@"SELECT lab_otdeleniya.id_lab_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM lab_otdeleniya INNER JOIN otdeleniya ON lab_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN lab_issledovaniya ON lab_otdeleniya.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_LabIssl = $@"SELECT lab_issledovaniya.id_lab_issledovaniya, lab_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM lab_issledovaniya;";

        public string Select_Pokazat_InstrIssl = $@"SELECT pokazat_instr_issled.id_pokazat_instr_issled, pokazat_instr_issled.naimenovanie AS 'Наименование', pokazat_instr_issled.ed_izm AS 'Ед. Изм.' 
FROM pokazat_instr_issled INNER JOIN instr_issledovaniya ON pokazat_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_Otdeleniya_InstrIssl = $@"SELECT instr_otdeleniya.id_instr_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM instr_otdeleniya INNER JOIN otdeleniya ON instr_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN instr_issledovaniya ON instr_otdeleniya.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_InstrIssl = $@"SELECT instr_issledovaniya.id_instr_issledovaniya, instr_issledovaniya.naimenovanie AS 'Наименование исследования'
        FROM instr_issledovaniya;";

        public string Select_Diagnozy = $@"SELECT diagnozy.id_diagnoza, diagnozy.naimenovanie AS 'Наименование исследования'
        FROM diagnozy;";

        public string Select_Lechenie = $@"SELECT lechenie.id_lecheniya, preparaty.naimenovanie AS 'Наименование препарата', preparaty.farm_svoistva AS 'Фармакологические свойства' 
FROM lechenie INNER JOIN preparaty ON lechenie.id_preparata = preparaty.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
WHERE diagnozy.id_diagnoza = @ID;";
        //Select

        //Insert
        public string Insert_Otdeleniya = $@"INSERT INTO otdeleniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Doljnosti = $@"INSERT INTO doljnosti (naimenovanie) VALUES (@Value1);";

        public string Insert_Preparaty = $@"INSERT INTO preparaty (naimenovanie, farm_svoistva) VALUES (@Value1, @Value2);";

        public string Insert_Gcgp = $@"INSERT INTO gcgp (nom_filiala, adress) VALUES (@Value1, @Value2);";

        public string Insert_Personal = $@"INSERT INTO personal (familiya, imya, otchestvo, id_otdeleniya, id_doljnosti) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Pacienty = $@"INSERT INTO pacienty (familiya, imya, otchestvo, data_rojdeniya, adress_projivaniya, id_gcgp) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6);";

        public string Insert_LabIssl = $@"INSERT INTO lab_issledovaniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Pokazat_LabIssl = $@"INSERT INTO pokazat_lab_issled (id_lab_issledovaniya, naimenovanie, ed_izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Otdeleniya_LabIssl = $@"INSERT INTO lab_otdeleniya (id_lab_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_InstrIssl = $@"INSERT INTO instr_issledovaniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Pokazat_InstrIssl = $@"INSERT INTO pokazat_instr_issled (id_instr_issledovaniya, naimenovanie, ed_izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Otdeleniya_InstrIssl = $@"INSERT INTO instr_otdeleniya (id_instr_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_Diagnozy = $@"INSERT INTO diagnozy (naimenovanie) VALUES (@Value1);";

        public string Insert_Lechenie = $@"INSERT INTO lechenie (id_diagnoza, id_preparata) VALUES (@Value1, @Value2);";
        //Insert

        //Update
        public string Update_Otdeleniya = $@"UPDATE otdeleniya SET naimenovanie = @Value1 WHERE id_otdeleniya = @ID;";

        public string Update_Doljnosti = $@"UPDATE doljnosti SET naimenovanie = @Value1 WHERE id_doljnosti = @ID;";

        public string Update_Preparaty = $@"UPDATE preparaty SET naimenovanie = @Value1, farm_svoistva = @Value2 WHERE id_preparata = @ID;";

        public string Update_Gcgp = $@"UPDATE gcgp SET nom_filiala = @Value1, adress = @Value2 WHERE id_gcgp = @ID;";

        public string Update_Personal = $@"UPDATE personal SET familiya = @Value1, imya = @Value2, otchestvo = @Value3, id_otdeleniya = @Value4, id_doljnosti = @Value5 WHERE id_personala = @ID;";

        public string Update_Pacienty = $@"UPDATE pacienty SET familiya = @Value1, imya = @Value2, otchestvo = @Value3, data_rojdeniya = @Value4, adress_projivaniya = @Value5, id_gcgp = @Value6 WHERE id_pacienta = @ID;";

        public string Update_LabIssl = $@"UPDATE lab_issledovaniya SET naimenovanie = @Value1 WHERE id_lab_issledovaniya = @ID;";

        public string Update_Pokazat_LabIssl = $@"UPDATE pokazat_lab_issled SET id_lab_issledovaniya = @Value1, naimenovanie = @Value2, ed_izm = @Value3 WHERE id_pokazat_lab_issled = @ID;";

        public string Update_Otdeleniya_LabIssl = $@"UPDATE lab_otdeleniya SET id_lab_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_lab_otdeleniya = @ID;";

        public string Update_InstrIssl = $@"UPDATE instr_issledovaniya SET naimenovanie = @Value1 WHERE id_instr_issledovaniya = @ID;";

        public string Update_Pokazat_InstrIssl = $@"UPDATE pokazat_instr_issled SET id_instr_issledovaniya = @Value1, naimenovanie = @Value2, ed_izm = @Value3 WHERE id_pokazat_instr_issled = @ID;";

        public string Update_Otdeleniya_InstrIssl = $@"UPDATE instr_otdeleniya SET id_instr_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_instr_otdeleniya = @ID;";

        public string Update_Diagnozy = $@"UPDATE diagnozy SET naimenovanie = @Value1 WHERE id_diagnoza = @ID;";

        public string Update_Lechenie = $@"UPDATE lechenie SET id_diagnoza = @Value1, id_preparata = @Value2 WHERE id_lecheniya = @ID;";
        //Update

        //Delete
        public string Delete_Otdeleniya = $@"DELETE FROM otdeleniya WHERE id_otdeleniya = @ID;";
        
        public string Delete_Doljnosti = $@"DELETE FROM doljnosti WHERE id_doljnosti = @ID;";

        public string Delete_Preparaty = $@"DELETE FROM preparaty WHERE id_preparata = @ID;";

        public string Delete_Gcgp = $@"DELETE FROM gcgp WHERE id_gcgp = @ID;";

        public string Delete_Personal = $@"DELETE FROM personal WHERE id_personala = @ID";

        public string Delete_Pacienty = $@"DELETE FROM pacienty WHERE id_pacienta = @ID";

        public string Delete_LabIssl = $@"DELETE FROM lab_issledovaniya WHERE id_lab_issledovaniya = @ID";

        public string Delete_Pokazat_LabIssl = $@"DELETE FROM pokazat_lab_issled WHERE id_pokazat_lab_issled = @ID;";

        public string Delete_Otdeleniya_LabIssl = $@"DELETE FROM lab_otdeleniya WHERE id_lab_otdeleniya = @ID;";

        public string Delete_InstrIssl = $@"DELETE FROM instr_issledovaniya WHERE id_instr_issledovaniya = @ID";

        public string Delete_Pokazat_InstrIssl = $@"DELETE FROM pokazat_instr_issled WHERE id_pokazat_instr_issled = @ID;";

        public string Delete_Otdeleniya_InstrIssl = $@"DELETE FROM instr_otdeleniya WHERE id_instr_otdeleniya = @ID;";

        public string Delete_Diagnozy = $@"DELETE FROM diagnozy WHERE id_diagnoza = @ID";

        public string Delete_Lechenie = $@"DELETE FROM lechenie WHERE id_lecheniya = @ID;";
        //Delete
    }
}
