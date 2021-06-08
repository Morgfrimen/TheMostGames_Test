using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
	public partial class TextBoxVerification : UserControl, INotifyPropertyChanged
	{
		private RichTextBox _RichBox;
		public TextBoxVerification()
		{
			InitializeComponent();
			DataContext = this;
			_RichBox = RichTextBox1;
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
			set => SetValue(_maxIndexProperty, value);
		}

		internal int MixIndex
		{
			get => (int)GetValue(_minIndexProperty);
			set => SetValue(_minIndexProperty, value);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

		private bool flag = false;
		private void RichTextBox1_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if(flag)
				return;
			TextRange result = new TextRange(_RichBox.Document.ContentStart, _RichBox.Document.ContentEnd);
			for (int index = 0; index < result.Text.Trim().Length; index++)
			{
				char c = result.Text[index];

				if (c is ';' or ',')
				{
					TextRange rangBlock = new TextRange(_RichBox.CaretPosition, _RichBox.Document.ContentEnd);
					flag = true;
					rangBlock.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Black));
				}
				else if (!char.IsDigit(c))
				{
					TextRange rangBlock = new TextRange(_RichBox.CaretPosition.GetPositionAtOffset(-1), _RichBox.CaretPosition);
					flag = true;
					rangBlock.ApplyPropertyValue(TextElement.ForegroundProperty,new SolidColorBrush(Colors.Red));
				}
				else
				{
					TextRange rangBlock = new TextRange(_RichBox.CaretPosition.GetPositionAtOffset(-1), _RichBox.CaretPosition);
					flag = true;
					rangBlock.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Black));
				}
			}
			flag = false;
		}
	}
}
