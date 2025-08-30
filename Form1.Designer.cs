namespace Food;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        mainbox = new System.Windows.Forms.ComboBox();
        Continue = new System.Windows.Forms.Button();
        test = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // mainbox
        // 
        mainbox.AllowDrop = true;
        mainbox.CausesValidation = false;
        mainbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        mainbox.FormattingEnabled = true;
        mainbox.Items.AddRange(new object[] { "Vælg bruger", "Charlotte", "Frederik", "Marie", "Nikolej", "Sara" });
        mainbox.Location = new System.Drawing.Point(43, 131);
        mainbox.Name = "mainbox";
        mainbox.Size = new System.Drawing.Size(160, 28);
        mainbox.TabIndex = 0;
        mainbox.Tag = "";
        // 
        // Continue
        // 
        Continue.Location = new System.Drawing.Point(37, 208);
        Continue.Name = "Continue";
        Continue.Size = new System.Drawing.Size(124, 65);
        Continue.TabIndex = 1;
        Continue.Text = "Continue";
        Continue.UseVisualStyleBackColor = true;
        Continue.Click += Continue_Click_1;
        // 
        // test
        // 
        test.Location = new System.Drawing.Point(113, 328);
        test.Name = "test";
        test.Size = new System.Drawing.Size(75, 56);
        test.TabIndex = 2;
        test.Text = "label1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1200, 825);
        Controls.Add(test);
        Controls.Add(Continue);
        Controls.Add(mainbox);
        StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label test;

    private System.Windows.Forms.Button Continue;

    private System.Windows.Forms.ComboBox mainbox;

    #endregion
}