using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TheMostGames_Task1.Annotations;

namespace TheMostGames_Task1.CustomControl
{
	/// <summary>
	/// Логика взаимодействия для TextBoxVerification.xaml
	/// </summary>
	public partial class TextBoxVerification : UserControl,INotifyPropertyChanged
	{
		private int minId;
		private int maxId;
		private Run _run;
		public TextBoxVerification()
		{
			InitializeComponent();
			DataContext = this;
		}

		static TextBoxVerification()
		{
			_minIndexProperty = DependencyProperty.Register(nameof(MixIndex), typeof(int), typeof(TextBoxVerification));
			_maxIndexProperty = DependencyProperty.Register(nameof(MaxIndex), typeof(int), typeof(TextBoxVerification));
		}

		private static readonly DependencyProperty _maxIndexProperty;
		private static readonly DependencyProperty _minIndexProperty;

		internal int MaxIndex
		{
			get => (int)GetValue(_maxIndexProperty);
			set
			{
				SetValue(_maxIndexProperty, value);
				maxId = value;
			}
		}

		internal int MixIndex
		{
			get => (int)GetValue(_minIndexProperty);
			set
			{
				SetValue(_minIndexProperty, value);
				minId = value;
			}
		}

		private string _text = "";

		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				OnPropertyChanged(nameof(Text));
				Valudate(_text);
			}
		}

		private void Valudate(string value)
		{
			if (!int.TryParse(value, out int valueInt))
			{
				_run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 1));
			}
			else
			{
				_run.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0,0 ));
			}
		}

		private void Run_OnInitialized(object? sender, EventArgs e)
		{
			_run = sender as Run;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
	}
}
