namespace Food;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    
    private void Continue_Click_1(object sender, EventArgs e)
    {
        test.Text = mainbox.SelectedItem.ToString();
    }
}