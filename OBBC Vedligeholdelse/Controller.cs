using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBBC_Vedligeholdelse.Application
{
    public class Controller
    {
        DatabaseController databaseController = new DatabaseController();
        public List<string> ShowCurrentReports(int areaChoice)
        {
            switch (areaChoice)
            {
                case 1:
                    return databaseController.GetAllCurrentReports();                    
                case 2:
                    return databaseController.GetSpecificCurrentReports("Bryst");               
                case 3:
                    return databaseController.GetSpecificCurrentReports("Ryg");
                case 4:
                    return databaseController.GetSpecificCurrentReports("Mave");
                case 5:
                    return databaseController.GetSpecificCurrentReports("Spinning");
                case 6:
                    return databaseController.GetSpecificCurrentReports("Ben");
                case 7:                    
                    return databaseController.GetSpecificCurrentReports("Arme");
                default:
                    return databaseController.GetAllCurrentReports();
            }
        }
        public void ChangeStatus(int statusChoice, int reportID)
        {
            switch (statusChoice)
            {
                case 1:
                    databaseController.ChangeReportStatus(reportID, "Grøn");
                    break;
                case 2:
                    databaseController.ChangeReportStatus(reportID, "Gul");
                    break;
                case 3:
                    databaseController.ChangeReportStatus(reportID, "Rød");
                    break;
                default:
                    throw new Exception("Status findes ikke!");
            }
        }
        public void CreateNewReport(int areaChoice, string errorReport, string date, string extraInfo)
        {
            switch (areaChoice)
            {
                case 1:                   
                    databaseController.CreateReport("Bryst",errorReport,date,extraInfo);                   
                    break;
                case 2:                    
                    databaseController.CreateReport("Ryg", errorReport, date, extraInfo);                   
                    break;
                case 3:               
                    databaseController.CreateReport("Mave", errorReport, date, extraInfo);                    
                    break;
                case 4:                   
                    databaseController.CreateReport("Spinning", errorReport, date, extraInfo);                   
                    break;
                case 5:                    
                    databaseController.CreateReport("Ben", errorReport, date, extraInfo);                    
                    break;
                case 6:                    
                    databaseController.CreateReport("Arme", errorReport, date, extraInfo);                    
                    break;            
                default:
                    throw new Exception("Området findes ikke!");
            }
        }
        public List<string> ShowOldReports(int areaChoice) //Der findes ikke gamle rapporter med ekstra??
        {           
            switch (areaChoice)
            {
                case 1:
                    return databaseController.GetAllOldReports();
                case 2:
                    return databaseController.GetSpecificOldReports("Bryst");
                case 3:
                    return databaseController.GetSpecificOldReports("Ryg");
                case 4:
                    return databaseController.GetSpecificOldReports("Mave");
                case 5:
                    return databaseController.GetSpecificOldReports("Spinning");
                case 6:
                    return databaseController.GetSpecificOldReports("Ben");
                case 7:
                    return databaseController.GetSpecificOldReports("Arme");
                default:
                    throw new Exception("Området findes ikke!");
            }
        }
        public List<string> ShowExtraInfoReports(int areaChoice)
        {
            switch (areaChoice)
            {
                case 1:
                    return databaseController.GetAllExtraInfoReports();
                case 2:
                    return databaseController.GetSpecificExtraInfoReports("Bryst");
                case 3:
                    return databaseController.GetSpecificExtraInfoReports("Ryg");
                case 4:
                    return databaseController.GetSpecificExtraInfoReports("Mave");
                case 5:
                    return databaseController.GetSpecificExtraInfoReports("Spinning");
                case 6:
                    return databaseController.GetSpecificExtraInfoReports("Ben");
                case 7:
                    return databaseController.GetSpecificExtraInfoReports("Arme");
                default:
                    throw new Exception("Området findes ikke!");
            }
        }
        public void DeleteReport(int reportId)
        {
            databaseController.DeleteReport(reportId);
        }
    }
}
