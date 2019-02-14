﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internal;
using Xamarin.Forms.Xaml;

namespace XFMinUp
{
	public class Datum
	{
		public string Name;
		public string Id;
		public long Ticks;
		public long SubTicks;
		public int Depth;
		public string Path;
		public int Line;
	}

	public partial class App : Application
	{
		const long MS = TimeSpan.TicksPerMillisecond;
		const int Extra = 0;

		public static string AppName;
		public static long Start;
		public static long End;
		public static List<Datum> Data = new List<Datum>();

		public App()
		{
			var contentPage = new ContentPage();
			var stackLayout = new StackLayout();
			var label = new Label();
			var button = new Button();

			contentPage.Content = stackLayout;
			stackLayout.Children.Add(label);
			stackLayout.Children.Add(button);

			for (var i = 0; i < Extra; i++)
			{
				stackLayout.Children.Add(new Label() { Text = i.ToString() });
				stackLayout.Children.Add(new Button() { Text = i.ToString() });
			}

			stackLayout.HorizontalOptions = LayoutOptions.Center;
			stackLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

			label.Text = $"{AppName}!";
			label.FontSize = 50;

			button.Text = "Show Startup Time";
			button.Clicked += Clicked;

			MainPage = contentPage;
		}

		private static void ASSERT(bool condition)
		{
			if (!condition) throw new Exception("assert");
		}

		private static long GatherTicks(ref int i)
		{
			var current = Data[i++];
			var depth = current.Depth;
			var total = current.Ticks;

			while (i < Data.Count)
			{
				var next = Data[i];
				if (next.Depth < depth)
					break;

				if (next.Depth > depth)
				{
					current.SubTicks = GatherTicks(ref i);
					ASSERT(current.Ticks >= current.SubTicks);
					continue;
				}

				i++;
				current = next;
				total += current.Ticks;
			}

			return total;
		}

		private void Clicked(object sender, EventArgs e)
		{
			Profile.Stop();
			foreach (var datum in Profile.Data)
			{
				Data.Add(new Datum()
				{
					Name = datum.Name,
					Id = datum.Id,
					Depth = datum.Depth,
					Ticks = datum.Ticks < 0 ? 0L : (long)datum.Ticks
				});
			}
			var i = 0;
			var totalMs = End - Start;
			var profiledMs = GatherTicks(ref i) / MS;

			var contentPage = new ContentPage();
			var scrollView = new ScrollView();
			var label = new Label();

			var controls = new Grid();
			var buttonA = new Button() { Text = "0s", HeightRequest = 62 };
			controls.Children.AddHorizontal(new[] { buttonA });

			var grid = new Grid
			{
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = GridLength.Star },
				}
			};
			contentPage.Content = grid;
			grid.Children.Add(scrollView, 0, 0);
			grid.Children.Add(controls, 0, 1);

			scrollView.Content = label;

			var showZeros = false;

			Action update = delegate ()
			{
				var sb = new StringBuilder();
				sb.AppendLine($"Custom = {totalMs}ms, ({totalMs - profiledMs}ms)");
				sb.AppendLine($"Profiled: {profiledMs}ms");
				AppendProfile(sb, profiledMs, showZeros);
				label.Text = sb.ToString();
			};
			buttonA.Clicked += delegate { showZeros = !showZeros; update(); };

			update();
			MainPage = contentPage;
		}

		void AppendProfile(StringBuilder sb, long profiledMs, bool showZeros)
		{
			foreach (var datum in Data)
			{
				var depth = datum.Depth;

				var name = datum.Name;
				if (datum.Id != null)
					name += $" ({datum.Id})";

				var ticksMs = datum.Ticks / MS;
				var exclusiveTicksMs = (datum.Ticks - datum.SubTicks) / MS;

				var percentage = (int)Math.Round(ticksMs / (double)profiledMs * 100);
				if (!showZeros && percentage == 0)
					continue;

				var line = $"{name} = {ticksMs}ms";
				if (exclusiveTicksMs != ticksMs)
					line += $" ({exclusiveTicksMs}ms)";
				line += $", {percentage}%";

				sb.AppendLine("".PadLeft(depth * 2) + line);
			}
		} 


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
