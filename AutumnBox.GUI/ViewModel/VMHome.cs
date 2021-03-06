﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/15 17:57:19 (UTC +8:00)
** desc： ...
*************************************************/

using AutumnBox.GUI.MVVM;
using AutumnBox.GUI.View.DialogContent;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace AutumnBox.GUI.ViewModel
{
    class VMHome : ViewModelBase
    {
        public FlexiableCommand OpenUrl
        {
            get
            {
                return _openUrl;
            }
            set
            {
                _openUrl = value;
                RaisePropertyChanged();
            }
        }
        private FlexiableCommand _openUrl;
        public FlexiableCommand Donate
        {
            get
            {
                return _donate;
            }
            set
            {
                _donate = value;
                RaisePropertyChanged();
            }
        }
        private FlexiableCommand _donate;
        public VMHome()
        {
            Donate = new FlexiableCommand(() =>
            {
                DialogHost.Show(new ContentDonate());
            });
            OpenUrl = new FlexiableCommand((args) =>
         {
             try
             {
                 Process.Start(args.ToString());
             }
             catch { }
         });
        }
    }
}
