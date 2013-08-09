using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SchnauzerMonitor
{
    class DataGridDesign
    {
        private DataTable table;

        public DataGridDesign() { }

        public DataGridDesign(DataTable dataTable) 
        {
            this.table = dataTable;
        }

        public void InitDataTable()
        {
            DataColumn col;

            col = new DataColumn();
            col.ColumnName = "客户名称";
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "产品名称";
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "规格";
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "单位";
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "期初存货数量";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "期初货款";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "期初帐款";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "发货数量";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "发货金额";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "开票数量";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "开票金额";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "回款数量";
            col.DataType = System.Type.GetType("System.Decimal");
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "回款金额";
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "未开票回款数量";
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "未开票回款金额";
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "期末存货数量";
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "期末应收货款";
            table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Decimal");
            col.ColumnName = "期末应收帐款";
            table.Columns.Add(col);
        }

        public void InitDataGridView()
        {
            /*
            MutilGridHeader topRow = new MutilGridHeader();
            topRow.SetRowCol(3, 18);

            //第一行
            topRow.Cells[0][0].Value = "客户";
            topRow.Cells[0][0].RowSpan = 3;

            topRow.Cells[0][1].Value = "产品名称";
            topRow.Cells[0][1].RowSpan = 3;

            topRow.Cells[0][2].Value = "规格";
            topRow.Cells[0][2].RowSpan = 3;

            topRow.Cells[0][3].Value = "单位";
            topRow.Cells[0][3].RowSpan = 3;

            topRow.Cells[0][4].Value = "期初";
            topRow.Cells[0][4].ColSpan = 3;

            topRow.Cells[0][7].Value = "本期";
            topRow.Cells[0][7].ColSpan = 8;

            topRow.Cells[0][15].Value = "期末";
            topRow.Cells[0][15].ColSpan = 3;


            //第二行
            topRow.Cells[1][4].Value = "存货数量";
            topRow.Cells[1][4].RowSpan = 2;

            topRow.Cells[1][5].Value = "应收货款";
            topRow.Cells[1][5].RowSpan = 2;

            topRow.Cells[1][6].Value = "应收帐款";
            topRow.Cells[1][6].RowSpan = 2;

            topRow.Cells[1][7].Value = "发货";
            topRow.Cells[1][7].ColSpan = 2;

            topRow.Cells[1][9].Value = "开票";
            topRow.Cells[1][9].ColSpan = 2;

            topRow.Cells[1][11].Value = "回款";
            topRow.Cells[1][11].ColSpan = 2;

            topRow.Cells[1][13].Value = "未开票回款";
            topRow.Cells[1][13].ColSpan = 2;

            topRow.Cells[1][15].Value = "存货数量";
            topRow.Cells[1][15].RowSpan = 2;

            topRow.Cells[1][16].Value = "应收货款";
            topRow.Cells[1][16].RowSpan = 2;

            topRow.Cells[1][17].Value = "应收票款";
            topRow.Cells[1][17].RowSpan = 2;

            //第三行
            topRow.Cells[2][7].Value = "数量";
            topRow.Cells[2][8].Value = "金额";
            topRow.Cells[2][9].Value = "数量";
            topRow.Cells[2][10].Value = "金额";
            topRow.Cells[2][11].Value = "数量";
            topRow.Cells[2][12].Value = "金额";
            topRow.Cells[2][13].Value = "数量";
            topRow.Cells[2][14].Value = "金额";


            dataGridViewEx1.Header = topRow;
            dataGridViewEx1.DataSource = table;
            table.DefaultView.AllowNew = false;

            dataGridViewEx1.Columns[0].Width = 120;
            dataGridViewEx1.Columns[1].Width = 100;
            dataGridViewEx1.Columns[2].Width = 80;
            for (int i = 2; i < 18; i++)
                dataGridViewEx1.Columns[i].Width = 60;
             */

        }
    }
}
