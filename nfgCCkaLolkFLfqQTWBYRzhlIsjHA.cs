using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using FearCheat;

public partial class nfgCCkaLolkFLfqQTWBYRzhlIsjHA : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class Class0
	{
		public TimeSpan timeSpan_0;

		public nfgCCkaLolkFLfqQTWBYRzhlIsjHA nfgCCkaLolkFLfqQTWBYRzhlIsjHA_0;

		internal void method_0()
		{
			vdeCnSLwwqKIRYMqozIUYvJYeuKI obj = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
			obj.method_0(timeSpan_0.Days + 1);
			obj.Show();
			nfgCCkaLolkFLfqQTWBYRzhlIsjHA_0.Close();
		}
	}

	[CompilerGenerated]
	private sealed class Class1
	{
		public TimeSpan timeSpan_0;

		public nfgCCkaLolkFLfqQTWBYRzhlIsjHA nfgCCkaLolkFLfqQTWBYRzhlIsjHA_0;

		internal void method_0()
		{
			vdeCnSLwwqKIRYMqozIUYvJYeuKI obj = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
			obj.method_0(timeSpan_0.Days + 1);
			obj.Show();
			nfgCCkaLolkFLfqQTWBYRzhlIsjHA_0.Close();
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class Class2
	{
		public static readonly Class2 _003C_003E9 = new Class2();

		public static ThreadStart _003C_003E9__2_1;

		internal void method_0()
		{
			try
			{
				WebRequest.Create("https://adminnew.ru/action.php?type=add-install").GetResponse();
			}
			catch
			{
			}
		}
	}

	private string string_0;

	private bool bool_0;

	public nfgCCkaLolkFLfqQTWBYRzhlIsjHA()
	{
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		GClass1.smethod_0();
		try
		{
			GClass1.smethod_3();
		}
		catch
		{
			GClass1.smethod_4();
			MessageBox.Show("Файл конфигурации поврежден. Необходимо провести процедуру активации.", "Fear Cheat", MessageBoxButton.OK);
			return;
		}
		new Thread((ThreadStart)delegate
		{
			try
			{
				string_0 = GClass1.smethod_1(SettingsAttribute.Key);
				using Stream stream = WebRequest.Create("https://adminnew.ru/api/fearcheat.php?action=check_key&key=" + string_0).GetResponse().GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream);
				string text = streamReader.ReadToEnd();
				if (text != "keyNotFound" && text != "keyExpired")
				{
					string[] array = text.Split('-');
					DateTime now = DateTime.Now;
					DateTime dateTime = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
					TimeSpan timeSpan_0 = dateTime - now;
					if (timeSpan_0.Days >= 0)
					{
						base.Dispatcher.BeginInvoke((Action)delegate
						{
							vdeCnSLwwqKIRYMqozIUYvJYeuKI obj2 = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
							obj2.method_0(timeSpan_0.Days + 1);
							obj2.Show();
							Close();
						});
					}
					else
					{
						GClass1.smethod_0();
						base.Dispatcher.BeginInvoke((Action)delegate
						{
							label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
							image_2.IsEnabled = true;
						});
					}
				}
				else
				{
					base.Dispatcher.BeginInvoke((Action)delegate
					{
						label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
						image_2.IsEnabled = true;
					});
				}
			}
			catch
			{
				string value = GClass1.smethod_1(SettingsAttribute.Expires);
				DateTime dateTime2 = default(DateTime);
				DateTime dateTime3 = default(DateTime);
				TimeSpan timeSpan_1 = default(TimeSpan);
				dateTime2 = Convert.ToDateTime(value);
				dateTime3 = DateTime.Now;
				timeSpan_1 = dateTime2 - dateTime3;
				base.Dispatcher.BeginInvoke((Action)delegate
				{
					vdeCnSLwwqKIRYMqozIUYvJYeuKI obj3 = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
					obj3.method_0(timeSpan_1.Days + 1);
					obj3.Show();
					Close();
				});
			}
		}).Start();
		new Thread((ThreadStart)delegate
		{
			try
			{
				WebRequest.Create("https://adminnew.ru/action.php?type=add-install").GetResponse();
			}
			catch
			{
			}
		}).Start();
	}

	private void image_0_MouseDown(object sender, MouseButtonEventArgs e)
	{
		Close();
	}

	private void image_1_MouseDown(object sender, MouseButtonEventArgs e)
	{
		base.WindowState = WindowState.Minimized;
	}

	private void rectangle_1_MouseDown(object sender, MouseButtonEventArgs e)
	{
		DragMove();
	}

	private void image_2_MouseDown(object sender, MouseButtonEventArgs e)
	{
		using Stream stream = WebRequest.Create("https://adminnew.ru/api/fearcheat.php?action=activate_key&key=" + textBox_0.Text).GetResponse().GetResponseStream();
		using StreamReader streamReader = new StreamReader(stream);
		string text = streamReader.ReadToEnd();
		switch (text)
		{
		case "keyNotFound":
			MessageBox.Show("Данный ключ не найден!", "Fear Cheat", MessageBoxButton.OK);
			return;
		case "keyAlreadyActivated":
			MessageBox.Show("Данный ключ уже активирован!", "Fear Cheat", MessageBoxButton.OK);
			return;
		case "keyExpired":
			MessageBox.Show("Истек срок действия данного ключа, необходимо обновить лицензию.", "Fear Cheat", MessageBoxButton.OK);
			return;
		}
		string[] array = text.Split('-');
		DateTime now = DateTime.Now;
		TimeSpan timeSpan = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2])) - now;
		MessageBox.Show("Ключ успешно активирован, приятного пользования!", "Fear Cheat", MessageBoxButton.OK);
		GClass1.smethod_2(SettingsAttribute.Key, textBox_0.Text);
		GClass1.smethod_2(SettingsAttribute.Expires, text);
		vdeCnSLwwqKIRYMqozIUYvJYeuKI obj = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
		obj.method_0(timeSpan.Days + 1);
		obj.Show();
		Close();
	}

	[CompilerGenerated]
	private void method_1()
	{
		try
		{
			string_0 = GClass1.smethod_1(SettingsAttribute.Key);
			using Stream stream = WebRequest.Create("https://adminnew.ru/api/fearcheat.php?action=check_key&key=" + string_0).GetResponse().GetResponseStream();
			using StreamReader streamReader = new StreamReader(stream);
			string text = streamReader.ReadToEnd();
			if (text != "keyNotFound" && text != "keyExpired")
			{
				string[] array = text.Split('-');
				DateTime now = DateTime.Now;
				DateTime dateTime = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
				TimeSpan timeSpan_0 = dateTime - now;
				if (timeSpan_0.Days >= 0)
				{
					base.Dispatcher.BeginInvoke((Action)delegate
					{
						vdeCnSLwwqKIRYMqozIUYvJYeuKI obj = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
						obj.method_0(timeSpan_0.Days + 1);
						obj.Show();
						Close();
					});
				}
				else
				{
					GClass1.smethod_0();
					base.Dispatcher.BeginInvoke((Action)delegate
					{
						label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
						image_2.IsEnabled = true;
					});
				}
			}
			else
			{
				base.Dispatcher.BeginInvoke((Action)delegate
				{
					label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
					image_2.IsEnabled = true;
				});
			}
		}
		catch
		{
			string value = GClass1.smethod_1(SettingsAttribute.Expires);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			TimeSpan timeSpan_1 = default(TimeSpan);
			dateTime2 = Convert.ToDateTime(value);
			dateTime3 = DateTime.Now;
			timeSpan_1 = dateTime2 - dateTime3;
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				vdeCnSLwwqKIRYMqozIUYvJYeuKI obj2 = new vdeCnSLwwqKIRYMqozIUYvJYeuKI();
				obj2.method_0(timeSpan_1.Days + 1);
				obj2.Show();
				Close();
			});
		}
	}

	[CompilerGenerated]
	private void method_2()
	{
		label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
		image_2.IsEnabled = true;
	}

	[CompilerGenerated]
	private void method_3()
	{
		label_0.Content = "ВВЕДИТЕ КЛЮЧ АКТИВАЦИИ";
		image_2.IsEnabled = true;
	}
}
