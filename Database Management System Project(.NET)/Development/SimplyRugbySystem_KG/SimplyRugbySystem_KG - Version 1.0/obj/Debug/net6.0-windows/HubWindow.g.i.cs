﻿#pragma checksum "..\..\..\HubWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "065961C0253FFB9D259C7BC5325BFDD11FDE0DDA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SimplyRugbySystem_KG___Version_1._0;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SimplyRugbySystem_KG___Version_1._0 {
    
    
    /// <summary>
    /// HubWindow
    /// </summary>
    public partial class HubWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\HubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Return;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\HubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_CurrentUser;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\HubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_CurrentUsersID;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\HubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_PlayerDetails;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\HubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_PlayerSkillDatabase;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SimplyRugbySystem_KG - Version 1.0;V1.0.0.0;component/hubwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HubWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_Return = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\HubWindow.xaml"
            this.btn_Return.Click += new System.Windows.RoutedEventHandler(this.btn_Return_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_CurrentUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txt_CurrentUsersID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btn_PlayerDetails = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\HubWindow.xaml"
            this.btn_PlayerDetails.Click += new System.Windows.RoutedEventHandler(this.btn_PlayerDetails_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_PlayerSkillDatabase = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\HubWindow.xaml"
            this.btn_PlayerSkillDatabase.Click += new System.Windows.RoutedEventHandler(this.btn_PlayerSkillDatabase_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

