﻿#pragma checksum "..\..\..\Pages\DeparturePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4B3429AA09C3F48933099D9669B900C70A8E8A8E59CD8E46F712622E6C9027AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FireDepartmentApp.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FireDepartmentApp.Pages {
    
    
    /// <summary>
    /// DeparturePage
    /// </summary>
    public partial class DeparturePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Pages\DeparturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSettlements;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\DeparturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSort;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\DeparturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewDepartures;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FireDepartmentApp;component/pages/departurepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DeparturePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Pages\DeparturePage.xaml"
            ((FireDepartmentApp.Pages.DeparturePage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboSettlements = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\Pages\DeparturePage.xaml"
            this.ComboSettlements.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSettlements_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\Pages\DeparturePage.xaml"
            this.ComboSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListViewDepartures = ((System.Windows.Controls.ListView)(target));
            
            #line 37 "..\..\..\Pages\DeparturePage.xaml"
            this.ListViewDepartures.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListViewDepartures_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

