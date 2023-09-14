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
  Dialogs, StdCtrls, SmartInspect.VCL, SmartInspect.Cloud;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

  Si: SmartInspect.VCL.TSmartInspect;
  SiMain: TSiSession;

const
  SiSession = 'Main';
  WriteKey = 'INSERT_WRITE_KEY';

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  SiMain.EnterMethod(Self, 'Button1Click');
  try
    SiMain.LogMessage(Edit1.Text);
  finally
    SiMain.LeaveMethod(Self, 'Button1Click');
  end;
end;

initialization

  Si := TSmartInspect.Create('Cloud sample project');

  Si.Connections := CloudConnectionStringBuilder().AddCloudProtocol
     .SetRegion('eu-central-1')
     .SetWriteKey(WriteKey)
     .EndProtocol.Build;

  SiMain := Si.AddSession(SiSession, True);

  Si.Enabled := True;
  SiMain.EnterProcess('Cloud');
  SiMain.LogMessage('Project started');

finalization

  SiMain.LogMessage('Cloud');
  SiMain.LeaveProcess('Project1');
  SiMain := nil;

  Si.Free;

end.
