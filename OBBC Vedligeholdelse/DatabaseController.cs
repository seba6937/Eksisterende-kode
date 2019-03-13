    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OBBC_Vedligeholdelse 
{
    public class DatabaseController
    {
        public string GetAllCurrentReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    throw new Exception("UPS" + e.Message);
                }
            }
        }
        public void GetSpecificCurrentReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisSpecifikkeAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    DatabaseReader(cmd);                       
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
                
            }
        }
        public string ChangeReportStatus(int reportID, string status)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ÆndreStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RapportID", reportID));
                    cmd.Parameters.Add(new SqlParameter("@Status", status));
                    cmd.ExecuteReader();
                    string success = "Reporten fik ændret status";
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
                
                throw new Exception("Fejl");
            }
        }
        public string CreateReport(string area,string errorReport, string date,string extraInfo)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    cmd.Parameters.Add(new SqlParameter("@ProblemBeskrivelse", errorReport));
                    cmd.Parameters.Add(new SqlParameter("@Tidspunkt", date));
                    cmd.Parameters.Add(new SqlParameter("@ExtraInfo", extraInfo));
                    DatabaseReader(cmd);
                    string success = "Rapporten blev oprettet";
                    return success;
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
                
            }
        }

        public string GetSpecificExtraInfoReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisSpecifikkeMedExtraNote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    return DatabaseReader(cmd);

                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
                
            }
        }

        public string GetAllExtraInfoReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleMedExtraNote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
            }
            throw new Exception("Fejl");
        }
        public string GetSpecificOldReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisSpecifikkeRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    return DatabaseReaderGreen(cmd);

                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
                
            }
        }
        public string GetAllOldReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return DatabaseReaderGreen(cmd);
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl" + e.Message);
                }
            }
        }
        private string DynamicConnectionString()
        {
            string _connectionString = null;
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\DatabaseAccess.txt"))
                {
                    string line;
                    string[] connectionArray;
                    string server;
                    string database;
                    string userId;
                    string password;
                    while ((line = sr.ReadLine()) != null)
                    {
                        connectionArray = line.Split(':');
                        server = connectionArray[0].ToString();
                        database = connectionArray[1].ToString();
                        userId = connectionArray[2].ToString();
                        password = connectionArray[3].ToString();
                        _connectionString = $"Server={server}; Database= {database}; User Id= {userId}; Password= {password}";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Fejl" + e.Message);
            }
            return _connectionString;
        }
        private string DatabaseReader(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    string reportID = reader["RapportID"].ToString();
                    string location = reader["Lokation"].ToString();
                    string PB = reader["ProblemBeskrivelse"].ToString();
                    string time = reader["Tidspunkt"].ToString();
                    string extraInfo = reader["ExtraInfo"].ToString();
                    string status = reader["Status"].ToString();
                    if (status == "Gul")
                    {
                        string res = "RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {PB} \nTidspunkt:  {time} \nExtra Info: {extraInfo}";
                        return res;                        
                    }
                    else if (status == "Rød")
                    {
                        string res = "RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {PB} \nTidspunkt:  {time} \nExtra Info: {extraInfo}";
                        return res;                        
                    }                    
                }                
            }
            throw new Exception("Fejl");
        }
        private string DatabaseReaderGreen(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string reportID = reader["RapportID"].ToString();
                    string location = reader["Lokation"].ToString();
                    string PB = reader["ProblemBeskrivelse"].ToString();
                    string time = reader["Tidspunkt"].ToString();
                    string extraInfo = reader["ExtraInfo"].ToString();
                    string status = reader["Status"].ToString();
                    if (status == "Grøn")
                    {
                        
                        string res = "RapportID: {reportID} \nLokation: {location} \nProblembeskrivelse: {PB} \nTidspunkt:  {time} \nExtra Info: {extraInfo}";
                        return res;
                    }
                }
            }
            throw new Exception("Fejl");
        }
    }
}
