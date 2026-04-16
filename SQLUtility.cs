using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CPUFramework
{
    public class SQLUtility
    {
        public static string ConnectionString = "Server=tcp:dev-tobycpu.database.windows.net,1433;" +
            "Initial Catalog=HeartyHearth;" +
            "Persist Security Info=False;" +
            "User ID=TobyR;" +
            "Password=Liron@123;" +
            "MultipleActiveResultSets=False;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;";
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
    }
}
//note
