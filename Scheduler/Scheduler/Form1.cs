using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.Text = string.Format("WorkerTimer 테스터 v{0}", version);
			this.MinimumSize = this.Size;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
