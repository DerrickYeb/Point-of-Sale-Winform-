namespace DesktopUI.Views
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.btnCustomersReport = new System.Windows.Forms.Button();
            this.btnProductsReprt = new System.Windows.Forms.Button();
            this.btnTotalSalesReport = new System.Windows.Forms.Button();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboSelectClient = new System.Windows.Forms.ComboBox();
            this.btnClientReport = new System.Windows.Forms.Button();
            this.selectClientDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboSelectProdt = new System.Windows.Forms.ComboBox();
            this.btnProductsReport = new System.Windows.Forms.Button();
            this.dateTimeProdt = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStockReport = new System.Windows.Forms.Button();
            this.dateTimeStoctStat = new System.Windows.Forms.DateTimePicker();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DesktopUI.Views.WaitingFormLoader), true, true);
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomersReport
            // 
            this.btnCustomersReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(233)))), ((int)(((byte)(182)))));
            this.btnCustomersReport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnCustomersReport.FlatAppearance.BorderSize = 0;
            this.btnCustomersReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomersReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.btnCustomersReport.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomersReport.Image")));
            this.btnCustomersReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomersReport.Location = new System.Drawing.Point(139, 32);
            this.btnCustomersReport.Name = "btnCustomersReport";
            this.btnCustomersReport.Size = new System.Drawing.Size(260, 138);
            this.btnCustomersReport.TabIndex = 0;
            this.btnCustomersReport.Text = "Customers";
            this.btnCustomersReport.UseVisualStyleBackColor = false;
            this.btnCustomersReport.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnProductsReprt
            // 
            this.btnProductsReprt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.btnProductsReprt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnProductsReprt.FlatAppearance.BorderSize = 0;
            this.btnProductsReprt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductsReprt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.btnProductsReprt.Image = ((System.Drawing.Image)(resources.GetObject("btnProductsReprt.Image")));
            this.btnProductsReprt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductsReprt.Location = new System.Drawing.Point(476, 32);
            this.btnProductsReprt.Name = "btnProductsReprt";
            this.btnProductsReprt.Size = new System.Drawing.Size(260, 138);
            this.btnProductsReprt.TabIndex = 0;
            this.btnProductsReprt.Text = "Products";
            this.btnProductsReprt.UseVisualStyleBackColor = false;
            // 
            // btnTotalSalesReport
            // 
            this.btnTotalSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.btnTotalSalesReport.FlatAppearance.BorderSize = 0;
            this.btnTotalSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTotalSalesReport.Image = ((System.Drawing.Image)(resources.GetObject("btnTotalSalesReport.Image")));
            this.btnTotalSalesReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTotalSalesReport.Location = new System.Drawing.Point(835, 32);
            this.btnTotalSalesReport.Name = "btnTotalSalesReport";
            this.btnTotalSalesReport.Size = new System.Drawing.Size(260, 138);
            this.btnTotalSalesReport.TabIndex = 0;
            this.btnTotalSalesReport.Text = "Total Sales";
            this.btnTotalSalesReport.UseVisualStyleBackColor = false;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(233)))), ((int)(((byte)(182)))));
            this.lblTotalCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCustomers.Location = new System.Drawing.Point(227, 41);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(55, 23);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "label1";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.lblTotalProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.lblTotalProducts.Location = new System.Drawing.Point(563, 41);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(55, 23);
            this.lblTotalProducts.TabIndex = 1;
            this.lblTotalProducts.Text = "label1";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.lblTotalSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalSales.Location = new System.Drawing.Point(929, 41);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(55, 23);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(135, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client Stats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(63, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(63, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Range";
            // 
            // comboSelectClient
            // 
            this.comboSelectClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(89)))));
            this.comboSelectClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSelectClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.comboSelectClient.FormattingEnabled = true;
            this.comboSelectClient.IntegralHeight = false;
            this.comboSelectClient.Location = new System.Drawing.Point(240, 262);
            this.comboSelectClient.Name = "comboSelectClient";
            this.comboSelectClient.Size = new System.Drawing.Size(314, 31);
            this.comboSelectClient.TabIndex = 0;
            // 
            // btnClientReport
            // 
            this.btnClientReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnClientReport.FlatAppearance.BorderSize = 0;
            this.btnClientReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.btnClientReport.Location = new System.Drawing.Point(343, 386);
            this.btnClientReport.Name = "btnClientReport";
            this.btnClientReport.Size = new System.Drawing.Size(142, 34);
            this.btnClientReport.TabIndex = 2;
            this.btnClientReport.Text = "Get Report";
            this.btnClientReport.UseVisualStyleBackColor = false;
            // 
            // selectClientDate
            // 
            this.selectClientDate.CalendarForeColor = System.Drawing.Color.White;
            this.selectClientDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(89)))));
            this.selectClientDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.selectClientDate.Location = new System.Drawing.Point(240, 330);
            this.selectClientDate.Name = "selectClientDate";
            this.selectClientDate.Size = new System.Drawing.Size(314, 30);
            this.selectClientDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label4.Location = new System.Drawing.Point(115, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Products Stats";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label5.Location = new System.Drawing.Point(26, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Select Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label6.Location = new System.Drawing.Point(26, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select Range";
            // 
            // comboSelectProdt
            // 
            this.comboSelectProdt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(89)))));
            this.comboSelectProdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSelectProdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.comboSelectProdt.FormattingEnabled = true;
            this.comboSelectProdt.IntegralHeight = false;
            this.comboSelectProdt.Location = new System.Drawing.Point(203, 474);
            this.comboSelectProdt.Name = "comboSelectProdt";
            this.comboSelectProdt.Size = new System.Drawing.Size(314, 31);
            this.comboSelectProdt.TabIndex = 3;
            // 
            // btnProductsReport
            // 
            this.btnProductsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnProductsReport.FlatAppearance.BorderSize = 0;
            this.btnProductsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductsReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.btnProductsReport.Location = new System.Drawing.Point(306, 598);
            this.btnProductsReport.Name = "btnProductsReport";
            this.btnProductsReport.Size = new System.Drawing.Size(142, 34);
            this.btnProductsReport.TabIndex = 5;
            this.btnProductsReport.Text = "Get Report";
            this.btnProductsReport.UseVisualStyleBackColor = false;
            // 
            // dateTimeProdt
            // 
            this.dateTimeProdt.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimeProdt.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(89)))));
            this.dateTimeProdt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeProdt.Location = new System.Drawing.Point(203, 542);
            this.dateTimeProdt.Name = "dateTimeProdt";
            this.dateTimeProdt.Size = new System.Drawing.Size(314, 30);
            this.dateTimeProdt.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label7.Location = new System.Drawing.Point(980, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stock Stats";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.label9.Location = new System.Drawing.Point(859, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Select Range";
            // 
            // btnStockReport
            // 
            this.btnStockReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnStockReport.FlatAppearance.BorderSize = 0;
            this.btnStockReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.btnStockReport.Location = new System.Drawing.Point(1139, 333);
            this.btnStockReport.Name = "btnStockReport";
            this.btnStockReport.Size = new System.Drawing.Size(142, 34);
            this.btnStockReport.TabIndex = 7;
            this.btnStockReport.Text = "Get Report";
            this.btnStockReport.UseVisualStyleBackColor = false;
            // 
            // dateTimeStoctStat
            // 
            this.dateTimeStoctStat.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimeStoctStat.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(89)))));
            this.dateTimeStoctStat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStoctStat.Location = new System.Drawing.Point(1036, 277);
            this.dateTimeStoctStat.Name = "dateTimeStoctStat";
            this.dateTimeStoctStat.Size = new System.Drawing.Size(314, 30);
            this.dateTimeStoctStat.TabIndex = 6;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1336, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(41, 35);
            this.btnMinimize.TabIndex = 27;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1383, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 35);
            this.btnClose.TabIndex = 28;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Report
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1438, 725);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dateTimeProdt);
            this.Controls.Add(this.dateTimeStoctStat);
            this.Controls.Add(this.selectClientDate);
            this.Controls.Add(this.btnProductsReport);
            this.Controls.Add(this.comboSelectProdt);
            this.Controls.Add(this.btnStockReport);
            this.Controls.Add(this.btnClientReport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboSelectClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.lblTotalCustomers);
            this.Controls.Add(this.btnTotalSalesReport);
            this.Controls.Add(this.btnProductsReprt);
            this.Controls.Add(this.btnCustomersReport);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCustomersReport;
        private System.Windows.Forms.Button btnProductsReprt;
        private System.Windows.Forms.Button btnTotalSalesReport;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboSelectClient;
        private System.Windows.Forms.Button btnClientReport;
        private System.Windows.Forms.DateTimePicker selectClientDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboSelectProdt;
        private System.Windows.Forms.Button btnProductsReport;
        private System.Windows.Forms.DateTimePicker dateTimeProdt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStockReport;
        private System.Windows.Forms.DateTimePicker dateTimeStoctStat;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
    }
}