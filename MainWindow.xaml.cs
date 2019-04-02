using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace json
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            System.IO.StreamReader reader;
            reader = new System.IO.StreamReader("json.txt");
            try
            {
                Dictionary<string, string> items=        Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                MessageBox.Show(items["name"] + " lives in " +items["city"]);
                reader.Close();
                foreach(string s in items.Keys)
                {
                    MessageBox.Show(s + ": " + items[s]);
                }
                items["name"] = "Robert";
                items["favFood"] = "ice cream";
                string newVersion = Newtonsoft.Json.JsonConvert.SerializeObject(items);
                System.IO.StreamWriter writer = new System.IO.StreamWriter("json.txt");
                writer.Write(newVersion);
                writer.Flush();
                writer.Close();
            }//end try
           
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }//end catch
        }
    }
}
