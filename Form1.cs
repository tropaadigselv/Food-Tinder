using System.Text.Json;

namespace Food;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    
    private void Continue_Click_1(object sender, EventArgs e)
    {
        if (mainbox.SelectedItem == null)
        {
            MessageBox.Show("No item selected!");
            return;
        }

        var file = "userFiles/" + mainbox.SelectedItem.ToString() + ".json";
        Params par;
        using (StreamReader r = new StreamReader(file))
        {
            var json = r.ReadToEnd();
            par = JsonSerializer.Deserialize<Params>(json);
        }

        if (par == null)
        {
            MessageBox.Show("Failed to deserialize JSON!");
            return;
        }

        if (par.Exclude == null || par.Exclude.Length == 0)
        {
            test.Text = "No exclusions found.";
        }
        else
        {
            test.Text = par.Exclude[0];
        }

        Get.Start();
    }
}