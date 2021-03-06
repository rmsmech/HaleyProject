﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using Haley.Abstractions;
using Haley.Utils;
using Haley.Enums;
using System.Collections;
using System.ComponentModel;
using Haley.Events;


namespace Haley.WPF.BaseControls
{
    [TemplatePart(Name = UIESourceControl, Type = typeof(ListView))]
    [TemplatePart(Name = UIESelectionControl, Type = typeof(ListView))]
    public class CollectionSelector : ItemsControl,ICornerRadius
    {
        private const string UIESourceControl = "PART_lstvew_source";
        private const string UIESelectionControl = "PART_lstvew_selection";

        private ListView _sourceControl;
        private ListView _selectionControl;

        #region Events
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent(nameof(SelectionChanged), RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Pagination));

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }
        #endregion

        static CollectionSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionSelector), new FrameworkPropertyMetadata(typeof(CollectionSelector)));
        }

        public CollectionSelector() 
        {
            CommandBindings.Add(new CommandBinding(ComponentCommands.MoveRight, Execute_MoveRight));
            CommandBindings.Add(new CommandBinding(ComponentCommands.MoveLeft, Execute_MoveLeft));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.SelectAll, Execute_SelectAll));
            CommandBindings.Add(new CommandBinding(AdditionalCommands.Highlight, Execute_Highlight));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _sourceControl = GetTemplateChild(UIESourceControl) as ListView;
            _selectionControl = GetTemplateChild(UIESelectionControl) as ListView;
        }
        void Execute_MoveRight(object sender, ExecutedRoutedEventArgs e)
        {
            //Get selected items of primary listview and add it to the itemssource of the secondary
            if (_sourceControl == null || _selectionControl == null) return;

            //The main reason for using a intermediate list is to avoid binding both listviews. Else, both becomes binded and one change immediately affects the other.

            //Get selected items.
            IList newlist = new List<object>();
            foreach (var item in _sourceControl.SelectedItems)
            {
                newlist.Add(item);
            }
            //Get existing selected items.
            IList oldvalues = new List<object>();

            if (SelectedItems != null)
            {
                foreach (var item in SelectedItems)
                {
                    oldvalues.Add(item);
                }
            }
            //Compare and get only new items
            foreach (var item in newlist)
            {
                if (!oldvalues.Contains(item))
                {
                    oldvalues.Add(item);
                }
            }
            SelectedItems = oldvalues;
            //Clear selection.
            _sourceControl.SelectedItems.Clear();
            RaiseSelectionChanged();
        }
        void Execute_MoveLeft(object sender, ExecutedRoutedEventArgs e)
        {
            //Get selected items of primary listview and add it to the itemssource of the secondary
            if (_sourceControl == null || _selectionControl == null) return;

            //Get selected items in Selection Host
            IList _toRemove = new List<object>();
            foreach (var item in _selectionControl.SelectedItems)
            {
                _toRemove.Add(item);
            }
            //Get existing selected items.
            IList oldvalues = new List<object>();
            if (SelectedItems != null)
            {
                foreach (var item in SelectedItems)
                {
                    oldvalues.Add(item);
                }
            }
            IList newvalues = new List<object>();
            //Compare and get only new items to remove
            foreach (var item in oldvalues)
            {
                if (!_toRemove.Contains(item))
                {
                    newvalues.Add(item);
                }
            }

            SelectedItems = newvalues;
            //Clear selection.
            _selectionControl.SelectedItems.Clear();
            RaiseSelectionChanged();
        }

        void RaiseSelectionChanged()
        {
            RaiseEvent(new UIRoutedEventArgs<IEnumerable>(SelectionChangedEvent, this) { value = SelectedItems });
        }
        void Execute_SelectAll(object sender, ExecutedRoutedEventArgs e)
        {
            if ((string)e.Parameter == "Source")
            {
                _sourceControl.SelectAll();
            }
            else
            {
                _selectionControl.SelectAll();
            }
        }
        void Execute_Highlight(object sender, ExecutedRoutedEventArgs e)
        {
            //Get all selected items
            //Get selected items in Selection Host
            IList _tohighlight = new List<object>();
            if (SelectedItems == null) return;
            foreach (var item in SelectedItems)
            {
                _tohighlight.Add(item);
            }

            _sourceControl.SelectedItems.Clear();
            foreach (var item in _tohighlight)
            {
                _sourceControl.SelectedItems.Add(item);
            }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(CollectionSelector), new PropertyMetadata(ResourceStore.cornerRadius));

        public Brush ItemSelectedColor
        {
            get { return (Brush)GetValue(ItemSelectedColorProperty); }
            set { SetValue(ItemSelectedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSelectedColorProperty =
            DependencyProperty.Register(nameof(ItemSelectedColor), typeof(Brush), typeof(CollectionSelector), new PropertyMetadata(null));

        public Brush ItemHoverColor
        {
            get { return (Brush)GetValue(ItemHoverColorProperty); }
            set { SetValue(ItemHoverColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemHoverColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemHoverColorProperty =
            DependencyProperty.Register(nameof(ItemHoverColor), typeof(Brush), typeof(CollectionSelector), new PropertyMetadata(null));

        public IEnumerable SelectedItems
        {
            get { return (IEnumerable)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(IEnumerable), typeof(CollectionSelector), new FrameworkPropertyMetadata(default(IEnumerable),FrameworkPropertyMetadataOptions.NotDataBindable));
    }
}