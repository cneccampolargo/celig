using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace celig.Model
{
    class DataBase
    {

        SQLiteConnection conn;

       // string patch = @"C:/Users/aluno/Desktop/BancoDeDados/DbUsers.db";
        List<SQLiteParameter> listaParameter = new List<SQLiteParameter>();

        public DataBase()
        {
            string connectionString = "Data Source=" + patch + ";Version=3";
            this.conn = new SQLiteConnection(connectionString);
        }


        public void OpenConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        public void addParameter(string nome, object valor, DbType tipo)
        {

            SQLiteParameter param = new SQLiteParameter(nome, valor);
            param.DbType = tipo;
            listaParameter.Add(param);
        }


        public SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            if (listaParameter != null)
            {
                foreach (SQLiteParameter parameter in listaParameter)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            SQLiteDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }



        


    }
}
