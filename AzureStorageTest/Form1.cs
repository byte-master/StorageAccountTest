using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Storage.Blobs;
using Microsoft.Azure; //Namespace for CloudConfigurationManager


namespace AzureStorageTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = textBox3.Text;

            string downloadpath = textBox4.Text;

            downloadpath = downloadpath.Replace(@"\", @"\\");
            lblmessage.Text = "";
            try
            {
                Azure.Storage.Blobs.BlobContainerClient container = new Azure.Storage.Blobs.BlobContainerClient(textBox1.Text, textBox2.Text);


                var BlobClient = container.GetBlobClient(textBox3.Text);
                BlobClient.DownloadTo(downloadpath + "\\" + file);
                lblmessage.Text= "Downloaded file to "+ textBox4.Text + @"\" +file+" Sucessfully";
            }
            catch(Exception ex)
            {
                lblmessage.Text = ex.Message.ToString();

            }
            
          

        }
    }
}
