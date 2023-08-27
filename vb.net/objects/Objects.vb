'
'  Copyright (C) Gurock Software GmbH. All rights reserved.
'
'  Description:
'
'  This example demonstrates the usage of multiple session objects
'  with one SmartInspect object. Each session object is assigned a
'  different session name and color for easier identification
'  and filtering in the SmartInspect console.
'
'

Imports Gurock.SmartInspect

Module Objects
    Sub Main()
        ' Create the SmartInspect and session objects
        Dim si As SmartInspect = New SmartInspect("Objects")
        Dim blue As Session = si.AddSession("Blue")
        Dim green As Session = si.AddSession("Green")

        ' Enable SmartInspect and set the connections string
        si.Connections = "tcp()"
        si.Enabled = True

        ' Set the session colors
        blue.Color = Color.Blue
        green.Color = Color.Green

        ' Log the messages
        blue.LogMessage("This message is blue!")
        green.LogMessage("This message is green!")
    End Sub
End Module
