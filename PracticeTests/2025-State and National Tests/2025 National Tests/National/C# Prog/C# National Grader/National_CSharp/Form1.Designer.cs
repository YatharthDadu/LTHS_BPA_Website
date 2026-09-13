namespace RestaurantSupplier_National
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblFoodCode = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.lblKG_QA = new System.Windows.Forms.Label();
            this.txtKG_QA = new System.Windows.Forms.TextBox();
            this.lblTotalCounts = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.lblEstimatedValue = new System.Windows.Forms.Label();
            this.lblRetypeCommand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalcuLaunch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(62, 153);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(136, 39);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting.Location = new System.Drawing.Point(51, 44);
            this.lblGreeting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(154, 32);
            this.lblGreeting.TabIndex = 2;
            this.lblGreeting.Text = "lblGreeting";
            // 
            // lblFoodCode
            // 
            this.lblFoodCode.AutoSize = true;
            this.lblFoodCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodCode.Location = new System.Drawing.Point(51, 222);
            this.lblFoodCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFoodCode.Name = "lblFoodCode";
            this.lblFoodCode.Size = new System.Drawing.Size(177, 32);
            this.lblFoodCode.TabIndex = 3;
            this.lblFoodCode.Text = "lblFoodCode";
            this.lblFoodCode.Visible = false;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.Location = new System.Drawing.Point(62, 294);
            this.txtSymbol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(136, 39);
            this.txtSymbol.TabIndex = 4;
            this.txtSymbol.Visible = false;
            this.txtSymbol.TextChanged += new System.EventHandler(this.txtSymbol_TextChanged);
            this.txtSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSymbol_KeyPress);
            // 
            // lblKG_QA
            // 
            this.lblKG_QA.AutoSize = true;
            this.lblKG_QA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKG_QA.Location = new System.Drawing.Point(57, 369);
            this.lblKG_QA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKG_QA.Name = "lblKG_QA";
            this.lblKG_QA.Size = new System.Drawing.Size(141, 32);
            this.lblKG_QA.TabIndex = 5;
            this.lblKG_QA.Text = "lblKG_QA";
            this.lblKG_QA.Visible = false;
            // 
            // txtKG_QA
            // 
            this.txtKG_QA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKG_QA.Location = new System.Drawing.Point(62, 434);
            this.txtKG_QA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKG_QA.Name = "txtKG_QA";
            this.txtKG_QA.Size = new System.Drawing.Size(136, 39);
            this.txtKG_QA.TabIndex = 6;
            this.txtKG_QA.Visible = false;
            this.txtKG_QA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTonnage_KeyPress);
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.AutoSize = true;
            this.lblTotalCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounts.Location = new System.Drawing.Point(42, 31);
            this.lblTotalCounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(198, 32);
            this.lblTotalCounts.TabIndex = 7;
            this.lblTotalCounts.Text = "lblTotalCounts";
            this.lblTotalCounts.Visible = false;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Location = new System.Drawing.Point(42, 201);
            this.lblList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(89, 32);
            this.lblList.TabIndex = 8;
            this.lblList.Text = "lblList";
            this.lblList.Visible = false;
            // 
            // lblEstimatedValue
            // 
            this.lblEstimatedValue.AutoSize = true;
            this.lblEstimatedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedValue.Location = new System.Drawing.Point(42, 111);
            this.lblEstimatedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimatedValue.Name = "lblEstimatedValue";
            this.lblEstimatedValue.Size = new System.Drawing.Size(245, 32);
            this.lblEstimatedValue.TabIndex = 9;
            this.lblEstimatedValue.Text = "lblEstimatedValue";
            this.lblEstimatedValue.Visible = false;
            // 
            // lblRetypeCommand
            // 
            this.lblRetypeCommand.AutoSize = true;
            this.lblRetypeCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetypeCommand.Location = new System.Drawing.Point(51, 96);
            this.lblRetypeCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetypeCommand.Name = "lblRetypeCommand";
            this.lblRetypeCommand.Size = new System.Drawing.Size(264, 32);
            this.lblRetypeCommand.TabIndex = 10;
            this.lblRetypeCommand.Text = "lblRetypeCommand";
            this.lblRetypeCommand.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1710, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 12;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1710, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 32);
            this.label2.TabIndex = 13;
            this.label2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblEstimatedValue);
            this.panel1.Controls.Add(this.lblList);
            this.panel1.Controls.Add(this.lblTotalCounts);
            this.panel1.Location = new System.Drawing.Point(972, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 1230);
            this.panel1.TabIndex = 14;
            // 
            // btnCalcuLaunch
            // 
            this.btnCalcuLaunch.Location = new System.Drawing.Point(827, 1188);
            this.btnCalcuLaunch.Name = "btnCalcuLaunch";
            this.btnCalcuLaunch.Size = new System.Drawing.Size(121, 62);
            this.btnCalcuLaunch.TabIndex = 15;
            this.btnCalcuLaunch.Text = "Calculator";
            this.btnCalcuLaunch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2097, 1274);
            this.Controls.Add(this.btnCalcuLaunch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRetypeCommand);
            this.Controls.Add(this.txtKG_QA);
            this.Controls.Add(this.lblKG_QA);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.lblFoodCode);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.txtCommand);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "BPA National Order Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtCommand;
        public System.Windows.Forms.Label lblGreeting;
        public System.Windows.Forms.Label lblFoodCode;
        public System.Windows.Forms.TextBox txtSymbol;
        public System.Windows.Forms.Label lblKG_QA;
        public System.Windows.Forms.TextBox txtKG_QA;
        public System.Windows.Forms.Label lblTotalCounts;
        public System.Windows.Forms.Label lblList;
        public System.Windows.Forms.Label lblEstimatedValue;
        public System.Windows.Forms.Label lblRetypeCommand;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCalcuLaunch;
        //private System.Windows.Forms.Label lblCHK;
    }
}

