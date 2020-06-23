using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing.Printing;
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

        public string Exists_Dop_Sved = $@"SELECT EXISTS(SELECT * FROM dop_sved WHERE id_epikriza = @ID);";

        public string Exists_Epikrizy = $@"SELECT EXISTS(SELECT 8 FROM epikrizy WHERE id_pacienta = @ID AND date_n = @Value1 AND date_k = @Value2 AND id_otdeleniya = @Value3 AND lvn_n = @Value4 AND lvn_k = @Value5 AND lech_vrach = @Value6);";

        public string Exists_Diagnozy_Pacienty = $@"SELECT EXISTS(SELECT * FROM diagnozy_pacienta WHERE id_epikriza = @ID AND id_diagnoza = @Value1);";

        public string Exists_Diagnozy_Pacienty_Edit = $@"SELECT EXISTS(SELECT * FROM diagnozy_pacienta WHERE id_epikriza = @ID AND id_diagnoza = @Value1 AND commentariy = @Value2 AND zaklucheniye = @Value3)";

        public string Exists_Perenesennye_Operacii = $@"SELECT EXISTS(SELECT * FROM perenesennye_operacii WHERE id_epikriza = @ID AND date_provedeniya = @Value1 AND provedeno = @Value2 AND commentariy = @Value3);";

        public string Exists_Proved_LabIssl = $@"SELECT EXISTS(SELECT * FROM proved_lab_issled WHERE id_epikriza = @ID AND id_lab_issledovaniya = @Value1 AND date_proved = @Value2);";

        public string Exists_Proved_InstrIssl = $@"SELECT EXISTS(SELECT * FROM proved_instr_issled WHERE id_epikriza = @ID AND id_instr_issledovaniya = @Value1 AND date_proved = @Value2);";
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
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y') AS 'Дата рождения', pol AS 'Пол', pacienty.adress_projivaniya AS 'Адрес проживания', gcgp.nom_filiala AS 'Филиал ГЦГП'
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

        public string Select_Otdeleniya_LabIssl = $@"SELECT lab_otdeleniya.id_lab_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM lab_otdeleniya INNER JOIN otdeleniya ON lab_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN lab_issledovaniya ON lab_otdeleniya.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_LabIssl = $@"SELECT lab_issledovaniya.id_lab_issledovaniya, lab_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM lab_issledovaniya;";

        public string Select_LabIssl_ComboBox = $@"SELECT lab_issledovaniya.naimenovanie FROM lab_issledovaniya INNER JOIN lab_otdeleniya ON lab_issledovaniya.id_lab_issledovaniya = lab_otdeleniya.id_lab_issledovaniya
WHERE lab_otdeleniya.id_otdeleniya = @Value1;";

        public string Select_ID_LabIssl_ComboBox = $@"SELECT id_lab_issledovaniya FROM lab_issledovaniya WHERE naimenovanie = @Value1;";

        public string Select_Pokazat_LabIssl_Insert_Epikrizy = $@"SELECT id_pokazat_lab_issled, naimenovanie AS 'Наименование', NULL AS 'Значение', ed_izm AS 'Ед. изм.', NULL AS 'Комментарий'
FROM pokazat_lab_issled
WHERE id_lab_issledovaniya = @ID;";

        public string Select_Dannye_LabIssl = $@"SELECT id_dannyh_lab_issled, pokazat_lab_issled.naimenovanie AS 'Наименование', znachenie AS 'Значение', pokazat_lab_issled.ed_izm AS 'Ед. изм.', commentariy AS 'Комментарий'
FROM dannye_lab_issled INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
INNER JOIN proved_lab_issled ON dannye_lab_issled.id_proved_lab_issled = proved_lab_issled.id_proved_lab_issled
WHERE proved_lab_issled.id_proved_lab_issled = @ID;";

        public string Select_Edit_Dannye_LabIssl = $@"SELECT dannye_lab_issled.id_dannyh_lab_issled, pokazat_lab_issled.naimenovanie, dannye_lab_issled.znachenie,pokazat_lab_issled.ed_izm,dannye_lab_issled.commentariy
FROM dannye_lab_issled INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
INNER JOIN pacienty ON dannye_lab_issled.id_pacienta = pacienty.id_pacienta
INNER JOIN lab_issledovaniya ON pokazat_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE dannye_lab_issled.id_pacienta = @ID AND dannye_lab_issled.date_proved = @Value1
AND lab_issledovaniya.id_lab_issledovaniya = @Value2;";

        public string Select_Pokazat_InstrIssl = $@"SELECT pokazat_instr_issled.id_pokazat_instr_issled, pokazat_instr_issled.naimenovanie AS 'Наименование', pokazat_instr_issled.ed_izm AS 'Ед. Изм.' 
FROM pokazat_instr_issled INNER JOIN instr_issledovaniya ON pokazat_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_Otdeleniya_InstrIssl = $@"SELECT instr_otdeleniya.id_instr_otdeleniya, otdeleniya.naimenovanie AS 'Наименование отделения'
FROM instr_otdeleniya INNER JOIN otdeleniya ON instr_otdeleniya.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN instr_issledovaniya ON instr_otdeleniya.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_InstrIssl = $@"SELECT instr_issledovaniya.id_instr_issledovaniya, instr_issledovaniya.naimenovanie AS 'Наименование исследования'
        FROM instr_issledovaniya;";

        public string Select_InstrIssl_ComboBox = $@"SELECT naimenovanie FROM instr_issledovaniya;";

        public string Select_ID_InstrIssl_ComboBox = $@"SELECT id_instr_issledovaniya FROM instr_issledovaniya WHERE naimenovanie = @Value1;";

        public string Select_Diagnozy = $@"SELECT diagnozy.id_diagnoza, diagnozy.naimenovanie AS 'Наименование диагноза'
        FROM diagnozy;";

        public string Select_Diagnozy_ComboBox = $@"SELECT naimenovanie FROM diagnozy;";

        public string Select_ID_Diagnozy_ComboBox = $@"SELECT id_diagnoza FROM diagnozy WHERE naimenovanie = @Value1;";
        
        public string Select_Pokazat_InstrIssl_Insert_Epikrizy = $@"SELECT id_pokazat_instr_issled, naimenovanie AS 'Наименование', NULL AS 'Значение', ed_izm AS 'Ед. изм.', NULL AS 'Комментарий'
FROM pokazat_instr_issled
WHERE id_instr_issledovaniya = @ID;";

        public string Select_Dannye_InstrIssl = $@"SELECT id_dannyh_instr_issled, pokazat_instr_issled.naimenovanie AS 'Наименование', znachenie AS 'Значение', pokazat_instr_issled.ed_izm AS 'Ед. изм.', commentariy AS 'Комментарий'
FROM dannye_instr_issled INNER JOIN pokazat_instr_issled ON dannye_instr_issled.id_pokazat_instr_issled = pokazat_instr_issled.id_pokazat_instr_issled
INNER JOIN proved_instr_issled ON dannye_instr_issled.id_proved_instr_issled = proved_instr_issled.id_proved_instr_issled
WHERE proved_instr_issled.id_proved_instr_issled = @ID;";

        public string Select_Edit_Dannye_InstrIssl = $@"SELECT dannye_instr_issled.id_dannyh_instr_issled, pokazat_instr_issled.naimenovanie, dannye_instr_issled.znachenie,pokazat_instr_issled.ed_izm,dannye_instr_issled.commentariy
FROM dannye_instr_issled INNER JOIN pokazat_instr_issled ON dannye_instr_issled.id_pokazat_instr_issled = pokazat_instr_issled.id_pokazat_instr_issled
INNER JOIN pacienty ON dannye_instr_issled.id_pacienta = pacienty.id_pacienta
INNER JOIN instr_issledovaniya ON pokazat_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE dannye_instr_issled.id_pacienta = @ID AND dannye_instr_issled.date_proved = @Value1
AND instr_issledovaniya.id_instr_issledovaniya = @Value2;";

        public string Select_Lechenie = $@"SELECT lechenie.id_lecheniya, preparaty.naimenovanie AS 'Наименование препарата', preparaty.farm_svoistva AS 'Фармакологические свойства' 
FROM lechenie INNER JOIN preparaty ON lechenie.id_preparata = preparaty.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
WHERE diagnozy.id_diagnoza = @ID;";

        public string Select_Perenesennye_Operacii = $@"SELECT id_operacii, date_provedeniya AS 'Дата проведения', provedeno AS 'Проведено (действия)', commentariy AS 'Послеоперационный период'
FROM perenesennye_operacii INNER JOIN epikrizy ON perenesennye_operacii.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Epikrizy = $@"SELECT id_epikriza, CONCAT('Эпикриз №',id_epikriza) AS 'Номер П/П', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Пациент (Ф.И.О.)', date_n AS 'Дата начала лечения',
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

        public string Select_Proved_LabIssl = $@"SELECT id_proved_lab_issled, lab_issledovaniya.naimenovanie AS 'Наименование', date_proved AS 'Дата проведения'
FROM proved_lab_issled INNER JOIN lab_issledovaniya ON proved_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Proved_InstrIssl = $@"SELECT id_proved_instr_issled, instr_issledovaniya.naimenovanie AS 'Наименование', date_proved AS 'Дата проведения'
FROM proved_instr_issled INNER JOIN instr_issledovaniya ON proved_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Dop_Sved = $@"SELECT CONCAT(ad, ';', gen_anam, ';', smoking, ';', alco, ';', imt, ';', cholesterin, ';', blood, ';', urina, ';', ekg, ';', skore, ';', vgd, ';', predstat, ';', mol, ';', flura, ';', glukoza, ';', suicide) FROM dop_sved WHERE id_epikriza = @ID;";
        //Select

        //Filter
        public string Select_Otdeleniya_Filter = $@"SELECT id_otdeleniya, naimenovanie AS 'Наименование отделения' FROM otdeleniya WHERE naimenovanie LIKE @Value1;";

        public string Select_Doljnosti_Filter = $@"SELECT id_doljnosti, naimenovanie AS 'Наименование должности' FROM doljnosti WHERE naimenovanie LIKE @Value1;";

        public string Select_Preparaty_Filter = $@"SELECT id_preparata, naimenovanie AS 'Наименование препарата', farm_svoistva AS 'Фармакологические свойства' FROM preparaty WHERE naimenovanie LIKE @Value1 OR farm_svoistva LIKE @Value1;";

        public string Select_Personal_Filter = $@"SELECT personal.id_personala, CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo) AS 'Ф.И.О. Сотрудника', 
otdeleniya.naimenovanie AS 'Наименование отделения', doljnosti.naimenovanie AS 'Наименование должности'
FROM personal INNER JOIN otdeleniya ON personal.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN doljnosti ON personal.id_doljnosti = doljnosti.id_doljnosti
WHERE CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo) LIKE @Value1 OR 
otdeleniya.naimenovanie LIKE @Value1 OR doljnosti.naimenovanie LIKE @Value1;";

        public string Select_Pacienty_Filter = $@"SET lc_time_names = 'ru_RU';
SELECT pacienty.id_pacienta, CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', 
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y') AS 'Дата рождения', pol AS 'Пол', pacienty.adress_projivaniya AS 'Адрес проживания', gcgp.nom_filiala AS 'Филиал ГЦГП'
FROM pacienty INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp
WHERE CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) LIKE @Value1 OR 
DATE_FORMAT(pacienty.data_rojdeniya,'%d %M %Y') LIKE @Value1 OR pol LIKE @Value1 OR pacienty.adress_projivaniya LIKE @Value1 OR gcgp.nom_filiala LIKE @Value1;";
        
        public string Select_Gcgp_Filter = $@"SELECT id_gcgp, nom_filiala AS 'Номер филиала', adress AS 'Адрес' FROM gcgp WHERE nom_filiala LIKE @Value1;";

        public string Select_LabIssl_Filter = $@"SELECT lab_issledovaniya.id_lab_issledovaniya, lab_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM lab_issledovaniya
WHERE naimenovanie LIKE @Value1;";

        public string Select_InstrIssl_Filter = $@"SELECT instr_issledovaniya.id_instr_issledovaniya, instr_issledovaniya.naimenovanie AS 'Наименование исследования'
        FROM instr_issledovaniya
WHERE naimenovanie LIKE @Value1;";

        public string Select_Diagnozy_Filter = $@"SELECT diagnozy.id_diagnoza, diagnozy.naimenovanie AS 'Наименование диагноза'
FROM diagnozy
WHERE naimenovanie LIKE @Value1;";

        public string Select_Epikrizy_Filter = $@"SELECT id_epikriza, CONCAT('Эпикриз №',id_epikriza) AS 'Номер П/П', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Пациент (Ф.И.О.)', date_n AS 'Дата начала лечения',
date_k AS 'Дата окончания лечения', otdeleniya.naimenovanie AS 'Наименование отделения'
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) LIKE @Value1 OR date_n LIKE @Value1 OR
date_k LIKE @Value1 OR otdeleniya.naimenovanie LIKE @Value1;";
        //Filter

        //Select Add Panel
        public string Select_Lab_Otdeleniya_Add = $@"SELECT lab_issledovaniya.naimenovanie AS 'Наименование исследования' FROM lab_issledovaniya
INNER JOIN lab_otdeleniya ON lab_issledovaniya.id_lab_issledovaniya = lab_otdeleniya.id_lab_issledovaniya
WHERE lab_otdeleniya.id_otdeleniya = @ID;";

        public string Select_Instr_Otdeleniya_Add = $@"SELECT instr_issledovaniya.naimenovanie AS 'Наименование исследования' FROM instr_issledovaniya
INNER JOIN instr_otdeleniya ON instr_issledovaniya.id_instr_issledovaniya = instr_otdeleniya.id_instr_issledovaniya
WHERE instr_otdeleniya.id_otdeleniya = @ID;";

        public string Select_Pacienty_Add = $@"SELECT CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента'
FROM pacienty INNER JOIN epikrizy ON pacienty.id_pacienta = epikrizy.id_pacienta
INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE otdeleniya.id_otdeleniya = @ID;";

        public string Select_Epikrizy_Add = $@"SELECT CONCAT('Эпикризы №', epikrizy.id_epikriza) AS 'Номер эпикриза', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', epikrizy.date_n AS 'Начало лечения', epikrizy.date_k AS 'Окончание лечения'
FROM epikrizy INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE otdeleniya.id_otdeleniya = @ID;";

        public string Select_Diagnozy_Add = $@"SELECT diagnozy.naimenovanie AS 'Наименование диагноза'
FROM diagnozy INNER JOIN lechenie ON diagnozy.id_diagnoza = lechenie.id_diagnoza
INNER JOIN preparaty ON lechenie.id_preparata = preparaty.id_preparata
WHERE preparaty.id_preparata = @ID;";

        public string Select_Pacienty_Add_2 = $@"SELECT CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента'
FROM pacienty INNER JOIN epikrizy ON pacienty.id_pacienta = epikrizy.id_pacienta
INNER JOIN diagnozy_pacienta ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN lechenie ON lechenie.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN preparaty ON preparaty.id_preparata = lechenie.id_preparata
WHERE preparaty.id_preparata = @ID
GROUP BY pacienty.id_pacienta;";

        public string Select_Epikrizy_Add_2 = $@"SELECT CONCAT('Эпикризы №', epikrizy.id_epikriza) AS 'Номер эпикриза', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', epikrizy.date_n AS 'Начало лечения', epikrizy.date_k AS 'Окончание лечения'
FROM epikrizy INNER JOIN diagnozy_pacienta ON  diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN lechenie ON diagnozy.id_diagnoza = lechenie.id_diagnoza
INNER JOIN preparaty ON lechenie.id_preparata = preparaty.id_preparata
WHERE preparaty.id_preparata = @ID;";

        public string Select_Diagnozy_Add_2 = $@"SELECT diagnozy.naimenovanie AS 'Наименование диагноза'
FROM diagnozy INNER JOIN diagnozy_pacienta ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN epikrizy ON epikrizy.id_epikriza = diagnozy_pacienta.id_epikriza
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID
GROUP BY diagnozy.id_diagnoza;";

        public string Select_Epikrizy_Add_3 = $@"SELECT CONCAT('Эпикризы №', epikrizy.id_epikriza) AS 'Номер эпикриза', CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента', epikrizy.date_n AS 'Начало лечения', epikrizy.date_k AS 'Окончание лечения'
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID;";

        public string Select_Perenes_Operacii_Add = $@"SELECT perenesennye_operacii.date_provedeniya AS 'Дата проведения', perenesennye_operacii.provedeno AS 'Проведено', perenesennye_operacii.commentariy AS 'Комментарий'
FROM perenesennye_operacii INNER JOIN epikrizy ON perenesennye_operacii.id_epikriza = epikrizy.id_epikriza
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID;";

        public string Select_Otdeleniya_Add = $@"SELECT otdeleniya.naimenovanie AS 'Наименование отделения'
FROM otdeleniya INNER JOIN epikrizy ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID
GROUP BY otdeleniya.id_otdeleniya;";

        public string Select_Lab_Issl_Add = $@"SET lc_time_names = 'ru_RU';
SELECT lab_issledovaniya.naimenovanie AS 'Наименование исследования', DATE_FORMAT(proved_lab_issled.date_proved, '%d %M %Y') AS 'Дата проведения'
FROM lab_issledovaniya INNER JOIN proved_lab_issled ON lab_issledovaniya.id_lab_issledovaniya = proved_lab_issled.id_lab_issledovaniya
INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID;";

        public string Select_Instr_Issl_Add = $@"SET lc_time_names = 'ru_RU';
SELECT instr_issledovaniya.naimenovanie AS 'Наименование исследования', DATE_FORMAT(proved_instr_issled.date_proved, '%d %M %Y') AS 'Дата проведения'
FROM instr_issledovaniya INNER JOIN proved_instr_issled ON instr_issledovaniya.id_instr_issledovaniya = proved_instr_issled.id_instr_issledovaniya
INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE pacienty.id_pacienta = @ID;";

        public string Select_Pacienty_Add_3 = $@"SELECT CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo) AS 'Ф.И.О. Пациента'
FROM pacienty INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp
WHERE gcgp.id_gcgp = @ID;";

        public string Select_Pokazat_Lab_Issl_Add = $@"SELECT pokazat_lab_issled.naimenovanie AS 'Наименование показателя', pokazat_lab_issled.ed_izm AS 'Ед. изм.'
FROM pokazat_lab_issled INNER JOIN lab_issledovaniya ON pokazat_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE lab_issledovaniya.id_lab_issledovaniya = @ID;";

        public string Select_Pokazat_Instr_Issl_Add = $@"SELECT pokazat_instr_issled.naimenovanie AS 'Наименование показателя', pokazat_instr_issled.ed_izm AS 'Ед. изм.'
FROM pokazat_instr_issled INNER JOIN instr_issledovaniya ON pokazat_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE instr_issledovaniya.id_instr_issledovaniya = @ID;";

        public string Select_Preparaty_Add = $@"SELECT preparaty.naimenovanie AS 'Наименование препарата', preparaty.farm_svoistva AS 'Фарм. свойства'
FROM preparaty INNER JOIN lechenie ON preparaty.id_preparata = lechenie.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
WHERE diagnozy.id_diagnoza = @ID;";

        public string Select_Lab_Issl_Add_2 = $@"SELECT lab_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM lab_issledovaniya INNER JOIN proved_lab_issled ON lab_issledovaniya.id_lab_issledovaniya = proved_lab_issled.id_lab_issledovaniya
INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Instr_Issl_Add_2 = $@"SELECT instr_issledovaniya.naimenovanie AS 'Наименование исследования'
FROM instr_issledovaniya INNER JOIN proved_instr_issled ON instr_issledovaniya.id_instr_issledovaniya = proved_instr_issled.id_instr_issledovaniya
INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Select_Diagnozy_Add_3 = $@"SELECT diagnozy.naimenovanie AS 'Наименование диагноза'
FROM diagnozy INNER JOIN diagnozy_pacienta ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID
GROUP BY diagnozy.id_diagnoza;";

        public string Select_Preparaty_Add_2 = $@"SELECT preparaty.naimenovanie AS 'Наименование препарата', preparaty.farm_svoistva AS 'Фарм. свойства'
FROM preparaty INNER JOIN lechenie ON preparaty.id_preparata = lechenie.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN diagnozy_pacienta ON diagnozy.id_diagnoza = diagnozy_pacienta.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID
GROUP BY preparaty.id_preparata;";
        //Select Add Panel

        //Insert
        public string Insert_Otdeleniya = $@"INSERT INTO otdeleniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Doljnosti = $@"INSERT INTO doljnosti (naimenovanie) VALUES (@Value1);";

        public string Insert_Preparaty = $@"INSERT INTO preparaty (naimenovanie, farm_svoistva) VALUES (@Value1, @Value2);";

        public string Insert_Gcgp = $@"INSERT INTO gcgp (nom_filiala, adress) VALUES (@Value1, @Value2);";

        public string Insert_Personal = $@"INSERT INTO personal (familiya, imya, otchestvo, id_otdeleniya, id_doljnosti) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Pacienty = $@"INSERT INTO pacienty (familiya, imya, otchestvo, data_rojdeniya, pol, adress_projivaniya, id_gcgp) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7);";

        public string Insert_LabIssl = $@"INSERT INTO lab_issledovaniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Pokazat_LabIssl = $@"INSERT INTO pokazat_lab_issled (id_lab_issledovaniya, naimenovanie, ed_izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Dannye_LabIssl = $@"INSERT INTO dannye_lab_issled (id_proved_lab_issled, id_pokazat_lab_issled, znachenie, commentariy) VALUES (@Value1, @Value2, @Value3, @Value4);";

        public string Insert_Proved_LabIssl = $@"INSERT INTO proved_lab_issled (id_epikriza, id_lab_issledovaniya, date_proved) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Otdeleniya_LabIssl = $@"INSERT INTO lab_otdeleniya (id_lab_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_InstrIssl = $@"INSERT INTO instr_issledovaniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Pokazat_InstrIssl = $@"INSERT INTO pokazat_instr_issled (id_instr_issledovaniya, naimenovanie, ed_izm) VALUES (@Value1, @Value2, @Value3);";
        
        public string Insert_Dannye_InstrIssl = $@"INSERT INTO dannye_instr_issled (id_proved_instr_issled, id_pokazat_instr_issled, znachenie, commentariy) VALUES (@Value1, @Value2, @Value3, @Value4);";

        public string Insert_Proved_InstrIssl = $@"INSERT INTO proved_instr_issled (id_epikriza, id_instr_issledovaniya, date_proved) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Otdeleniya_InstrIssl = $@"INSERT INTO instr_otdeleniya (id_instr_issledovaniya, id_otdeleniya) VALUES (@Value1, @Value2);";

        public string Insert_Diagnozy = $@"INSERT INTO diagnozy (naimenovanie) VALUES (@Value1);";

        public string Insert_Lechenie = $@"INSERT INTO lechenie (id_diagnoza, id_preparata) VALUES (@Value1, @Value2);";

        public string Insert_Perenesennye_Operacii = $@"INSERT INTO perenesennye_operacii (id_epikriza, date_provedeniya, provedeno, commentariy) VALUES (@Value1, @Value2, @Value3, @Value4);";

        public string Insert_Epikrizy = $@"INSERT INTO epikrizy (id_pacienta, date_n, date_k, id_otdeleniya, sost_vypiski, lvn_n, lvn_k, recomendacii, lech_vrach) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9);";

        public string Insert_Diagnozy_Pacienta = $@"INSERT INTO diagnozy_pacienta (id_epikriza, id_diagnoza, commentariy, zaklucheniye) VALUES (@Value1, @Value2, @Value3, @Value4);";

        public string Insert_Dop_Sved = $@"INSERT INTO dop_sved (id_epikriza, ad, gen_anam, smoking, alco, imt, cholesterin, blood, urina, ekg, skore, vgd, predstat, mol, flura, glukoza, suicide) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value17, @Value8, @Value9, @Value10, @Value11, @Value12, @Value13, @Value14, @Value15, @Value16, @Value17);";
        //Insert

        //Update
        public string Update_Otdeleniya = $@"UPDATE otdeleniya SET naimenovanie = @Value1 WHERE id_otdeleniya = @ID;";

        public string Update_Doljnosti = $@"UPDATE doljnosti SET naimenovanie = @Value1 WHERE id_doljnosti = @ID;";

        public string Update_Preparaty = $@"UPDATE preparaty SET naimenovanie = @Value1, farm_svoistva = @Value2 WHERE id_preparata = @ID;";

        public string Update_Gcgp = $@"UPDATE gcgp SET nom_filiala = @Value1, adress = @Value2 WHERE id_gcgp = @ID;";

        public string Update_Personal = $@"UPDATE personal SET familiya = @Value1, imya = @Value2, otchestvo = @Value3, id_otdeleniya = @Value4, id_doljnosti = @Value5 WHERE id_personala = @ID;";

        public string Update_Pacienty = $@"UPDATE pacienty SET familiya = @Value1, imya = @Value2, otchestvo = @Value3, data_rojdeniya = @Value4, pol = @Value5, adress_projivaniya = @Value6, id_gcgp = @Value7 WHERE id_pacienta = @ID;";

        public string Update_LabIssl = $@"UPDATE lab_issledovaniya SET naimenovanie = @Value1 WHERE id_lab_issledovaniya = @ID;";

        public string Update_Pokazat_LabIssl = $@"UPDATE pokazat_lab_issled SET id_lab_issledovaniya = @Value1, naimenovanie = @Value2, ed_izm = @Value3 WHERE id_pokazat_lab_issled = @ID;";

        public string Update_Dannye_LabIssl = $@"UPDATE dannye_lab_issled SET znachenie = @Value1, commentariy = @Value2 WHERE id_dannyh_lab_issled = @ID;";

        public string Update_Proved_LabIssl = $@"UPDATE proved_lab_issled SET id_epikriza = @Value1, date_proved = @Value2 WHERE id_proved_lab_issled = @ID;";

        public string Update_Otdeleniya_LabIssl = $@"UPDATE lab_otdeleniya SET id_lab_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_lab_otdeleniya = @ID;";

        public string Update_InstrIssl = $@"UPDATE instr_issledovaniya SET naimenovanie = @Value1 WHERE id_instr_issledovaniya = @ID;";

        public string Update_Pokazat_InstrIssl = $@"UPDATE pokazat_instr_issled SET id_instr_issledovaniya = @Value1, naimenovanie = @Value2, ed_izm = @Value3 WHERE id_pokazat_instr_issled = @ID;";

        public string Update_Dannye_InstrIssl = $@"UPDATE dannye_instr_issled SET znachenie = @Value1, commentariy = @Value2 WHERE id_dannyh_instr_issled = @ID;";

        public string Update_Proved_InstrIssl = $@"UPDATE proved_instr_issled SET id_epikriza = @Value1, date_proved = @Value2 WHERE id_proved_instr_issled = @ID;";

        public string Update_Otdeleniya_InstrIssl = $@"UPDATE instr_otdeleniya SET id_instr_issledovaniya = @Value1, id_otdeleniya = @Value2 WHERE id_instr_otdeleniya = @ID;";

        public string Update_Diagnozy = $@"UPDATE diagnozy SET naimenovanie = @Value1 WHERE id_diagnoza = @ID;";

        public string Update_Lechenie = $@"UPDATE lechenie SET id_diagnoza = @Value1, id_preparata = @Value2 WHERE id_lecheniya = @ID;";

        public string Update_Perenesennye_Operacii = $@"UPDATE perenesennye_operacii SET id_epikriza = @Value1, date_provedeniya = @Value2, provedeno = @Value3, commentariy = @Value4 WHERE id_operacii = @ID;";

        public string Update_Epikrizy = $@"UPDATE epikrizy SET id_pacienta = @Value1, date_n = @Value2, date_k = @Value3, id_otdeleniya = @Value4, sost_vypiski = @Value5, lvn_n = @Value6, lvn_k = @Value7, recomendacii = @Value8, lech_vrach = @Value9 WHERE id_epikriza = @ID;";
        
        public string Update_Diagnozy_Pacienta = $@"UPDATE diagnozy_pacienta SET id_epikriza = @Value1, id_diagnoza = @Value2, commentariy = @Value3, zaklucheniye = @Value4 WHERE id_diagnoza_pacienta = @ID;";

        public string Update_Dop_Sved = $@"UPDATE dop_sved SET ad = @Value1, gen_anam = @Value2, smoking = @Value3, alco = @Value4, imt = @Value5, cholesterin = @Value6, blood = @Value7, urina = @Value8, ekg = @Value9, skore = @Value10, vgd = @Value11, predstat = @Value12, mol = @Value13, flura = @Value14, glukoza = @Value15, suicide = @Value16 WHERE id_epikriza = @ID;";
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

        public string Delete_Proved_LabIssl = $@"DELETE FROM proved_lab_issled WHERE id_proved_lab_issled = @ID;";

        public string Delete_Otdeleniya_LabIssl = $@"DELETE FROM lab_otdeleniya WHERE id_lab_otdeleniya = @ID;";

        public string Delete_InstrIssl = $@"DELETE FROM instr_issledovaniya WHERE id_instr_issledovaniya = @ID";

        public string Delete_Pokazat_InstrIssl = $@"DELETE FROM pokazat_instr_issled WHERE id_pokazat_instr_issled = @ID;";

        public string Delete_Proved_InstrIssl = $@"DELETE FROM proved_instr_issled WHERE id_proved_instr_issled = @ID;";

        public string Delete_Otdeleniya_InstrIssl = $@"DELETE FROM instr_otdeleniya WHERE id_instr_otdeleniya = @ID;";

        public string Delete_Diagnozy = $@"DELETE FROM diagnozy WHERE id_diagnoza = @ID";

        public string Delete_Lechenie = $@"DELETE FROM lechenie WHERE id_lecheniya = @ID;";

        public string Delete_Perenesennye_Operacii = $@"DELETE FROM perenesennye_operacii WHERE id_operacii = @ID;";

        public string Delete_Epikrizy = $@"DELETE FROM epikrizy WHERE id_epikriza = @ID;";
        
        public string Delete_Diagnozy_Pacienta = $@"DELETE FROM diagnozy_pacienta WHERE id_diagnoza_pacienta = @ID";
        //Delete

        //Print Epikrizy
        public string Print_Epikrizy = $@"SELECT CONCAT(CONCAT('Выписной эпикриз №',id_epikriza,' пациента ',
CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo)),';',id_epikriza,';', 
CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo,' ', DATE_FORMAT(pacienty.data_rojdeniya, '%d.%m.%Y'), ' года рождения'),';', 
pacienty.adress_projivaniya, ';', gcgp.nom_filiala,';', otdeleniya.naimenovanie,';', DATE_FORMAT(date_n, '%d.%m.%Y'),';', DATE_FORMAT(date_k, '%d.%m.%Y'),';', 
sost_vypiski,';', DATE_FORMAT(lvn_n, '%d.%m.%Y'),';', DATE_FORMAT(lvn_k, '%d.%m.%Y'),';',recomendacii,';',lech_vrach)
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp
INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Diagnozy_Pacienta = $@"SELECT CONCAT(diagnozy.naimenovanie,'. ', commentariy,'. ')
FROM diagnozy_pacienta INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Perenesennye_Operacii = $@"SELECT CONCAT(Date_Format(date_provedeniya, '%d.%m.%y'),'г. - ',provedeno,'. Послеоперационный период: ',commentariy, '. ')
FROM perenesennye_operacii INNER JOIN epikrizy ON perenesennye_operacii.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Zaklucheniya_Pacienta = $@"SELECT CONCAT(diagnozy.naimenovanie,'. ', commentariy,'. ')
FROM diagnozy_pacienta INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
WHERE epikrizy.id_epikriza = @ID AND diagnozy_pacienta.zaklucheniye = 'Да';";

        public string Print_Preparaty = $@"SELECT DISTINCT preparaty.naimenovanie FROM preparaty
INNER JOIN lechenie ON preparaty.id_preparata = lechenie.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN diagnozy_pacienta ON diagnozy.id_diagnoza = diagnozy_pacienta.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Dop_Sved = $@"SELECT CONCAT(ad,';',gen_anam,';',smoking,';',alco,';',imt,';',
cholesterin,';',blood,';',urina,';',ekg,';',skore,';',vgd,';',predstat,';',mol,';',flura,';',glukoza,';',suicide)
FROM dop_sved INNER JOIN epikrizy ON dop_sved.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Proved_LabIssl = $@"SELECT proved_lab_issled.id_proved_lab_issled, CONCAT(lab_issledovaniya.naimenovanie,' от ', DATE_FORMAT(date_proved, '%d.%m.%y'),'г. : ')
FROM proved_lab_issled INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN lab_issledovaniya ON proved_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Dannye_LabIssl = $@"SELECT CASE
	WHEN pokazat_lab_issled.ed_izm = '' AND commentariy = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie)
	WHEN pokazat_lab_issled.ed_izm = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', commentariy)
	WHEN commentariy = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', pokazat_lab_issled.ed_izm)
	ELSE CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', pokazat_lab_issled.ed_izm,' ',commentariy)
END
FROM dannye_lab_issled
INNER JOIN proved_lab_issled ON dannye_lab_issled.id_proved_lab_issled = proved_lab_issled.id_proved_lab_issled
INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID AND proved_lab_issled.id_proved_lab_issled = @Value1;";

        public string Print_Proved_InstrIssl = $@"SELECT proved_instr_issled.id_proved_instr_issled, CONCAT(instr_issledovaniya.naimenovanie,' от ', DATE_FORMAT(date_proved, '%d.%m.%y'),'г. : ')
FROM proved_instr_issled INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN instr_issledovaniya ON proved_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE epikrizy.id_epikriza = @ID;";

        public string Print_Dannye_InstrIssl = $@"SELECT CASE
	WHEN pokazat_instr_issled.ed_izm = '' AND commentariy = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie)
	WHEN pokazat_instr_issled.ed_izm = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', commentariy)
	WHEN commentariy = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', pokazat_instr_issled.ed_izm)
	ELSE CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', pokazat_instr_issled.ed_izm,' ',commentariy)
END
FROM dannye_instr_issled
INNER JOIN proved_instr_issled ON dannye_instr_issled.id_proved_instr_issled = proved_instr_issled.id_proved_instr_issled
INNER JOIN pokazat_instr_issled ON dannye_instr_issled.id_pokazat_instr_issled = pokazat_instr_issled.id_pokazat_instr_issled
INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_epikriza = @ID AND proved_instr_issled.id_proved_instr_issled = @Value1;";

        public string Print_Zav_Otdeleniya = $@"SELECT CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo) 
FROM personal 
INNER JOIN otdeleniya ON personal.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN doljnosti ON personal.id_doljnosti = doljnosti.id_doljnosti
INNER JOIN epikrizy ON otdeleniya.id_otdeleniya = epikrizy.id_otdeleniya
WHERE epikrizy.id_epikriza = @ID AND doljnosti.id_doljnosti = 5;";

        public string Select_Pol_Pacienta = $@"SELECT pol 
FROM pacienty INNER JOIN epikrizy ON pacienty.id_pacienta = epikrizy.id_pacienta
WHERE epikrizy.id_epikriza = @ID;";
        //Print Epikrizy

        //Print Kartochka
        public string Print_Kartochka_Pacienta = $@"SELECT CONCAT(CONCAT('Личная карточка №',id_pacienta,' ',CONCAT(familiya,' ',imya,' ',otchestvo,DATE_FORMAT(data_rojdeniya,'%d.%m.%Y'),' года рождения')),';',
id_pacienta,';',CONCAT(pacienty.familiya,' ', pacienty.imya, ' ', pacienty.otchestvo,' ', DATE_FORMAT(pacienty.data_rojdeniya, '%d.%m.%Y')),';',
adress_projivaniya,';',gcgp.nom_filiala)
FROM pacienty INNER JOIN gcgp ON pacienty.id_gcgp = gcgp.id_gcgp
WHERE id_pacienta = @ID;";

        public string Print_Otdeleniya_Pacienta = $@"SELECT CONCAT(otdeleniya.naimenovanie,': с ', DATE_FORMAT(epikrizy.date_n,'%d.%m.%Y'),' по ', DATE_FORMAT(epikrizy.date_k,'%d.%m.%Y'),'. Лечащий врач: ', lech_vrach,'. ')
FROM epikrizy INNER JOIN otdeleniya ON epikrizy.id_otdeleniya = otdeleniya.id_otdeleniya
WHERE id_pacienta = @ID;";

        public string Print_Perenes_Zabol_Pacienta = $@"SELECT CONCAT(diagnozy.naimenovanie,'. ', commentariy,'. ')
FROM diagnozy_pacienta INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
WHERE id_pacienta = @ID AND diagnozy_pacienta.zaklucheniye = 'Да';";

        public string Print_Perenesennye_Operacii_Pacienta = $@"SELECT CONCAT(Date_Format(date_provedeniya, '%d.%m.%y'),'г. - ',provedeno,'. Послеоперационный период: ',commentariy, '. ')
FROM perenesennye_operacii INNER JOIN epikrizy ON perenesennye_operacii.id_epikriza = epikrizy.id_epikriza
WHERE id_pacienta = @ID;";

        public string Print_Preparaty_Pacienta = $@"SELECT DISTINCT preparaty.naimenovanie FROM preparaty
INNER JOIN lechenie ON preparaty.id_preparata = lechenie.id_preparata
INNER JOIN diagnozy ON lechenie.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN diagnozy_pacienta ON diagnozy.id_diagnoza = diagnozy_pacienta.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE id_pacienta = @ID;";
        
        public string Print_Proved_LabIssl_Pacienta = $@"SELECT proved_lab_issled.id_proved_lab_issled, CONCAT(lab_issledovaniya.naimenovanie,' от ', DATE_FORMAT(date_proved, '%d.%m.%y'),'г. : ')
FROM proved_lab_issled INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN lab_issledovaniya ON proved_lab_issled.id_lab_issledovaniya = lab_issledovaniya.id_lab_issledovaniya
WHERE epikrizy.id_pacienta = @ID;";

        public string Print_Dannye_LabIssl_Pacienta = $@"SELECT CASE
	WHEN pokazat_lab_issled.ed_izm = '' AND commentariy = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie)
	WHEN pokazat_lab_issled.ed_izm = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', commentariy)
	WHEN commentariy = ''
		THEN CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', pokazat_lab_issled.ed_izm)
	ELSE CONCAT(pokazat_lab_issled.naimenovanie,' ', znachenie,' ', pokazat_lab_issled.ed_izm,' ',commentariy)
END
FROM dannye_lab_issled
INNER JOIN proved_lab_issled ON dannye_lab_issled.id_proved_lab_issled = proved_lab_issled.id_proved_lab_issled
INNER JOIN pokazat_lab_issled ON dannye_lab_issled.id_pokazat_lab_issled = pokazat_lab_issled.id_pokazat_lab_issled
INNER JOIN epikrizy ON proved_lab_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_pacienta = @ID AND proved_lab_issled.id_proved_lab_issled = @Value1";

        public string Print_Proved_InstrIssl_Pacienta = $@"SELECT proved_instr_issled.id_proved_instr_issled, CONCAT(instr_issledovaniya.naimenovanie,' от ', DATE_FORMAT(date_proved, '%d.%m.%y'),'г. : ')
FROM proved_instr_issled INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
INNER JOIN instr_issledovaniya ON proved_instr_issled.id_instr_issledovaniya = instr_issledovaniya.id_instr_issledovaniya
WHERE epikrizy.id_pacienta = @ID;";

        public string Print_Dannye_InstrIssl_Pacienta = $@"SELECT CASE
	WHEN pokazat_instr_issled.ed_izm = '' AND commentariy = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie)
	WHEN pokazat_instr_issled.ed_izm = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', commentariy)
	WHEN commentariy = ''
		THEN CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', pokazat_instr_issled.ed_izm)
	ELSE CONCAT(pokazat_instr_issled.naimenovanie,' ', znachenie,' ', pokazat_instr_issled.ed_izm,' ',commentariy)
END
FROM dannye_instr_issled
INNER JOIN proved_instr_issled ON dannye_instr_issled.id_proved_instr_issled = proved_instr_issled.id_proved_instr_issled
INNER JOIN pokazat_instr_issled ON dannye_instr_issled.id_pokazat_instr_issled = pokazat_instr_issled.id_pokazat_instr_issled
INNER JOIN epikrizy ON proved_instr_issled.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.id_pacienta = @ID AND proved_instr_issled.id_proved_instr_issled = @Value1;";

        public string Print_Recomendacii_Pacienta = $@"SELECT CONCAT(CONCAT('C ',date_n,' по ',date_k,': '),recomendacii)
FROM epikrizy WHERE id_pacienta = @ID;";

        public string Select_Pol_Pacienta_Kartochka = $@"SELECT pol 
FROM pacienty WHERE id_pacienta = @ID;";
        //Print Kartochka

        //Print Reestr
        public string Print_Reestr = $@"SELECT id_epikriza, CONCAT(pacienty.familiya, ' ',pacienty.imya, ' ', pacienty.otchestvo), DATE_FORMAT(date_n,'%d.%m.%Y'), DATE_FORMAT(date_k,'%d.%m.%Y'), lech_vrach
FROM epikrizy INNER JOIN pacienty ON epikrizy.id_pacienta = pacienty.id_pacienta
WHERE id_otdeleniya = @ID AND date_n BETWEEN @Value1 AND @Value2 AND date_k BETWEEN @Value1 AND @Value2;";
        //Print Reestr

        //Dinamic
        public string Select_Dinamic = $@"SET lc_time_names = 'ru_RU';
SELECT COUNT(diagnozy_pacienta.id_diagnoza), DATE_FORMAT(epikrizy.date_k,'31 %M %Yг.')
FROM diagnozy_pacienta INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE diagnozy.id_diagnoza = @ID AND diagnozy_pacienta.zaklucheniye = 'Да'
GROUP BY DATE_FORMAT(epikrizy.date_k,'31 %M %Yг.')
ORDER BY DATE_FORMAT(epikrizy.date_k,'31 %M %Yг.') DESC;";

        public string Select_Statistics = $@"SET lc_time_names = 'ru_RU';
SELECT COUNT(diagnozy_pacienta.id_diagnoza), diagnozy.naimenovanie
FROM diagnozy_pacienta INNER JOIN diagnozy ON diagnozy_pacienta.id_diagnoza = diagnozy.id_diagnoza
INNER JOIN epikrizy ON diagnozy_pacienta.id_epikriza = epikrizy.id_epikriza
WHERE epikrizy.date_k BETWEEN @Value1 AND @Value2 AND diagnozy_pacienta.zaklucheniye = 'Да'
GROUP BY diagnozy.naimenovanie
ORDER BY COUNT(diagnozy_pacienta.id_diagnoza) DESC;";
        //Dinamic
    }
}
