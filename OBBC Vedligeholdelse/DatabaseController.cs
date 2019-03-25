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
        public List<string> GetAllCurrentReports()
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
        public List<string> GetSpecificCurrentReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisSpecifikkeAktuelleFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    return DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl! " + e.Message);
                }
            }
        }
        public string ChangeReportStatus(int reportID, string status)
        {
            string success = "Reporten fik ændret status";
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

                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl! " + e.Message);
                }
                return success;
            }
        }
        public string CreateReport(string area, string errorReport, string date,string extraInfo)
        {
            string success = "Rapporten blev oprettet";
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
                    
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl! " + e.Message);
                }
                return success;
            }
        }

        public List<string> GetSpecificExtraInfoReports(string area)
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
                    throw new Exception("Fejl! " + e.Message);
                }
                
            }
        }

        public List<string> GetAllExtraInfoReports()
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
                    throw new Exception("Fejl! " + e.Message);
                }
            }
            
        }
        public List<string> GetSpecificOldReports(string area)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisSpecifikkeRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Lokation", area));
                    return DatabaseReader(cmd);

                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl! " + e.Message);
                }
                
            }
        }
        public List<string> GetAllOldReports()
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VisAlleRepareredeFejlRapporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return DatabaseReader(cmd);
                }
                catch (SqlException e)
                {
                    throw new Exception("Fejl! " + e.Message);
                }
            }
        }
        private string DynamicConnectionString()
        {
            string _connectionString = null;
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\OBBC Vedligeholdelse\DatabaseAccess.txt"))
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
                throw new Exception("Fejl! " + e.Message);
            }
            return _connectionString;
        }
        private List<string> DatabaseReader(SqlCommand cmd)
        {
            List<string> data = new List<string>();
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
                    if (status.Equals("Gul") || status.Equals("Rød"))
                    {
                        string res = reportID + "/" + location + "/" + PB + "/" + time + "/" + extraInfo + "/" + status;
                        data.Add(res);        
                    }
                    else if (status.Equals("Grøn"))
                    {
                        string res = reportID + "/" + location + "/" + PB + "/" + time + "/" + extraInfo + "/" + status;
                        data.Add(res);
                    }
                }
                return data;
            }
            throw new Exception("Fejl!");
        }
        public void DeleteReport(int reportId)
        {
            using (SqlConnection con = new SqlConnection(DynamicConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ReportId", reportId));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException e)
                {
                    throw new Exception("UPS" + e.Message);
                }
            }
        }
    }
}
