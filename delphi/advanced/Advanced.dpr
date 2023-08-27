(*
 *  Copyright (C) Gurock Software GmbH. All rights reserved.
 *
 *  Description:
 *
 *  This example demonstrates the most used features of the 
 *  SmartInspect Delphi library. Each page features another 
 *  part of the SmartInspect Delphi library functionality.
 *
 *)

program Advanced;

uses
  Forms,
  MainUnit in 'MainUnit.pas' {MainForm};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
