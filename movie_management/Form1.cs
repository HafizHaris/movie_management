using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movie_management
{

  
    public partial class Form1 : Form
    {
        List<Movie> movies;
        public Form1()
        {
            InitializeComponent();
            movies = new List<Movie>();
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void emptyTextBoxes()
        {
            txt_name.Text = string.Empty;
            txt_director.Text = string.Empty;
            txt_writer.Text = string.Empty;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        //add
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_name.Text) || String.IsNullOrEmpty(txt_director.Text) || String.IsNullOrEmpty(txt_writer.Text))
            {
                MessageBox.Show("Please fill all the fields properly", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {


                string release_date = dt_release.Value.ToShortDateString();

                //store in a list
                Movie m = new Movie();
                m.name = txt_name.Text;
                m.director = txt_director.Text;
                m.writer = txt_writer.Text;
                m.release_date = release_date;
                movies.Add(m);


                grd_movies.Rows.Add(txt_name.Text, txt_director.Text, txt_writer.Text, release_date);
                emptyTextBoxes();
            
            }

        }

        class Movie
        {
            public string name { get; set; }

            public string director { get; set; }

            public string writer { get; set; }

            public string release_date { get; set; }

           
        }
        //find
        private void button4_Click(object sender, EventArgs e)
        {

            string query = txt_find.Text;
            var myItem = movies.Find(item => item.name == query);
            if (myItem == null)
            {
                MessageBox.Show("Movie not found", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_name.Text = myItem.name;
                txt_director.Text = myItem.director;
                txt_writer.Text = myItem.writer;
                dt_release.Value = Convert.ToDateTime(myItem.release_date);
                txt_find.ReadOnly = true;
                
            }
        }

        //remove
        private void button3_Click(object sender, EventArgs e)
        {
            
            var name = txt_find.Text;

            if (String.IsNullOrEmpty(txt_find.Text))
            {
                MessageBox.Show("Please fill all the fields properly", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                movies.RemoveAll(x => x.name == name);
                txt_find.ReadOnly = false;
                txt_find.Text = string.Empty;
                emptyTextBoxes();
                update_list();
                MessageBox.Show("Movie deleted successfully", "Success message",
                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //update
        private void button2_Click(object sender, EventArgs e)
            {
            var name = txt_find.Text;
            var obj = movies.FirstOrDefault(x => x.name == name);

            obj.name = txt_name.Text;
            obj.director = txt_director.Text;
            obj.writer = txt_writer.Text;
            obj.release_date = dt_release.Value.ToShortDateString();
            movies.Where(w => w.name == name).ToList().ForEach(s => s.name = txt_name.Text);
            
            update_list();
            txt_find.Text = string.Empty;
            txt_find.ReadOnly = false;
            emptyTextBoxes();
            

        }

        private void update_list() {
            grd_movies.DataSource = movies;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
