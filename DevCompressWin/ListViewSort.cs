using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevCompressWin
{
    public class mySorter : IComparer
    {
        private Comparer comparer;
        private int sortColumn;
        private SortOrder sortOrder;
        public mySorter()
        {
            sortColumn = 0;
            sortOrder = SortOrder.None;
            comparer = Comparer.Default;
        }
        //指定进行排序的列
        public int SortColumn
        {
            get { return sortColumn; }
            set { sortColumn = value; }
        }
        //指定按升序或降序进行排序
        public SortOrder SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }
        public int Compare(object x, object y)
        {
            int CompareResult;
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            string a= itemX.SubItems[this.sortColumn].Text;
            string b=itemY.SubItems[this.sortColumn].Text;

            long a1, b1;

            if (long.TryParse(a, out a1) && long.TryParse(b, out b1))
            {
                CompareResult = comparer.Compare(a1,b1);
            }
            else
            {
                //在这里您可以提供自定义的排序
                CompareResult = comparer.Compare(a, b);
            }
            if (this.SortOrder == SortOrder.Ascending)
                return CompareResult;
            else if (this.SortOrder == SortOrder.Descending)
                return (-CompareResult);
            else
                return 0;
        }
    }

}
