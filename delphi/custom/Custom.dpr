(*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the logging of custom Log Entries
 *  with the SmartInspect library.
 *
 *)

program Custom;

{$APPTYPE CONSOLE}

uses
{$IFDEF VER150} // Delphi 7
  SmartInspect
{$ELSE}
  SmartInspect.VCL.SiAuto, SmartInspect.VCL, SmartInspect.Core;
{$ENDIF}

var
  LContext: TSiInspectorViewerContext;
begin
  // Enable SmartInspect logging.
  Si.Enabled := True;

  // Create a custom inspector viewer context.
  LContext := TSiInspectorViewerContext.Create;
  try
    // Add a group and the related entries.
    LContext.StartGroup('FindOptions');
    LContext.AppendKeyValue('Regex', True);
    LContext.AppendKeyValue('WholeWord', False);
    LContext.AppendKeyValue('CaseSensitive', True);
    LContext.AppendKeyValue('Title', 'Foobar');

    // Start another group.
    LContext.StartGroup('Tcp');
    LContext.AppendKeyValue('ListenOnStartup', True);
    LContext.AppendKeyValue('Port', Integer(4228));
    LContext.AppendKeyValue('UseAllInterfaces', True);

    // Then send the custom context.
    SiMain.LogCustomContext('Custom Data', ltText, LContext);
  finally
    LContext.Free;
  end;
end.
