using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class DataRetriever : IDataPageRetriever
    {
        private string tableName;
        private SqlCommand command;

        public DataRetriever(string connectionString,string tableName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
            this.tableName = tableName;
        }

        private int rowsCountValue = -1;

        public int RowCount
        {
            get
            {
                //Return the existing value if it has already been determined

                if (rowsCountValue != -1)
                {
                    return rowsCountValue;
                }
                command.CommandText = "SELECT COUNT(*) FROM " + tableName;
                rowsCountValue = (int)command.ExecuteScalar();
                return rowsCountValue;
            }
        }

        private DataColumnCollection columnsValue;

        public DataColumnCollection Columns
        {
            get
            {
                if (columnsValue != null)
                {
                    return columnsValue;
                }

                command.CommandText = "SELECT * FROM " + tableName;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.FillSchema(table, SchemaType.Source);
                columnsValue = table.Columns;
                return columnsValue;
            }
        }

        private string commaSeperatedListOfColumnNamesValue = null;

        private string CommaSeperatedListOfColumnNames
        {
            get
            {
                if (commaSeperatedListOfColumnNamesValue != null)
                {
                    return commaSeperatedListOfColumnNamesValue;
                }

                StringBuilder commaSeperatedColumnNames = new StringBuilder();

                bool firstColumn = true;

                foreach (DataColumn column in Columns)
                {
                    if (!firstColumn)
                    {
                        commaSeperatedColumnNames.Append( "," );
                    }
                    commaSeperatedColumnNames.Append(column.ColumnName);
                    firstColumn = false;
                }

                commaSeperatedListOfColumnNamesValue = commaSeperatedColumnNames.ToString();
                return commaSeperatedListOfColumnNamesValue;
            }
        }

        //Declare variables to be reused by the SupplyPageOfData method
        private string columnToSortBy;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            if (columnToSortBy == null)
            {
                columnToSortBy = Columns[0].ColumnName;
            }
            if (!Columns[columnToSortBy].Unique)
            {
                throw new InvalidOperationException(string.Format("Column {0} must contain unique values.", columnToSortBy));
            }
            command.CommandText = "Select Top " + rowsPerPage + " " + CommaSeperatedListOfColumnNames + " From " + tableName + " WHERE " + columnToSortBy + " NOT IN ( SELECT TOP " + lowerPageBoundary + " " + columnToSortBy + " From " + tableName + " Order By " + columnToSortBy + " ) Order By " + columnToSortBy;
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }
    }
}
