namespace MMR.UI.Forms
{
    partial class RandomSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pRandomSettings = new System.Windows.Forms.Panel();
            this.lSettings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tSetting = new System.Windows.Forms.TextBox();
            this.pRandomSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Random Settings Pool:";
            // 
            // pRandomSettings
            // 
            this.pRandomSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRandomSettings.AutoScroll = true;
            this.pRandomSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRandomSettings.Controls.Add(this.lSettings);
            this.pRandomSettings.Location = new System.Drawing.Point(16, 32);
            this.pRandomSettings.Name = "pRandomSettings";
            this.pRandomSettings.Size = new System.Drawing.Size(344, 445);
            this.pRandomSettings.TabIndex = 2;
            // 
            // lSettings
            // 
            this.lSettings.CheckBoxes = true;
            this.lSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSettings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lSettings.HideSelection = false;
            this.lSettings.Location = new System.Drawing.Point(0, 0);
            this.lSettings.Name = "lSettings";
            this.lSettings.Size = new System.Drawing.Size(342, 443);
            this.lSettings.TabIndex = 2;
            this.lSettings.UseCompatibleStateImageBehavior = false;
            this.lSettings.View = System.Windows.Forms.View.List;
            this.lSettings.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lSettings_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 160;
            // 
            // tSetting
            // 
            this.tSetting.Location = new System.Drawing.Point(15, 483);
            this.tSetting.Name = "tSetting";
            this.tSetting.Size = new System.Drawing.Size(342, 20);
            this.tSetting.TabIndex = 5;
            // 
            // RandomSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 515);
            this.Controls.Add(this.tSetting);
            this.Controls.Add(this.pRandomSettings);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RandomSettingsForm";
            this.Text = "Random Settings Pool";
            this.pRandomSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pRandomSettings;
        private System.Windows.Forms.TextBox tSetting;
        private System.Windows.Forms.ListView lSettings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}