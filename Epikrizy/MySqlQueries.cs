using System;
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

        public string Exists_Perenesennye_Operacii = $@"SELECT EXISTS(SELECT * FROM perenesennye_operacii WHERE id_pacienta = @Value1 AND date_provedeniya = @Value2 AND provedeno = @Value3 AND commentariy = @Value4);";
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

        public string Select_Lech_Vrach_ComboBox = $@"SELECT CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo)
FROM personal INNER JOIN otdeleniya ON personal.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE personal.id_otdeleniya = @ID";

        public string Select_Pacienty = $@"SET lc_time_names = 'ru_RU';
SELECT pacienty.id_pacienta, CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', 
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y') AS 'Дата рождения', pacienty.adress_projivaniya AS 'Адрес проживания', gcgp.nom_filiala AS 'Филиал ГЦГП'
FROM pacienty INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp;";

        public string Select_Pacienty_ComboBox = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo, ' ',
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y'))
FROM pacienty;";

        public string Select_ID_Pacienty_ComboBox = $@"SET lc_time_names = 'ru_RU';
SELECT id_pacienta
FROM pacienty
WHERE CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo, ' ',
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y')) = @Value1;";

        public string Select_Gcgp = $@"SELECT id_gcgp, nom_filiala AS 'Номер филиала', adress AS 'Адрес' FROM gcgp;";

        public string Select_Gcgp_ComboBox = $@"SELECT nom_filiala FROM gcgp;";

        public string Select_ID_Gcgp_ComboBox = $@"SELECT id_gcgp FROM gcgp WHERE nom_filiala = @Value1;";

        public string Select_Pokazat_LabIssl = $@"SELECT pokazat_lab_issled.id_pokazat_lab_issled, pokazat_lab_issled.naimenovanie AS 'Наименование', pokazat_lab_issled.ed_izm AS 'Ед. Изм.' 
FROM pokazat_lab_issled INNER JOIN lab_issledovaniya ON pokazat_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_Pokazat_LabIssl_Insert_Epikrizy = $@"SELECT id_pokazat_lab_issled, naimenovanie AS 'Наименование', NULL AS 'Значение', ed_izm AS 'Ед. изм.', NULL AS 'Комментарий'
FROM pokazat_lab_issled
WHERE id_lab_issledovaniya = @ID;";

        public string Select_Otdeleniya_LabIssl = $@"SELECT lab_otdeleniya.id_lab_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM lab_otdeleniya INNER JOIN otdeleniya ON lab_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN lab_issledovaniya ON lab_otdeleniya.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_LabIssl = $@"SELECT lab_issledovaniya.id_lab_issledovaniya, lab_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM lab_issledovaniya;";

        public string Select_LabIssl_ComboBox = $@"SELECT lab_issledovaniya.naimenovanie FROM lab_issledovaniya INNER JOIN lab_otdeleniya ON lab_issledovaniya.id_lab_issledovaniya = lab_otdeleniya.id_lab_issledovaniya
WHERE lab_otdeleniya.id_otdeleniya = @Value1;";

        public string Select_ID_LabIssl_ComboBox = $@"SELECT id_lab_issledovaniya FROM lab_issledovaniya WHERE naimenovanie = @Value1;";

        public string Select_Pokazat_InstrIssl = $@"SELECT pokazat_instr_issled.id_pokazat_instr_issled, pokazat_instr_issled.naimenovanie AS 'Наименование', pokazat_instr_issled.ed_izm AS 'Ед. Изм.' 
FROM pokazat_instr_issled INNER JOIN instr_issledovaniya ON pokazat_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_Dannye_LabIssl = $@"SELECT dannye_lab_issled.id_dannyh_lab_issled, pokazat_lab_issled.naimenovanie, dannye_lab_issled.znachenie, pokazat_lab_issled.ed_izm, dannye_lab_issled.commentariy
FROM dannye_lab_issled
INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
WHERE dannye_lab_issled.id_pacienta = @ID AND dannye_lab_issled.date_proved = @Value1 AND pokazat_lab_issled.id_lab_issledovaniya = @Value2";

        public string Select_Edit_Dannye_LabIssl = $@"SELECT dannye_lab_issled.id_dannyh_lab_issled, pokazat_lab_issled.naimenovanie, dannye_lab_issled.znachenie,pokazat_lab_issled.ed_izm,dannye_lab_issled.commentariy
FROM dannye_lab_issled INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
INNER JOIN pacienty ON dannye_lab_issled.id_pacienta = pacienty.id_pacienta
INNER JOIN lab_issledovaniya ON pokazat_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE dannye_lab_issled.id_pacienta = @ID AND dannye_lab_issled.date_proved = @Value1
AND lab_issledovaniya.id_lab_issledovaniya = @Value2;";

        public string Select_Otdeleniya_InstrIssl = $@"SELECT instr_otdeleniya.id_instr_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM instr_otdeleniya INNER JOIN otdeleniya ON instr_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN instr_issledovaniya ON instr_otdeleniya.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_InstrIssl = $@"SELECT instr_issledovaniya.id_instr_issledovaniya, instr_issledovaniya.naimenovanie AS 'Наименование исследования'
        FROM instr_issledovaniya;";

        public string Select_InstrIssl_ComboBox = $@"SELECT naimenovanie FROM instr_issledovaniya;";

        public string Select_Diagnozy = $@"SELECT diagnozy.id_diagnoza, diagnozy.naimenovanie AS 'Наименование исследования'
        FROM diagnozy;";

        public string Select_Diagnozy_ComboBox = $@"SELECT naimenovanie FROM diagnozy;";

        public string Select_ID_Diagnozy_ComboBox = $@"SELECT id_diagnoza FROM diagnozy WHERE naimenovanie = @Value1;";

        public string Select_Lechenie = $@"SELECT lechenie.id_lecheniya, preparaty.naimenovanie AS 'Наименование препарата', preparaty.farm_svoistva AS 'Фармакологические свойства' 
FROM lechenie INNER JOIN preparaty ON lechenie.id_preparata = preparaty.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
WHERE diagnozy.id_diagnoza = @ID;";

        public string Select_Perenesennye_Operacii = $@"SELECT id_operacii, date_provedeniya AS 'Дата проведения', provedeno AS 'Проведено (действия)', commentariy AS 'Послеоперационный период'
FROM perenesennye_operacii INNER JOIN epikrizy ON perenesennye_operacii.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Epikrizy = $@"SELECT id_epikriza, CONCAT('Эпикриз №',id_epikriza) AS '', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Пациент (Ф.И.О.)', date_n AS 'Дата начала лечения',
date_k AS 'Дата окончания лечения', otdeleniya.naimenovanie AS 'Наименование отделения'
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya;";

        public string Select_Edit_Epikrizy = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT(CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo, ' ',
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y')),';', date_n,';',
date_k,';', otdeleniya.naimenovanie,';', sost_vypiski,';',lvn_n,';',lvn_k,';',recomendacii,';',lech_vrach)
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE id_epikriza = @ID;";

        public string Select_Dianozy_Pacienta = $@"SELECT id_diagnoza_pacienta, diagnozy.naimenovanie AS 'Наименование диагноза', commentariy AS 'Комментарий', zaklucheniye AS 'Является заключением'
FROM diagnozy_pacienta INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Proved_LabIssl = $@"SELECT DISTINCT lab_issledovaniya.id_lab_issledovaniya, lab_issledovaniya.naimenovanie AS 'Наименование', dannye_lab_issled.date_proved AS 'Дата проведения' 
FROM lab_issledovaniya
INNER JOIN pokazat_lab_issled ON lab_issledovaniya.id_lab_issledovaniya = pokazat_lab_issled.id_lab_issledovaniya
INNER JOIN dannye_lab_issled ON pokazat_lab_issled.id_pokazat_lab_issled = dannye_lab_issled.id_pokazat_lab_issled
WHERE dannye_lab_issled.id_pacienta = '1' AND dannye_lab_issled.date_proved BETWEEN @Value1 AND @Value2;";
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

        public string Insert_Dannye_LabIssl = $@"INSERT INTO dannye_lab_issled (id_pacienta, id_pokazat_lab_issled, date_proved, znachenie, commentariy) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Otdeleniya_LabIssl = $@"INSERT INTO lab_otdeleniya (id_lab_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_InstrIssl = $@"INSERT INTO instr_issledovaniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Pokazat_InstrIssl = $@"INSERT INTO pokazat_instr_issled (id_instr_issledovaniya, naimenovanie, ed_izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Otdeleniya_InstrIssl = $@"INSERT INTO instr_otdeleniya (id_instr_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_Diagnozy = $@"INSERT INTO diagnozy (naimenovanie) VALUES (@Value1);";

        public string Insert_Lechenie = $@"INSERT INTO lechenie (id_diagnoza, id_preparata) VALUES (@Value1, @Value2);";

        public string Insert_Perenesennye_Operacii = $@"INSERT INTO perenesennye_operacii (id_epikriza, date_provedeniya, provedeno, commentariy) VALUES (@Value1, @Value2, @Value3, @Value4);";

        public string Insert_Epikrizy = $@"INSERT INTO epikrizy (id_pacienta, date_n, date_k, id_otdeleniya, sost_vypiski, lvn_n, lvn_k, recomendacii, lech_vrach) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9);";

        public string Insert_Diagnozy_Pacienta = $@"INSERT INTO diagnozy_pacienta (id_epikriza, id_diagnoza, commentariy, zaklucheniye) VALUES (@Value1, @Value2, @Value3, @Value4);";
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

        public string Update_Dannye_labIssl = $@"UPDATE dannye_lab_issled SET znachenie = @Value1, commentariy = @Value2 WHERE id_dannyh_lab_issled = @ID;";

        public string Update_Otdeleniya_LabIssl = $@"UPDATE lab_otdeleniya SET id_lab_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_lab_otdeleniya = @ID;";

        public string Update_InstrIssl = $@"UPDATE instr_issledovaniya SET naimenovanie = @Value1 WHERE id_instr_issledovaniya = @ID;";

        public string Update_Pokazat_InstrIssl = $@"UPDATE pokazat_instr_issled SET id_instr_issledovaniya = @Value1, naimenovanie = @Value2, ed_izm = @Value3 WHERE id_pokazat_instr_issled = @ID;";

        public string Update_Otdeleniya_InstrIssl = $@"UPDATE instr_otdeleniya SET id_instr_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_instr_otdeleniya = @ID;";

        public string Update_Diagnozy = $@"UPDATE diagnozy SET naimenovanie = @Value1 WHERE id_diagnoza = @ID;";

        public string Update_Lechenie = $@"UPDATE lechenie SET id_diagnoza = @Value1, id_preparata = @Value2 WHERE id_lecheniya = @ID;";

        public string Update_Perenesennye_Operacii = $@"UPDATE perenesennye_operacii SET id_epikriza = @Value1, date_provedeniya = @Value2, provedeno = @Value3, commentariy = @Value4 WHERE id_operacii = @ID;";

        public string Update_Epikrizy = $@"UPDATE epikrizy SET id_pacienta = @Value1, date_n = @Value2, date_k = @Value3, id_otdeleniya = @Value4, sost_vypiski = @Value5, lvn_n = @Value6, lvn_k = @Value7, recomendacii = @Value8, lech_vrach = @Value9 WHERE id_epikriza = @ID;";
        
        public string Update_Diagnozy_Pacienta = $@"UPDATE diagnozy_pacienta SET id_epikriza = @Value1, id_diagnoza = @Value2, commentariy = @Value3, zaklucheniye = @Value4 WHERE id_diagnoza_pacienta = @ID;";
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

        public string Delete_Perenesennye_Operacii = $@"DELETE FROM perenesennye_operacii WHERE id_operacii = @ID;";

        public string Delete_Epikrizy = $@"DELETE FROM epikrizy WHERE id_epikriza = @ID;";
        
        public string Delete_Diagnozy_Pacienta = $@"DELETE FROM diagnozy_pacienta WHERE id_diagnoza_pacienta = @ID";
        //Delete
    }
}
