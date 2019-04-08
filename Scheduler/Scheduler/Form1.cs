using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schedule;

namespace Scheduler
{
	public partial class Form1 : Form
	{
		static ScheduleTimer _Timer = new ScheduleTimer();
		delegate void TickHandler(DateTime tick);
		private delegate void Anonymous();

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

		/// <summary>
		/// 지정한 시간에 이벤트 발생
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			IScheduledItem item = new ScheduledTime(EventTimeBase.Hourly, TimeSpan.FromMinutes(20));

			ScheduleTimer TickTimer = new ScheduleTimer();
			TickTimer.AddJob(new Schedule.ScheduledTime(EventTimeBase.BySecond, TimeSpan.Zero),
				new TickHandler(_TickTimer_Elapsed)
				);
			TickTimer.Start();
		}

		private void _TickTimer_Elapsed(DateTime EventTime)
		{
			lock (this)
			{
				Invoke(new Anonymous(delegate
				{
					label1.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
				}));
			}
			//this.Invoke(new System.Threading.ThreadStart(this.Invalidate));
			label1.Invoke(new System.Threading.ThreadStart(label1.Invalidate));
		}
	}
}
