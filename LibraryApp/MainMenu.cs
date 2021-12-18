using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace LibraryApp
{
    public partial class MainMenu : MaterialForm
    {
        public MainMenu()
        {
            InitializeComponent();

            //Material temayı uygula
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //Renk seçimi
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue900, Accent.Blue400,
                TextShade.WHITE
            );
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            st.ShowDialog();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            Books bk = new Books();
            bk.ShowDialog();
        }

        private void btn_lendhand_Click(object sender, EventArgs e)
        {
            LendHand bw = new LendHand();
            bw.ShowDialog();
        }

        private void btn_graph_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.ShowDialog();
        }

        
    }
}
