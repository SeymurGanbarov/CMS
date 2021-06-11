using CMS.DAL.DAO;
using System.Collections.Generic;

namespace CMS.DAL
{
    public static class DataContext
    {
        static DataContext()
        {
            //initialize
            Groups = new List<GroupDAO>();
            Customers = new List<CustomerDAO>();
            GroupToCustomers = new List<GroupToCustomerDAO>();
            GroupToMaintenances = new List<GroupToMaintenanceDAO>();
            Maintenances = new List<MaintenanceDAO>();
            MaintenanceFeatures = new List<MaintenanceFeatureDAO>();
        }

        public static List<GroupDAO> Groups { get; set; }
        public static List<CustomerDAO> Customers { get; set; }
        public static List<GroupToCustomerDAO> GroupToCustomers { get; set; }
        public static List<GroupToMaintenanceDAO> GroupToMaintenances { get; set; }
        public static List<MaintenanceDAO> Maintenances { get; set; }
        public static List<MaintenanceFeatureDAO> MaintenanceFeatures { get; set; }
    }
}
