using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epikrizy
{
    public class MySqlQueries
    {
        //Select
        public string Select_Otdeleniya = $@"SELECT id_otdeleniya, naimenovanie AS 'Наименование отделения' FROM otdeleniya;";

        public string Select_Otdeleniya_ComboBox = $@"SELECT naimenovanie FROM otdeleniya";

        public string Select_ID_Otdeleniya_ComboBox = $@"SELECT id_otdeleniya FROM otdeleniya WHERE naimenovanie = @Value1";

        public string Select_Doljnosti = $@"SELECT id_doljnosti, naimenovanie AS 'Наименование должности' FROM doljnosti;";

        public string Select_Doljnosti_ComboBox = $@"SELECT naimenovanie FROM doljnosti;";

        public string Select_ID_Doljnosti_ComboBox = $@"SELECT id_doljnosti FROM doljnosti WHERE naimenovanie = @Value1;";

        public string Select_Personal = $@"SELECT personal.id_personala, CONCAT(personal.familiya,' ', personal.imya, ' ', personal.otchestvo) AS 'Ф.И.О. Сотрудника', 
otdeleniya.naimenovanie AS 'Наименование отделения', doljnosti.naimenovanie AS 'Наименование должности'
FROM personal INNER JOIN otdeleniya ON personal.id_otdeleniya = otdeleniya.id_otdeleniya
INNER JOIN doljnosti ON personal.id_doljnosti = doljnosti.id_doljnosti;";

        public string Select_Gcgp = $@"SELECT id_gcgp, nom_filiala AS 'Номер филиала', adress AS 'Адрес' FROM gcgp;";
        //Select

        //Insert
        public string Insert_Otdeleniya = $@"INSERT INTO otdeleniya (naimenovanie) VALUES (@Value1);";

        public string Insert_Doljnosti = $@"INSERT INTO doljnosti (naimenovanie) VALUES (@Value1);";

        public string Insert_Gcgp = $@"INSERT INTO gcgp (nom_filiala, adress) VALUES (@Value1, @Value2);";

        public string Insert_Personal = $@"INSERT INTO personal (familiya, imya, otchestvo, id_otdeleniya, id_doljnosti) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";
        //Insert

        //Update
        public string Update_Otdeleniya = $@"UPDATE otdeleniya SET naimenovanie = @Value1 WHERE id_otdeleniya = @ID;";

        public string Update_Doljnosti = $@"UPDATE doljnosti SET naimenovanie = @Value1 WHERE id_doljnosti = @ID;";

        public string Update_Gcgp = $@"UPDATE gcgp SET nom_filiala = @Value1, adress = @Value2 WHERE id_gcgp = @ID;";

        public string Update_Personal = $@"UPDATE personal SET familiya = @Value1, imya = @Value2, otchestvo = @Value3, id_otdeleniya = @Value4, id_doljnosti = @Value5 WHERE id_personala = @ID;";
        //Update

        //Delete
        public string Delete_Otdeleniya = $@"DELETE FROM otdeleniya WHERE id_otdeleniya = @ID;";
        
        public string Delete_Doljnosti = $@"DELETE FROM doljnosti WHERE id_doljnosti = @ID;";

        public string Delete_Gcgp = $@"DELETE FROM gcgp WHERE id_gcgp = @ID;";

        public string Delete_Personal = $@"DELETE FROM personal WHERE id_personala = @ID";
        //Delete
    }
}
