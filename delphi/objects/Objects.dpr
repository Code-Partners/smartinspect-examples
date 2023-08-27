(*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the usage of multiple session objects
 *  with one SmartInspect object. Each session object is assigned a
 *  different session name and color for easier identification
 *  and filtering in the SmartInspect console.
 *
 *)

program Objects;

{$APPTYPE CONSOLE}

uses
{$IFDEF VER150} // Delphi 7
  SmartInspect,
{$ELSE}
  SmartInspect.VCL,
{$ENDIF}
  vcl.Graphics,
  SysUtils;

var
  Si: TSmartInspect;
  SiBlue, SiGreen: TSiSession;

begin
  // Create the SmartInspect instance
  Si := TSmartInspect.Create('Objects');
  try
    Si.Connections := 'tcp()';
    Si.Enabled := True;

    // Create the sessions and set colors
    SiBlue := Si.AddSession('Blue');
    SiBlue.Color := clBlue;
    SiGreen := Si.AddSession('Green');
    SiGreen.Color := clGreen;

    // Log the messages
    SiBlue.LogMessage('This message is blue!');
    SiGreen.LogMessage('This message is green!');
    SiGreen.LogMessage('😁 All good');


  finally
    // Free the SmartInspect instance.
    // The child sessions will also be freed.
    Si.Free;
  end;
end.
