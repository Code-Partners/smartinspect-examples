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

program Cloud;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin

  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;

end.
