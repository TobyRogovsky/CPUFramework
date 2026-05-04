using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace CPUFramework
{
    public class SQLUtility
    {
        public static string ConnectionString = "";

        public static void ExecuteSQL(string sqlstatement)
        {
            GetDataTable(sqlstatement);
        }

        public static int GetFirstColumnFirstRowValue(string sql)
        {
            int n = 0;

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value) 
                {                    
                    int.TryParse(dt.Rows[0][0].ToString(), out n);
                }
                
            } 

            return n;
        }

        public static DataTable GetDataTable(string sqlstatement)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new();
            conn.ConnectionString = ConnectionString;
            conn.Open();

            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstatement;
            var dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public static void SetConnectionString()
        {
            ConnectionString =
                "Server=tcp:dev-tobycpu.database.windows.net,1433;" +
                "Initial Catalog=RecipeDB;" +
                "Persist Security Info=False;" +
                "User ID=TobyR;" +
                "Password=Liron@123;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;";
        }

    }
}
//note
