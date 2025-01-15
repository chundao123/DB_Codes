using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;//dll引用


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=localhost:1521;User Id=sys;Password=123456;DBA Privilege=SYSDBA";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            // Execute a SQL SELECT
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from students";
            OracleDataReader reader = cmd.ExecuteReader();

            // Print all student numbers
            while (reader.Read())
                Console.WriteLine(reader.GetDecimal(0));

            // Clean up
            reader.Dispose();
            cmd.Dispose();
            conn.Dispose();
            conn.Close();
            Console.ReadLine();
        }
    }
}