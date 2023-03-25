﻿#pragma checksum "..\..\..\MainSetting\SettingViewer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189304D57E8BF4AACA4090EE8DB2DECCDAB18720"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolTVController;
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


namespace SchoolTVController {
    
    
    /// <summary>
    /// SettingViewer
    /// </summary>
    public partial class SettingViewer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AutoRefreshTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TvDataFilePathTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GroupPresetDataFilePathTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MasterSettingFilePathTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AccessTokenTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonTVListReader;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGroupPresetReader;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMastetSettingReader;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TmpDataWriteButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\MainSetting\SettingViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolTVController;component/mainsetting/settingviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainSetting\SettingViewer.xaml"
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
            
            #line 8 "..\..\..\MainSetting\SettingViewer.xaml"
            ((SchoolTVController.SettingViewer)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AutoRefreshTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\MainSetting\SettingViewer.xaml"
            this.AutoRefreshTimeTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AutoRefreshTimeValidation);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TvDataFilePathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.GroupPresetDataFilePathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MasterSettingFilePathTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AccessTokenTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\MainSetting\SettingViewer.xaml"
            this.AccessTokenTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.AccessTokenTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonTVListReader = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\MainSetting\SettingViewer.xaml"
            this.ButtonTVListReader.Click += new System.Windows.RoutedEventHandler(this.ButtonTVListReader_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonGroupPresetReader = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\MainSetting\SettingViewer.xaml"
            this.ButtonGroupPresetReader.Click += new System.Windows.RoutedEventHandler(this.ButtonGroupPresetReader_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonMastetSettingReader = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\MainSetting\SettingViewer.xaml"
            this.ButtonMastetSettingReader.Click += new System.Windows.RoutedEventHandler(this.ButtonMastetSettingReader_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.TmpDataWriteButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\MainSetting\SettingViewer.xaml"
            this.TmpDataWriteButton.Click += new System.Windows.RoutedEventHandler(this.TmpDataWriteButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\MainSetting\SettingViewer.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

