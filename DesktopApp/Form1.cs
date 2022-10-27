using MyDatabase;
using RepositoryServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //MovieRepository movieRepository = new MovieRepository(db);

            //var movies = movieRepository.GetAll();

            //dataGridView1.DataSource = movies;

        }
    }
}
