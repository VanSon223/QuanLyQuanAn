using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }
        public void SwitchTable(int id1, int id2)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_SwicthTable @idTbale1 , @idTable2", new object[] { id1, id2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> TableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                TableList.Add(table);
            }

            return TableList;
        }
        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood(name,status)VALUES ( N'{0}',N'Trống')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int id, string name)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}', status = N'Trống'  WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int id)
        {

            string query = string.Format("Delete TableFood where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
