using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Internal.PrintLayout;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraRichEdit.Native;

namespace OzayPlise.UserControls
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        private int rowIndex = 0; // Satır numarasını takip etmek için
        public XtraReport1(DataTable data,string document_title)
        {
            InitializeComponent();
            this.DataSource = data;
            this.customerName.Text = document_title + " Detayları"; // Başlık metnini ayarla

            float tableWidth = this.PageWidth - this.Margins.Left - this.Margins.Right;

            // 🧾 Sadece başlık satırı (PageHeader)
            XRTable headerTable = new XRTable
            {
                WidthF = tableWidth,
                Borders = BorderSide.None,
                 TextAlignment = TextAlignment.MiddleCenter
            };
            XRTableRow headerRow = new XRTableRow();

            foreach (DataColumn col in data.Columns)
            {
                XRTableCell headerCell = new XRTableCell
                {
                    Text = col.ColumnName,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    Borders = BorderSide.None,
                    TextAlignment = TextAlignment.MiddleCenter
                };
                headerRow.Cells.Add(headerCell);
            }

            headerTable.Rows.Add(headerRow);
            headerTable.HeightF = headerTable.HeightF + 10;
            PageHeader.Controls.Add(headerTable); // Sadece 1 kere başlık gösterilir
            PageHeader.HeightF = headerTable.HeightF;

            // 📊 Veri satırı (Detail satırı için şablon)
            XRTable detailTable = new XRTable
            {
                WidthF = tableWidth,
                Borders = BorderSide.None,
                TextAlignment = TextAlignment.MiddleCenter
            };
            XRTableRow detailRow = new XRTableRow();

            foreach (DataColumn col in data.Columns)
            {
                XRTableCell detailCell = new XRTableCell
                {
                    Borders = BorderSide.None,
                    TextAlignment = TextAlignment.MiddleCenter
                };
                detailCell.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", $"[{col.ColumnName}]"));
                detailRow.Cells.Add(detailCell);
            }

            detailTable.Rows.Add(detailRow);
            Detail.Controls.Add(detailTable);

            // 🎯 Satır arka planını alternating olarak ayarla
            this.Detail.BeforePrint += (s, e) =>
            {
                Color bgColor = (rowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240);

                foreach (XRControl ctrl in this.Detail.Controls)
                {
                    if (ctrl is XRTable t)
                    {
                        foreach (XRTableRow row in t.Rows)
                        {
                            foreach (XRTableCell cell in row.Cells)
                                cell.BackColor = bgColor;
                        }
                    }
                }

                rowIndex++; // Her satır için artır
            };
        }

    }
}
