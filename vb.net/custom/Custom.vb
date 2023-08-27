'
'  Copyright (C) Gurock Software GmbH. All rights reserved.
'
'  Description:
'
'  This example demonstrates the logging of custom Log Entries
'  with the SmartInspect library.
'

Imports System.Text
Imports Gurock.SmartInspect

Module Custom

    Sub Main()
        ' Enable SmartInspect
        SiAuto.Si.Enabled = True
        SiAuto.Main.EnterProcess("Custom")
        Try
            ' Create a custom inspector viewer context.
            Dim ctx As New InspectorViewerContext
            Try
                ' Add a group and the related entries.
                ctx.StartGroup("FindOptions")
                ctx.AppendKeyValue("Regex", True)
                ctx.AppendKeyValue("WholeWord", False)
                ctx.AppendKeyValue("CaseSensitive", True)
                ctx.AppendKeyValue("Title", "Foobar")

                ' Start another group.
                ctx.StartGroup("Tcp")
                ctx.AppendKeyValue("ListenOnStartup", True)
                ctx.AppendKeyValue("Port", 4228)
                ctx.AppendKeyValue("UseAllInterfaces", True)

                ' Then send the custom context.
                SiAuto.Main.LogCustomContext("Custom Data", _
                 LogEntryType.Text, ctx)
            Finally
                ctx.Dispose()
            End Try
        Finally
            SiAuto.Main.LeaveProcess("Custom")
        End Try
    End Sub

End Module
