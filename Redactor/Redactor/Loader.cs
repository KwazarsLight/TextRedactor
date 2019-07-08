using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace Redactor
{


    public sealed class Loader : IDisposable
    {
        enum eRequest { Insert, Delete, PullRow, PullTable };

        private SQLiteConnection con = new SQLiteConnection(
        ConfigurationManager.ConnectionStrings["FileDatabaseConnection"].ConnectionString, true);
        string sqlRequest;
        SQLiteCommand command;

        private static Loader instance;
        private static object syncRoot = new Object();
        public string Name { get; private set; }

        private Loader(string name)
        {
            this.Name = name;
        }
        public Loader()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }

        }


        private string ParseSqlRequest(TextFile file, eRequest request)
        {
            switch (request)
            {
                case eRequest.Insert:
                    return "insert into Files(Name, Extension, File) values (@Name, @Extension, @File);";
                case eRequest.Delete:
                    return "delete Files where Id_File = @IdFileValue";
                case eRequest.PullRow:
                    return "select * from Files where  Id_File = @IdFileValue";
                case eRequest.PullTable:
                    return "select Id_File, Name, Extension from Files";
                default:
                    throw new ArgumentNullException();
            }
        }


        public void InsertFile(TextFile file)
        {
            sqlRequest = ParseSqlRequest(file, eRequest.Insert);

            command = new SQLiteCommand(sqlRequest, con);

            command.Parameters.Add("@Name", DbType.String, file.FileName.Length).Value = file.FileName;
            command.Parameters.Add("@Extension", DbType.String, 20).Value = file.FileExtension;
            command.Parameters.Add("@File", DbType.Binary, Int32.MaxValue).Value = file.FileContent;
            command.ExecuteNonQuery();
        }

        public void DeleteFile(TextFile file, int indexFileToDelete)
        {
            sqlRequest = ParseSqlRequest(file, eRequest.Delete);

            command = new SQLiteCommand(sqlRequest, con);

            command.Parameters.Add("@IdFileValue", DbType.Int32, Int32.MaxValue).Value = indexFileToDelete;
            command.ExecuteNonQuery();
        }

        public async Task<DataTable> ShowTable()
        {
            DataTable table = new DataTable();
            System.Data.Common.DbDataReader reader;
            sqlRequest = ParseSqlRequest(null, eRequest.PullTable);

            command = new SQLiteCommand(sqlRequest, con);

            reader = await command.ExecuteReaderAsync();

            table.Load(reader);

            return table;
        }

        public TextFile ReadFile(int indexRow)
        {
            TextFile file;
            sqlRequest = ParseSqlRequest(null, eRequest.PullRow);

            command = new SQLiteCommand(sqlRequest, con);
            command.Parameters.Add("@IdFileValue", DbType.Int32, Int32.MaxValue).Value = indexRow;
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                file = new TextFile(
                      reader["Name"].ToString(),//.TrimStart().TrimEnd(),
                      TextFile.StringToeExtensions(reader["Extension"].ToString()),
                      (byte[])reader["File"]

                );
                return file;
            }
            catch (InvalidOperationException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
        }
    
        public void Dispose()
        {
            con.Close();
        }
    }
}
