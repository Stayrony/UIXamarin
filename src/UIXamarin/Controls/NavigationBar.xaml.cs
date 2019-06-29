using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace UIXamarin.Controls
{
    public partial class NavigationBar : ContentView
    {
        public NavigationBar()
        {
            InitializeComponent();

            var rightToolbarItems = new ObservableCollection<View>();
            rightToolbarItems.CollectionChanged += OnRightToolbarItemsCollectionChanged;
            RightToolbarItems = rightToolbarItems;

            var leftToolbarItems = new ObservableCollection<View>();
            leftToolbarItems.CollectionChanged += OnLeftToolbarItemsCollectionChanged;
            LeftToolbarItems = leftToolbarItems;

            var centralToolbarItems = new ObservableCollection<View>();
            centralToolbarItems.CollectionChanged += OnCentralToolbarItemsCollectionChanged;
            CentralToolBarItems = centralToolbarItems;

            Title = null;
        }

        #region -- Public properties --

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(NavigationBar), string.Empty);

        public static readonly BindableProperty ShowBottomLineProperty =
            BindableProperty.Create("ShowBottomLine", typeof(bool), typeof(NavigationBar), true);

        public IList<View> RightToolbarItems { get; set; }

        public IList<View> LeftToolbarItems { get; set; }

        public IList<View> CentralToolBarItems { get; set; }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public bool ShowBottomLine
        {
            get { return (bool)GetValue(ShowBottomLineProperty); }
            set { SetValue(ShowBottomLineProperty, value); }
        }

        #endregion

        #region -- Private helpers --

        private void OnRightToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RightToolBarItemsContainer.Children.Clear();
            foreach (var toolbarItem in RightToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
                RightToolBarItemsContainer.Children.Add(toolbarItem);
            }
        }

        private void OnLeftToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LeftToolBarItemsContainer.Children.Clear();
            foreach (var toolbarItem in LeftToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
                LeftToolBarItemsContainer.Children.Add(toolbarItem);
            }
        }

        private void OnCentralToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CentralToolBarItemsContainer.Children.Clear();

            if (CentralToolBarItems.Any())
            {
                TitleLabel.IsVisible =
                              Logo.IsVisible = false;

                foreach (var toolbarItem in CentralToolBarItems)
                {
                    toolbarItem.BindingContext = BindingContext;
                    CentralToolBarItemsContainer.Children.Add(toolbarItem);
                }
            }
            else
            {
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region -- Overrides --

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Title))
            {
                if (!string.IsNullOrWhiteSpace(Title))
                {
                    TitleLabel.IsVisible = true;
                    Logo.IsVisible = false;
                }
                else
                {
                    TitleLabel.IsVisible = false;
                    Logo.IsVisible = true;
                }

                TitleLabel.Text = Title;
            }

            if (propertyName == nameof(ShowBottomLine))
            {
                BottomLine.IsVisible = ShowBottomLine;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            foreach (var toolbarItem in LeftToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }

            foreach (var toolbarItem in RightToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }

            foreach (var toolbarItem in CentralToolBarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }
        }

        #endregion
    }
}
