﻿using Laba5.Tools.Navigation;

namespace Laba5.Managers
{
    internal class NavigationManager
    {
        private static readonly object Locker = new object();
        private static NavigationManager _instance;

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                 lock (Locker)
                 {
                     return _instance ?? (_instance = new NavigationManager());
                 }
            }
        }

        private INavigationModel _navigationModel;

        private NavigationManager()
        {
            
        }

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType)
        {
            _navigationModel.Navigate(viewType);
        }

    }
}
