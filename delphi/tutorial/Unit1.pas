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

unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

uses
{$IFDEF VER150} // Delphi 7
  SiAuto;
{$ELSE}
  SmartInspect.VCL.SiAuto;
{$ENDIF}

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  SiMain.EnterMethod(Self, 'Button1Click');
  try
    SiMain.LogMessage('This is my first SmartInspect message!');
  finally
    SiMain.LeaveMethod(Self, 'Button1Click');
  end;
end;

end.
