
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static FinalProject.SQLite.Tables;

namespace FinalProject.SQLite
{
    public class DBServices
    {
        #region Application Information Table Info Related Services
        #region Operations for DBVersion Table
        //Insert or Update Version Number
        public static async Task<bool> InsertDBVersionNumber()
        {
            bool result = false;

            DBVersion DBVersion = new DBVersion();
            DBVersion.SNo = 1;
            DBVersion.DBVersionNumber = SQLiteOperations.DBVersionNumber;
            try
            {
                await App.Database.DBConnection().InsertAsync(DBVersion);
                result = true;
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
                try
                {
                    await App.Database.DBConnection().UpdateAsync(DBVersion);
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message.ToString());
                    result = false;
                }
            }
            return result;
        }
        #endregion
        #region Getting Version Number
        public static Task<List<DBVersion>> GetDBVersionDetails()
        {
            Task<List<DBVersion>> DBVersionDetails = null;
            try
            {
                DBVersionDetails = App.Database.DBConnection().Table<DBVersion>().Where(x => x.SNo == 1).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return DBVersionDetails;
        }
        #endregion
        #endregion

        #region User Related

        public static Task<List<ToDoItem>> GetItemDetails()
        {
            Task<List<ToDoItem>> StudentsDetails = null;
            try
            {
                StudentsDetails = App.Database.DBConnection().Table<ToDoItem>().OrderBy(x => x.ItemName).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return StudentsDetails;
        }

        public static async Task<bool> InsertTodoItem(string itemName)
        {
            bool result = false;
            ToDoItem todo = new ToDoItem();
            todo.ItemName = itemName;
            todo.IsDone = false;

            try
            {
                await App.Database.DBConnection().InsertAsync(todo);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return result;
        }

        public static Task<List<ToDoItem>> GetTodoItem()
        {
            Task<List<ToDoItem>> StudentsDetails = null;
            try
            {
                StudentsDetails = App.Database.DBConnection().Table<ToDoItem>().OrderBy(x => x.ItemName).ToListAsync();
            }
            catch (Exception Ex)
            {
                Console.Write(Ex.Message.ToString());
            }
            return StudentsDetails;
        }

        #endregion
    }
}

