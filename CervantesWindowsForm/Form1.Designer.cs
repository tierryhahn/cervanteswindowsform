namespace CervantesWindowsForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFieldText;
        private System.Windows.Forms.TextBox txtFieldNumeric;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblFieldText;
        private System.Windows.Forms.Label lblFieldNumeric;

        private void InitializeComponent()
        {
            this.txtFieldText = new System.Windows.Forms.TextBox();
            this.txtFieldNumeric = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblFieldText = new System.Windows.Forms.Label();
            this.lblFieldNumeric = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // lblFieldText
            //
            this.lblFieldText.Location = new System.Drawing.Point(12, 12);
            this.lblFieldText.Name = "lblFieldText";
            this.lblFieldText.Size = new System.Drawing.Size(260, 20);
            this.lblFieldText.TabIndex = 0;
            this.lblFieldText.Text = "Campo Texto:";
            //
            // txtFieldText
            //
            this.txtFieldText.Location = new System.Drawing.Point(12, 32);
            this.txtFieldText.Name = "txtFieldText";
            this.txtFieldText.Size = new System.Drawing.Size(260, 20);
            this.txtFieldText.TabIndex = 1;
            //
            // lblFieldNumeric
            //
            this.lblFieldNumeric.Location = new System.Drawing.Point(12, 62);
            this.lblFieldNumeric.Name = "lblFieldNumeric";
            this.lblFieldNumeric.Size = new System.Drawing.Size(260, 20);
            this.lblFieldNumeric.TabIndex = 2;
            this.lblFieldNumeric.Text = "Campo Numérico:";
            //
            // txtFieldNumeric
            //
            this.txtFieldNumeric.Location = new System.Drawing.Point(12, 82);
            this.txtFieldNumeric.Name = "txtFieldNumeric";
            this.txtFieldNumeric.Size = new System.Drawing.Size(260, 20);
            this.txtFieldNumeric.TabIndex = 3;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(12, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(100, 108);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(192, 108);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // dataGridView
            //
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 137);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(260, 156);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFieldNumeric);
            this.Controls.Add(this.lblFieldNumeric);
            this.Controls.Add(this.txtFieldText);
            this.Controls.Add(this.lblFieldText);
            this.Name = "Form1";
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}