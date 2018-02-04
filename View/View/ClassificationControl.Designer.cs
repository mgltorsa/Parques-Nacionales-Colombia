using System.Windows.Forms;

namespace View
{
    partial class ClassificationControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.group = new System.Windows.Forms.GroupBox();
            this.rbOpeningState = new System.Windows.Forms.RadioButton();
            this.rbVIsitors = new System.Windows.Forms.RadioButton();
            this.rbCost = new System.Windows.Forms.RadioButton();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // group
            // 
            this.group.BackColor = System.Drawing.Color.LightGray;
            this.group.Controls.Add(this.rbOpeningState);
            this.group.Controls.Add(this.rbVIsitors);
            this.group.Controls.Add(this.rbCost);
            this.group.Controls.Add(this.rbCategory);
            this.group.Location = new System.Drawing.Point(3, 3);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(637, 95);
            this.group.TabIndex = 4;
            this.group.TabStop = false;
            this.group.Text = "Clasificar";
            // 
            // rbOpeningState
            // 
            this.rbOpeningState.AutoSize = true;
            this.rbOpeningState.Location = new System.Drawing.Point(495, 45);
            this.rbOpeningState.Name = "rbOpeningState";
            this.rbOpeningState.Size = new System.Drawing.Size(115, 17);
            this.rbOpeningState.TabIndex = 0;
            this.rbOpeningState.TabStop = true;
            this.rbOpeningState.Text = "Estado de apertura";
            this.rbOpeningState.UseVisualStyleBackColor = true;
            this.rbOpeningState.CheckedChanged += new System.EventHandler(this.ChangeLisener);
            // 
            // rbVIsitors
            // 
            this.rbVIsitors.AutoSize = true;
            this.rbVIsitors.Location = new System.Drawing.Point(321, 45);
            this.rbVIsitors.Name = "rbVIsitors";
            this.rbVIsitors.Size = new System.Drawing.Size(124, 17);
            this.rbVIsitors.TabIndex = 0;
            this.rbVIsitors.TabStop = true;
            this.rbVIsitors.Text = "Número de visitantes";
            this.rbVIsitors.UseVisualStyleBackColor = true;
            this.rbVIsitors.CheckedChanged += new System.EventHandler(this.ChangeLisener);
            // 
            // rbCost
            // 
            this.rbCost.AutoSize = true;
            this.rbCost.Location = new System.Drawing.Point(206, 45);
            this.rbCost.Name = "rbCost";
            this.rbCost.Size = new System.Drawing.Size(55, 17);
            this.rbCost.TabIndex = 0;
            this.rbCost.TabStop = true;
            this.rbCost.Text = "Precio";
            this.rbCost.UseVisualStyleBackColor = true;
            this.rbCost.CheckedChanged += new System.EventHandler(this.ChangeLisener);
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(45, 45);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(97, 17);
            this.rbCategory.TabIndex = 0;
            this.rbCategory.TabStop = true;
            this.rbCategory.Text = "Tipo de parque";
            this.rbCategory.UseVisualStyleBackColor = true;
            this.rbCategory.CheckedChanged += new System.EventHandler(this.ChangeLisener);
            // 
            // ClassificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group);
            this.Name = "ClassificationControl";
            this.Size = new System.Drawing.Size(643, 104);
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.RadioButton rbOpeningState;
        private System.Windows.Forms.RadioButton rbVIsitors;
        private System.Windows.Forms.RadioButton rbCost;
        private System.Windows.Forms.RadioButton rbCategory;
        private Main main;
    }
}
