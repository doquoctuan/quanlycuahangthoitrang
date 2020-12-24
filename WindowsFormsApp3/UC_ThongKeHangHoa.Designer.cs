
namespace WindowsFormsApp3
{
    partial class UC_ThongKeHangHoa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtThongKe = new System.Windows.Forms.DataGridView();
            this.txtThongKe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // dtThongKe
            // 
            this.dtThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtThongKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtThongKe.Location = new System.Drawing.Point(20, 82);
            this.dtThongKe.Name = "dtThongKe";
            this.dtThongKe.ReadOnly = true;
            this.dtThongKe.RowHeadersWidth = 51;
            this.dtThongKe.RowTemplate.Height = 24;
            this.dtThongKe.Size = new System.Drawing.Size(929, 489);
            this.dtThongKe.TabIndex = 0;
            // 
            // txtThongKe
            // 
            this.txtThongKe.AutoSize = true;
            this.txtThongKe.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongKe.Location = new System.Drawing.Point(403, 27);
            this.txtThongKe.Name = "txtThongKe";
            this.txtThongKe.Size = new System.Drawing.Size(0, 36);
            this.txtThongKe.TabIndex = 1;
            this.txtThongKe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UC_ThongKeHangHoa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtThongKe);
            this.Controls.Add(this.dtThongKe);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_ThongKeHangHoa";
            this.Size = new System.Drawing.Size(974, 596);
            ((System.ComponentModel.ISupportInitialize)(this.dtThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtThongKe;
        private System.Windows.Forms.Label txtThongKe;
    }
}
