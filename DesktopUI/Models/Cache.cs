using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Models
{
    public class Cache
    {
        private static int RowsPerPage;
      

        //Represents one page of data

        public struct DataPage
        {
            public DataTable table;

            public DataPage(DataTable table, int rowIndex)
            {
                this.table = table;
                LowestIndex = MapToLowerBoundary(rowIndex);
                HighestIndex = MapToUpperBoundary(rowIndex);
                System.Diagnostics.Debug.Assert(LowestIndex >= 0);
                System.Diagnostics.Debug.Assert(HighestIndex >= 0);
            }

            public int LowestIndex { get; }
            public int HighestIndex { get; }
            public static int MapToLowerBoundary(int rowIndex)
            {
                return (rowIndex / RowsPerPage) * RowsPerPage;
            }
            private static int MapToUpperBoundary(int rowIndex)
            {
                return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
            }
        }
        private DataPage[] cachePages;
        private IDataPageRetriever dataSupply;

        public Cache(IDataPageRetriever dataSupplier,int rowsPerPage)
        {
            dataSupply = dataSupplier;
            Cache.RowsPerPage = rowsPerPage;
            LoadFirstTwoPages();
        }

        private bool IfPageCached_ThenSetElement(int rowIndex,int columnIndex, ref string element)
        {
            if (IsRowCachedInPage(0,rowIndex))
            {
                element = cachePages[0].table.Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }
            else if (IsRowCachedInPage(1,rowIndex))
            {
                element = cachePages[1].table.Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }
            return false;
        }
        public string RetrieveElement(int rowIndex,int columnIndex)
        {
            string element = null;

            if (IfPageCached_ThenSetElement(rowIndex,columnIndex,ref element))
            {
                return element;
            }
            else
            {
                return RetrieveData_CacheIt_ThenReturnElement(rowIndex, columnIndex);
            }
        }
        public void LoadFirstTwoPages()
        {
            cachePages = new DataPage[]
            {
                new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0),RowsPerPage),0),
                new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(RowsPerPage),RowsPerPage),RowsPerPage)
            };
        }

        private string RetrieveData_CacheIt_ThenReturnElement(int rowIndex,int columnIndex)
        {
            DataTable table = dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);


            cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);
            return RetrieveData_CacheIt_ThenReturnElement(rowIndex, columnIndex);
        }

        private int GetIndexToUnusedPage(int rowIndex)
        {
            if (rowIndex > cachePages[1].HighestIndex && rowIndex > cachePages[1].HighestIndex)
            {
                int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
                int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
                int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
        }
        private bool IsRowCachedInPage(int pageNumber,int rowIndex)
        {
            return rowIndex <= cachePages[pageNumber].HighestIndex && rowIndex >= cachePages[pageNumber].LowestIndex;
        }
    }
}
