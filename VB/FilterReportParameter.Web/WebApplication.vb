﻿Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo

Namespace FilterReportParameter.Web
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    Partial Public Class FilterReportParameterAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As FilterReportParameter.Module.FilterReportParameterModule
        Private reportsModuleV2 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
        Private reportsAspNetModuleV2 As DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub
        Private Sub FilterReportParameterAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Dim message As String = "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & ControlChars.CrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & ControlChars.CrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & ControlChars.CrLf & "Anyway, refer to the following help topics for more detailed information:" & ControlChars.CrLf & "'Update Application and Database Versions' at http://help.devexpress.com/#Xaf/CustomDocument2795" & ControlChars.CrLf & "'Database Security References' at http://help.devexpress.com/#Xaf/CustomDocument3237" & ControlChars.CrLf & "If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/"

                If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                    message &= ControlChars.CrLf & ControlChars.CrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
                End If
                Throw New InvalidOperationException(message)
            End If
#End If
        End Sub
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New FilterReportParameter.Module.FilterReportParameterModule()
            Me.reportsModuleV2 = New DevExpress.ExpressApp.ReportsV2.ReportsModuleV2()
            Me.reportsAspNetModuleV2 = New DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' reportsModuleV2
            ' 
            Me.reportsModuleV2.EnableInplaceReports = True
            Me.reportsModuleV2.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportDataV2)
            ' 
            ' reportsAspNetModuleV2
            ' 
            Me.reportsAspNetModuleV2.ReportViewerType = DevExpress.ExpressApp.ReportsV2.Web.ReportViewerTypes.HTML5
            ' 
            ' FilterReportParameterAspNetApplication
            ' 
            Me.ApplicationName = "FilterReportParameter"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.reportsModuleV2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.reportsAspNetModuleV2)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
