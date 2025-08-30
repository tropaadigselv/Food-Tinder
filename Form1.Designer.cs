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
        Continue = new System.Windows.Forms.Button();
        test = new System.Windows.Forms.Label();
        mainbox = new System.Windows.Forms.ComboBox();
        SuspendLayout();
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
        test.Size = new System.Drawing.Size(354, 213);
        test.TabIndex = 2;
        test.Text = "label1";
        // 
        // mainbox
        // 
        mainbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        mainbox.FormattingEnabled = true;
        mainbox.Location = new System.Drawing.Point(23, 97);
        mainbox.Name = "mainbox";
        mainbox.Size = new System.Drawing.Size(181, 23);
        mainbox.DataSource = new User[]
        {
            new User { PersonID = 0, name = "Vælg bruger" },
            new User { PersonID = 1, name = "Chalotte" },
            new User { PersonID = 2, name = "Frederik" },
            new User { PersonID = 3, name = "Marie" },
            new User { PersonID = 4, name = "Nikolej" },
            new User { PersonID = 5, name = "Sara" }
        };
        mainbox.DisplayMember = "name";
        mainbox.ValueMember = "PersonID";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1202, 833);
        Controls.Add(mainbox);
        Controls.Add(test);
        Controls.Add(Continue);
        StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox mainbox;

    private System.Windows.Forms.Label test;

    private System.Windows.Forms.Button Continue;

    #endregion
}