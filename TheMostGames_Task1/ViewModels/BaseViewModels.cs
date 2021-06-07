﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

using TheMostGames_Task1.Annotations;

namespace TheMostGames_Task1.ViewModels
{

	internal abstract class BaseViewModels :INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

}
