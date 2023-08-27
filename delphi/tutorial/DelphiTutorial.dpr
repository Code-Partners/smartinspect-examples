(*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example is the source code of the getting started tutorial
 *  included in the online help. Please see the tutorial for more
 *  information.
 *
 *)

program DelphiTutorial;

uses
{$IFDEF VER150} // Delphi 7
  SiAuto,
{$ELSE}
  SmartInspect.VCL.SiAuto,
{$ENDIF}
  Forms,
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin
  Si.Connections := 'tcp()';
  Si.Enabled := True;
  SiMain.EnterProcess('DelphiTutorial');
  try
    Application.Initialize;
    Application.CreateForm(TForm1, Form1);
    Application.Run;
  finally
    SiMain.LeaveProcess('DelphiTutorial');
  end;
end.
