
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
using ZedGraph;
using BLL;

namespace LibraryApp
{
    public partial class Graph : MaterialForm
    {
        private Book_BLL bk;
        private LH_BLL lh;

        public Graph()
        {
            bk = new Book_BLL();
            lh = new LH_BLL();

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

        private void Graph_Load(object sender, System.EventArgs e)
        {
            GraphPane zedgraph;
            zedgraph = zedGraphControl1.GraphPane;

            double[] b = { 0 };
            double[] h = { 0 };
            b[0] = bk.CountBooks();
            h[0] = lh.CountHandedBooks();

            zedgraph.Title.Text = "Library Statistics";

            PointPairList pl = new PointPairList(b, h);

            BarItem b_bar = zedgraph.AddBar("All Books", null, b, Color.Purple);
            BarItem h_bar = zedgraph.AddBar("Handed Books", null, h, Color.Green);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }
    }
}
