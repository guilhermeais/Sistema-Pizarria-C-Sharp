
namespace InterfaceUsuario.UserControls
{
    partial class ucStatus
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
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.rdbAtivo = new System.Windows.Forms.RadioButton();
            this.rdbDesativo = new System.Windows.Forms.RadioButton();
            this.gpbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.rdbDesativo);
            this.gpbStatus.Controls.Add(this.rdbAtivo);
            this.gpbStatus.Location = new System.Drawing.Point(3, 3);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(193, 63);
            this.gpbStatus.TabIndex = 0;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Status";
            // 
            // rdbAtivo
            // 
            this.rdbAtivo.AutoSize = true;
            this.rdbAtivo.Location = new System.Drawing.Point(33, 32);
            this.rdbAtivo.Name = "rdbAtivo";
            this.rdbAtivo.Size = new System.Drawing.Size(49, 17);
            this.rdbAtivo.TabIndex = 0;
            this.rdbAtivo.TabStop = true;
            this.rdbAtivo.Text = "Ativo";
            this.rdbAtivo.UseVisualStyleBackColor = true;
            this.rdbAtivo.CheckedChanged += new System.EventHandler(this.rdbAtivo_CheckedChanged);
            // 
            // rdbDesativo
            // 
            this.rdbDesativo.AutoSize = true;
            this.rdbDesativo.Location = new System.Drawing.Point(88, 32);
            this.rdbDesativo.Name = "rdbDesativo";
            this.rdbDesativo.Size = new System.Drawing.Size(67, 17);
            this.rdbDesativo.TabIndex = 1;
            this.rdbDesativo.TabStop = true;
            this.rdbDesativo.Text = "Desativo";
            this.rdbDesativo.UseVisualStyleBackColor = true;
            this.rdbDesativo.CheckedChanged += new System.EventHandler(this.rdbDesativo_CheckedChanged);
            // 
            // ucStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbStatus);
            this.Name = "ucStatus";
            this.Size = new System.Drawing.Size(199, 69);
            this.Load += new System.EventHandler(this.ucStatus_Load);
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.RadioButton rdbDesativo;
        private System.Windows.Forms.RadioButton rdbAtivo;
    }
}
