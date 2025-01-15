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
            string connString = "Data Source=localhost/XE:1521;User Id=sys;Password=123456;DBA Privilege=SYSDBA";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            Console.WriteLine("Connection State:" + conn.State);
            // Execute a SQL SELECT
            OracleCommand cmd = new OracleCommand("select * from Student", conn);
            OracleDataReader reader = cmd.ExecuteReader();

            // Print all student numbers
            while (reader.Read())
            {
                Console.WriteLine($"{reader["studentId"],-12} {reader["firstName"],-12} {reader["lastName"],-12} {reader["email"],-12} {reader["phoneNo"],-12} {reader["cga"],-12} {reader["departmentId"],-12} {reader["admissionYear"],-12}");
            }
                //Insert myself
                Console.WriteLine("请输入要插入的记录字段（字段之间用逗号隔开，字段顺序为：studentId, firstName, lastName, email, phoneNo, cga, departmentId, admissionYear）：");
            string input = Console.ReadLine();
            string[] fields = input.Split(',');

            string insertSql = "INSERT INTO Student (studentId, firstName, lastName, email, phoneNo, cga, departmentId, admissionYear) VALUES (:studentId, :firstName, :lastName, :email, :phoneNo, :cga, :departmentId, :admissionYear)";
            OracleCommand insertCmd = new OracleCommand(insertSql, conn);
            insertCmd.Parameters.Add(":studentId", fields[0].Trim());
            insertCmd.Parameters.Add(":firstName", fields[1].Trim());
            insertCmd.Parameters.Add(":lastName", fields[2].Trim());
            insertCmd.Parameters.Add(":email", fields[3].Trim());
            insertCmd.Parameters.Add(":phoneNo", fields[4].Trim());
            insertCmd.Parameters.Add(":cga", fields[5].Trim() == "" ? (object)DBNull.Value : double.Parse(fields[5].Trim()));
            insertCmd.Parameters.Add(":departmentId", fields[6].Trim());
            insertCmd.Parameters.Add(":admissionYear", fields[7].Trim());
            insertCmd.ExecuteNonQuery();

            Console.WriteLine("更新后的 Student 表记录：");
            cmd = new OracleCommand("SELECT * FROM Student", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["studentId"],-12} {reader["firstName"],-12} {reader["lastName"],-12} {reader["email"],-12} {reader["phoneNo"],-12} {reader["cga"],-12} {reader["departmentId"],-12} {reader["admissionYear"],-12}");
            }

            // Clean up
            reader.Dispose();
            cmd.Dispose();
            conn.Dispose();
            conn.Close();
            Console.ReadLine();
        }
    }
}
