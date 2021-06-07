using System.Windows;
using System.Windows.Controls;

namespace TheMostGames_Task1.CustomControl
{

	internal sealed class TextBoxVerification : TextBox
	{
		static TextBoxVerification()
		{
			_minIndexProperty = DependencyProperty.Register(nameof(MixIndex), typeof(int), typeof(TextBoxVerification));
			_maxIndexProperty = DependencyProperty.Register(nameof(MaxIndex), typeof(int), typeof(TextBoxVerification));
			_textProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBoxVerification));
		}

		private static readonly DependencyProperty _maxIndexProperty;
		private static readonly DependencyProperty _minIndexProperty;
		private static readonly DependencyProperty _textProperty;

		internal int MaxIndex
		{
			get => (int) GetValue(_maxIndexProperty);
			set => SetValue(_maxIndexProperty, value);
		}

		internal int MixIndex
		{
			get => (int) GetValue(_minIndexProperty);
			set => SetValue(_minIndexProperty, value);
		}

		internal new string Text
		{
			get => (string) GetValue(_textProperty);
			set => SetValue(_textProperty, value);
		}
	}

}
