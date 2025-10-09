using System;
//Name Spaces
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhumlaniKamnandi.Properties;//***needs to be added to be able to use the Settings property
using System.Windows.Forms;
namespace PhumlaniKamnandi.Data
{
    public class DB
    {
        #region Variable declaration
        //***Once the database is created you can find the correct connection string by using the Settings.Default object to select the correct connection string
        private string strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ndzub\\OneDrive\\Documents\\GitHub\\PhumlaniKamnandi\\PhumlaniKamnandi\\hotelDB.mdf;Integrated Security=True";
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        public enum DBOperation
        {
            Add, Edit,Delete
        }
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                //Open a connection & create a new dataset object
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Error");
                return;
            }
        }

        #endregion

        #region Update the DateSet
        /// <summary>
        /// Loads data from the database into a specified table in dataset.
        /// </summary>
        /// <param name="aSQLstring">SQL query string to select data.</param>
        /// <param name="aTable">The dataset table name to fill.</param>
        public void FillDataSet(string aSQLstring, string aTable)
        {
            //fills dataset fresh from the db for a specific table and with a specific Query
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                if (dsMain.Tables[aTable]!= null)
                    dsMain.Tables[aTable].Clear();
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        #endregion

        #region Update the data source 
        /// <summary>
        /// Updates the database with changes made in the dataset.
        /// </summary>
        /// <param name="sqlLocal">SQL query used to refresh the dataset after update.</param>
        /// <param name="table">The name of the table to update.</param>
        /// <returns>True if update succeeds, false otherwise.</returns>
        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success;
            try
            {
                //open the connection
                cnMain.Open();
                //***update the database table via the data adapter
                daMain.Update(dsMain, table);
                //---close the connection
                cnMain.Close();
                //refresh the dataset
                FillDataSet(sqlLocal, table);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }
        #endregion
    }
}
