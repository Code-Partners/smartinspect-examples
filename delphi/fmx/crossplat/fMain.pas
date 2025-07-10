unit fMain;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Graphics, FMX.Dialogs,
  System.Actions, FMX.ActnList, FMX.Controls.Presentation, FMX.StdCtrls,
  SmartInspect.FMX, FMX.Edit, FMX.Layouts;

type
  TForm2 = class(TForm)
    Button1: TButton;
    ActionList1: TActionList;
    actSIConnect: TAction;
    edtIP: TEdit;
    Button2: TButton;
    actLogMessage: TAction;
    actLogSystemInfo: TAction;
    Button3: TButton;
    Header: TToolBar;
    HeaderLabel: TLabel;
    Footer: TToolBar;
    Layout1: TLayout;
    Button4: TButton;
    actLogScreenshot: TAction;
    procedure actSIConnectExecute(Sender: TObject);
    procedure actSIConnectUpdate(Sender: TObject);
    procedure actGenericConnectedUpdate(Sender: TObject);
    procedure actLogMessageExecute(Sender: TObject);
    procedure actLogSystemInfoExecute(Sender: TObject);
    procedure actLogScreenshotExecute(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;
  Si : TSmartInspect;
  SiMain : TSiSession;

implementation

{$R *.fmx}

procedure TForm2.actGenericConnectedUpdate(Sender: TObject);
begin
  if Sender is TAction then
    TAction(Sender).Enabled := Si.Enabled;
end;

procedure TForm2.actLogMessageExecute(Sender: TObject);
begin
  SiMain.LogMessage('Hello from FMX')
end;

procedure TForm2.actLogScreenshotExecute(Sender: TObject);
begin
  SiMain.LogScreenshot(self.Name, self, True);
end;

procedure TForm2.actLogSystemInfoExecute(Sender: TObject);
begin
  SiMain.LogSystem;
end;

procedure TForm2.actSIConnectExecute(Sender: TObject);
begin
  if Si.Enabled then
  begin
    SiMain.LeaveProcess;
    Si.Enabled := False;
  end
  else
  begin
    Si.Connections := Format('tcp(host="%s")', [edtIP.Text]);
    Si.Enabled := True;
    SiMain.EnterProcess;
  end;

end;

procedure TForm2.actSIConnectUpdate(Sender: TObject);
begin
  if Si.Enabled then
    actSIConnect.Text := 'Disconnect'
  else
  begin
    actSIConnect.Text := 'Connect';
    actSIConnect.Enabled := edtIP.Text.Length > 0;
  end;
end;

initialization
  Si := TSmartInspect.Create('FMXTest');
  SiMain := Si.AddSession('Main');
finalization
  Si.Free;

end.
