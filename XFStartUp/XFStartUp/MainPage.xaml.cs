using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStartUp
{
	public partial class MainPage : ContentPage
	{
		public static long Start;
		public static long End;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnClick(object sender, EventArgs e)
		{
			var label = (Label)this.FindByName("Label");
			label.Text = $"OnResume - OnCreate: {End - Start}ms";
		}
	}
}
