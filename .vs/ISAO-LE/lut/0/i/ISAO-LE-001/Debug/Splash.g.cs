﻿#pragma checksum "Splash.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C2EBBC65A3054B16F034FFCED4AB61EE2DFACEB1F1AE7407843ECC3A193B3791"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ISAO_LE_001;
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


namespace ISAO_LE_001 {
    
    
    /// <summary>
    /// Splash
    /// </summary>
    public partial class Splash : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ISAO_LE_001.Splash Splash1;
        
        #line default
        #line hidden
        
        
        #line 9 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 17 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbar;
        
        #line default
        #line hidden
        
        
        #line 18 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label produit;
        
        #line default
        #line hidden
        
        
        #line 19 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 20 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_connect;
        
        #line default
        #line hidden
        
        
        #line 21 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 22 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_close;
        
        #line default
        #line hidden
        
        
        #line 23 "Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
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
            System.Uri resourceLocater = new System.Uri("/ISAO-LE-001;component/splash.xaml", System.UriKind.Relative);
            
            #line 1 "Splash.xaml"
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
            this.Splash1 = ((ISAO_LE_001.Splash)(target));
            
            #line 8 "Splash.xaml"
            this.Splash1.Activated += new System.EventHandler(this.SplashActivated);
            
            #line default
            #line hidden
            
            #line 8 "Splash.xaml"
            this.Splash1.ContentRendered += new System.EventHandler(this.SplashRendered);
            
            #line default
            #line hidden
            
            #line 8 "Splash.xaml"
            this.Splash1.Closed += new System.EventHandler(this.SplashClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.pbar = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 17 "Splash.xaml"
            this.pbar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ProgressBar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.produit = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.bt_connect = ((System.Windows.Controls.Button)(target));
            
            #line 20 "Splash.xaml"
            this.bt_connect.Click += new System.Windows.RoutedEventHandler(this.Bt_ConnectOnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.bt_close = ((System.Windows.Controls.Button)(target));
            
            #line 22 "Splash.xaml"
            this.bt_close.Click += new System.Windows.RoutedEventHandler(this.Bt_CloseOnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

