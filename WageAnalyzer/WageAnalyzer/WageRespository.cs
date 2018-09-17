using System;
using System.Collections.Generic;
using SQLite;
using WageAnalyzer.Models;

namespace WageAnalyzer
{
    public class WageRespository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection conn;


        public WageRespository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<WageCollectorViewModel>();
        }

        public void AddNewWage(float DayWages, float DayHours, float DayMinutes, string Restaurant)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(DayWages.ToString()))
                    throw new Exception("Valid ammount of money required");
                if (string.IsNullOrEmpty(Restaurant))
                    throw new Exception("Valid restaurant name required");
                if (string.IsNullOrEmpty(DayHours.ToString()))
                    throw new Exception("Valid hour ammount required");

                // TODO: insert a new person into the Person table

                StatusMessage = string.Format("{0} {1} {2} [3} record(s) added [Name: {1})", result, DayWages, DayHours, Restaurant);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0} {1} {2}. Error: {3}", DayWages, DayHours, Restaurant, ex.Message);
            }

        }

        public List<WageCollectorViewModel> GetAllWages()
        {
            try
            {
                return conn.Table<WageCollectorViewModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<WageCollectorViewModel>();
            // TODO: return a list of people saved to the Person table in the database
        }
    }
}
